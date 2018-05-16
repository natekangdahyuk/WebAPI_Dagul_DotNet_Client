using System;
using System.Collections.Generic;

using System.Text;


namespace Packet.DataType
{
    /// <summary>
    /// 아이템 타입
    /// </summary>
    public enum eItemType
    {
        ArcaneSword,
        PsychicBow,
        BlazePistol,
        MentalStaff,
        DualBlade,
        EnergyGauntlet,
        Helmet,
        Armor,
        Glove,
        Accessories1,
        Accessories2,
        Accessories3,
        Accessories4,
        Max
    }

    /// <summary>
    /// 스킬 타입
    /// </summary>
    public enum eSkillType
    {
        Passive, // 패시브
        Active,  // 액티브
        Max
    }
}
