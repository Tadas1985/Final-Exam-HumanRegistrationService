using System;
using System.Collections.Generic;

namespace Human_Registration_Service.Models
{
    public class HumanInformation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public UInt64 PersonalNumber { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
 
        public Location LocationLink { get; set; }
       
    }
}



// paleidziam migracijas su: Add-MIgration name
// paleidziam migracijas su: Update_Database