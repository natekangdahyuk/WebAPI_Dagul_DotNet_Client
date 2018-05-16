using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClientNetworkLib.Network;
using Network.Packet;
using Network.Utility;
using Network.Base;
using Packet;
using Packet.Base;
using WebSocketSharp;

namespace firstGG
{
    public class cChatPeer : cPeerBase
    {
        private WebSocket Socket { get; set; }
        private Queue<cHTTPData> ReceivedDataQueue { get; set; }
        private object ReceivedDataQueueLock { get; set; }

        public cChatPeer(IMarshaller marshaller, string uri)
            : base(marshaller, uri)
        {
            Socket = new WebSocket(uri);
            ReceivedDataQueue = new Queue<cHTTPData>();
            ReceivedDataQueueLock = new object();

            //Socket.OnOpen += (sender, e) => Socket.Send("Hi, there!");
            Socket.OnMessage += (sender, args) => AddDataToReceivedDataQueue(cHTTPData.eResultCode.SUCCEED, args);
            //Socket.OnError += (sender, e) => ReceivedDataQueue.Enqueue(new cHTTPData(_PeerIndex, cHTTPData.eResultCode.FAILURE, e.Message));
            Socket.OnError += (sender, args) => AddErrorToReceivedDataQueue(cHTTPData.eResultCode.FAILURE, args);
            //IsError = true;
            //Socket.OnClose += (sender, e) => ReceivedDataQueue.Enqueue(new cHTTPData(_PeerIndex, cHTTPData.eResultCode.Close, e.Reason));

#if DEBUG
            // To change the logging level.
            Socket.Log.Level = LogLevel.Trace;

            // To change the wait time for the response to the Ping or Close.
            Socket.WaitTime = TimeSpan.FromSeconds(10);
#endif

            Socket.Connect();
        }

        /// <summary>
        /// 서버에서 받은 정상 데이터를 처리한다.
        /// </summary>
        /// <param name="resultCode">결과 코드</param>
        /// <param name="args">서버로부터 받은 내용</param>
        private void AddDataToReceivedDataQueue(cHTTPData.eResultCode resultCode, WebSocketSharp.MessageEventArgs args)
        {
            lock (ReceivedDataQueueLock)
            {
                ReceivedDataQueue.Enqueue(new cHTTPData(cHTTPData.eResultCode.SUCCEED, args.Data));
            }
        }

        /// <summary>
        /// 서버에서 받은 오류 데이터를 처리한다.
        /// </summary>
        /// <param name="resultCode">결과 코드</param>
        /// <param name="args">서버로부터 받은 내용</param>
        private void AddErrorToReceivedDataQueue(cHTTPData.eResultCode resultCode, WebSocketSharp.ErrorEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("Error ===============================================> {0}", args.Message);
        }

        /// <summary>
        /// 데이터를 전송한다.
        /// </summary>
        /// <param name="sendBuffer">패킷이 들어있는 버퍼</param>
        public override void Send(ArraySegment<Byte> sendBuffer)
        {
            Socket.Send(sendBuffer.Array);
        }

        /// <summary>
        /// 패킷을 전송한다.
        /// </summary>
        /// <param name="packet">전송할 패킷</param>
        public override void Send(IPacket packet)
        {
            string message = Marshaller.Marshal(packet);
            ArraySegment<byte> binaryData = cConvertUtil.ConvertStringToBinary(message);
            Send(binaryData);
        }

        /// <summary>
        /// 패킷을 전송한다.
        /// </summary>
        /// <param name="packet">전송할 패킷</param>
        public override void Send(string packet)
        {
            string message = packet;
            ArraySegment<byte> binaryData = cConvertUtil.ConvertStringToBinary(message);
            Send(binaryData);
        }

        /// <summary>
        /// 받은 데이터를 처리한다.(주로 서버에서 사용)
        /// </summary>
        /// <param name="packetManager">패킷 매니저</param>
        /// <param name="packetHandlerManager">패킷 핸들러 매니저</param>
        /// <param name="receiveBuffer">데이터가 저장되어 있는 버퍼</param>
        /// <param name="receiveBufferLength">데이터가 저장되어 있는 버퍼의 길이(데이터의 길이)</param>
        /// <returns>성공 유무</returns>
        public override bool Receive(
            IPacketManager packetManager,
            cPacketHandlerManager packetHandlerManager,
            ArraySegment<Byte> receiveBuffer,
            int receiveBufferLength)
        {
            return false;
        }

        /// <summary>
        /// 버퍼에 저장되어 있는 내용을 처리한다.(주로 클라이언트에서 사용)
        /// </summary>
        /// <param name="packetManager">패킷 매니저</param>
        /// <param name="packetHandlerManager">패킷 핸들러 매니저</param>
        /// <returns>성공 유무</returns>
        public override void Receive(IPacketManager packetManager, cPacketHandlerManager packetHandlerManager)
        {
            lock (ReceivedDataQueueLock)
            {
                for (int loop1 = 0; ReceivedDataQueue.Count > loop1; ++loop1)
                {
                    cHTTPData httpData = ReceivedDataQueue.Dequeue();
                    if (false == ExtractPacket(packetManager, packetHandlerManager, httpData.Data))
                    {
                        //cLogger.Warning("cannot extract packet (data: {0})\r\n", httpData.Data);
                        continue;
                    }
                }
            }
        }


        /// <summary>
        /// 버퍼에 저장되어 있는 내용을 웹페이지에서 처리한다.. 위랑 다름(주로 클라이언트에서 사용)
        /// </summary>
        /// <param name="packetManager">패킷 매니저</param>
        /// <param name="packetHandlerManager">패킷 핸들러 매니저</param>
        /// <returns>성공 유무</returns>
        public string ReceiveWeb(IPacketManager packetManager, cPacketHandlerManager packetHandlerManager)
        {
            lock (ReceivedDataQueueLock)
            {
                for (int loop1 = 0; ReceivedDataQueue.Count > loop1; ++loop1)
                {
                    cHTTPData httpData = ReceivedDataQueue.Dequeue();
                    if (false == ExtractPacket(packetManager, packetHandlerManager, httpData.Data))
                    {
                        //cLogger.Warning("cannot extract packet (data: {0})\r\n", httpData.Data);
                        continue;
                    }
                    return httpData.Data;
                }
            }
            return  null;
        }

        /// <summary>
        /// 소켓을 닫는다.
        /// </summary>
        public void Close()
        {
            Socket.Close();
        }
    }
}