using System;
using System.Collections.Generic;

using System.Text;


namespace Packet.Base
{
    /// <summary>
    /// 패킷 팩토리 인터페이스
    /// </summary>
    public interface IPacketCreator
    {
        /// <summary>
        /// 패킷Id를 반환한다.
        /// </summary>
        /// <returns>패킷Id</returns>
        ePacketId GetPacketId();

        /// <summary>
        /// 데이터를 패킷으로 만든다.
        /// </summary>
        /// <param name="data">생성할 패킷에 대한 데이터</param>
        /// <returns>생성한 패킷</returns>
        IPacket Unmarshal(string data);
    }
}
