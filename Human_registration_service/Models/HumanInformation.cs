using System.Collections.Generic;

namespace Human_Registration_Service.Models
{
    public class HumanInformation
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PersonalNUmber { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Location> LivingLocation;
    }
}



// paleidziam migracijas su: Add-MIgration name
// paleidziam migracijas su: Update_Database