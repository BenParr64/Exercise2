using Exercise_1;
using Exercise1.UnitTests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

/*namespace Exercise1.UnitTests
{
    [TestClass]
    public class JourneyServiceTests
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
            /*
            
            var expected = new JourneyResult()
                {
                    Journeys = new List<Journey>()
                    {
                        new Journey()
                        {
                            Legs = new List<Leg>()
                            {
                                new Leg()
                                {

                                }
                            }
                        }
                    }
                };

            //Act
            var sut = new JourneyService(httpClientServiceMock);
            var result = await sut.GetJourney(Properties);

            //Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(result, expected);
        }
    }
}*/