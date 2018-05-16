using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Network.Base;
using Packet;
using Packet.Base;

using PacketCreatorMap = System.Collections.Generic.Dictionary<Packet.ePacketId, Packet.Base.IPacket>;

namespace Network.Packet
{
    /// <summary>
    /// 패킷을 관리한다. 대체적으로 할당을 한다.
    /// </summary>
    public class cPacketManager : IPacketManager
    {
        private PacketCreatorMap PacketCreator = new PacketCreatorMap(); // 패킷 팩토리

        /// <summary>
        /// 생성자
        /// </summary>
        public cPacketManager()
        {
        }

        /// <summary>
        /// 패킷을 추가한다.
        /// </summary>
        /// <param name="packetCreator">패킷 팩토리</param>
        //public void Add(IPacketCreator packetCreator)
        //{
        //    if (true == PacketCreator.ContainsKey(packetCreator.GetPacketId()))
        //    {
        //        throw new Exception(String.Format("a packet id already exists (packet_id: {0})", packetCreator.GetPacketId()));
        //    }

        //    PacketCreator.Add(packetCreator.GetPacketId(), packetCreator);
        //}
        public void Add(IPacket packetCreator)
        {
            if (true == PacketCreator.ContainsKey(packetCreator.GetPacketId()))
            {
                throw new Exception(String.Format("a packet id already exists (packet_id: {0})", packetCreator.GetPacketId()));
            }

            PacketCreator.Add(packetCreator.GetPacketId(), packetCreator);
        }

        /// <summary>
        /// 패킷을 할당한다.
        /// </summary>
        /// <param name="packetId">패킷Id</param>
        /// <param name="data">패킷 데이터</param>
        /// <returns>할당된 패킷</returns>
        //public IPacket Allocate(ePacketId packetId, string data)
        //{
        //    if (false == PacketCreator.ContainsKey(packetId))
        //    {
        //        return null;
        //    }

        //    return PacketCreator[packetId].Unmarshal(data);
        //}
        public IPacket Allocate(ePacketId packetId, string data)
        {
            if (false == PacketCreator.ContainsKey(packetId))
            {
                return null;
            }
            IPacket aaa = PacketCreator[packetId].Unmarshal(data);
            return aaa;

            //return PacketCreator[packetId].Unmarshal(data);
        }
    }
}
