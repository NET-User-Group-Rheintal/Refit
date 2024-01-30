using Refit;
using RefitAppShared;

namespace RefitApiSdk;
public interface IRefitApi
{
    [Get(ApiEndpoints.WeatherForecast.Get)]
    Task<WeatherForecast[]> GetWeatherForecastAsync();
}
