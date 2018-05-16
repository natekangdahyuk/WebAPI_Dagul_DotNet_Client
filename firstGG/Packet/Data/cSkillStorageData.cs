using System;
using System.Collections.Generic;

using System.Text;


namespace Packet.Data
{
    /// <summary>
    /// 스킬 스토리지 데이터
    /// </summary>
    public class cSkillStorageData
    {
        public Byte Slot { get; set; }                 // 스킬 슬롯
        public Int32 SkillIndex { get; set; }          // 스킬 인덱스
        public Byte ReinforcementLevel { get; set; }   // 강화 레벨
        public bool TranscendanceEnabled { get; set; } // 초월 유무

        /// <summary>
        /// 성공 유무
        /// </summary>
        public cSkillStorageData()
        {
        }

        /// <summary>
        /// 초기화를한다.
        /// </summary>
        public void Initialize()
        {
            Slot = Byte.MaxValue;
            SkillIndex = 0;
            ReinforcementLevel = 0;
            TranscendanceEnabled = false;
        }
    }

    public class cSkillStorageDataList : List<cSkillStorageData>
    {
    }
}
