using Microsoft.AspNetCore.Mvc;
using Presentation.Api.ViewModel;

namespace Presentation.Api.Controllers
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
    }

    public static class WeatherForecastEndpoints
    {
        public static void MapWeatherForecastEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/WeatherForecast");

            group.MapGet("/", () =>
            {
                return new[] { new WeatherForecast() };
            })
            .WithName("GetAllWeatherForecasts");

            group.MapGet("/{id}", (int id) =>
            {
                //return new WeatherForecast { ID = id };
            })
            .WithName("GetWeatherForecastById");

            group.MapPut("/{id}", (int id, WeatherForecast input) =>
            {
                return TypedResults.NoContent();
            })
            .WithName("UpdateWeatherForecast");

            group.MapPost("/", (WeatherForecast model) =>
            {
                //return TypedResults.Created($"/WeatherForecasts/{model.ID}", model);
            })
            .WithName("CreateWeatherForecast");

            group.MapDelete("/{id}", (int id) =>
            {
                //return TypedResults.Ok(new WeatherForecast { ID = id });
            })
            .WithName("DeleteWeatherForecast");
        }
    }
}