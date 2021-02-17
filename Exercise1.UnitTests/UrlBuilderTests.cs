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
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_JourneyStartIsNotNumber_ThrowsJourneyRequestException()
        {
            //Arrange
            Properties.JourneyStart = "100007a";
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }

        [TestMethod]
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_JourneyEndIsNotNumber_ThrowsJourneyRequestException()
        {
            //Arrange
            Properties.JourneyEnd = "100016a";
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }

        [TestMethod]
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_JourneyStartLengthIsNot7_ThrowsJourneyRequestException()
        {
            //Arrange
            Properties.JourneyStart = "10000777";
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }

        [TestMethod]
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_JourneyEndLengthIsNot7_ThrowsJourneyRequestException()
        {
            //Arrange
            Properties.JourneyStart = "10001600";
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }

        [TestMethod]
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_JourneyPrefIsString_ThrowsJourneyRequestException()
        {
            //Arrange
            Properties.JourneyPref = "Fastest";
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }

        [TestMethod]
        [ExpectedException(typeof(JourneyRequestException))]
        public void UrlBuilder_AccessOptionIsString_ThrowsJourneyRequestException()
        {
            //Arrange
            Properties.AccessOption = "NotSpecified";
            var builder = new UrlBuilder(Properties);

            //Act => Assert
            builder.Build();
        }
    }
}
