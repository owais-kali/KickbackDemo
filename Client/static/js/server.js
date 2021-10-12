// default socket onmessage handler
// websocket expects the following binary format: emitterID(uint64), followed by binary video data (no separators)
// if the message is a string then it should be a command JSON of the form: {"name":[command_string]}
const normalMode = function (message) {
	if (typeof message.data != 'string') {
		//demuxer.handlePacket(message.data);
		
		message.data.slice(0, 1).arrayBuffer().then((buf) => {
			var num1  = bytesToNum(buf, 0, 1);
			console.log("Got binary length: " + num1);
		});
		OnDataRecive(message.data)

	} else {
		OnDataRecive(message.data)
		
        // let msg = JSON.parse(message.data);
		// console.log("comm: ", msg);
		// switch (msg.name) {
		// 	case 'response':
		// 		rpc.resolve(msg);
		// 		break;
		// 	case 'identify':
		// 		let id = parseInt(idBox.value);
		// 		if (isNaN(id)) {
		// 			console.log("invalid ID field");
		// 			// respond anyway to clear the rpc queue
		// 		}
		// 		rpc.respond(msg.tag, {kind: 'receiver', id: id});
		// 		break;
		// 	case 'echo':
		// 		ws.onmessage = echoMode;
		// }
	}
}

// open websocket and send signal to begin streaming
const establish_connection = function () {
	let conn = 'ws';
	if (ssl.checked === true) {
		conn = 'wss';
	}

	//let WS_URL = conn + '://' + document.getElementById('adr').value + '/wsout';
	let WS_URL = "ws://127.0.0.1:3000/Client"
	try {
		ws = new WebSocket(WS_URL);
		ws.onmessage = normalMode;
		ws.onclose = () => {
			this.onclick = establish_connection;
			this.innerHTML = 'Connect';
			button_stream.style.display = 'none';
			inputLabel.style.display = 'none';
			inputBox.style.display = 'none';
			test.innerHTML = 'Disconnected';
		};

		// switch connection button functionality
		this.onclick = close_connection;
		this.innerHTML = 'Disconnect';
		this.style.backgroundColor = 'cyan';

		test.innerHTML = 'Connected';

		// activate stream button and input streaming
		button_stream.style.display = 'block';
		button_stream.onclick = start_stream;
		inputLabel.style.display = 'block';
		inputBox.style.display = 'block';

        Emit_WsOpen();

	} catch (err) {
		this.style.backgroundColor = 'crimson';
		console.log(err.message);
	}
}

// stop transmission and close websocket once all buffered data has been sent
const close_connection = function () {
	ws.close(1000);
}

// signal the server to start streaming
const start_stream = function () {
	rpc.send('start', null);
	this.onclick = stop_stream;
	this.innerHTML = 'Stop';
}

// signal the server to stop streaming, without closing the websocket
const stop_stream = function () {
	rpc.send('stop', null).then(() => {
		video.reset();
		audio.reset();
	});
	this.onclick = start_stream;
	this.innerHTML = 'Start';
}