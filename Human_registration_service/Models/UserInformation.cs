using Microsoft.EntityFrameworkCore;
using System;


namespace Human_Registration_Service.Models
{
    [Index(nameof(UserName),IsUnique =true) ]
    public class UserInformation
    {
        public static UserInformation Create(string userName, string password)
        {
            var userInformation = new UserInformation();
            userInformation.UserName = userName;
    
            Authentication.Password.Encrypt(password,out byte [] Password, out byte[] Salt);
            userInformation.Password = Password;
            userInformation.Salt = Salt;
            return userInformation;


        }

        public Guid Id { get; set; }
        
        public string UserName { get; set;}
        public byte[] Password { get; set;}
        public byte[] Salt { get; set; }
        public string Role { get; set;}


        public HumanInformation HumanInformationLink { get; set; }
        
    }
}
