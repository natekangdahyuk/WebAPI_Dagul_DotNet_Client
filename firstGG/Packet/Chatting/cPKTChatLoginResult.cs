using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    public class cPKTChatLoginResult : cJSONPacketBase
    {
        public enum eResultCode
        {
            SUCCEED,
            TOO_SHORT_ACCOUNT_ID, // 계정이 너무 짧다.
            MAX
        }

        public eResultCode ResultCode { get; set; }

        public cPKTChatLoginResult()
        {
            ResultCode = eResultCode.MAX;
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTChatLoginResult;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTChatLoginResult>(data);
        }
    }
}
