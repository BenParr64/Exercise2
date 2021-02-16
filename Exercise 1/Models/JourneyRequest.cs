using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    public class JourneyRequest
    {
        public string JourneyStart { get; set; }
        public string JourneyEnd { get; set; }
        public string AccessOption { get; set; }
        public string JourneyPref { get; set; }

        public JourneyRequest(string journeyStart,string journeyEnd, string accessOption, string journeyPref)
        {
            JourneyStart = journeyStart;
            JourneyEnd = journeyEnd;
            AccessOption = accessOption;
            JourneyPref = journeyPref;
        }

        public JourneyRequest()
        {

        }

    }
}
