using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Packet.Base;

namespace Network.Base
{
    public interface IPacketHandler
    {
        void Execute(IPeer peer, IPacket packet);
    }
}
