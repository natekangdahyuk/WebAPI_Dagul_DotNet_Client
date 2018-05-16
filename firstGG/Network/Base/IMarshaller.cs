using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packet.Base;

namespace Network.Base
{
    /// <summary>
    /// 패킷을 분석한다.
    /// </summary>
    public interface IMarshaller
    {
        /// <summary>
        /// 패킷을 마샬링 한다.
        /// </summary>
        /// <param name="packet">마샬링할 패킷</param>
        /// <returns>패킷 문자열</returns>
        string Marshal(IPacket packet);

        /// <summary>
        /// 데이터를 언마샬링 한다.
        /// </summary>
        /// <param name="message">언마샬링할 데이터</param>
        /// <param name="packetManager">패킷 매니저</param>
        /// <returns>생성한 패킷</returns>
        IPacket Unmarshal(string data, IPacketManager packetManager);
    }
}
