using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using System.Text;

using AFC;
using ClientNetworkLib.Network;
using ClientNetworkLib.PacketHandler;
using Network.Packet;
using Network.Base;
using Packet;

namespace firstGG
{
    public partial class webSocketAspx : System.Web.UI.Page
    {
        private System.Timers.Timer ReceivedDataQueueTimer { get; set; }
        private cPacketManager PacketManager { get; set; }
        private cPacketHandlerManager PacketHandlerManager { get; set; }

        //private cChatPeer Peer { get; set; }
        public static cChatPeer Peer { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Peer = new cChatPeer(new cJSONMarshaller(), "ws://localhost:61455/WebSocketDataNoEnc/WebPacketReceiver/Game");
                //Peer = new cChatPeer(new cJSONMarshaller(), "ws://localhost:61455/api/WebPacketReceiver/Chat");
                //Peer = new cChatPeer(new cJSONMarshaller(), "ws://localhost:54427/WebSocketChatNoEnc/WebPacketReceiver");
                Peer = new cChatPeer(new cJSONMarshaller(), "ws://localhost:54427/WebSocketChatNoEnc/PacketReceiver");

                PacketManager = new cPacketManager();
                PacketManager.Add(new cPKTChatLogin());
                PacketManager.Add(new cPKTChatLoginResult());
                PacketManager.Add(new cPKTChatRoomChange());
                PacketManager.Add(new cPKTChatRoomChangeResult());
                PacketManager.Add(new cPKTSay());
                PacketManager.Add(new cPKTSayResult());
                PacketManager.Add(new cPKTSayNotify());
                PacketManager.Add(new cPKTGameLogin());
                PacketManager.Add(new cPKTGameLoginResult());
                PacketManager.Add(new cPKTIdentify());
                PacketManager.Add(new cPKTIdentifyResult());
                PacketManager.Add(new cPKTAccountLoad());
                PacketManager.Add(new cPKTAccountLoadResult());
                PacketManager.Add(new cPKTInit());
                PacketManager.Add(new cPKTInitResult());

                PacketHandlerManager = new cPacketHandlerManager();
                PacketHandlerManager.Add(ePacketId.cPKTChatLoginResult, new cPKTChatLoginResultHandler());
                PacketHandlerManager.Add(ePacketId.cPKTChatRoomChangeResult, new cPKTChatRoomChangeResultHandler());
                PacketHandlerManager.Add(ePacketId.cPKTSayResult, new cPKTSayResultHandler());
                PacketHandlerManager.Add(ePacketId.cPKTSayNotify, new cPKTSayNotifyHandler());

                ReceivedDataQueueTimer = new System.Timers.Timer(100);
                ReceivedDataQueueTimer.Elapsed += new ElapsedEventHandler(OnReceivedDataQueueTimer);
                ReceivedDataQueueTimer.Enabled = true;
                ReceivedDataQueueTimer.Start();

                SocketChatLogin_Click();
            }
        }

        //페이지 로딩과 동시에 로그인
        protected void SocketChatLogin_Click()
        {
            cPKTChatLogin sendPacket = new cPKTChatLogin();
            sendPacket.AccountId = Guid.NewGuid().ToString();

            Peer.Send(sendPacket);
        }

        //페이지 로딩과 동시에 로그인
        protected void SocketChatLogin_Click2()
        {
            string msg = "13,{\"AccountId\":\"fiend24\", \"WG_Cmd\":\"init\", \"data\":{}}";
            //"0,{\"AccountId\":\"006b7711-e8b0-4455-92fe-b6c9febe6fcc\"}"
            Peer.Send(msg);
        }

        //메세지 발송
        protected void btnSendMsg_Click(object sender, EventArgs e)
        {            
            cPKTSay sendPacket = new cPKTSay();
            sendPacket.Message = txtSendMsg.Text;
            Peer.Send(sendPacket);
        }

        
        //메세지 결과 웹페이지에 표시 // 이런식으로는 안되고.. 자바스크립트 호출
        private void writeMsg(string msg)
        {
            //string jsMethodName  = "WriteChatLog("+msg+")";
            //string jsMethodName = "WriteChatLog('xxxx')";
            //ScriptManager.RegisterClientScriptBlock(this, typeof(string), "WriteChatLog", jsMethodName, true);
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "WriteChatLog", jsMethodName, true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "WriteChatLog","<script>commsLog.innerHTML += '<tr><td class=\"commslog-server\">Server</td><td class=\"commslog-client\">Client</td><td class=\"commslog-data\">" + msg + "</td></tr></script>");
            
        }


        string msg = "";
        private void OnReceivedDataQueueTimer(object source, ElapsedEventArgs e)
        {
            ReceivedDataQueueTimer.Stop();
            //Peer.Receive(PacketManager, PacketHandlerManager);
            msg =Peer.ReceiveWeb(PacketManager, PacketHandlerManager);            
            if (msg != null)
            {
                writeMsg(msg);                
            }

            ReceivedDataQueueTimer.Start();
        }
        
    }
}