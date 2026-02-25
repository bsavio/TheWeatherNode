using TheWeatherNode.Core.Models;

namespace TheWeatherNode.Core.Interfaces
{
    internal interface ISevereWeatherService
    {
        Task<SevereWeatherData> GetSevereWeatherAsync(double latitude, double longitude);
        Task<IEnumerable<HourlyForecast>> GetDewPointDataAsync(double latitude, double longitude);
    }
}
