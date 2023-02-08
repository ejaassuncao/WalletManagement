using Microsoft.AspNetCore.Http.HttpResults;

namespace Presentation.Api.ViewModel
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
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