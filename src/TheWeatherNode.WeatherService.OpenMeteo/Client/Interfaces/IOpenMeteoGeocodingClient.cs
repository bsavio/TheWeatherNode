using TheWeatherNode.WeatherService.OpenMeteo.DTOs;

namespace TheWeatherNode.WeatherService.OpenMeteo.Client.Interfaces
{
    public interface IOpenMeteoGeocodingClient
    {
        Task<IList<OpenMeteoGeocodingDto>> GetLocationsAsync(string search);
    }
}
