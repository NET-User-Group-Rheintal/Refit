namespace RefitAppShared;
public class ApiEndpoints
{
    private const string ApiBase = "";

    public static class WeatherForecast
    {
        public const string Get = $"{ApiBase}/weatherforecast";
    }
}
