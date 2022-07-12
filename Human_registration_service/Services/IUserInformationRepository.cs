using Human_Registration_Service.Models;

namespace Human_Registration_Service.Services
{
    public interface IUserInformationRepository
    {
        public bool AddNewUser(string userName, string password);
        public bool LogIn(string userName, string password);
    }
}
