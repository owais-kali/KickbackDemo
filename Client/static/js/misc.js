//#region  Misc Func
function CombineInt8Array(a, b) {
	var c = new Int8Array(a.length + b.length);
	c.set(a);
	c.set(b, a.length);
	return c;
}
function CombineFloat32Array(a, b) {
	var c = new Float32Array(a.length + b.length);
	c.set(a);
	c.set(b, a.length);
	return c;
}

function ByteToInt32(_byte, _offset) {
	return (_byte[_offset] & 255) + ((_byte[_offset + 1] & 255) << 8) + ((_byte[_offset + 2] & 255) << 16) + ((_byte[_offset + 3] & 255) << 24);
	//return _byte[_offset] + _byte[_offset + 1] * 256 + _byte[_offset + 2] * 256 * 256 + _byte[_offset + 3] * 256 * 256 * 256;
}
//#endregion
//#endregion

/***UTIL***/

// converts byte array buffer into a number
// offset - start position in buffer
// n - number of bytes to use
const bytesToNum = function (bytes, offset, n) {
	let view = new DataView(bytes);
	switch (n) {
		case 8:
			return view.getBigUint64(offset);

		case 1:
			return view.getUint8(offset);
	}
};

// pads a string with '0' to the left, to cover exactly 8 characters
const pad8 = function (str) {
	let s = '';
	for (let i = str.length; i < 8; i++) {
		s += '0';
	}
	s += str;

	return s;
};