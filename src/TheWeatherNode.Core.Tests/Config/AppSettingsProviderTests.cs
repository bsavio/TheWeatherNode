using System.Text;
using Microsoft.Extensions.Configuration;
using TheWeatherNode.Core.Config;
using Xunit;

namespace TheWeatherNode.Core.Tests.Config
{
    /// <summary>
    /// Unit tests for the <see cref="AppSettingsProvider"/> class.
    /// </summary>
    public class AppSettingsProviderTests
    {
        /// <summary>
        /// Test settings model for deserialization testing.
        /// </summary>
        private class TestSettings
        {
            public string Name { get; set; } = string.Empty;
            public int Value { get; set; }
            public bool Enabled { get; set; }
        }

        /// <summary>
        /// Creates a JSON stream for testing purposes.
        /// </summary>
        private static Stream CreateJsonStream(string json)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(json);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        #region GetAppSetting<T>(string appSetting) Tests

        [Fact]
        public void GetAppSetting_WithValidSectionName_ReturnsCorrectType()
        {
            // Arrange
            var json = """
            {
              "TestSettings": {
                "Name": "TestApp",
                "Value": 42,
                "Enabled": true
              }
            }
            """;
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act
            var result = provider.GetAppSetting<TestSettings>("TestSettings");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("TestApp", result.Name);
            Assert.Equal(42, result.Value);
            Assert.True(result.Enabled);
        }

        [Fact]
        public void GetAppSetting_WithNonexistentSection_ThrowsInvalidOperationException()
        {
            // Arrange
            var json = """
            {
              "OtherSettings": {
                "Name": "Test"
              }
            }
            """;
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(
                () => provider.GetAppSetting<TestSettings>("NonexistentSettings"));
            Assert.Contains("not found in configuration", ex.Message);
        }

        [Fact]
        public void GetAppSetting_WithNullSection_ThrowsInvalidOperationException()
        {
            // Arrange
            var json = "{}";
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(
                () => provider.GetAppSetting<TestSettings>("TestSettings"));
            Assert.Contains("not found in configuration", ex.Message);
        }

        [Fact]
        public void GetAppSetting_WithEmptySection_ThrowsInvalidOperationException()
        {
            // Arrange
            var json = """
            {
              "TestSettings": null
            }
            """;
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(
                () => provider.GetAppSetting<TestSettings>("TestSettings"));
            Assert.Contains("not found in configuration", ex.Message);
        }

        [Fact]
        public void GetAppSetting_WithPartialData_ReturnsObjectWithDefaultValues()
        {
            // Arrange
            var json = """
            {
              "TestSettings": {
                "Name": "PartialTest"
              }
            }
            """;
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act
            var result = provider.GetAppSetting<TestSettings>("TestSettings");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("PartialTest", result.Name);
            Assert.Equal(0, result.Value); // Default int value
            Assert.False(result.Enabled); // Default bool value
        }

        #endregion

        #region GetAppSetting<T>() Tests (Type Name Inference)

        [Fact]
        public void GetAppSetting_WithoutParameter_UsesTypeNameAsSection()
        {
            // Arrange
            var json = """
            {
              "TestSettings": {
                "Name": "InferredName",
                "Value": 99,
                "Enabled": true
              }
            }
            """;
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act
            var result = provider.GetAppSetting<TestSettings>();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("InferredName", result.Name);
            Assert.Equal(99, result.Value);
            Assert.True(result.Enabled);
        }

        [Fact]
        public void GetAppSetting_WithoutParameter_ThrowsWhenSectionNotFound()
        {
            // Arrange
            var json = "{}";
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(
                () => provider.GetAppSetting<TestSettings>());
            Assert.Contains("not found in configuration", ex.Message);
        }

        #endregion

        #region GetConfigSection Tests

        [Fact]
        public void GetConfigSection_WithValidSectionName_ReturnsConfigurationSection()
        {
            // Arrange
            var json = """
            {
              "DatabaseSettings": {
                "ConnectionString": "Server=localhost;Database=TestDb"
              }
            }
            """;
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act
            var section = provider.GetConfigSection("DatabaseSettings");

            // Assert
            Assert.NotNull(section);
            Assert.Equal("DatabaseSettings", section.Key);
            Assert.NotNull(section["ConnectionString"]);
            Assert.Equal("Server=localhost;Database=TestDb", section["ConnectionString"]);
        }

        [Fact]
        public void GetConfigSection_WithNonexistentSection_ReturnsEmptySection()
        {
            // Arrange
            var json = "{}";
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act
            var section = provider.GetConfigSection("NonexistentSection");

            // Assert
            Assert.NotNull(section);
            Assert.Empty(section.GetChildren());
        }

        [Fact]
        public void GetConfigSection_WithNestedSection_ReturnsCorrectData()
        {
            // Arrange
            var json = """
            {
              "AppSettings": {
                "Nested": {
                  "Key1": "Value1",
                  "Key2": "Value2"
                }
              }
            }
            """;
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act
            var section = provider.GetConfigSection("AppSettings:Nested");

            // Assert
            Assert.NotNull(section);
            Assert.Equal("Value1", section["Key1"]);
            Assert.Equal("Value2", section["Key2"]);
        }

        #endregion

        #region GetEnvironment Tests

        [Fact]
        public void GetEnvironment_WhenEnvironmentVariableSet_ReturnsEnvironmentValue()
        {
            // Arrange
            const string expectedEnv = "production";
            Environment.SetEnvironmentVariable("env", expectedEnv);

            var json = "{}";
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            try
            {
                // Act
                var result = provider.GetEnvironment();

                // Assert
                Assert.Equal(expectedEnv, result);
            }
            finally
            {
                // Cleanup
                Environment.SetEnvironmentVariable("env", null);
            }
        }

        [Fact]
        public void GetEnvironment_WhenEnvironmentVariableNotSet_ReturnsDefaultValue()
        {
            // Arrange
            Environment.SetEnvironmentVariable("env", null);

            var json = "{}";
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act
            var result = provider.GetEnvironment();

            // Assert
            Assert.Equal("local", result);
        }

        [Theory]
        [InlineData("development")]
        [InlineData("staging")]
        [InlineData("production")]
        public void GetEnvironment_WithVariousEnvironmentValues_ReturnsCorrectValue(string envValue)
        {
            // Arrange
            Environment.SetEnvironmentVariable("env", envValue);

            var json = "{}";
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            try
            {
                // Act
                var result = provider.GetEnvironment();

                // Assert
                Assert.Equal(envValue, result);
            }
            finally
            {
                // Cleanup
                Environment.SetEnvironmentVariable("env", null);
            }
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void MultipleGetAppSetting_WithSameSectionName_ReturnsSameData()
        {
            // Arrange
            var json = """
            {
              "TestSettings": {
                "Name": "MultipleCallTest",
                "Value": 123,
                "Enabled": true
              }
            }
            """;
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act
            var result1 = provider.GetAppSetting<TestSettings>("TestSettings");
            var result2 = provider.GetAppSetting<TestSettings>("TestSettings");

            // Assert
            Assert.Equal(result1.Name, result2.Name);
            Assert.Equal(result1.Value, result2.Value);
            Assert.Equal(result1.Enabled, result2.Enabled);
        }

        [Fact]
        public void GetAppSetting_AndGetConfigSection_ReturnConsistentData()
        {
            // Arrange
            var json = """
            {
              "TestSettings": {
                "Name": "ConsistencyTest",
                "Value": 456
              }
            }
            """;
            var stream = CreateJsonStream(json);
            var provider = new AppSettingsProvider(stream);

            // Act
            var appSetting = provider.GetAppSetting<TestSettings>("TestSettings");
            var configSection = provider.GetConfigSection("TestSettings");

            // Assert
            Assert.Equal(appSetting.Name, configSection["Name"]);
            Assert.Equal(appSetting.Value.ToString(), configSection["Value"]);
        }

        #endregion
    }
}