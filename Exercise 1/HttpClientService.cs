using Exercise_1.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exercise_1
{

    public class HttpClientService : IHttpClientService
    {
        HttpClient client = new HttpClient();

        
        public async Task<string> GetRequestAsync(string url)
        {
            var response = await client.GetStringAsync(url);

            return response;  
        }
    }
}
