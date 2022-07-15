using Human_Registration_Service.Models;
using System;

namespace Human_Registration_Service.Services
{
    public interface IUserInformationRepository
    {
        public bool AddNewUser(string userName, string password);
        public bool LogIn(string userName, string password, out string role);

        public bool DeleteUser(string userName);
        public Guid FindIdByUserName(string userName);
       
    }
}
