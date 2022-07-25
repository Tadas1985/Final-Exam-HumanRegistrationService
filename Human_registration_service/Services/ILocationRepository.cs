namespace Human_Registration_Service.Services
{
    public interface ILocationRepository
    {
        public bool AddNewLocation(string userName, string city, string street, int houseNumber, int apartmentNumber);
        public void UpdateCity(string userName, string newCity);
        public void UpdateStreet(string userName, string newStreetName);
        public void UpdateHouseNumber(string userName, int newHouseNUmber);
        public void UpdateApartmentNumber(string userName, int newApartmentNumber);
    }
}
