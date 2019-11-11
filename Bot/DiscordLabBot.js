const Discord = require("discord.js");
const client = new Discord.Client();
const net = require('net');
const tcpSocket = net.createServer();
const connection = tcpSocket.listen("7727", "127.0.0.1")

// #region Bot events
client.on("ready", () => {
	console.log("Bot online")
});

client.on("warn", warn => utils.ConsoleMessage(warn, `warning`));
client.on("error", error => utils.ConsoleMessage(error, `error`));
//client.on("debug", debug => utils.ConsoleMessage(debug, `debug`));
client.on('disconnect', () => utils.ConsoleMessage('Connection to the Discord API has been lost. I will attempt to reconnect momentarily', `info`));
client.on('reconnecting', () => utils.ConsoleMessage('Attempting to reconnect to the Discord API now. Please stand by...', `info`));

tcpSocket.on("error", (e) => { console.log(e) })

tcpSocket.on("connection", (socket) => {

	socket.on("data", (data) => {
		var string = String.fromCharCode.apply(String, data)

		console.log(string)

		console.log()

		client.channels.get('blarg').send(string);
	})


})

client.login("blarg");