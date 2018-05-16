using System;
using System.Collections.Generic;

using System.Text;


namespace Packet.Base
{
    public interface IPacketManager
    {
        /// <summary>
        /// 패킷 팩토리를 추가한다.
        /// </summary>
        /// <param name="packet">패킷 팩토리</param>
        //void Add(IPacketCreator packetCreator);
        void Add(IPacket packetCreator);

        /// <summary>
        /// 패킷을 할당한다.
        /// </summary>
        /// <param name="packetId">패킷Id</param>
        /// <param name="data">패킷 데이터</param>
        /// <returns>생성된 패킷</returns>
        IPacket Allocate(ePacketId packetId, string data);
    }
}
