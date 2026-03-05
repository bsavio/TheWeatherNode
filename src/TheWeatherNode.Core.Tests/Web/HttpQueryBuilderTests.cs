using TheWeatherNode.Core.Web;
using Xunit;

namespace TheWeatherNode.Core.Tests.Web
{
    /// <summary>
    /// Unit tests for the <see cref="HttpQueryBuilder"/> class.
    /// </summary>
    public class HttpQueryBuilderTests
    {
        #region Empty Dictionary Tests

        [Fact]
        public void BuildQueryString_WithEmptyDictionary_ReturnsEmptyString()
        {
            // Arrange
            var parameters = new Dictionary<string, object>();

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Empty(result);
        }

        #endregion

        #region Single Parameter Tests

        [Fact]
        public void BuildQueryString_WithSingleStringParameter_ReturnsCorrectFormat()
        {
            // Arrange
            var parameters = new Dictionary<string, object> { { "key", "value" } };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Equal("key=value", result);
        }

        [Fact]
        public void BuildQueryString_WithSingleIntegerParameter_ReturnsCorrectFormat()
        {
            // Arrange
            var parameters = new Dictionary<string, object> { { "count", 10 } };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Equal("count=10", result);
        }

        [Fact]
        public void BuildQueryString_WithSingleDoubleParameter_ReturnsCorrectFormat()
        {
            // Arrange
            var parameters = new Dictionary<string, object> { { "latitude", 40.7128 } };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Equal("latitude=40.7128", result);
        }

        [Fact]
        public void BuildQueryString_WithSingleBooleanParameter_ReturnsCorrectFormat()
        {
            // Arrange
            var parameters = new Dictionary<string, object> { { "enabled", true } };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Equal("enabled=True", result);
        }

        #endregion

        #region Multiple Parameters Tests

        [Fact]
        public void BuildQueryString_WithMultipleStringParameters_ReturnsCorrectFormat()
        {
            // Arrange
            var parameters = new Dictionary<string, object>
            {
                { "key1", "value1" },
                { "key2", "value2" },
                { "key3", "value3" }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Contains("key1=value1", result);
            Assert.Contains("key2=value2", result);
            Assert.Contains("key3=value3", result);
            Assert.Contains("&", result);
        }

        [Fact]
        public void BuildQueryString_WithMixedTypeParameters_ReturnsCorrectFormat()
        {
            // Arrange
            var parameters = new Dictionary<string, object>
            {
                { "name", "John" },
                { "age", 30 },
                { "height", 5.9 }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Contains("name=John", result);
            Assert.Contains("age=30", result);
            Assert.Contains("height=5.9", result);
        }

        #endregion

        #region List Parameter Tests

        [Fact]
        public void BuildQueryString_WithSingleListParameter_ReturnsCommaSeparatedValues()
        {
            // Arrange
            var parameters = new Dictionary<string, object>
            {
                { "tags", new List<string> { "tag1", "tag2", "tag3" } }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Equal("tags=tag1,tag2,tag3", result);
        }

        [Fact]
        public void BuildQueryString_WithEmptyListParameter_ReturnsEmptyValue()
        {
            // Arrange
            var parameters = new Dictionary<string, object>
            {
                { "tags", new List<string>() }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Equal("tags=", result);
        }

        [Fact]
        public void BuildQueryString_WithSingleItemListParameter_ReturnsSingleValue()
        {
            // Arrange
            var parameters = new Dictionary<string, object>
            {
                { "tags", new List<string> { "only-tag" } }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Equal("tags=only-tag", result);
        }

        [Fact]
        public void BuildQueryString_WithMultipleListParameters_ReturnsCorrectFormat()
        {
            // Arrange
            var parameters = new Dictionary<string, object>
            {
                { "tags", new List<string> { "tag1", "tag2" } },
                { "categories", new List<string> { "cat1", "cat2", "cat3" } }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Contains("tags=tag1,tag2", result);
            Assert.Contains("categories=cat1,cat2,cat3", result);
            Assert.Contains("&", result);
        }

        #endregion

        #region Mixed Parameter Tests

        [Fact]
        public void BuildQueryString_WithMixedScalarAndListParameters_ReturnsCorrectFormat()
        {
            // Arrange
            var parameters = new Dictionary<string, object>
            {
                { "name", "test" },
                { "tags", new List<string> { "tag1", "tag2" } },
                { "count", 5 }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Contains("name=test", result);
            Assert.Contains("tags=tag1,tag2", result);
            Assert.Contains("count=5", result);
        }

        #endregion

        #region Special Characters Tests

        [Theory]
        [InlineData("value with spaces")]
        [InlineData("value/with/slashes")]
        [InlineData("value-with-dashes")]
        [InlineData("value_with_underscores")]
        public void BuildQueryString_WithSpecialCharacters_ReturnsValueAsIs(string value)
        {
            // Arrange
            var parameters = new Dictionary<string, object> { { "key", value } };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Equal($"key={value}", result);
        }

        [Fact]
        public void BuildQueryString_WithListItemsContainingSpecialCharacters_ReturnsValueAsIs()
        {
            // Arrange
            var parameters = new Dictionary<string, object>
            {
                { "items", new List<string> { "item-1", "item_2", "item 3" } }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Equal("items=item-1,item_2,item 3", result);
        }

        #endregion

        #region Real-World Scenario Tests

        [Fact]
        public void BuildQueryString_WithWeatherApiParameters_ReturnsCorrectFormat()
        {
            // Arrange
            var parameters = new Dictionary<string, object>
            {
                { "latitude", 40.7128 },
                { "longitude", -74.0060 },
                { "temperature_unit", "celsius" },
                { "wind_speed_unit", "kmh" },
                { "precipitation_unit", "mm" },
                { "current", new List<string> { "temperature_2m", "relative_humidity_2m", "weather_code" } }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Contains("latitude=40.7128", result);
            Assert.Contains("longitude=-74.006", result);  // Floating point precision
            Assert.Contains("temperature_unit=celsius", result);
            Assert.Contains("wind_speed_unit=kmh", result);
            Assert.Contains("precipitation_unit=mm", result);
            Assert.Contains("current=temperature_2m,relative_humidity_2m,weather_code", result);
        }

        [Fact]
        public void BuildQueryString_WithGeocodingApiParameters_ReturnsCorrectFormat()
        {
            // Arrange
            var parameters = new Dictionary<string, object>
            {
                { "name", "New York" },
                { "count", 10 },
                { "language", "en" }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Contains("name=New York", result);
            Assert.Contains("count=10", result);
            Assert.Contains("language=en", result);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void BuildQueryString_WithEmptyStringValue_ReturnsEmptyValue()
        {
            // Arrange
            var parameters = new Dictionary<string, object> { { "key", string.Empty } };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Equal("key=", result);
        }

        [Fact]
        public void BuildQueryString_WithZeroValue_ReturnsZero()
        {
            // Arrange
            var parameters = new Dictionary<string, object> { { "count", 0 } };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Equal("count=0", result);
        }

        [Fact]
        public void BuildQueryString_WithNegativeValue_ReturnsNegative()
        {
            // Arrange
            var parameters = new Dictionary<string, object> { { "latitude", -90.0 } };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Contains("latitude=-90", result);
        }

        [Fact]
        public void BuildQueryString_WithVeryLargeDictionary_ReturnsAllParameters()
        {
            // Arrange
            var parameters = new Dictionary<string, object>();
            for (int i = 0; i < 100; i++)
            {
                parameters.Add($"param{i}", $"value{i}");
            }

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.Contains("param0=value0", result);
            Assert.Contains("param99=value99", result);
            var ampersandCount = result.Count(c => c == '&');
            Assert.Equal(99, ampersandCount); // 100 params = 99 ampersands
        }

        #endregion

        #region Parameter Ordering Tests

        [Fact]
        public void BuildQueryString_WithDictionaryParameters_MaintainsOrder()
        {
            // Arrange
            var parameters = new Dictionary<string, object>
            {
                { "first", "1" },
                { "second", "2" },
                { "third", "3" }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            var parts = result.Split('&');
            Assert.Equal(3, parts.Length);
            Assert.Equal("first=1", parts[0]);
            Assert.Equal("second=2", parts[1]);
            Assert.Equal("third=3", parts[2]);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void BuildQueryString_ComplexRealWorldScenario_ReturnsValidQueryString()
        {
            // Arrange - Simulating a complex API request
            var parameters = new Dictionary<string, object>
            {
                { "latitude", 48.8566 },
                { "longitude", 2.3522 },
                { "temperature_unit", "celsius" },
                { "wind_speed_unit", "kmh" },
                { "precipitation_unit", "mm" },
                { "current", new List<string> 
                { 
                    "temperature_2m", 
                    "apparent_temperature",
                    "relative_humidity_2m",
                    "weather_code"
                }},
                { "hourly", new List<string> 
                { 
                    "temperature_2m",
                    "precipitation",
                    "weather_code"
                }},
                { "daily", new List<string> 
                { 
                    "temperature_2m_max",
                    "temperature_2m_min",
                    "precipitation_sum"
                }},
                { "timezone", "Europe/Paris" }
            };

            // Act
            var result = HttpQueryBuilder.BuildQueryString(parameters);

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains("latitude=48.8566", result);
            Assert.Contains("longitude=2.3522", result);
            Assert.Contains("current=temperature_2m,apparent_temperature,relative_humidity_2m,weather_code", result);
            Assert.Contains("hourly=temperature_2m,precipitation,weather_code", result);
            Assert.Contains("daily=temperature_2m_max,temperature_2m_min,precipitation_sum", result);
            Assert.Contains("timezone=Europe/Paris", result);

            // Verify it can be parsed back
            var segments = result.Split('&');
            Assert.True(segments.Length > 5, "Should have multiple parameters");
        }

        #endregion
    }
}