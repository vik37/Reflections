namespace Reflections
{
    public class Weather
    {
        [ReportItem(1)]
        public string City { get; set; }
        [ReportItem(2)]
        public string Description { get; set; }
        [ReportItem(3, Heading = "Temperature", Units = "°C")]
        public double TemperatureCentigrade { get; set; }
        [ReportItem(4, Heading = "Rainfall", Units = " Inchess", Format = "N2")]
        public double RainfallInches { get; set; }

    }

    public static class WeatherData
    {
        public static IEnumerable<Weather> Weathers()
            => new List<Weather>()
            {
                new Weather{City = "London", Description = "Sunny Spells", TemperatureCentigrade = 19, RainfallInches = 0.20},
                new Weather{City = "Skopje", Description = "Very Hot", TemperatureCentigrade = 38, RainfallInches = 0.10},
                new Weather{City = "New York", Description = "Rains", TemperatureCentigrade = 15, RainfallInches = 0.60},
                new Weather{City = "Munich", Description = "Foggy", TemperatureCentigrade = 10, RainfallInches = 0.40},
                new Weather{City = "Moscow", Description = "Little Snow", TemperatureCentigrade = 2, RainfallInches = 0.50}
            };

    }
}
