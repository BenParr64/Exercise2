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
            var urlBuilder = new UrlBuilder(properties);
            var url = urlBuilder.Build();

            var response = await _httpClientService.GetRequestAsync(url);

            return response;
        }
    }
}

