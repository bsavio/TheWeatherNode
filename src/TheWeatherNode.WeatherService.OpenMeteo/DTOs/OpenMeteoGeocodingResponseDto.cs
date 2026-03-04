using System.Text.Json.Serialization;

namespace TheWeatherNode.WeatherService.OpenMeteo.DTOs
{
    public class OpenMeteoGeocodingResponseDto
    {
        [JsonPropertyName("results")]
        public IList<OpenMeteoGeocodingDto> Results { get; set; } = new List<OpenMeteoGeocodingDto>();
    }
}
