using System.Net.Http.Json;
using TheWeatherNode.Core.Web;
using TheWeatherNode.WeatherService.OpenMeteo.Client.Interfaces;
using TheWeatherNode.WeatherService.OpenMeteo.Client.Settings;


namespace TheWeatherNode.WeatherService.OpenMeteo.Client
{
    public class OpenMeteoWeatherClient : IOpenMeteoWeatherClient
    {
        private readonly HttpClient _httpClient;
        private readonly OpenMeteoWeatherClientSettings _settings;

        public OpenMeteoWeatherClient(HttpClient httpClient, OpenMeteoWeatherClientSettings settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.BaseUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(settings.Timeout);
            _settings = settings;
        }

        public async Task<T> GetForcastAsync<T>(Dictionary<string, object> parameters)
        {
            var query = HttpQueryBuilder.BuildQueryString(parameters);
            var response = await _httpClient.GetAsync($"{_settings.ForcastEndPoint}?{query}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<T>() ?? throw new Exception("Failed to deserialize response.");
            return result;
        }
    }

}