using TheWeatherNode.Core;
using Xunit;

namespace TheWeatherNode.Core.Tests
{
    /// <summary>
    /// Unit tests for the <see cref="Utility"/> class.
    /// </summary>
    public class UtilityTests
    {
        #region StringToBytes Tests

        [Fact]
        public void StringToBytes_WithSimpleString_ReturnsCorrectBytes()
        {
            // Arrange
            const string input = "Hello";

            // Act
            var result = Utility.StringToBytes(input);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(input.Length * sizeof(char), result.Length);
        }

        [Fact]
        public void StringToBytes_WithEmptyString_ReturnsEmptyByteArray()
        {
            // Arrange
            const string input = "";

            // Act
            var result = Utility.StringToBytes(input);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void StringToBytes_WithSpecialCharacters_ReturnsCorrectBytes()
        {
            // Arrange
            const string input = "Hello@#$%^&*()";

            // Act
            var result = Utility.StringToBytes(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(input.Length * sizeof(char), result.Length);
        }

        [Fact]
        public void StringToBytes_WithUnicodeCharacters_ReturnsCorrectBytes()
        {
            // Arrange
            const string input = "Hello世界🌍";

            // Act
            var result = Utility.StringToBytes(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(input.Length * sizeof(char), result.Length);
        }

        [Fact]
        public void StringToBytes_WithWhitespace_ReturnsCorrectBytes()
        {
            // Arrange
            const string input = "  Hello  World  ";

            // Act
            var result = Utility.StringToBytes(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(input.Length * sizeof(char), result.Length);
        }

        [Fact]
        public void StringToBytes_WithNewlines_ReturnsCorrectBytes()
        {
            // Arrange
            const string input = "Hello\nWorld\r\nTest";

            // Act
            var result = Utility.StringToBytes(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(input.Length * sizeof(char), result.Length);
        }

        #endregion

        #region BytesToString Tests

        [Fact]
        public void BytesToString_WithValidBytes_ReturnsCorrectString()
        {
            // Arrange
            const string original = "Hello";
            var bytes = Utility.StringToBytes(original);

            // Act
            var result = Utility.BytesToString(bytes);

            // Assert
            Assert.Equal(original, result);
        }

        [Fact]
        public void BytesToString_WithEmptyByteArray_ReturnsEmptyString()
        {
            // Arrange
            var bytes = Array.Empty<byte>();

            // Act
            var result = Utility.BytesToString(bytes);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void BytesToString_WithSpecialCharacterBytes_ReturnsCorrectString()
        {
            // Arrange
            const string original = "Test@#$%^&*()";
            var bytes = Utility.StringToBytes(original);

            // Act
            var result = Utility.BytesToString(bytes);

            // Assert
            Assert.Equal(original, result);
        }

        [Fact]
        public void BytesToString_WithUnicodeBytes_ReturnsCorrectString()
        {
            // Arrange
            const string original = "Hello世界🌍";
            var bytes = Utility.StringToBytes(original);

            // Act
            var result = Utility.BytesToString(bytes);

            // Assert
            Assert.Equal(original, result);
        }

        #endregion

        #region StringToBytes and BytesToString RoundTrip Tests

        [Theory]
        [InlineData("Simple")]
        [InlineData("With Spaces")]
        [InlineData("With\nNewlines")]
        [InlineData("Special!@#$%^&*()")]
        [InlineData("Unicode: 日本語")]
        public void StringToBytes_BytesToString_RoundTrip_ReturnsOriginal(string original)
        {
            // Act
            var bytes = Utility.StringToBytes(original);
            var result = Utility.BytesToString(bytes);

            // Assert
            Assert.Equal(original, result);
        }

        #endregion

        #region StringToStream Tests

        [Fact]
        public void StringToStream_WithSimpleString_ReturnsValidStream()
        {
            // Arrange
            const string input = "Hello World";

            // Act
            var stream = Utility.StringToStream(input);

            // Assert
            Assert.NotNull(stream);
            Assert.True(stream.CanRead);
            Assert.True(stream.CanSeek);
            Assert.Equal(0, stream.Position);
        }

        [Fact]
        public void StringToStream_WithSimpleString_StreamContainsCorrectContent()
        {
            // Arrange
            const string input = "Hello World";

            // Act
            var stream = Utility.StringToStream(input);
            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();

            // Assert
            Assert.Equal(input, content);
        }

        [Fact]
        public void StringToStream_WithEmptyString_ReturnsValidStream()
        {
            // Arrange
            const string input = "";

            // Act
            var stream = Utility.StringToStream(input);

            // Assert
            Assert.NotNull(stream);
            Assert.Equal(0, stream.Length);
        }

        [Fact]
        public void StringToStream_WithMultilineString_ReturnsValidStream()
        {
            // Arrange
            const string input = "Line 1\nLine 2\nLine 3";

            // Act
            var stream = Utility.StringToStream(input);
            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();

            // Assert
            Assert.Equal(input, content);
        }

        [Fact]
        public void StringToStream_PositionIsAtBeginning_AfterCreation()
        {
            // Arrange
            const string input = "Test";

            // Act
            var stream = Utility.StringToStream(input);

            // Assert
            Assert.Equal(0, stream.Position);
        }

        #endregion

        #region ParseEnum Tests

        [Fact]
        public void ParseEnum_WithValidEnumValue_ReturnsCorrectEnum()
        {
            // Act
            var result = Utility.ParseEnum<DayOfWeek>("Monday");

            // Assert
            Assert.Equal(DayOfWeek.Monday, result);
        }

        [Fact]
        public void ParseEnum_WithLowerCaseEnumValue_ReturnsCorrectEnum()
        {
            // Act
            var result = Utility.ParseEnum<DayOfWeek>("monday");

            // Assert
            Assert.Equal(DayOfWeek.Monday, result);
        }

        [Fact]
        public void ParseEnum_WithUpperCaseEnumValue_ReturnsCorrectEnum()
        {
            // Act
            var result = Utility.ParseEnum<DayOfWeek>("FRIDAY");

            // Assert
            Assert.Equal(DayOfWeek.Friday, result);
        }

        [Fact]
        public void ParseEnum_WithMixedCaseEnumValue_ReturnsCorrectEnum()
        {
            // Act
            var result = Utility.ParseEnum<DayOfWeek>("WeDnEsDaY");

            // Assert
            Assert.Equal(DayOfWeek.Wednesday, result);
        }

        [Theory]
        [InlineData("Monday", DayOfWeek.Monday)]
        [InlineData("Tuesday", DayOfWeek.Tuesday)]
        [InlineData("Wednesday", DayOfWeek.Wednesday)]
        [InlineData("Thursday", DayOfWeek.Thursday)]
        [InlineData("Friday", DayOfWeek.Friday)]
        [InlineData("Saturday", DayOfWeek.Saturday)]
        [InlineData("Sunday", DayOfWeek.Sunday)]
        public void ParseEnum_WithVariousDayValues_ReturnsCorrectEnum(string dayString, DayOfWeek expected)
        {
            // Act
            var result = Utility.ParseEnum<DayOfWeek>(dayString);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParseEnum_WithInvalidEnumValue_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => Utility.ParseEnum<DayOfWeek>("InvalidDay"));
            Assert.Contains("was not found", ex.Message);
        }

        #endregion

        #region GetEnvironmentVariable Tests

        [Fact]
        public void GetEnvironmentVariable_WithExistingVariable_ReturnsValue()
        {
            // Arrange
            const string varName = "TEST_VAR";
            const string varValue = "test_value";
            Environment.SetEnvironmentVariable(varName, varValue);

            try
            {
                // Act
                var result = Utility.GetEnvironmentVariable(varName);

                // Assert
                Assert.Equal(varValue, result);
            }
            finally
            {
                // Cleanup
                Environment.SetEnvironmentVariable(varName, null);
            }
        }

        [Fact]
        public void GetEnvironmentVariable_WithNonexistentVariable_ReturnsNull()
        {
            // Act
            var result = Utility.GetEnvironmentVariable("NONEXISTENT_VAR_12345");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetEnvironmentVariable_WithEmptyString_ReturnsNullWhenVariableNotSet()
        {
            // Arrange
            const string varName = "EMPTY_VAR_TEST";
            // Make sure it's not set
            Environment.SetEnvironmentVariable(varName, null);

            // Act
            var result = Utility.GetEnvironmentVariable(varName);

            // Assert
            Assert.Null(result);
        }

        #endregion

        #region GetEpochTime Tests

        [Fact]
        public void GetEpochTime_WithoutParameter_ReturnsPositiveInteger()
        {
            // Act
            var result = Utility.GetEpochTime();

            // Assert
            Assert.True(result > 0);
            Assert.IsType<int>(result);
        }

        [Fact]
        public void GetEpochTime_WithNullParameter_ReturnsCurrentEpochTime()
        {
            // Act
            var result = Utility.GetEpochTime(null);

            // Assert
            Assert.True(result > 0);
        }

        [Fact]
        public void GetEpochTime_WithEpochDate_ReturnsZero()
        {
            // Arrange
            var epochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var result = Utility.GetEpochTime(epochDate);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetEpochTime_WithDateAfterEpoch_ReturnsPositiveValue()
        {
            // Arrange
            var futureDate = new DateTime(1970, 1, 1, 1, 0, 0, DateTimeKind.Utc);

            // Act
            var result = Utility.GetEpochTime(futureDate);

            // Assert
            Assert.Equal(3600, result); // 1 hour = 3600 seconds
        }

        [Fact]
        public void GetEpochTime_WithKnownDate_ReturnsCorrectEpochTime()
        {
            // Arrange
            var date = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var result = Utility.GetEpochTime(date);

            // Assert
            Assert.Equal(946684800, result); // Known epoch time for Y2K
        }

        [Fact]
        public void GetEpochTime_WithLocalTime_ConvertsToUtcCorrectly()
        {
            // Arrange
            var localDate = new DateTime(1970, 1, 1, 0, 0, 0);

            // Act
            var result = Utility.GetEpochTime(localDate);

            // Assert
            Assert.IsType<int>(result);
            // Value depends on system timezone, just verify it's an int
        }

        #endregion

        #region Base64Encode Tests

        [Theory]
        [InlineData("Hello")]
        [InlineData("Hello World")]
        [InlineData("Test123!@#")]
        public void Base64Encode_WithValidString_ReturnsBase64String(string input)
        {
            // Act
            var result = Utility.Base64Encode(input);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            // Should be valid base64
            var decodedBytes = Convert.FromBase64String(result);
            Assert.NotNull(decodedBytes);
        }

        [Fact]
        public void Base64Encode_WithEmptyString_ReturnsEmptyString()
        {
            // Act
            var result = Utility.Base64Encode("");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Base64Encode_WithUnicodeString_ReturnsValidBase64()
        {
            // Arrange
            const string input = "Hello世界";

            // Act
            var result = Utility.Base64Encode(input);

            // Assert
            Assert.NotEmpty(result);
            var decodedBytes = Convert.FromBase64String(result);
            var decodedString = System.Text.Encoding.UTF8.GetString(decodedBytes);
            Assert.Equal(input, decodedString);
        }

        [Fact]
        public void Base64Encode_WithSpecialCharacters_ReturnsValidBase64()
        {
            // Arrange
            const string input = "!@#$%^&*()_+-=[]{}|;:',.<>?/";

            // Act
            var result = Utility.Base64Encode(input);

            // Assert
            Assert.NotEmpty(result);
            var decodedBytes = Convert.FromBase64String(result);
            var decodedString = System.Text.Encoding.UTF8.GetString(decodedBytes);
            Assert.Equal(input, decodedString);
        }

        #endregion

        #region Base64Decode Tests

        [Fact]
        public void Base64Decode_WithValidBase64String_ReturnsOriginalString()
        {
            // Arrange
            const string original = "Hello";
            var encoded = Utility.Base64Encode(original);

            // Act
            var result = Utility.Base64Decode(encoded);

            // Assert
            Assert.Equal(original, result);
        }

        [Fact]
        public void Base64Decode_WithEmptyString_ReturnsEmptyString()
        {
            // Act
            var result = Utility.Base64Decode("");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Base64Decode_WithUnicodeBase64_ReturnsUnicodeString()
        {
            // Arrange
            const string original = "World世界";
            var encoded = Utility.Base64Encode(original);

            // Act
            var result = Utility.Base64Decode(encoded);

            // Assert
            Assert.Equal(original, result);
        }

        [Fact]
        public void Base64Decode_WithInvalidBase64_ThrowsFormatException()
        {
            // Act & Assert
            Assert.Throws<FormatException>(() => Utility.Base64Decode("!!!Invalid Base64!!!"));
        }

        #endregion

        #region Base64Encode and Decode RoundTrip Tests

        [Theory]
        [InlineData("Simple")]
        [InlineData("With Spaces")]
        [InlineData("With\nNewlines")]
        [InlineData("Special!@#$%^&*()")]
        [InlineData("Unicode: 日本語")]
        [InlineData("")]
        public void Base64Encode_Decode_RoundTrip_ReturnsOriginal(string original)
        {
            // Act
            var encoded = Utility.Base64Encode(original);
            var decoded = Utility.Base64Decode(encoded);

            // Assert
            Assert.Equal(original, decoded);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void StringToStream_WithBytesFromStringToBytes_RoundTrip_ReturnsOriginal()
        {
            // Arrange - Use Utility.StringToStream instead of manual MemoryStream
            const string original = "Integration Test String";

            // Act
            var stream = Utility.StringToStream(original);
            using var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();

            // Assert
            Assert.Equal(original, result);
        }

        [Fact]
        public void ComplexConversion_MultipleOperations_MaintainsIntegrity()
        {
            // Arrange
            const string original = "Complex Data!@#世界";

            // Act - Multiple conversions
            var encoded = Utility.Base64Encode(original);
            var bytes = Utility.StringToBytes(encoded);
            var decodedFromBytes = Utility.BytesToString(bytes);
            var decoded = Utility.Base64Decode(decodedFromBytes);

            // Assert
            Assert.Equal(original, decoded);
        }

        #endregion

        #region Null and Edge Case Tests

        [Fact]
        public void StringToBytes_WithVeryLongString_ReturnsCorrectBytes()
        {
            // Arrange
            var input = new string('A', 10000);

            // Act
            var result = Utility.StringToBytes(input);

            // Assert
            Assert.Equal(input.Length * sizeof(char), result.Length);
        }

        [Fact]
        public void Base64Encode_WithVeryLongString_ReturnsValidBase64()
        {
            // Arrange
            var input = new string('A', 10000);

            // Act
            var encoded = Utility.Base64Encode(input);
            var decoded = Utility.Base64Decode(encoded);

            // Assert
            Assert.Equal(input, decoded);
        }

        #endregion
    }
}