using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace Exercise_1
{

    public class Program
    {

        static async Task Main(string[] args)
        {
            
            string fileName = @"C:\Users\BenParr\source\repos\Exercise 1\ics_codes.csv";
            IcsConverter converter = new IcsConverter(fileName);
            var stations = converter.ReadFile();

            foreach (var s in stations)
            {
                Console.WriteLine($"s.StationName");
            }

            Console.WriteLine("Please select a station");
            var stationString = Console.ReadLine();
            stations.Select(s => s.IcsCode);

            var request = new JourneyRequest("1000077", "1000160", "NotSpecified", "Fastest");

            var httpClientService = new HttpClientService();
            var service = new JourneyService(httpClientService);
            var results = await service.GetJourney(request);

            foreach (var j in results.Journeys.SelectMany(i => i.Legs))
            {
                Console.WriteLine($"{j.ArrivalNaptan}, {j.DepatureNaptan}");
            }
            
        }
    }
}
