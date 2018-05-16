using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace AFC
{
    /// <summary>
    /// 웹 관련 유틸 모음
    /// </summary>
    public static class cWebUtility
    {
        private const string RequestParameterName = "param"; // 서버에 요청할때 사용하는 URI 뒤에 붙는 파라미터 항목 이름

        /// <summary>
        /// 웹서버에 요청을 한다.
        /// </summary>
        /// <param name="uri">주소</param>
        /// <param name="parameters">파라미터 문자열</param>
        /// <returns>결과</returns>
        public static string Request(string uri, string parameters = "")
        {
            StringBuilder param = new StringBuilder();
            param.Append(parameters);

            byte[] paramByte = UTF8Encoding.UTF8.GetBytes(param.ToString());

            // 계정이 없으면 생성한다.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = paramByte.Length;

            Stream dataParams = request.GetRequestStream();
            dataParams.Write(paramByte, 0, paramByte.Length);
            dataParams.Close();

            // 요청, 응답 받기
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // 응답 Stream 읽기
            Stream stReadData = response.GetResponseStream();
            StreamReader srReadData = new StreamReader(stReadData, Encoding.Default);

            // 응답 Stream -> 응답 String 변환
            return srReadData.ReadToEnd();
        }

        /// <summary>
        /// Request에 사용할 파라미터를 만든다.
        /// </summary>
        /// <param name="param">요청할 파라미터</param>
        /// <returns>구성된 파라미터 문자열</returns>
        public static string MakeParameter(string param)
        {
            return String.Format("{0}={1}", RequestParameterName, cBase64.Base64Encoding(param));
        }
    }
}
