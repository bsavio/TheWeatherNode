using System.Net;
using System.Net.Http.Json;
using TheWeatherNode.Core.Web;
using TheWeatherNode.WeatherService.OpenMeteo.Clients.Interfaces;
using TheWeatherNode.WeatherService.OpenMeteo.Clients.Settings;
using TheWeatherNode.WeatherService.OpenMeteo.DTOs;

namespace TheWeatherNode.WeatherService.OpenMeteo.Clients
{
    public class OpenMeteoGeocodingClient : IOpenMeteoGeocodingClient
    {
        private readonly HttpClient _httpClient;
        private readonly OpenMeteoGeocodingClientSettings _settings;

        public OpenMeteoGeocodingClient(HttpClient httpClient, OpenMeteoGeocodingClientSettings settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.BaseUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(settings.Timeout);
            this._settings = settings;
        }

        public async Task<IList<OpenMeteoGeocodingDto>> GetLocationsAsync(string search)
        {
            var parameters = new Dictionary<string, object>
            {
                { "name", search },
            };
            var query = HttpQueryBuilder.BuildQueryString(parameters);
            var response = await _httpClient.GetAsync($"{_settings.SearchEndPoint}?{query}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<OpenMeteoGeocodingResponseDto>() ?? throw new Exception("Failed to deserialize response.");
            return result.Results;
        }
    }
}
