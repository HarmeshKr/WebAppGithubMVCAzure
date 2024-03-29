using Microsoft.AspNetCore.Mvc;

namespace WebAppGithubMVCAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("colors")]
        public IActionResult Colors()
        {
            return Ok(new string[] {"red","green","blue","orange","gold"});
        }

        [HttpGet("days")]
        public IActionResult Days()
        {
            return Ok(new string[] { "sunday","monday","tuesday" });
        }

        [HttpGet("seasons")]
        public IActionResult Seasons()
        {
            return Ok(new string[] { "Winter", "Spring", "Summer","Rainy Season","Autumn" });
        }
    }
}
