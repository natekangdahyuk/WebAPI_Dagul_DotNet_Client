using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Packet;
using Packet.Base;
using Network.Base;

namespace Network.Packet
{
    public class cPacketHandlerManager
    {
        private Dictionary<ePacketId, IPacketHandler> PacketHandlerMap = null; // 패킷 핸들러 맵

        public cPacketHandlerManager()
        {
            PacketHandlerMap = new Dictionary<ePacketId, IPacketHandler>();
        }

        public bool Add(ePacketId packetId, IPacketHandler packetHandler)
        {
            if (true == PacketHandlerMap.ContainsKey(packetId))
            {
                return false;
            }

            PacketHandlerMap.Add(packetId, packetHandler);
            return true;
        }

        public bool Execute(IPeer peer, IPacket packet)
        {
            if (false == PacketHandlerMap.ContainsKey(packet.GetPacketId()))
            {
                return false;
            }

            IPacketHandler packetHandler = PacketHandlerMap[packet.GetPacketId()];
            packetHandler.Execute(peer, packet);
            return true;
        }
    }
}
