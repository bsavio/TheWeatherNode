using System.Net.Http.Json;
using TheWeatherNode.Core.Web;


namespace TheWeatherNode.WeatherService.OpenMeteo.Client
{
    public class OpenMeteoClient : IOpenMeteoClient
    {
        private readonly HttpClient _httpClient;

        public OpenMeteoClient(HttpClient httpClient, OpenMeteoClientSettings settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.BaseUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(settings.Timeout);
        }

        public async Task<T> GetAsync<T>(string endpoint, Dictionary<string, object> parameters)
        {
            var query = HttpQueryBuilder.BuildQueryString(parameters);
            var response = await _httpClient.GetAsync($"{endpoint}?{query}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<T>() ?? throw new Exception("Failed to deserialize response.");
            return result;
        }
    }

}