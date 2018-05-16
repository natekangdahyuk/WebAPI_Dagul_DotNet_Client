using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    /// <summary>
    /// 클라이언트가 게임 서버에 인증을 하고 플레이어 정보를 받는 작업을 하는 패킷
    /// </summary>
    public class cPKTIdentify : cWebPacketBase
    {
        public bool IsFirst { get; set; }         // 처음 입장(플레이어 정보를 생성하기 위해서 사용) 
        public Int32 CharacterIndex { get; set; } // 캐릭터 인덱스

        public cPKTIdentify()
        {
            IsFirst = false;
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTIdentify;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTIdentify>(data);
        }
    }
}
