using Exercise_1.Interfaces;
using System.Threading.Tasks;

namespace Exercise_1
{
    public class JourneyService
    {
        private readonly IHttpClientService _httpClientService;

        public JourneyService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<string> GetJourney(JourneyRequest properties)
        {
            var url = GetUrl
            (
                properties.JourneyStart,
                properties.JourneyEnd,
                properties.AccessOption,
                properties.JourneyPref 
            );

            var response = await _httpClientService.GetRequestAsync(url);

            return response;
        }

        public string GetUrl(string journeyStart, string journeyEnd, string accessOption, string journeyPref)
        {
            return 
                $"https://appsvc-journeyplannermiddleware-test-01.azurewebsites.net/api/Journey/{journeyStart}/to/{journeyEnd}/?accessOption={accessOption}&journeyPreference={journeyPref}";
        }
    }

}

