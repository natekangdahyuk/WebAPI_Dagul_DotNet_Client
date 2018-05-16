using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Network.Packet;
using Packet.Base;

namespace Network.Base
{
    public interface IPeer
    {
        /// <summary>
        /// 피어Id
        /// </summary>
        string PeerId { get; set; }

        /// <summary>
        /// 마샬러
        /// </summary>
        IMarshaller Marshaller { get; set; }

        /// <summary>
        /// 데이터를 전송한다.
        /// </summary>
        /// <param name="sendBuffer">패킷이 들어있는 버퍼</param>
        void Send(ArraySegment<Byte> sendBuffer);

        /// <summary>
        /// 패킷을 전송한다.
        /// </summary>
        /// <param name="packet">전송할 패킷</param>
        void Send(IPacket packet);

        /// <summary>
        /// 받은 데이터를 처리한다.(주로 서버에서 사용)
        /// </summary>
        /// <param name="packetManager">패킷 매니저</param>
        /// <param name="packetHandlerManager">패킷 핸들러 매니저</param>
        /// <param name="receiveBuffer">데이터가 저장되어 있는 버퍼</param>
        /// <param name="receiveBufferSize">데이터가 저장되어 있는 버퍼의 길이(데이터의 길이)</param>
        /// <returns>성공 유무</returns>
        bool Receive(IPacketManager packetManager, cPacketHandlerManager packetHandlerManager, ArraySegment<Byte> receiveBuffer, int receiveBufferSize);

        /// <summary>
        /// 버퍼에 저장되어 있는 내용을 처리한다.(주로 클라이언트에서 사용)
        /// </summary>
        /// <param name="packetManager">패킷 매니저</param>
        /// <param name="packetHandlerManager">패킷 핸들러 매니저</param>
        void Receive(IPacketManager packetManager, cPacketHandlerManager packetHandlerManager);
    }
}
