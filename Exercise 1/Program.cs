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
            //Read file of ICS Codes and station names and return list of StationIcs Objects
            string fileName = @"C:\Users\BenParr\source\repos\Exercise 1\ics_codes.csv";
            IcsConverter converter = new IcsConverter(fileName);
            var stations = converter.ReadFile();

            //Print out station names to the console
            foreach (var s in stations)
            {
                Console.WriteLine($"{s.StationName}");
            }

            //Start station
            Console.WriteLine("Please select your start station");
            var startStationString = Console.ReadLine();
            var statStationObj = stations.Select(s => s).Where(s => s.StationName == startStationString).ToList();
            var startStationIcs = statStationObj[0].IcsCode;

            //End station
            Console.WriteLine("Please select your end station");
            var endStationString = Console.ReadLine();
            var endStationObj = stations.Select(s => s).Where(s => s.StationName == endStationString).ToList();
            var endStationIcs = endStationObj[0].IcsCode;

            //Confirm trip to console
            Console.WriteLine($"Your trip is from {startStationString} (station code = {startStationIcs}) to {endStationString} (station code = {endStationIcs})");

            var request = new JourneyRequest(startStationIcs.ToString(), endStationIcs.ToString(), "NotSpecified", "Fastest");

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
