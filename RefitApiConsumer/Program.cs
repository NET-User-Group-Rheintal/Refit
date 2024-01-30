using Refit;
using Microsoft.Extensions.DependencyInjection;
using RefitApiSdk;

var services = new ServiceCollection();

// NuGet Refit.HttpClientFactory
services
    .AddHttpClient()
    .AddRefitClient<IRefitApi>()
    .ConfigureHttpClient(x =>
        x.BaseAddress = new Uri("https://localhost:7254"));

var provider = services.BuildServiceProvider();

var weatherForecastApi = provider.GetRequiredService<IRefitApi>();

var weathers = await weatherForecastApi.GetWeatherForecastAsync();

foreach (var weather in weathers)
{
    Console.WriteLine($"Date: {weather.Date} | {weather.TemperatureC} C | {weather.TemperatureF} F | Summary: {weather.Summary}");
}

Console.ReadLine();