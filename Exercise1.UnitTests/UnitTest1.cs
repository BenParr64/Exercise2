using Exercise_1;
using Exercise1.UnitTests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Exercise1.UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public async Task JourneyService_GetJourney_ReturnsStringResponse()
        {
            //Arrange
            var property = new JourneyRequest()
            {
                JourneyStart = "1000077",
                JourneyEnd = "1000160",
                AccessOption = "NotSpecified",
                JourneyPref = "Fastest"
            };

            var httpClientServiceMock = new HttpClientServiceMock();

            var sut = new JourneyService(httpClientServiceMock);

            //Act
            var result = await sut.GetJourney(property);

            var expected = "Mock Response";

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, expected);
        }
    }
}
