
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheWeatherNode.Core.Interfaces;

namespace TheWeatherNode.Server.Controllers
{
    [Route("location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IGeocodingService geocodingService;
        private readonly ILogger<LocationController> logger;

        public LocationController(IGeocodingService geocodingService, ILogger<LocationController> logger)
        {
            this.geocodingService = geocodingService;
            this.logger = logger;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchLocations(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Query parameter cannot be null or empty.");
            }
            try
            {
                var locations = await geocodingService.SearchLocationsAsync(query);
                return Ok(locations);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while searching for locations with query: {Query}", query);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
