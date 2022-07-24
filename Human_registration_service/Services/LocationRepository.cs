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
           // var currentUser = users.ToArray()[0];

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

        public void UpdateApartmentNumber(string userName, int newApartmentNumber)
        {
            var apartmentNumber = _context.UserInformation.Where(x => x.UserName == userName).Include(x => x.HumanInformationLink).First();
            apartmentNumber.HumanInformationLink.LocationLink.ApartmentNumber = newApartmentNumber;
            _context.SaveChanges();
            

        }

        //public void UpdateCity(string city, string newCity)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void UpdateHouseNUmber(int houseNumber, int newHouseNUmber)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void UpdateStreet(string streetName, string newStreetName)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
