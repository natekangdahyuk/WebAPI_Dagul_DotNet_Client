using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Network.Packet;
using Network.Base;
using Packet.Base;

namespace ClientNetworkLib.Network
{
    /// <summary>
    /// 접속한 클라이언트 전송 처리
    /// </summary>
    public abstract class cPeerBase : IPeer
    {
        public IMarshaller Marshaller { get; set; }
        public string PeerId { get; set; }
        public bool IsError { get; private set; }
        public string ServerAddress { get; private set; }

        public cPeerBase(IMarshaller marshaller, string serverAddress)
        {
            Marshaller = marshaller;
            IsError = false;
            ServerAddress = serverAddress;
        }

        /// <summary>
        /// 데이터를 전송한다.
        /// </summary>
        /// <param name="sendBuffer">패킷이 들어있는 버퍼</param>
        public abstract void Send(ArraySegment<Byte> sendBuffer);

        /// <summary>
        /// 패킷을 전송한다.
        /// </summary>
        /// <param name="packet">전송할 패킷</param>
        public abstract void Send(IPacket packet);

        /// <summary>
        /// 패킷을 전송한다.
        /// </summary>
        /// <param name="packet">전송할 패킷</param>
        public abstract void Send(string packet);

        /// <summary>
        /// 받은 데이터를 처리한다.(주로 서버에서 사용)
        /// </summary>
        /// <param name="packetManager">패킷 매니저</param>
        /// <param name="packetHandlerManager">패킷 핸들러 매니저</param>
        /// <param name="receiveBuffer">데이터가 저장되어 있는 버퍼</param>
        /// <param name="receiveBufferLength">데이터가 저장되어 있는 버퍼의 길이(데이터의 길이)</param>
        /// <returns>성공 유무</returns>
        public abstract bool Receive(
            IPacketManager packetManager,
            cPacketHandlerManager packetHandlerManager,
            ArraySegment<Byte> receiveBuffer,
            int receiveBufferLength);

        /// <summary>
        /// 버퍼에 저장되어 있는 내용을 처리한다.(주로 클라이언트에서 사용)
        /// </summary>
        /// <param name="packetManager">패킷 매니저</param>
        /// <param name="packetHandlerManager">패킷 핸들러 매니저</param>
        /// <returns>성공 유무</returns>
        public abstract void Receive(IPacketManager packetManager, cPacketHandlerManager packetHandlerManager);

        /// <summary>
        /// 패킷을 추출한다.
        /// </summary>
        /// <param name="packetManager">패킷 매니저</param>
        /// <param name="packetHandlerManager">패킷 핸들러 매니저</param>
        /// <param name="data">추출할 데이터</param>
        /// <returns>성공 유무</returns>
        public bool ExtractPacket(IPacketManager packetManager, cPacketHandlerManager packetHandlerManager, string data)
        {
            //딸랑 packet 가 하는짓은 어떤 패킷 핸들러의 ResultCode 의 값이 success 인지 디시리얼된 값을 가져오는 짓이다.
            IPacket packet = Marshaller.Unmarshal(data, packetManager);
            if (null == packet)
            {
                return false;
            }
            //그럼 다시 이걸 핸들 메니저의 실행으로 가면
            packetHandlerManager.Execute(this, packet);
            return true;
        }

        /// <summary>
        /// 마샬러를 반환한다.
        /// </summary>
        /// <returns>반환할 마샬러</returns>
        public IMarshaller GetMarshaller()
        {
            return Marshaller;
        }
    }
}
