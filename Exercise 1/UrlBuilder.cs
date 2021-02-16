using Exercise_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            if (!ValidateInputs())
            {
                throw new JourneyRequestException("You have enterd invalid inputs");
            } 


            var journeyStart = Properties.JourneyStart;
            var journeyEnd = Properties.JourneyEnd;
            var accessOption = Properties.AccessOption;
            var journeyPref = Properties.JourneyPref;

                return
                $"https://appsvc-journeyplannermiddleware-test-01.azurewebsites.net/api/Journey/{journeyStart}/to/{journeyEnd}/?accessOption={accessOption}&journeyPreference={journeyPref}";
        }

        public bool ValidateInputs()
        {
            return (ValidateJourneyStartIsNumber() && ValidateJourneyEndIsNumber() && ValidateJourneyLength());
            
        }

        private bool ValidateJourneyStartIsNumber()
        {
            return Regex.IsMatch(Properties.JourneyStart, @"^\d+$");
            //return (int.TryParse(Properties.JourneyStart, out int n)) && (int.TryParse(Properties.JourneyEnd, out int m));
        }

        private bool ValidateJourneyEndIsNumber()
        {
            return Regex.IsMatch(Properties.JourneyEnd, @"^\d+$");
        }

        private bool ValidateJourneyLength()
        {
            return Properties.JourneyEnd.Length == 7 && Properties.JourneyStart.Length == 7;
        }
    }
}
