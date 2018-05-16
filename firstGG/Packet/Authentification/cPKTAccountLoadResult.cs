using System;
using System.Collections.Generic;

using System.Text;

using Packet.Base;
using Packet.Data;

namespace Packet
{
    public class cPKTAccountLoadResult : cJSONPacketBase
    {
        /// <summary>
        /// 결과 코드S
        /// </summary>
        public enum eResultCode
        {
            SUCCEED,          // 성공
            NO_DATA,          // 데이터가 없음
            CANNOT_FIND_PEER, // 피어를 찾지 못함
            MAX
        }

        public eResultCode ResultCode { get; set; }                     // 결과 코드
        public cAccountData AccountData { get; set; }                   // 계정 데이터
        public cItemStorageDataList ItemStorageDataList { get; set; }   // 아이템 스토리지 데이터 리스트
        public cItemDeckDataList ItemDeckDataList { get; set; }         // 아이템 덱 데이터
        public cSkillStorageDataList SkillStorageDataList { get; set; } // 스킬 스토리지 데이터
        public cSkillDeckDataList SkillDeckDataList { get; set; }       // 스킬 덱 데이터

        public cPKTAccountLoadResult()
        {
            ResultCode = eResultCode.MAX;
            AccountData = new cAccountData();
            ItemStorageDataList = new cItemStorageDataList();
            ItemDeckDataList = new cItemDeckDataList();
            SkillStorageDataList = new cSkillStorageDataList();
            SkillDeckDataList = new cSkillDeckDataList();
        }

        public override ePacketId GetPacketId()
        {
            return ePacketId.cPKTAccountLoadResult;
        }

        public override string Marshal()
        {
            return JsonFx.Json.JsonWriter.Serialize(this);
        }

        public override IPacket Unmarshal(string data)
        {
            return (IPacket)JsonFx.Json.JsonReader.Deserialize<cPKTAccountLoadResult>(data);
        }
    }
}
