using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;
using Common;

namespace Packet
{
    public class cPKTInitResult : cJSONPacketBase
    {
        public enum eResultCode
        {
            SUCCEED,
            TOO_SHORT_ACCOUNT_ID, // 계정이 너무 짧다.
            MAX
        }

        public eResultCode ResultCode { get; set; }
        public string Message { get; set; }

        public cPKTInitResult()
        {
            ResultCode = eResultCode.MAX;
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTInitResult;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
           
        }

        public override string MarshalDataNoEnc()
        {
            string strData = Common.Lib.cJSON._Serialize<cPKTInitResult>(this);
            return strData;
            //return JsonFx.Json.JsonWriter.Serialize(this);

        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTInitResult>(data);
        }
    }
}
