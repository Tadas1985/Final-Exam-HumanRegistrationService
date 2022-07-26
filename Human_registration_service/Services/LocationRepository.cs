using Human_Registration_Service.Context;
using Human_Registration_Service.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Human_Registration_Service.Services
{
    public class LocationRepository: ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public bool AddNewLocation(string userName, string city, string street, int houseNumber, int apartmentNumber)
        {
           
            var currentUser = _context.UserInformation.Where(x => x.UserName == userName).Include(x => x.HumanInformationLink).First();
            //var currentUser = users.ToArray()[0];

            if (currentUser.HumanInformationLink == null)
                return false;
            if (currentUser.HumanInformationLink.LocationLink !=null)
                return false;   
            Location locationInformation = new Location(city, street, houseNumber, apartmentNumber);
            _context.Add(locationInformation);
            _context.SaveChanges();

            currentUser.HumanInformationLink.LocationLink = locationInformation;
            _context.SaveChanges();

            return true;
        }
        public Location GetLocationByUserName(string userName)
        {
            var user = _context.UserInformation.Where(x => x.UserName == userName).Include(x => x.HumanInformationLink).Include(x => x.HumanInformationLink.LocationLink).First();
            
            return user.HumanInformationLink.LocationLink;
        }
        public void UpdateApartmentNumber(string userName, int newApartmentNumber)
        {
            GetLocationByUserName(userName).ApartmentNumber = newApartmentNumber;
            _context.SaveChanges();
            
        }

        public void UpdateCity(string userName, string newCity)
        {
            GetLocationByUserName(userName).City = newCity;
            _context.SaveChanges();
        }

        public void UpdateHouseNumber(string userName, int newHouseNUmber)
        {
            GetLocationByUserName(userName).HouseNumber = newHouseNUmber;
            _context.SaveChanges();
        }

        public void UpdateStreet(string userName, string newStreetName)
        {
            GetLocationByUserName(userName).Street = newStreetName;
            _context.SaveChanges();
        }
    }
}
