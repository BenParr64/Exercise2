using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Xunit.Sdk;

namespace Exercise_1
{
    [TestClass]
    public class JourneyServiceTests
    {
        //Class, Method, ReturnValue
        [TestMethod]
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
