using Exercise_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    public class UrlBuilder : IUrlBuilder
    {
        public JourneyRequest Properties { get; set; }

        public UrlBuilder(JourneyRequest properties)
        {
            Properties = properties;
        }

        public string Build()
        {

            var journeyStart = Properties.JourneyStart;
            var journeyEnd = Properties.JourneyEnd;
            var accessOption = Properties.AccessOption;
            var journeyPref = Properties.JourneyPref;
            
                return
                $"https://appsvc-journeyplannermiddleware-test-01.azurewebsites.net/api/Journey/{journeyStart}/to/{journeyEnd}/?accessOption={accessOption}&journeyPreference={journeyPref}";
        }
    }
}
