using System;
using System.Collections.Generic;

using System.Text;


namespace Packet.Base
{
    /// <summary>
    /// 패킷 인터페이스
    /// </summary>
    public interface IPacket
    {
        /// <summary>
        /// 패킷Id를 반환한다.
        /// </summary>
        /// <returns>패킷Id</returns>
        ePacketId GetPacketId();

        /// <summary>
        /// 패킷에 있는 내용을 전송할 수 있게 만든다.
        /// </summary>
        /// <returns>전송할 수 있는 문자열</returns>
        string Marshal();

        /// <summary>
        /// 패킷에 있는 내용을 전송할 수 있게 만든다.
        /// </summary>
        /// <returns>전송할 수 있는 문자열</returns>
        string MarshalDataNoEnc();

        IPacket Unmarshal(string data);
    }
}
