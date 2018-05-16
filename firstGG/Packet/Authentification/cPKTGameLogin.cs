using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    public class cPKTGameLogin : cJSONPacketBase
    {
        public enum eDeviceType
        {
            PC,  // 데스크탑PC
            AOS, // 안드로이드OS
            IOS, // 애플 iOS
            MAX
        }

        public string AccountId { get; set; }
        public eDeviceType DeviceType { get; set; }

        public cPKTGameLogin()
        {
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTGameLogin;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTGameLogin>(data);
        }
    }
}
