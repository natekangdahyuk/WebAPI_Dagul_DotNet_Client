using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    public class cPKTSay : cWebPacketBase
    {
        public string Message { get; set; }

        public cPKTSay()
        {
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTSay;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTSay>(data);
        }
    }
}
