using Exercise_1.CSV;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Exercise_1
{
    class IcsConverter
    {
        public string FileName { get; set; }
        public List<StationIcs> Stations;
        public IcsConverter(string fileName)
        {
            FileName = fileName;
        }
        public List<StationIcs> ReadFile()
        {
            Stations = new List<StationIcs>();
            StreamReader sr = new StreamReader(FileName);
            StringBuilder sb = new StringBuilder();
            string s;
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                string[] str = s.Split(',');
                string str1 = str[0].ToString();
                if (!str1.Equals("ICS Code"))
                {
                    Stations.Add(new StationIcs(Int32.Parse(str[0]), str[1].ToString()));
                }
            }
            return Stations;
        }
    }
}
