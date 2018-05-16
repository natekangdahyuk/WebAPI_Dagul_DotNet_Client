using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    public class cPKTInit : cJSONPacketBase
    {

        public string AccountId;

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTInit;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {            
            IPacket aaa = (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTInit>(data);
            return aaa;
        }

    }
    




}
