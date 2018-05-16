using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Network.Base;
using Packet;
using Packet.Base;
using UnityEngine;

namespace Network.Packet
{
    public class cJSONMarshaller : IMarshaller
    {
        public cJSONMarshaller()
        {
        }

        public string Marshal(IPacket packet)
        {
            return String.Format("{0},{1}",
                Convert.ToString((int)packet.GetPacketId()),
                packet.Marshal());
        }

        /// <summary>
        /// 데이터를 언마샬 한다.
        /// </summary>
        /// <param name="data">언마샬링할 데이터</param>
        /// <param name="packetManager">패킷 매니저</param>
        /// <returns>생성한 패킷</returns>
        public IPacket Unmarshal(string data, IPacketManager packetManager)
        {
            ePacketId packetId = ePacketId.Max;
            string packetData = "";

            int packetIdIndex = data.IndexOf(',');
            if (-1 == packetIdIndex)
            {
                return null;
            }

            string packetIdData = data.Substring(0, packetIdIndex);
            if (0 == packetIdData.Length)
            {
                return null;
            }

            packetData = data.Substring(packetIdIndex + 1, data.Length - packetIdData.Length - 1); // ','가 있어서 -1을 하였다.
            packetId = (ePacketId)Convert.ToInt32(packetIdData);

            IPacket aaa = packetManager.Allocate(packetId, packetData);
            return aaa;
        }
    }
}
