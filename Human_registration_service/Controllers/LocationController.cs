using Human_Registration_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
        [HttpPut("updateApartmentNumber")]
        public void UpdateApartment([FromQuery] string userName, [FromQuery] int apartmentNumber)
        {
            _locationRepository.UpdateApartmentNumber(userName, apartmentNumber);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
        [HttpPut("updateCity")]
        public void UpdateEmail([FromQuery] string userName, string newCity)
        {
            _locationRepository.UpdateCity(userName, newCity);           
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
        [HttpPut("updateStreet")]
        public void UpdateStreet([FromQuery] string userName, string newStreet)
        {
            _locationRepository.UpdateStreet(userName, newStreet);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
        [HttpPut("updateHouseNumber")]
        public void UpdateHouseNUmber([FromQuery] string userName, int newHouseNumber)
        {
            _locationRepository.UpdateHouseNumber(userName, newHouseNumber);
        }
    }
}
