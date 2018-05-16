using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    public class cPKTAccountLoad : cWebPacketBase
    {
        public Int64 AccountSN { get; set; }                        // 계정 시리얼 번호

        public cPKTAccountLoad()
        {
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTAccountLoad;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTAccountLoad>(data);
        }
    }
}
