"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl(virtualDirectory + "/ChatHub?autentification=" + autentification + "&token=" + token).build();

// new signalR.HubConnectionBuilder().withUrl(virtualDirectory + "/chatHub?idDc=" + idDc + "&idDoc=" + idDoc + "&idUser=" + idUser + "&operation=" + operation).build();




//Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    console.log("123456");
    //  document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
