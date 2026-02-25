using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherNode.Core
{
    public class Utility
    {
        ///// <summary>
        /////     Converts Anonymous object to dictionary.
        ///// </summary>
        ///// <param name="anonymousObject">The anonymous object.</param>
        ///// <returns></returns>
        //public static Dictionary<string, object> AnonymousObjectToDictionary(object anonymousObject)
        //{
        //    var dictionary = new Dictionary<string, object>();
        //    if (anonymousObject == null) return dictionary;
        //    foreach (var propertyInfo in anonymousObject.GetType().GetProperties())
        //        dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(anonymousObject, null));
        //    return dictionary;
        //}

        /// <summary>
        ///     Encoding insensitive String to bytes conversion.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static byte[] StringToBytes(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        ///     Encoding insensitive Bytes to string conversion.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static string BytesToString(byte[] bytes)
        {
            var chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        /// <summary>
        /// Strings to stream.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static Stream StringToStream(string str)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        ///     Parses the string to enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Gets the environment variable.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string? GetEnvironmentVariable(string value)
        {
            return Environment.GetEnvironmentVariable(value);
        }

        public static int GetEpochTime(DateTime? dateTime = null)
        {
            var timeSpan = dateTime.GetValueOrDefault(DateTime.Now).ToUniversalTime() - new DateTime(1970, 1, 1);
            return (int)timeSpan.TotalSeconds;

        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
