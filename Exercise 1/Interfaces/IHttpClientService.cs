using System.Threading.Tasks;

namespace Exercise_1.Interfaces
{
    public interface IHttpClientService
    {
        Task<string> GetRequestAsync(string url);
    }
}
