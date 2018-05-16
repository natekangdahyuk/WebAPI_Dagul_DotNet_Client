using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    public class cPKTChatRoomChange : cWebPacketBase
    {
        public int NewChatRoomIndex; // 새로운 채팅방 인덱스

        public cPKTChatRoomChange()
        {
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTChatRoomChange;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTChatRoomChange>(data);
        }
    }
}
