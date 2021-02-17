using Exercise_1.Interfaces;
using System.Threading.Tasks;

namespace Exercise1.UnitTests.Mock
{
    public class HttpClientServiceMock : IHttpClientService
    {
        private const string MockResponse = "{'journeys':[{'tags':{'accessOptions':[],'journeyPreferences':['fastest']},'duration':27,'legs':[{'mode':'tube','departureNaptan':'940GZZLUEUS','arrivalNaptan':940GZZLULNB','lines':['NorSB'],'duration':11},{'mode':'tube','departureNaptan':'940GZZLULNB','arrivalNaptan':'940GZZLUNGW','lines':['JubSB'],'duration':9}]}],'errors':[]}";


        public Task<string> GetRequestAsync(string url)
        {
            var task = new Task<string>(() => "Mock Response");

            task.Start();

            return task;
        }
    }
}
