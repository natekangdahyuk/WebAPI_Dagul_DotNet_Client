using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    public class cPKTChatRoomChangeResult : cJSONPacketBase
    {
        public enum eResultCode
        {
            SUCCEED,                 // 성공
            CANNOT_CHANGE_CHAT_ROOM, // 채팅방을 변경할 수 없음
            MAX
        }

        private eResultCode _ResultCode = eResultCode.MAX;

        public eResultCode ResultCode { get { return _ResultCode; } set { _ResultCode = value; } }

        public cPKTChatRoomChangeResult()
        {
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTChatRoomChangeResult;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTChatRoomChangeResult>(data);
        }
    }
}
