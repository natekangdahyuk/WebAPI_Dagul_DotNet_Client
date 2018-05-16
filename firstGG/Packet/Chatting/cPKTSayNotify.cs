using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    public class cPKTSayNotify : cJSONPacketBase
    {
        public enum eResultCode
        {
            SUCCEED,
            MAX
        }

        public string AccountId { get; set; }
        public string Message { get; set; }

        public cPKTSayNotify()
        {
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTSayNotify;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTSayNotify>(data);
        }
    }
}
