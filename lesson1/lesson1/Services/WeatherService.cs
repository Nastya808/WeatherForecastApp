using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["WeatherApiKey"];
        }

        public async Task<WeatherModel> GetWeatherAsync(string city)
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            var data = JObject.Parse(response);

            var weatherModel = new WeatherModel
            {
                City = data["name"].ToString(),
                Date = DateTime.Now.ToString("dd MMM yyyy"),
                Description = data["weather"][0]["description"].ToString(),
                IconUrl = $"http://openweathermap.org/img/w/{data["weather"][0]["icon"]}.png",
                Temperature = double.Parse(data["main"]["temp"].ToString()),
                MinTemperature = double.Parse(data["main"]["temp_min"].ToString()),
                MaxTemperature = double.Parse(data["main"]["temp_max"].ToString()),
                WindSpeed = double.Parse(data["wind"]["speed"].ToString()),
                HourlyForecasts = new List<WeatherModel.HourlyForecast>() // Populate with real data if available
            };

            return weatherModel;
        }
    }
}
