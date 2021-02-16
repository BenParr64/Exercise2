using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exercise_1
{


    public class Program
    {

        static async Task Main(string[] args)
        {
            var request = new JourneyRequest("", "", "", "");

            var httpClientService = new HttpClientService();
            var service = new JourneyService(httpClientService);

            Console.WriteLine(service);
            Console.WriteLine(request);
            Console.ReadLine();
        }
        
    }
}
