using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    /// <summary>
    /// 클라이언트가 게임 서버에 인증을 하고 플레이어 정보를 받기는 작업을 하는 결과 패킷
    /// </summary>
    public class cPKTIdentifyResult : cJSONPacketBase
    {
        public enum eResultCode
        {
            SUCCEED,                       // 성공
            INVALID_ACCOUNT_ID,            // 잘못된 계정
            INVALID_AUTH_KEY,              // 잘못된 인증키
            NOT_DEFINED_DB_RESULT_CODE,    // 선언되지 않은 디비 결과 코드
            CANNOT_INITIALIZE_PLAYER_DATA, // 플레이어 데이터를 초기화할 수 없음
            INVALID_IDENTIFICATION,        // 잘못된 확인 정보(계정, 인증키 등이 잘못되었음)
            UNKNOWN,                       // 알 수 없는 오류
            MAX
        }

        public eResultCode ResultCode { get; set; } // 결과 코드

        public cPKTIdentifyResult()
        {
            ResultCode = eResultCode.MAX;
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTIdentifyResult;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTIdentifyResult>(data);
        }
    }
}
