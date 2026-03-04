using TheWeatherNode.Core.Models.Responses;

namespace TheWeatherNode.Core.Interfaces
{
    /// <summary>
    /// Defines the contract for geocoding service operations.
    /// </summary>
    /// <remarks>
    /// This interface abstracts geocoding functionality, enabling location name to coordinate
    /// conversions and vice versa. Implementations may use various geocoding providers
    /// (e.g., Open-Meteo, Google Maps, etc.).
    /// 
    /// Geocoding operations support:
    /// - Forward geocoding: Converting location names to geographic coordinates
    /// - Reverse geocoding: Converting coordinates to location names
    /// - Location search with optional country filtering for refined results
    /// </remarks>
    public interface IGeocodingService
    {
        /// <summary>
        /// Searches for locations matching the specified query string asynchronously.
        /// </summary>
        /// <remarks>
        /// Performs a forward geocoding search to find locations matching the provided query.
        /// The query can be a city name, address, or any location identifier supported by
        /// the underlying geocoding provider.
        /// 
        /// Multiple results may be returned if the query matches several locations.
        /// Results are typically ordered by relevance or population size.
        /// </remarks>
        /// <param name="query">
        /// The search query string (e.g., "New York", "Paris, France", "40.7128, -74.0060").
        /// Cannot be null or empty.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// an enumerable collection of <see cref="Location"/> objects matching the query.
        /// Returns an empty collection if no matches are found.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="query"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="query"/> is empty or whitespace.
        /// </exception>
        /// <exception cref="System.Net.Http.HttpRequestException">
        /// Thrown when the geocoding API request fails.
        /// </exception>
        Task<IEnumerable<Location>> SearchLocationsAsync(string query);

        /// <summary>
        /// Retrieves a specific location by city name, with optional country filtering asynchronously.
        /// </summary>
        /// <remarks>
        /// Performs a targeted location lookup by city name, optionally narrowed by country.
        /// When a country is provided, the search results are filtered to locations within
        /// that country, reducing ambiguity for cities that share names across regions.
        /// 
        /// Returns the first matching location if multiple results are found, typically
        /// the one with the largest population or highest relevance score.
        /// </remarks>
        /// <param name="city">
        /// The city name to search for (e.g., "York", "London", "Paris").
        /// Cannot be null or empty.
        /// </param>
        /// <param name="country">
        /// Optional country name or country code to filter results geographically.
        /// When provided, only locations within the specified country are considered.
        /// If null or not specified, searches across all countries.
        /// Examples: "United States", "US", "France", "FR"
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains
        /// a <see cref="Location"/> object if a matching location is found; otherwise, null.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="city"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when <paramref name="city"/> is empty or whitespace.
        /// </exception>
        /// <exception cref="System.Net.Http.HttpRequestException">
        /// Thrown when the geocoding API request fails.
        /// </exception>
        Task<Location?> GetLocationAsync(string city, string? country = null);
    }
}
