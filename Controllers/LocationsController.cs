using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly List<Location> locations;

        public LocationsController()
        {
            // Initialize locations with sample data
            locations = new List<Location>
            {
                new Location { Id = 1, Name = "Location A", AvailabilityStartTime = new TimeSpan(10, 0, 0), AvailabilityEndTime = new TimeSpan(13, 0, 0) },
                new Location { Id = 2, Name = "Location B", AvailabilityStartTime = new TimeSpan(9, 30, 0), AvailabilityEndTime = new TimeSpan(12, 30, 0) },
                // Add more locations as needed
            };
        }

        [HttpGet]
        public IActionResult GetLocationsWithAvailability()
        {
            try
            {
                // Filter locations based on availability between 10am and 1pm
                var availableLocations = locations
                    .Where(location => location.AvailabilityStartTime >= new TimeSpan(10, 0, 0) && location.AvailabilityEndTime <= new TimeSpan(13, 0, 0))
                    .ToList();

                return Ok(availableLocations);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }
    }

    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan AvailabilityStartTime { get; set; }
        public TimeSpan AvailabilityEndTime { get; set; }
    }
}

