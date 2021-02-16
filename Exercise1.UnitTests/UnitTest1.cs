using Exercise_1;
using Exercise1.UnitTests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Exercise1.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        public JourneyRequest Properties = new JourneyRequest()
        {
            JourneyStart = "1000077",
            JourneyEnd = "1000160",
            AccessOption = "NotSpecified",
            JourneyPref = "Fastest"
        };

        [TestMethod]
        public async Task JourneyService_GetJourney_ReturnsStringResponse()
        {
            //Arrange
            var httpClientServiceMock = new HttpClientServiceMock();
            var sut = new JourneyService(httpClientServiceMock);

            //Act
            var result = await sut.GetJourney(Properties);
            var expected = "Mock Response";

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public async Task JourneyService_GetUrl_ReturnsStringUrl()
        {
            var httpClientService = new HttpClientService();
            var sut = new JourneyService(httpClientService);
            await sut.GetJourney(Properties);
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