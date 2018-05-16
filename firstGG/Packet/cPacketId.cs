using System;
using System.Collections.Generic;

using System.Text;


namespace Packet
{
    public enum ePacketId
    {
        cPKTChatLogin,
        cPKTChatLoginResult,
        cPKTChatRoomChange,
        cPKTChatRoomChangeResult,
        cPKTSay,
        cPKTSayResult,
        cPKTSayNotify,
        cPKTGameLogin,
        cPKTGameLoginResult,
        cPKTIdentify,
        cPKTIdentifyResult,
        cPKTAccountLoad,
        cPKTAccountLoadResult,

        cPKTInit = 13,
        cPKTInitResult = 14,
        Max
    }
}
