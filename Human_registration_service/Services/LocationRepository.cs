using Human_Registration_Service.Context;
using Human_Registration_Service.Models;

namespace Human_Registration_Service.Services
{
    public class LocationRepository: ILocationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LocationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddNewLocation(string city, string street, int houseNumber, int apartmentNumber)
        {
            Location location = new Location(city, street, houseNumber, apartmentNumber);
            _dbContext.Add(location);
            _dbContext.SaveChanges();            
        }

        //public void UpdateApartmentNumber(int apartmentNumber, int newApartmentNumber)
        //{
        //    throw new System.NotImplementedException();

        //}

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
