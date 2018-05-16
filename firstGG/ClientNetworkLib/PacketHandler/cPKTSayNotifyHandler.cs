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
    public class cPKTSayNotifyHandler : IPacketHandler
    {
        public void Execute(IPeer peer, IPacket packet)
        {
            cPKTSayNotify recvPacket = (cPKTSayNotify)packet;
            Debug.Log(
                String.Format("PKTSayNotifyHandler =====> AccountId: {0}, Message: {1}",
                recvPacket.AccountId,
                recvPacket.Message));

            MessageManager.Message = String.Format("PKTSayNotifyHandler =====> AccountId: {0}, Message: {1}",
                recvPacket.AccountId,
                recvPacket.Message);
        }
    }
}
