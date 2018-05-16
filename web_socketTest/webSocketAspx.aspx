<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webSocketAspx.aspx.cs" Inherits="firstGG.webSocketAspx" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
    <script src="/Scripts/jquery-3.1.1.min.js"></script>
    <script src="webSocketAspx.js"></script>
    <style>
        table {
            border: 0
        }

        .commslog-data {
            font-family: Consolas, Courier New, Courier, monospace;
        }

        .commslog-server {
            background-color: red;
            color: white
        }

        .commslog-client {
            background-color: green;
            color: white
        }
    </style>
</head>
<body>
    
    <h1>WebSocket Test Page</h1>
    <pre>
        설명.. Connect  부분은 자동으로 돌아가야 한다.. 현재는 소스  안에
        SocketChatLogin_Click()  이게 그 역할을 한다.
        javascript 로 변경하면. 웹서비스를 호출 하고 거기서 리턴 받아서 다시 확인 하라 화주 웹을 참고하면 될듯 합니다.
        그러면.. 웹 채팅 구현이 됩니다.
    </pre>
    <p id="stateLabel">Ready to connect...</p>
    <div>
        <label for="connectionUrl">WebSocket Server URL:</label>
        <input id="connectionUrl" />
        <button id="connectButton" type="submit">Connect</button>
    </div>
    <div>
        <label for="sendMessage">Message to send:</label>
        <input id="sendMessage" disabled />
        <button id="sendButton" type="submit" disabled>Send</button>
        <button id="closeButton" disabled>Close Socket</button>
        <br />        
    </div>
    <form id="form1" runat="server">        
        
        <asp:TextBox ID="txtSendMsg" runat="server" Columns="20" MaxLength="100" />        
        <asp:Button ID="btnSendMsg" runat="server" Text="닷넷샌드" OnClick="btnSendMsg_Click" />
        결과값 : <asp:Label ID="lblSendMsgResult" runat="server"></asp:Label>
        
    </form>
    <p>Note: When connected to the default server (i.e. the server in the address bar ;)), the message "ServerClose" will cause the server to close the connection. Similarly, the message "ServerAbort" will cause the server to forcibly terminate the connection without a closing handshake</p>
    <h2>Communication Log</h2>
    <table style="width: 800px">
        <thead>
            <tr>
                <td style="width: 100px">From</td>
                <td style="width: 100px">To</td>
                <td>Data</td>
            </tr>
        </thead>
        <tbody id="commsLog"></tbody>
    </table>
    <script>
        var connectionForm = document.getElementById("connectionForm");
        var connectionUrl = document.getElementById("connectionUrl");
        var connectButton = document.getElementById("connectButton");
        var stateLabel = document.getElementById("stateLabel");
        var sendMessage = document.getElementById("sendMessage");
        var sendButton = document.getElementById("sendButton");
        var sendForm = document.getElementById("sendForm");
        var commsLog = document.getElementById("commsLog");

        var socket;

        var scheme = document.location.protocol == "https:" ? "wss" : "ws";
        var port = document.location.port ? (":" + document.location.port) : "";

        //connectionUrl.value = scheme + "://" + document.location.hostname + port;
        connectionUrl.value ="ws://localhost:54427/WebSocketChatNoEnc/PacketReceiver";
        function updateState() {
            function disable() {
                sendMessage.disabled = true;
                sendButton.disabled = true;
                closeButton.disabled = true;
            }
            function enable() {
                sendMessage.disabled = false;
                sendButton.disabled = false;
                closeButton.disabled = false;
            }

            connectionUrl.disabled = true;
            connectButton.disabled = true;

            if (!socket) {
                disable();
            } else {
                switch (socket.readyState) {
                    case WebSocket.CLOSED:
                        stateLabel.innerHTML = "Closed";
                        disable();
                        connectionUrl.disabled = false;
                        connectButton.disabled = false;
                        break;
                    case WebSocket.CLOSING:
                        stateLabel.innerHTML = "Closing...";
                        disable();
                        break;
                    case WebSocket.CONNECTING:
                        stateLabel.innerHTML = "Connecting...";
                        disable();
                        break;
                    case WebSocket.OPEN:
                        stateLabel.innerHTML = "Open";
                        enable();
                        break;
                    default:
                        stateLabel.innerHTML = "Unknown WebSocket State: " + socket.readyState;
                        disable();
                        break;
                }
            }
        }

        closeButton.onclick = function () {
            if (!socket || socket.readyState != WebSocket.OPEN) {
                alert("socket not connected");
            }
            socket.close(1000, "Closing from client");
        }

        sendButton.onclick = function () {
            if (!socket || socket.readyState != WebSocket.OPEN) {
                alert("socket not connected");
            }
            var data = sendMessage.value;
            //cs 파일 호출
            socket.send(data);
            commsLog.innerHTML += '<tr>' +
                '<td class="commslog-client">Client</td>' +
                '<td class="commslog-server">Server</td>' +
                '<td class="commslog-data">' + data + '</td>'
            '</tr>';
        }

        connectButton.onclick = function() {
            stateLabel.innerHTML = "Connecting";
            socket = new WebSocket(connectionUrl.value);
            socket.onopen = function (event) {
                updateState();
                commsLog.innerHTML += '<tr>' +
                    '<td colspan="3" class="commslog-data">Connection opened</td>' +
                '</tr>';
            };
            socket.onclose = function (event) {
                updateState();
                commsLog.innerHTML += '<tr>' +
                    '<td colspan="3" class="commslog-data">Connection closed. Code: ' + event.code + '. Reason: ' + event.reason + '</td>' +
                '</tr>';
            };
            socket.onerror = updateState;
            socket.onmessage = function (event) {
                commsLog.innerHTML += '<tr>' +
                    '<td class="commslog-server">Server</td>' +
                    '<td class="commslog-client">Client</td>' +
                    '<td class="commslog-data">' + event.data + '</td>'
                '</tr>';
            };
        };
    </script>
    
</body>
</html>