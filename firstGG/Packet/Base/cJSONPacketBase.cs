using System;
using System.Collections.Generic;

using System.Text;


namespace Packet.Base
{
    /// <summary>
    /// JSON을 사용하는 패킷의 기본형
    /// </summary>
    /// <typeparam name="TPacketName"></typeparam>
    public class cJSONPacketBase : IPacket
    {
        /// <summary>
        /// 패킷Id를 반환한다.
        /// </summary>
        /// <returns>패킷Id</returns>
        public virtual ePacketId GetPacketId()
        {
            return ePacketId.Max;
        }

        /// <summary>
        /// 패킷에 있는 내용을 전송할 수 있게 만든다.
        /// </summary>
        /// <returns>전송할 수 있는 문자열</returns>
        public virtual string Marshal()
        {
            return string.Empty;
        }

        /// <summary>
        /// 패킷에 있는 내용을 전송할 수 있게 만든다.
        /// </summary>
        /// <returns>전송할 수 있는 문자열</returns>
        public virtual string MarshalDataNoEnc()
        {
            return string.Empty;
        }

        /// <summary>
        /// 패킷을 생성한다.
        /// </summary>
        /// <param name="data">생성할 때 사용할 데이터</param>
        /// <returns>생성한 패킷</returns>
        public virtual IPacket Unmarshal(string data)
        {
            return null;
        }
    }
}
