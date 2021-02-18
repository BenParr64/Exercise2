using Exercise_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private readonly int journeyLength = 7;

        public string Build()
        {
            var journeyStart = Properties.JourneyStart;
            var journeyEnd = Properties.JourneyEnd;
            var accessOption = Properties.AccessOption;
            var journeyPref = Properties.JourneyPref;

            ValidateInputs();

            return
            $"https://appsvc-journeyplannermiddleware-test-01.azurewebsites.net/api/Journey/{journeyStart}/to/{journeyEnd}/?accessOption={accessOption}&journeyPreference={journeyPref}";
        }

        public void ValidateInputs()
        {
            if (!ValidateJourneyStartIsNumber())
                throw new JourneyRequestException("Journey Start is not a number");
            if (!ValidateJourneyEndIsNumber())
                throw new JourneyRequestException("Journey End is not a number");
            if (!ValidateJourneyStartLength())
                throw new JourneyRequestException($"Journey Start needs to be a length of {journeyLength}");
            if (!ValidateJourneyEndLength())
                throw new JourneyRequestException($"Journey End needs to be a length of {journeyLength}");
            if (!ValidateAccessOptions())
                throw new JourneyRequestException($"Invalid Access option selected");
            if (!ValidateJourneyPreference())
                throw new JourneyRequestException($"Invalid journey option selected");
        }

        public bool ValidateJourneyStartIsNumber()
        {
            return Regex.IsMatch(Properties.JourneyStart, @"^\d+$");
            //return (int.TryParse(Properties.JourneyStart, out int n)) && (int.TryParse(Properties.JourneyEnd, out int m));
        }

        public bool ValidateJourneyEndIsNumber()
        {
            return Regex.IsMatch(Properties.JourneyEnd, @"^\d+$");
        }

        public bool ValidateJourneyStartLength()
        {
            return Properties.JourneyStart.Length == journeyLength;
        }

        public bool ValidateJourneyEndLength()
        {
            return Properties.JourneyEnd.Length == journeyLength;
        }

        public bool ValidateAccessOptions()
        {
            return
            (
                Properties.AccessOption.ToLower() == "NotSpecified".ToLower() ||
                Properties.AccessOption.ToLower() == "NoSolidStairs".ToLower() ||
                Properties.AccessOption.ToLower() == "NoEscalators".ToLower() ||
                Properties.AccessOption.ToLower() == "NoElevators".ToLower() ||
                Properties.AccessOption.ToLower() == "StepFreeToPlatform".ToLower() ||
                Properties.AccessOption.ToLower() == "StepFreeToVehicle".ToLower() ||
                Properties.AccessOption == ""
            );
        }

        public bool ValidateJourneyPreference()
        {
            return
            (
                Properties.JourneyPref.ToLower() == "NotSpecified".ToLower() ||
                Properties.JourneyPref.ToLower() == "LeastInterchanges".ToLower() ||
                Properties.JourneyPref.ToLower() == "Fastest".ToLower() ||
                Properties.JourneyPref.ToLower() == "LeastWalking".ToLower() ||
                Properties.JourneyPref == ""
             );
        }
    }
}
