using Microsoft.Extensions.Logging;
using TheWeatherNode.Core.Interfaces;
using TheWeatherNode.Core.Models.Responses;
using TheWeatherNode.WeatherService.OpenMeteo.Client;
using TheWeatherNode.WeatherService.OpenMeteo.Client.Interfaces;

namespace TheWeatherNode.WeatherService.OpenMeteo.Services
{
    public class OpenMeteoGeocodingService : IGeocodingService
    {
        private readonly IOpenMeteoGeocodingClient _openMeteoGeocodingClient;
        private readonly ILogger<OpenMeteoGeocodingService> _logger;

        public OpenMeteoGeocodingService(IOpenMeteoGeocodingClient openMeteoGeocodingClient, ILogger<OpenMeteoGeocodingService> logger)
        {
            _openMeteoGeocodingClient = openMeteoGeocodingClient;
            _logger = logger;
        }


        public async Task<Location?> GetLocationAsync(string city, string? country = null)
        {
            var locations = await SearchLocationsAsync(country is not null ? $"{city}, {country}" : city);
            return locations.FirstOrDefault(loc => string.Equals(loc.Name, city, StringComparison.OrdinalIgnoreCase) &&
                                                 (country is null || string.Equals(loc.Country, country, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<IEnumerable<Location>> SearchLocationsAsync(string query)
        {
            _logger.LogDebug("Searching for locations with query: {Query}", query);
            var locations = await _openMeteoGeocodingClient.GetLocationsAsync(query);
            _logger.LogDebug("Received {Count} locations from OpenMeteoGeocodingClient", locations.Count());
            return locations.Select(loc => new Location
            {
                Name = loc.Name ?? string.Empty,
                Latitude = loc.Latitude,
                Longitude = loc.Longitude,
                Country = loc.Country ?? string.Empty,
                CountryCode = loc.CountryCode ?? string.Empty,
                PostalCodes = loc.Postcodes ?? Enumerable.Empty<string>(),
                State = loc.Admin1 ?? string.Empty,
                Population = loc.Population,
                Timezone = loc.Timezone ?? string.Empty
            });
        }
    }
}
