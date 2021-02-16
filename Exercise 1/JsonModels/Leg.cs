using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{

    public class Leg
        {
            public string Mode { get; set; }
            public string DepatureNaptan { get; set; }
            public string ArrivalNaptan { get; set; }
            public List<string> Lines { get; set; }
            public int Duration { get; set; }
        }
}

