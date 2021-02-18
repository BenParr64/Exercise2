using Exercise_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1.UnitTests
{
    [TestClass]
    public class UrlBuilderTests
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


        [TestMethod]
        [DataRow("100007a")]
        [DataRow("asdasff")]
        [DataRow("12dasff")]
        [DataRow("12d@@ff")]
        [DataRow("B£N")]
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_JourneyStartIsNotNumber_ThrowsJourneyRequestException(string data)
        {
            //Arrange
            Properties.JourneyStart = data;
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }

        [TestMethod]
        [DataRow("100007a")]
        [DataRow("10000^%")]
        [DataRow("gf0007a")]
        [DataRow("J@CK")]
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_JourneyEndIsNotNumber_ThrowsJourneyRequestException(string data)
        {
            //Arrange
            Properties.JourneyEnd = data;
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }

        [TestMethod]
        [DataRow("10000777")]
        [DataRow("10007")]
        [DataRow("10000777555555")]
        [DataRow("1235")]
        [DataRow("1333")]
        [DataRow("")]
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_JourneyStartLengthIsNot7_ThrowsJourneyRequestException(string data)
        {
            //Arrange
            Properties.JourneyStart = data;
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }

        [TestMethod]
        [DataRow("10000777")]
        [DataRow("10007")]
        [DataRow("10000777555555")]
        [DataRow("1235")]
        [DataRow("1333")]
        [DataRow("")]
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_JourneyEndLengthIsNot7_ThrowsJourneyRequestException(string data)
        {
            //Arrange
            Properties.JourneyStart = data;
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }

        [TestMethod]
        [DataRow("10000777")]
        [DataRow("NoTrains")]
        [DataRow("NoTravelling")]
        [DataRow("NoTravel")]
        [DataRow("NoMoving")]
        [DataRow("BoatsOnly")]
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_InvalidAccessOptions_ThrowsJourneyRequestException(string data)
        { 
            //Arrange
            Properties.AccessOption = data;
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }

        [TestMethod]
        [DataRow("10000777")]
        [DataRow("Really slow")]
        [DataRow("PrivateHelicopter")]
        [DataRow("Most Walking")]
        [DataRow("GoFast")]
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_InvalidJourneyPref_ThrowsJourneyRequestException(string data)
        {
            //Arrange
            Properties.JourneyPref = data;
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }
    }
}
