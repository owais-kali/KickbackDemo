const panel = document.getElementById('panel');
const button_stream = document.getElementById('button_stream');
const ssl = document.getElementById('ssl');
const idBox = document.getElementById('id');
const inputLabel = document.getElementById('inputLabel');
const inputBox = document.getElementById('inputBox');

const test = document.getElementById('test');

var ws; //websocket

//#region FMTP
var label_img = 1001;
var dataID_img = 0;
var dataLength_img = 0;
var receivedLength_img = 0;
var dataByte_img = new Uint8Array(0);
var ReadyToGetFrame_img = true;

var label_aud = 2001;
var dataID_aud = 0;
var dataLength_aud = 0;
var receivedLength_aud = 0;
var dataByte_aud = new Uint8Array(100);
var ReadyToGetFrame_aud = true;
var SourceSampleRate = 48000;
var SourceChannels = 1;
var ABuffer = new Float32Array(0);

var socket;
var isServer;

var startTime = 0;
var audioCtx = new AudioContext();
function OnDataRecive(Jsondata) {
	console.log("OnDataRecive: ");
	var data = JSON.parse(Jsondata)
	var _byteData = new Uint8Array(data._bytes);
	var _label = ByteToInt32(_byteData, 0);

	//Audio
	if (_label == label_aud) {
		var _dataID = ByteToInt32(_byteData, 4);
		if (_dataID != dataID_aud) receivedLength_aud = 0;

		dataID_aud = _dataID;
		dataLength_aud = ByteToInt32(_byteData, 8);
		//var _offset = ByteToInt32(_byteData, 12);
		var _GZipMode = (_byteData[16] == 1) ? true : false;

		if (receivedLength_aud == 0) dataByte_aud = new Uint8Array(0);
		receivedLength_aud += _byteData.length - 17;
		//----------------add byte----------------
		dataByte_aud = CombineInt8Array(dataByte_aud, _byteData.slice(17, _byteData.length));
		//----------------add byte----------------
		if (ReadyToGetFrame_aud) {
			if (receivedLength_aud == dataLength_aud) ProcessAudioData(dataByte_aud, _GZipMode);
		}
	}

	//Video
	if (_label == label_img) {
		var _dataID = ByteToInt32(_byteData, 4);
		if (_dataID != dataID_img) receivedLength_img = 0;

		dataID_img = _dataID;
		dataLength_img = ByteToInt32(_byteData, 8);
		//var _offset = ByteToInt32(_byteData, 12);
		var _GZipMode = (_byteData[16] == 1) ? true : false;

		if (receivedLength_img == 0) dataByte_img = new Uint8Array(0);
		receivedLength_img += _byteData.length - 17;

		//----------------add byte----------------
		dataByte_img = CombineInt8Array(dataByte_img, _byteData.slice(17, _byteData.length));
		//----------------add byte----------------

		if (ReadyToGetFrame_img) {
			if (receivedLength_img == dataLength_img) ProcessImageData(dataByte_img, _GZipMode);
		}
	}
}

//#region Audio Func
function ProcessAudioData(_byte, _GZipMode) {
	ReadyToGetFrame_aud = false;

	var bytes = new Uint8Array(_byte);
	if (_GZipMode) {
		var gunzip = new Zlib.Gunzip(bytes);
		bytes = gunzip.decompress();
	}

	//read meta data
	SourceSampleRate = ByteToInt32(bytes, 0);
	SourceChannels = ByteToInt32(bytes, 4);

	//conver byte[] to float
	var BufferData = bytes.slice(8, bytes.length);
	var AudioInt16 = new Int16Array(BufferData.buffer);

	//=====================playback=====================
	if (AudioInt16.length > 0) StreamAudio(SourceChannels, AudioInt16.length, SourceSampleRate, AudioInt16);
	//=====================playback=====================

	ReadyToGetFrame_aud = true;
	document.getElementById("StatusTextAudioInfo").innerHTML = "info: " + SourceChannels + "x" + SourceSampleRate + " | " + (_GZipMode ? ("Zip(" + Math.round((_byte.length / bytes.length) * 100) + "%)") : "Raw");
	document.getElementById("StatusTextAudio").innerHTML = "(kB)" + Math.round(_byte.length / 1000);
}

function StreamAudio(NUM_CHANNELS, NUM_SAMPLES, SAMPLE_RATE, AUDIO_CHUNKS) {
	var audioBuffer = audioCtx.createBuffer(NUM_CHANNELS, (NUM_SAMPLES / NUM_CHANNELS), SAMPLE_RATE);
	for (var channel = 0; channel < NUM_CHANNELS; channel++) {
		// This gives us the actual ArrayBuffer that contains the data
		var nowBuffering = audioBuffer.getChannelData(channel);
		for (var i = 0; i < NUM_SAMPLES; i++) {
			var order = i * NUM_CHANNELS + channel;
			var localSample = 1.0 / 32767.0;
			localSample *= AUDIO_CHUNKS[order];
			nowBuffering[i] = localSample;
		}
	}

	var source = audioCtx.createBufferSource();
	source.buffer = audioBuffer;

	source.connect(audioCtx.destination);
	source.start(startTime);

	startTime += audioBuffer.duration;
}
//#endregion
//#region Video Func
function ProcessImageData(_byte, _GZipMode) {
	ReadyToGetFrame_img = false;

	var binary = '';

	var bytes = new Uint8Array(_byte);
	if (_GZipMode) {
		var gunzip = new Zlib.Gunzip(bytes);
		bytes = gunzip.decompress();
	}

	//----conver byte[] to Base64 string----
	var len = bytes.byteLength;
	for (var i = 0; i < len; i++) {
		binary += String.fromCharCode(bytes[i]);
	}
	//----conver byte[] to Base64 string----

	//----display image----
	var img = document.getElementById('DisplayImg');
	img.src = 'data:image/jpeg;base64,' + btoa(binary);
	//img.width = data.Width;
	//img.height = data.Height;
	//----display image----

	ReadyToGetFrame_img = true;

	document.getElementById("StatusTextVideoInfo").innerHTML = "info: " + img.width + "x" + img.height + " | " + (_GZipMode ? ("Zip(" + Math.round((_byte.length / bytes.length) * 100) + "%)") : "Raw");
	document.getElementById("StatusTextVideo").innerHTML = "(kB)" + Math.round(_byte.length / 1000);
}
//#endregion


// defines new video packet processing for an individual stream
// used by 'video' and 'audio' members
const buffer = function (data) {
	this.chain = this.chain.then(() => {
		if (this.buf != null) {
			return new Promise((resolve, reject) => {
				this.buf.onupdateend = () => {
					let n = this.buf.buffered.length - 1;
					if (n >= 0) {
						// forward playback to first timestamp of latest segment
						if (n > this.currentSegment) {
							this.startTime = Date.now().valueOf();

							this.currentSegment = n;
							let startTs = this.buf.buffered.start(n);
							this.display.currentTime = startTs;
							console.log(this.type + " forwarded to second " + startTs);

							this.startTS = this.buf.buffered.end(n);
						}

						let ts = this.buf.buffered.end(n);
						console.log(this.type + " latest timestamp = " + ts);
					}
					resolve();
				};
				this.buf.appendBuffer(data);
			});
		}
	});

	return this.chain;
}

/***VIDEO***/

// used to create video streams from received data


// Audio
// used to create audio streams from received data
// its member keys should be equivalent to the 8 byte packet prefix corresponding to an emitter
const audio = {
	type: 'audio', // buffer logging
	display: null, // DOM video element
	source: null, // MediaSource
	buf: null, // SourceBuffer used by 'source'
	header: null, // webm header
	currentSegment: -1,
	startTime: null,
	startTS: null,

	chain: Promise.resolve(null), // used to ensure operations on this stream are synchronous

	buffer: buffer,


	// create new stream and an associated audio HTML element
	// input should be a webm header
	init: function (header) {
		// do nothing if stream already exists
		if (audio.header != null) {
			return;
		}

		let source = new MediaSource();
		let display = document.createElement('audio');

		display.controls = true;
		display.src = URL.createObjectURL(source);
		source.onsourceopen = () => {
			audio.buf = source.addSourceBuffer('audio/webm; codecs="opus"');
			audio.buffer(header).then(() => {
				audio.header = header;
				console.log("new audio stream created");
			});
		};
		source.onsourceended = () => {
			display.remove();
		};

		audioPanel.appendChild(display);
		audio.display = display;
		audio.source = source;
	},

	// resets audio object to default and removes the audio element
	reset: function () {
		if (audio.source == null) {
			return;
		}

		audio.source.endOfStream();

		audio.display = null;
		audio.source = null;
		audio.buf = null;
		audio.header = null;
		audio.currentSegment = -1;
		audio.startTime = null;
		audio.startTS = null;
		audio.chain = Promise.resolve(null);

		console.log('audio stream discarded');
	}
}

// captures headers or forwards data to appropriate stream
const demuxer = {
	handlePacket: function (data) {
		data.slice(0, 1).arrayBuffer().then((buf) => {
			let type = bytesToNum(buf, 0, 1);
			data.slice(1).arrayBuffer().then((buf) => {
				let stream = video;
				if (type === 1) {
					stream = audio;
				}

				// check for expected headers
				// note: header capturing might no longer be a useful feature
				if (stream.header == null) {
					stream.init(buf);
					return;
				}

				stream.buffer(buf);
			});
		});
	}
};

/***INPUT***/

const input = {
	ref0: Date.now(), // session reference time
	ref: null, // current packet reference time
	buf: new ArrayBuffer(1024), // current packet buffer
	view: null, // buf DataView
	i: 4, // next available buffer index
	active: {}, // currently pressed keys
	tick: null, // timer

	grow: function () {
		let tmp = new Uint8Array(input.buf);
		input.buf = new ArrayBuffer(2 * tmp.byteLength);
		let view = new Uint8Array(input.buf);
		for (let i = 0; i < tmp.length; i++) {
			view[i] = tmp[i];
		}
		input.view = new DataView(input.buf);
	},

	// buffer keyboard/mouse button event
	pushK: function (time, code, key) {
		let i = input.i;
		// grow buffer if necessary
		if (input.buf.byteLength < i + 5) input.grow();

		let view = input.view;
		view.setUint16(i, time - input.ref, true);
		view.setUint8(i + 2, code);
		view.setUint16(i + 3, key, true);
		input.i += 5;
	},

	// buffer mouse wheel event
	pushMW: function (time, mag) {
		let i = input.i;
		if (input.buf.byteLength < i + 4) input.grow();

		let view = input.view;
		view.setUint16(i, time - input.ref, true);
		view.setUint8(i + 2, 2);
		view.setInt8(i + 3, mag);
		input.i += 4;
	},

	// buffer mouse move event
	pushMM: function (time, x, y) {
		let i = input.i;
		if (input.buf.byteLength < i + 7) input.grow();

		let view = input.view;
		view.setUint16(i, time - input.ref, true);
		view.setUint8(i + 2, 3);
		view.setUint16(i + 3, x, true);
		view.setUint16(i + 5, y, true);
		input.i += 7
	},

	// transmit buffer and prepare next cycle
	sync: function () {
		let t = Date.now();

		// transmit current buffer
		ws.send(new DataView(input.buf, 0, input.i));

		input.ref = t;
		input.view.setUint32(0, t - input.ref0, true);
		input.i = 4;
		// key press turnover
		for (kc in input.active) {
			input.pushK(t, 4, kc);
		}
	},

	// event handlers
	keyDown: function (event) {
		let t = Date.now();
		if (!event.repeat) {
			let kc = event.keyCode;
			input.pushK(t, 4, kc);
			input.active[kc] = null;
		}
		event.preventDefault();
	},
	keyUp: function (event) {
		let t = Date.now();
		let kc = event.keyCode;
		input.pushK(t, 0, kc);
		delete (input.active[kc]);
	},
	mouseDown: function (event) {
		let t = Date.now();
		let kc;
		switch (event.button) {
			case 0:
				kc = 323;
				break;
			case 1:
				kc = 325;
				break;
			case 2:
				kc = 324;
				break;
		}
		input.pushK(t, 4, kc);
		input.active[kc] = null;
		event.preventDefault();
	},
	mouseUp: function (event) {
		let t = Date.now();
		let kc;
		switch (event.button) {
			case 0:
				kc = 323;
				break;
			case 1:
				kc = 325;
				break;
			case 2:
				kc = 324;
				break;
		}
		input.pushK(t, 0, kc);
		delete (input.active[kc])
		event.preventDefault();
	},
	mouseWheel: function (event) {
		let t = Date.now();
		input.pushMW(t, event.deltaY);
		event.preventDefault();
	},
	mouseMove: function (event) {
		let t = Date.now();

		// constrain X and Y between 0 and element max
		// otherwise they will be out of bounds when mousing over the element edges
		let target = event.target;

		let x = event.offsetX;
		if (x < 0) x = 0;
		else if (x > target.clientWidth) x = target.clientWidth;

		let y = event.offsetY;
		if (y < 0) y = 0;
		else if (y > target.clientHeight) y = target.clientHeight;

		input.pushMM(t, x, y);
	}
};

inputBox.oncontextmenu = function (event) {
	event.preventDefault();
}

// setup the input element to get focus and capture user inputs
inputBox.onmouseenter = function () {
	inputBox.focus();

	inputBox.onkeydown = input.keyDown;
	inputBox.onkeyup = input.keyUp;
	inputBox.onmousedown = input.mouseDown;
	inputBox.onmouseup = input.mouseUp;
	inputBox.onwheel = input.mouseWheel;
	inputBox.onmousemove = input.mouseMove;

	input.ref = Date.now();
	input.view = new DataView(input.buf);
	input.view.setUint32(0, input.ref - input.ref0, true);
	input.tick = setInterval(input.sync, 50);
};

// stop input capture
inputBox.onmouseleave = function () {
	clearInterval(input.tick);
	input.i = 4;
	input.active = {};
	input.mouse = [0, 0, 0];

	inputBox.onkeydown = function () { };
	inputBox.onkeyup = function () { };
	inputBox.onmousedown = function () { };
	inputBox.onmouseup = function () { };
	inputBox.onwheel = function () { };
	inputBox.onmousemove = function () { };

	inputBox.blur();
};




/***COMMUNICATION***/

// handles rpc messages
const rpc = {
	n: 0, // last used tag
	max: (~0) >>> 1, // 2^31-1

	pending: {}, // holds pending response callbacks

	// send an rpc message with the given name and data through the websocket
	send: function (name, data) {
		if (this.n >= this.max) {
			this.n = 0;
		}
		this.n++;
		let tag = this.n;

		let message = {
			name: name,
			data: data,
			tag: tag,
			error: "y",
		}
		message = JSON.stringify(message);

		return new Promise((resolve, reject) => {
			let f = function (msg) {
				resolve(msg);
			}
			this.pending[tag] = f;

			ws.send(message);
		})
	},

	// resolve the outgoing request with the same tag
	resolve: function (msg) {
		let tag = msg.tag;
		this.pending[tag](msg);
		delete this.pending[tag];
	},

	// respond to the given request message using the given data
	respond: function (tag, data) {
		let message = {
			name: 'response',
			data: data,
			tag: tag
		}
		ws.send(JSON.stringify(message));
	}
}

// return message unaltered; then resume normal mode
const echoMode = function (message) {
	ws.send(message);

	ws.onmessage = normalMode;
}
