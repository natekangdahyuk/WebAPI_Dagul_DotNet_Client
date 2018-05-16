using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    public class cPKTChatLogin : cJSONPacketBase
    {
        public string AccountId;

        public cPKTChatLogin()
        {
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTChatLogin;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTChatLogin>(data);
        }
    }
}
