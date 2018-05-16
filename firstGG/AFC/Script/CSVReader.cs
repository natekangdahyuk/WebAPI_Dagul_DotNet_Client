using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AFC.Script
{
    /// <summary>
    /// CSV 파일을 읽기 편하게 처리한다.
    /// </summary>
    public class cCSVReader
    {
        private cCSVParser CSVParser { get; set; }
        private Dictionary<string, int> CSVColumnNameMap { get; set; } // CSV의 컬럼명과 배열의 위치를 매핑(키: 컬럼명, 값: 배열 위치)
        private string[][] CSVData { get; set; }
        private int CurrentIndex { get; set; } // 파싱한 csv 배열에 대한 현재 인덱스(0번째는 컬럼명)

        /// <summary>
        /// 생성자
        /// </summary>
        public cCSVReader()
        {
            Initialize();
        }

        public cCSVReader(string fileName)
        {
            Initialize();
            Parse(fileName);
        }

        /// <summary>
        /// 초기화를 한다.
        /// </summary>
        public void Initialize()
        {
            CSVParser = new cCSVParser();
            CSVColumnNameMap = new Dictionary<string, int>();
            CSVData = null;
            CurrentIndex = 0;
        }

        /// <summary>
        /// csv 파일을 파싱한다.
        /// </summary>
        /// <param name="fileName">csv 파일 이름</param>
        /// <returns>성공유무</returns>
        public bool Parse(string fileName)
        {
            StreamReader file = new StreamReader(fileName, Encoding.Default);

            CSVData = CSVParser.Parse(file);
            if (CSVData.Length == 0)
            {
                return false;
            }

            // 컬럼 이름만 세팅한다.
            for (int loop1 = 0; loop1 < CSVData[0].Length; ++loop1)
            {
                if (CSVColumnNameMap.ContainsKey(CSVData[0][loop1]) == true)
                {
                    return false;
                }

                CSVColumnNameMap.Add(CSVData[0][loop1].Trim(), loop1);
            }

            return true;
        }

        /// <summary>
        /// 다음 컬럼으로 이동한다.
        /// </summary>
        /// <returns>성공유무</returns>
        public bool Next()
        {
            ++CurrentIndex;
            if (CSVData.Length <= CurrentIndex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 컬럼명에 대한 값을 반환한다.
        /// </summary>
        /// <param name="columnName">컬럼명</param>
        /// <returns>컬럼에 대한 값</returns>
        public string this[string columnName]
        {
            get
            {
                return AsString(columnName);
            }
        }

        /// <summary>
        /// 문자열을 반환한다.
        /// </summary>
        /// <returns>문자열</returns>
        public string ToDebugString()
        {
            //StringBuilder message = new StringBuilder();
            //foreach (string[] line in _CsvData)
            //{
            //    message.AppendFormat("ItemIndex: {0}, ItemNameKor: {1}, DescKor: {2}, Rate: {3}\r\n", line[0], line[1], line[2], line[3]);
            //}

            //return message.ToString();
            return "";
        }

        /// <summary>
        /// 컬럼 이름에 있는 데이터를 반환한다.
        /// </summary>
        /// <param name="columnName">컬럼 이름</param>
        /// <returns>데이터</returns>
        private string GetData(string columnName)
        {
            if (CurrentIndex == 0)
            {
                return null;
            }

            if (false == CSVColumnNameMap.ContainsKey(columnName))
            {
                return null;
            }

            int index = CSVColumnNameMap[columnName];
            return CSVData[CurrentIndex][index];
        }

        /// <summary>
        /// 컬럼 이름의 데이터를 string형 데이터로 반환한다.
        /// </summary>
        /// <param name="columnName">컬럼 이름</param>
        /// <param name="defaultValue">데이터가 없을 경우 디폴트 설정값</param>
        /// <returns>string형 데이터</returns>
        public string AsString(string columnName, string defaultValue = "")
        {
            string data = GetData(columnName);
            if (null == data)
            {
                return defaultValue;
            }

            return data;
        }

        /// <summary>
        /// 컬럼 이름에 있는 데이터를 반환한다.
        /// </summary>
        /// <typeparam name="T">변수 타입</typeparam>
        /// <param name="columnName">컬럼 이름</param>
        /// <returns>데이터</returns>
        public T GetData<T>(string columnName)
        {
            string data = GetData(columnName);
            if (null == data)
            {
                throw new Exception(String.Format("Cannot find column name (ColumnName: {0})", columnName));
            }

             return (T)Convert.ChangeType(data, typeof(T));
        }

        /// <summary>
        /// 컬럼 이름에 있는 데이터를 반환하며, 컬럼 이름이 잘못되었을 경우 defaultValue를 반환한다.
        /// </summary>
        /// <typeparam name="T">변수 타입</typeparam>
        /// <param name="columnName">컬럼 이름</param>
        /// <param name="defaultValue">컬럼 이름이 없을 경우 디폴트값</param>
        /// <param name="isStrict">컬럼 이름이 없을 경우 throw 유무</param>
        /// <returns>데이터</returns>
        public T GetData<T>(string columnName, bool isStrict, T defaultValue)
        {
            string data = GetData(columnName);
            if (null == data)
            {
                if (false == isStrict)
                {
                    return defaultValue;
                }
                else
                {
                    throw new Exception(String.Format("Cannot find column name (ColumnName: {0})", columnName));
                }
            }

            if (typeof(T) == typeof(int))
            {
                return (T)Convert.ChangeType(data, typeof(T));
            }

            return defaultValue;
        }
    }
}
