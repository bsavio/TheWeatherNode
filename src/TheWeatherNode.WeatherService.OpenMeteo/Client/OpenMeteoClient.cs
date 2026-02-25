using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;


namespace TheWeatherNode.WeatherService.OpenMeteo.Client
{
    public class OpenMeteoClient : IOpenMeteoClient
    {
        private readonly HttpClient _httpClient;

        public OpenMeteoClient(OpenMeteoClientSettings openMeteoClientSettings, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(openMeteoClientSettings.BaseUrl);
        }

        public async Task<T?> GetAsync<T>(string endpoint, Dictionary<string, string> parameters)
        {
            var query = QueryString.Create(parameters);
            var response = await _httpClient.GetAsync($"{endpoint}{query}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }

}