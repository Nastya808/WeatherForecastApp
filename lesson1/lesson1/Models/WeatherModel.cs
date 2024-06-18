namespace WeatherForecastApp.Models
{
    public class WeatherModel
    {
        public string City { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public double Temperature { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double WindSpeed { get; set; }
        public List<HourlyForecast> HourlyForecasts { get; set; }

        public class HourlyForecast
        {
            public string Time { get; set; }
            public string IconUrl { get; set; }
            public string Description { get; set; }
            public double Temperature { get; set; }
            public double WindSpeed { get; set; }
        }
    }
}
