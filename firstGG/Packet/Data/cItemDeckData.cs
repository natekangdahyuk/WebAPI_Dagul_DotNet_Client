using System;
using System.Collections.Generic;

using System.Text;

using Packet.DataType;

namespace Packet.Data
{
    /// <summary>
    /// 아이템 덱 데이터
    /// </summary>
    public class cItemDeckData
    {
        public Byte DeckId { get; set; }
        public eItemType Slot { get; set; }
        public Byte ItemStorageSlot { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public cItemDeckData()
        {
        }

        /// <summary>
        /// 초기화를 한다.
        /// </summary>
        public void Initialize()
        {
            DeckId = Byte.MaxValue;
            Slot = eItemType.Max;
            ItemStorageSlot = Byte.MaxValue;
        }
    }

    public class cItemDeckDataList : List<cItemDeckData>
    {
    }
}
