//using UnityEngine;
//using System;
//using System.IO;
//using System.Text;
//using System.Collections;
//using System.Collections.Generic;

//namespace AFC
//{
//    public abstract class CSVLoader<T> where T : class
//    {
//        protected Dictionary<int, T> _dictionary = new Dictionary<int, T>();

//        public CSVLoader(string name)
//        {
//            string _path = "Data/CSVData/"; //Resources 밑 데이터경로

//            TextAsset _txtFile = Resources.Load(_path + name, typeof(TextAsset)) as TextAsset;
//            StringReader reader = new StringReader(_txtFile.text);
//            string _info = reader.ReadLine();

//            string _strLine;
//            _dictionary.Clear();
//            while ((_strLine = reader.ReadLine()) != null)
//            {
//                string[] _stat = _strLine.Split(',');
//                SetData(ref _stat);
//            }
//        }

//        abstract public void SetData(ref string[] _stat);

//        public T GetData(int ID)
//        {
//            T infoData;
//            if (_dictionary.TryGetValue(ID, out infoData))
//                return infoData;
//            else
//                return null;
//        }

//        protected void TestInfoData(string[] inputDataString)
//        {
//            string[] stat = inputDataString;

//            for (int forint = 0; forint < stat.Length; forint++)
//            {
//                // 1. 빈공간이 있는지 확인한다
//                if (stat[forint].Length <= 0)
//                    stat[forint] = "0";
//            }
//        }
//    }
//}