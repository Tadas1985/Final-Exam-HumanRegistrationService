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
        public bool AddLocation([FromQuery] string userName , [FromQuery] string city, [FromQuery] string streetName, [FromQuery] int houseNumber, [FromQuery] int apartmentNumber )
            {
               return _locationRepository.AddNewLocation(userName, city, streetName, houseNumber, apartmentNumber);
            }
        [HttpPost("updateLocation")]
        public void UpdateLocation([FromQuery] string userName, [FromQuery] string city, [FromQuery] string streetName, [FromQuery] int houseNumber, [FromQuery] int apartmentNumber )
        {
            _locationRepository.AddNewLocation(userName, city, streetName, houseNumber, apartmentNumber);
        }
        [HttpPost("updateApartmentNumber")]
        public void UpdateApartment([FromQuery] string userName, [FromQuery] int apartmentNumber)
        {
            _locationRepository.UpdateApartmentNumber(userName, apartmentNumber);
        }
    }
}
