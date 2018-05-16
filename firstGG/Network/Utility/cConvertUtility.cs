using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Utility
{
    public static class cConvertUtil
    {
        /// <summary>
        /// 문자열 데이터를 바이너리 형식으로 변경한다.
        /// </summary>
        /// <param name="stringData">문자열 데이터</param>
        /// <returns>바이너리 데이터</returns>
        public static ArraySegment<byte> ConvertStringToBinary(string stringData)
        {
            return new ArraySegment<byte>(Encoding.UTF8.GetBytes(stringData));
        }
    }
}
