namespace Human_Registration_Service.Services
{
    public interface ILocationRepository
    {
        public bool AddNewLocation(string userName, string city, string street, int houseNumber, int apartmentNumber);
        //public void UpdateCity(string city, string newCity);
        //public void UpdateStreet(string streetName, string newStreetName);
        //public void UpdateHouseNUmber(int houseNumber, int newHouseNUmber);
        public void UpdateApartmentNumber(string userName, int newApartmentNumber);
    }
}
