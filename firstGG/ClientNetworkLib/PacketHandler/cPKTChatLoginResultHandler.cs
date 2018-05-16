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
    public class cPKTChatLoginResultHandler : IPacketHandler
    {
        public void Execute(IPeer peer, IPacket packet)
        {
            cPKTChatLoginResult recvPacket = (cPKTChatLoginResult)packet;
            Debug.Log(String.Format(
                "PKTChatLoginResultHandler =====> ResultCode: {0}",
                recvPacket.ResultCode.ToString()));

            MessageManager.Message = String.Format("PKTChatLoginResultHandler =====> ResultCode: {0}", recvPacket.ResultCode.ToString());
        }
    }
}
