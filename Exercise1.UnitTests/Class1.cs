using Exercise_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1.UnitTests
{
    [TestClass]
    public class Class1
    {
        public JourneyRequest Properties = new JourneyRequest()
        {
            JourneyStart = "1000077",
            JourneyEnd = "1000160",
            AccessOption = "NotSpecified",
            JourneyPref = "Fastest"
        };

        [TestMethod]
        public void UrlBuilder_GetUrl_ReturnsStringUrl()
        {
            var urlBuilder = new UrlBuilder(Properties);
            var result = urlBuilder.Build();
            //Act
            var expected =
                $"https://appsvc-journeyplannermiddleware-test-01.azurewebsites.net/api/Journey/{Properties.JourneyStart}/to/{Properties.JourneyEnd}/?accessOption={Properties.AccessOption}&journeyPreference={Properties.JourneyPref}";

            //Assert 
            Assert.AreEqual(expected, result);
        }
    }
}
