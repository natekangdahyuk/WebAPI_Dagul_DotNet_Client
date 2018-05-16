using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientNetworkLib.Network
{
    public class cHTTPData
    {
        public enum eResultCode
        {
            SUCCEED,
            FAILURE,
            Close,
            MAX
        };

        public eResultCode ResultCode { get; set; }
        public string Data { get; set; }

        public cHTTPData()
        {
        }

        public cHTTPData(eResultCode resultCode, string data)
        {
            ResultCode = resultCode;
            Data = data;
        }
    }
}
