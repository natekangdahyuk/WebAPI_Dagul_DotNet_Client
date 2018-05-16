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
    public class cPKTGameLoginResultHandler : IPacketHandler
    {
        public void Execute(IPeer peer, IPacket packet)
        {
            cPKTGameLoginResult recvPacket = (cPKTGameLoginResult)packet;
            Console.WriteLine("PKTGameLoginResultHandler =====> ResultCode: {0}", recvPacket.ResultCode.ToString());
            MessageManager.Message = String.Format("PKTGameLoginResultHandler =====> ResultCode: {0}", recvPacket.ResultCode.ToString());
        }
    }
}
