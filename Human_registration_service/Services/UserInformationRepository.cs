using Human_Registration_Service.Context;
using Human_Registration_Service.Models;
using System.Linq;

namespace Human_Registration_Service.Services
{
    public class UserInformationRepository : IUserInformationRepository
    {
        private readonly ApplicationDbContext _context;

        public UserInformationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserInformation AddNewUser(string userName, string password)
        {
            UserInformation userInformation = UserInformation.Create(userName, password);
            _context.UserInformation.Add(userInformation);
            _context.SaveChanges();
            return userInformation;

        }

        public bool LogIn(string userName, string password)
        {
            var users =   _context.UserInformation.Where(x => x.UserName == userName);
            if (users.Count() == 0)
            {
                return false;
            }
            
            var currentUser = users.ToArray()[0];
            Authentication.Password.EncryptWithSalt(password, out byte []passwordHash, currentUser.Salt);
            
            if (currentUser.Password.SequenceEqual(passwordHash))
            {
                return true;
            }
            
            return false;

            
            
        }
    }
}
