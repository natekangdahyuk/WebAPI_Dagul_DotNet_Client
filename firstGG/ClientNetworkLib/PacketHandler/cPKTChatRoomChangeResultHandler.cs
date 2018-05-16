using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Network.Base;
using Packet;
using Packet.Base;

namespace ClientNetworkLib.PacketHandler
{
    public class cPKTChatRoomChangeResultHandler : IPacketHandler
    {
        public void Execute(IPeer peer, IPacket packet)
        {
            cPKTChatRoomChangeResult recvPacket = (cPKTChatRoomChangeResult)packet;
            Console.WriteLine("PKTChatRoomChangeResultHandler =====> ResultCode: {0}", recvPacket.ResultCode.ToString());
        }
    }
}
