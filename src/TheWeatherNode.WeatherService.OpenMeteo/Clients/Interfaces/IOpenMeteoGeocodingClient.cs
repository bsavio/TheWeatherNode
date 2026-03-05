using TheWeatherNode.WeatherService.OpenMeteo.DTOs;

namespace TheWeatherNode.WeatherService.OpenMeteo.Clients.Interfaces
{
    public interface IOpenMeteoGeocodingClient
    {
        Task<IList<OpenMeteoGeocodingDto>> GetLocationsAsync(string search);
    }
}
