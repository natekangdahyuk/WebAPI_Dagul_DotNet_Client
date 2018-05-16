using System;
using System.Collections.Generic;

using System.Text;


namespace Packet.Data
{
    /// <summary>
    /// 아이템 스토리지 데이터
    /// </summary>
    public class cItemStorageData
    {
        public Byte Slot { get; set; }
        public Int32 ItemIndex { get; set; }
        public Byte ReinforcementLevel { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public cItemStorageData()
        {
        }

        /// <summary>
        /// 초기화를 한다.
        /// </summary>
        public void Initialize()
        {
            Slot = Byte.MaxValue;
            ItemIndex = 0;
            ReinforcementLevel = 0;
        }
    }

    public class cItemStorageDataList : List<cItemStorageData>
    {
    }
}
