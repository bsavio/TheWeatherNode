namespace TheWeatherNode.WeatherService.OpenMeteo.Client.Interfaces
{
    public interface IOpenMeteoWeatherClient
    {
        Task<T> GetForcastAsync<T>(Dictionary<string, object> parameters);
    }
}