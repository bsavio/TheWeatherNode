using TheWeatherNode.Core.Models;

namespace TheWeatherNode.Core.Interfaces
{
    public interface IGeocodingService
    {
        Task<IEnumerable<Location>> SearchLocationsAsync(string query);
        Task<Location?> GetLocationAsync(string city, string? country = null);
    }
}
