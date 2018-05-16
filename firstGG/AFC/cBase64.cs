using System;
using System.Collections.Generic;
using System.Text;

namespace AFC
{
    /// <summary>
    /// Base64 유틸리티
    /// </summary>
    public static class cBase64
    {
        /// <summary>
        /// 일반 문자열을 Base64로 변환한다.
        /// </summary>
        /// <param name="data">일반 문자열</param>
        /// <param name="encoding">인코딩 타입</param>
        /// <returns>Base64로 변환된 문자열</returns>
        public static string Base64Encoding(string data, Encoding encoding = null)
        {
            if (null == encoding)
            {
                encoding = Encoding.UTF8;
            }

            return Base64Encoding(encoding.GetBytes(data), encoding);
        }

        /// <summary>
        /// 바이트 배열을 Base64로 변환한다.
        /// </summary>
        /// <param name="data">바이트 배열</param>
        /// <param name="encoding">이코딩 타입</param>
        /// <returns>Base64로 변환된 문자열</returns>
        public static string Base64Encoding(byte[] data, Encoding encoding = null)
        {
            if (null == encoding)
            {
                encoding = Encoding.UTF8;
            }

            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// Base64를 일반 문자열로 변환한다.
        /// </summary>
        /// <param name="data">Base64 텍스트</param>
        /// <param name="encoding">인코딩 타입</param>
        /// <returns>일반 문자열</returns>
        public static string Base64Decoding(string data, Encoding encoding = null)
        {
            if (null == encoding)
            {
                encoding = Encoding.UTF8;
            }

            byte[] arr = System.Convert.FromBase64String(data);
            return encoding.GetString(arr);
        }
    }
}
