using API.Internal.Weather.ViewModels;

namespace API.Internal.Weather
{
    public static class Endpoints
    {
        public static void RegisterWeatherEndpoints(this IEndpointRouteBuilder routes)
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            var weather = routes
                .MapGroup("weather")
                .WithTags("weather");
            weather.MapGet($"{Constants.Internal}/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();
        }
    }
}
