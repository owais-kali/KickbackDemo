const path = require('path');
const express = require('express');
const http = require('http');
const app = express();
const httpServer = http.createServer(app);

const PORT = process.env.PORT || 3001;

// HTTP stuff
app.use(express.static(__dirname + '/static'));
app.get('/receiver', (req, res) => res.sendFile(path.resolve(__dirname, 'static/html/receiver.html')));
//app.get('/emitter', (req, res) => res.sendFile(path.resolve(__dirname, 'static/html/emitter.html')));
app.get('/', (req, res) => {
    /* res.send(`
        <a href="emitter">Emitter</a><br>
        <a href="receiver">Receiver</a>
    `); */
    res.sendFile(path.resolve(__dirname, 'static/html/receiver.html'));
});
httpServer.listen(PORT, () => console.log(`HTTP server listening at http://localhost:${PORT}`));
