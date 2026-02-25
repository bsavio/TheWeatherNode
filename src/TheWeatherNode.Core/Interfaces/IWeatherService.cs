using TheWeatherNode.Core.Models;

namespace TheWeatherNode.Core.Interfaces
{
    public interface IWeatherService
    {
        Task<CurrentWeather> GetCurrentWeatherAsync(double latitude, double longitude);
        Task<IEnumerable<HourlyForecast>> GetHourlyForecastAsync(double latitude, double longitude, int days = 7);
    }
}
