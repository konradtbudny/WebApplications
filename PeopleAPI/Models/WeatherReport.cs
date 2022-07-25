using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleAPI.Models
{
    public class WeatherReport
    {
        private int temperature;
        public static List<WeatherReport> WeatherReports = new List<WeatherReport>();
        public int DayNumber { get; set; }
        public string Outlook { get; set; }
        public int Humidity { get; set; }
        public string Wind { get; set; }
        public string Decision { get; set; }
        public double NormalizedTemperature => Temperature / getMaxTemperature();
        public double NormalizedHumidity => Humidity / 100;
        
        public int Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public double NormalizedOutlook
        {
            get
            {
                if (Outlook == "Sunny")
                {
                    return 0;
                }
                else if (Outlook == "Overcast")
                {
                    return 0.5;
                }
                return 1;
            }
        }

        public double NormalizedWind
        {
            get
            {
                if (Outlook == "Weak")
                {
                    return 0;
                }
                return 1;
            }
        }

        public WeatherReport(int day, string outlook, int temperature, int humidity, string wind, string decision, bool addToExtension = true)
        {
            DayNumber = day;
            Outlook = outlook;
            Temperature = temperature;
            Humidity = humidity;
            Wind = wind;
            Decision = decision;
            if (addToExtension)
            {
                WeatherReports.Add(this);
            }
        }

        private int getMaxTemperature()
        {
            int maxTemp = int.MinValue;
            maxTemp = WeatherReports.Max(x => x.Temperature);
            return maxTemp;
        }

        public double getDistance(WeatherReport o)
        {
            return Math.Sqrt(Math.Pow(NormalizedTemperature - o.NormalizedTemperature, 2) +
                 Math.Pow(NormalizedHumidity - o.NormalizedHumidity, 2) +
                 Math.Pow(NormalizedOutlook - o.NormalizedOutlook, 2) +
                 Math.Pow(NormalizedWind - o.NormalizedWind, 2));
        }

        public override string ToString()
        {
            return "Outlook=" + Outlook + " Temperature=" + Temperature + " Humidity=" + Humidity + " Wind= " + Wind + " Decision=" + Decision;
        }
    }
}