using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Network.Base;
using Packet;
using Packet.Base;
using UnityEngine;

namespace ClientNetworkLib.PacketHandler
{
    public class cPKTSayResultHandler : IPacketHandler
    {
        public void Execute(IPeer peer, IPacket packet)
        {
            cPKTSayResult recvPacket = (cPKTSayResult)packet;
            Debug.Log(
                String.Format("PKTSayResultHandler =====> ResultCode: {0}",
                recvPacket.ResultCode.ToString()));
        }
    }
}
