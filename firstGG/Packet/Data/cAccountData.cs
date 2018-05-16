using System;
using System.Collections.Generic;

using System.Text;


namespace Packet.Data
{
    /// <summary>
    /// 계정 데이터
    /// </summary>
    public class cAccountData
    {
        public string AccountId { get; set; }
        public Int64 AccountSN { get; set; }
        public Int32 CharacterIndex { get; set; }
        public Byte CharacterLevel { get; set; }
        public UInt32 CharacterExp { get; set; }
        public UInt32 Gold { get; set; }
        public UInt32 Cash { get; set; }
        public UInt16 FriendshipPoint { get; set; }
        public UInt16 ArenaPoint { get; set; }
        public UInt16 GuildPoint { get; set; }
        public UInt16 AdventurePower { get; set; }
        public Byte DailyDungeonPower { get; set; }
        public Byte InfiniteTowerPower { get; set; }
        public UInt16 ArenaPower { get; set; }
        public Byte GuildRacePower { get; set; }
        public Byte GuildMatchUpPower { get; set; }
        public Byte WeeklyMazePower { get; set; }
        public Byte EventDungeonPower { get; set; }
        public Byte SkillStorageCount { get; set; }
        public Byte ItemStorageCount { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public cAccountData()
        {
        }

        /// <summary>
        /// 초기화를 한다.
        /// </summary>
        public void Initialize()
        {
            AccountId = "";
            AccountSN = 0;
            CharacterIndex = 0;
            CharacterLevel = 0;
            CharacterExp = 0;
            Gold = 0;
            Cash = 0;
            AdventurePower = 0;
            DailyDungeonPower = 0;
            InfiniteTowerPower = 0;
            ArenaPower = 0;
            GuildRacePower = 0;
            GuildMatchUpPower = 0;
            WeeklyMazePower = 0;
            EventDungeonPower = 0;
            FriendshipPoint = 0;
            ArenaPoint = 0;
            GuildPoint = 0;
            SkillStorageCount = 0;
            ItemStorageCount = 0;
        }
    }
}
