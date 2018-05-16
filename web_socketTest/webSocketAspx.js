function WriteChatLog(msg) {
    commsLog.innerHTML += '<tr>' +
        '<td class="commslog-server">Server</td>' +
        '<td class="commslog-client">Client</td>' +
        '<td class="commslog-data">' + msg + '</td>'
    '</tr>';
}