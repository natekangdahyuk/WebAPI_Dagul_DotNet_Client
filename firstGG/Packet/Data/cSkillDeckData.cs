using System;
using System.Collections.Generic;

using System.Text;


using Packet.DataType;

namespace Packet.Data
{
    /// <summary>
    /// 스킬 덱 데이터
    /// </summary>
    public class cSkillDeckData
    {
        public Byte DeckId { get; set; }
        public eSkillType SkillType { get; set; }
        public Byte Slot { get; set; }
        public Byte SkillStorage_Slot { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public cSkillDeckData()
        {
        }

        /// <summary>
        /// 초기화를 한다.
        /// </summary>
        public void Initialize()
        {
            DeckId = Byte.MaxValue;
            SkillType = eSkillType.Max;
            Slot = Byte.MaxValue;
            SkillStorage_Slot = Byte.MaxValue;
        }
    }

    public class cSkillDeckDataList : List<cSkillDeckData>
    {
    }
}
