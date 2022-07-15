using Human_Registration_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Human_Registration_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController
    {
        ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpPost("addLocation")]
        public void AddLocation([FromQuery] string city, [FromQuery] string streetName, [FromQuery] int houseNumber, [FromQuery] int apartmentNumber )
            {
                _locationRepository.AddNewLocation(city, streetName, houseNumber, apartmentNumber);
            }
        [HttpPost("updateLocation")]
        public void UpdateLocation([FromQuery] string city, [FromQuery] string streetName, [FromQuery] int houseNumber, [FromQuery] int apartmentNumber)
        {
            _locationRepository.AddNewLocation(city, streetName, houseNumber, apartmentNumber);
        }
    }
}
