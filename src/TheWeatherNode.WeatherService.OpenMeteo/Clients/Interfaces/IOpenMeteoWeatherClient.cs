namespace TheWeatherNode.WeatherService.OpenMeteo.Clients.Interfaces
{
    public interface IOpenMeteoWeatherClient
    {
        Task<T> GetForcastAsync<T>(Dictionary<string, object> parameters);
    }
}