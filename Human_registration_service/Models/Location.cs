using System;

namespace Human_Registration_Service.Models
{
    public class Location
    {
     


        public Location(string city, string street, int houseNumber, int apartmentNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            ApartmentNumber = apartmentNumber;
        }

        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
