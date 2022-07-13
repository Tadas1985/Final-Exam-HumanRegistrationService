using System;

namespace Human_Registration_Service.DTOs
{
    public class HumanInformationDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public UInt64 PersonalNumber { get; set; }
        public UInt64 PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}
