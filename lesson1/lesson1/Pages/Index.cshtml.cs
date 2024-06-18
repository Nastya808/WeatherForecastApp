using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherForecastApp.Models;
using WeatherForecastApp.Services;

namespace WeatherForecastApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WeatherService _weatherService;

        public IndexModel(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [BindProperty(SupportsGet = true)]
        public string City { get; set; }

        public WeatherModel Weather { get; set; }

        public async Task OnGet()
        {
            if (!string.IsNullOrEmpty(City))
            {
                Weather = await _weatherService.GetWeatherAsync(City);
            }
        }
    }
}
