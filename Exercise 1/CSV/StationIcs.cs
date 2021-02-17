using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1.CSV
{
    public class StationIcs
    {
        public int IcsCode { get; set; }
        public string StationName { get; set; }

        public StationIcs(int icsCode, string stationName)
        {
            IcsCode = icsCode;
            StationName = stationName;
        }
    }

}
