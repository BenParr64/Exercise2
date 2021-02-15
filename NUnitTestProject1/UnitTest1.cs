using Exercise_1;
using NUnit.Framework;

namespace NUnitTestProject1
{
    public class RequestTests
    {
        [Test]
        public async void JourneyService_GetJourney_ReturnsStringResponse()
        {
            //Arrange
            var property = new JourneyRequest()
            {
                JourneyStart = "1000077",
                JourneyEnd = "1000160",
                AccessOption = "NotSpecified",
                JourneyPref = "Fastest"
            };

            var sut = new JourneyService();

            //Act
            var result = await sut.GetJourney(property);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}