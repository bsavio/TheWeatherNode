
namespace TheWeatherNode.WeatherService.OpenMeteo.Client
{
    public interface IOpenMeteoClient
    {
        Task<T> GetAsync<T>(string endpoint, Dictionary<string, object> parameters);
    }
}