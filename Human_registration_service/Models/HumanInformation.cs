using System;
using System.Collections.Generic;

namespace Human_Registration_Service.Models
{
    public class HumanInformation
    {
        public HumanInformation(string name, string lastName, ulong personalNumber, ulong phoneNumber, string email, byte[] profileImage)
        {
            Name = name;
            LastName = lastName;
            PersonalNumber = personalNumber;
            PhoneNumber = phoneNumber;
            Email = email;
            ProfileImage = profileImage;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public UInt64 PersonalNumber { get; set; }
        public UInt64 PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] ProfileImage { get; set; }
        public Location LocationLink { get; set; }
        
       
    }
}



// paleidziam migracijas su: Add-MIgration name
// paleidziam migracijas su: Update_Database