using Exercise_1.Interfaces;
using System.Threading.Tasks;

namespace Exercise1.UnitTests.Mock
{
    public class HttpClientServiceMock : IHttpClientService
    {
        public Task<string> GetRequestAsync(string url)
        {
            var task = new Task<string>(() => "Mock Response");

            task.Start();

            return task;
        }
    }
}
