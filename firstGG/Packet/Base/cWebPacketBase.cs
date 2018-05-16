using System;
using System.Collections.Generic;

using System.Text;


namespace Packet.Base
{
    public class cWebPacketBase : cJSONPacketBase
    {
        public string AuthKey { get; set; }
        public string AccountId { get; set; }
    }
}
