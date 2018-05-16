using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    public class cPKTSayResult : cJSONPacketBase
    {
        public enum eResultCode
        {
            SUCCEED, // 성공 
            FAILURE, // 실패 
            MAX
        }

        public eResultCode ResultCode { get; set; }
        public string Message { get; set; }

        public cPKTSayResult()
        {
            ResultCode = eResultCode.MAX;
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTSayResult;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTSayResult>(data);
        }
    }
}
