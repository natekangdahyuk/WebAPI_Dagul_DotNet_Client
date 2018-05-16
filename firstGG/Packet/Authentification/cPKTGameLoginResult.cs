using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;

namespace Packet
{
    public class cPKTGameLoginResult : cJSONPacketBase
    {
        public enum eResultCode
        {
            SUCCEED,                    // 성공
            INVALID_ACCOUNT_ID,         // 잘못된 계정
            ACCOUNT_CREATION_FAILURE,   // 계정을 생성 실패
            BANNED_ACCOUNT,             // 접속 금지된 계정
            LOW_CLIENT_VERSION,         // 클라이언트 버전이 낮음
            INVALID_LOGIN_TYPE,         // 잘못된 로그인 타입
            NOT_DEFINED_DB_RESULT_CODE, // 선언되어 있지 않은 결과 코드
            UNKNOWN,                    // 알 수 없는 오류
            MAX
        }

        public eResultCode ResultCode { get; set; }
        public bool IsFirst { get; set; }
        public string GameServerIP { get; set; }
        public string AuthKey { get; set; }

        public cPKTGameLoginResult()
        {
            ResultCode = eResultCode.MAX;
            IsFirst = false;
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTGameLoginResult;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTGameLoginResult>(data);
        }
    }
}
