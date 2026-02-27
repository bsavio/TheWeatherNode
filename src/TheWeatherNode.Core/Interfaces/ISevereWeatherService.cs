using TheWeatherNode.Core.Models.Responses;

namespace TheWeatherNode.Core.Interfaces
{
    internal interface ISevereWeatherService
    {
        Task<SevereWeatherData> GetSevereWeatherAsync(double latitude, double longitude);
        Task<IEnumerable<HourlyForecast>> GetDewPointDataAsync(double latitude, double longitude);
    }
}
