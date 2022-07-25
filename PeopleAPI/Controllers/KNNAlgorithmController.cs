//https://localhost:44371/KNNAlgorithm/knn?outlook=Sunny&temperature=76&wind=Weak&humidity=76
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PeopleAPI.Models;

namespace PeopleAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KNNAlgorithmController : ControllerBase
    {
        private static readonly int[] days = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        private static readonly String[] outlook = new String[] { "Sunny", "Sunny", "Overcast", "Rain", "Rain", "Rain", "Overcast", "Sunny", "Sunny", "Rain", "Sunny", "Overcast", "Overcast", "Rain" };
        private static readonly int[] temperatures = new int[] { 85, 80, 83, 70, 68, 65, 64, 72, 69, 75, 75, 72, 81, 71 };
        private static readonly int[] humidity = new int[] { 85, 90, 78, 96, 80, 70, 65, 95, 70, 80, 70, 90, 75, 80 };
        private static readonly String[] wind = new String[] { "Weak", "Strong", "Weak", "Weak", "Weak", "Strong", "Strong", "Weak", "Weak", "Weak", "Strong", "Strong", "Weak", "Strong" };
        private static readonly String[] decision = new String[] { "No", "No", "Yes", "Yes", "Yes", "No", "Yes", "No", "Yes", "Yes", "Yes", "Yes", "Yes", "No" };
        static KNNAlgorithmController()
        {
            for (int i = 0; i < days.Length; i++)
            {
                new WeatherReport(days[i], outlook[i], temperatures[i], humidity[i], wind[i], decision[i]);
            }
        }

        [Route("Knn")]
        public string Knn([FromQuery] string outlook,
                          [FromQuery] int temperature,
                          [FromQuery]string wind,
                          [FromQuery]int humidity)
        {
            WeatherReport newReport = new WeatherReport(days.Length, outlook, temperature, humidity, wind, null, false);
            WeatherReport.WeatherReports.Sort((o1, o2) =>
            {
                double d1 = newReport.getDistance(o1);
                double d2 = newReport.getDistance(o2);
                return d1.CompareTo(d2);
            });
            int k = (int)Math.Sqrt(WeatherReport.WeatherReports.Count());
            if (k % 2 == 0)
            {
                k++;
            }
            int yesCount = 0, noCount = 0;
            for (int i = 0; i < k; i++)
            {
                if (WeatherReport.WeatherReports[i].Decision == ("Yes"))
                    yesCount++;
                if (WeatherReport.WeatherReports[i].Decision == ("No"))
                    noCount++;
            }
            if (yesCount >= noCount)
                newReport.Decision = "Yes";
            if (noCount > yesCount)
                newReport.Decision = "No";
            WeatherReport.WeatherReports.Add(newReport);
            string s = string.Join("\n", WeatherReport.WeatherReports);
            return s + "\nYes:" + yesCount + " No:" + noCount + "\n" + newReport.Decision;
        }
    }
}