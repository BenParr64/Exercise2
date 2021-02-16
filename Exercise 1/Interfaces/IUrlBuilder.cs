using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1.Interfaces
{
    interface IUrlBuilder
    {
        JourneyRequest Properties { get; set; }
        string Build();
    }
}
