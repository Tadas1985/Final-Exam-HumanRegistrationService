using Human_Registration_Service.Context;
using Human_Registration_Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public bool AddNewUser(string userName, string password)
        {
            UserInformation userInformation = UserInformation.Create(userName, password);
            _context.UserInformation.Add(userInformation);
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }

        }

        public bool DeleteUser(string userName)
        {
            //_context.UserInformation.RemoveRange(_context.UserInformation.Where(x => x.UserName == userName).Include(x => x.HumanInformationLink));
            var users = _context.UserInformation.Where(x => x.UserName == userName).Include(x => x.HumanInformationLink).Include(x => x.HumanInformationLink.LocationLink);
            var currentUser = users.ToArray()[0];

            if (currentUser.HumanInformationLink != null)
            {
                if (currentUser.HumanInformationLink.LocationLink != null)
                {
                    _context.Remove(currentUser.HumanInformationLink.LocationLink);
                }
                _context.Remove(currentUser.HumanInformationLink);
            }
            _context.Remove(currentUser);
            return _context.SaveChanges()>0;
        }
        public UserInformation GetUserByName(string name)
        {
            var users = _context.UserInformation.Where(x => x.UserName == name);
            if (users.Count() == 0)
            {
                return null;
            }
            _context.Entry(users.ToArray()[0]).Reload();
            return users.ToArray()[0];
        }
        
        public bool LogIn(string userName, string password, out string role)
        {
           
            role = null;
            var currentUser = GetUserByName(userName);
            if (currentUser == null)
                return false;   
            Authentication.Password.EncryptWithSalt(password, out byte []passwordHash, currentUser.Salt);
            
            if (currentUser.Password.SequenceEqual(passwordHash))
            {
                //var jwt = new Authentication.JwtService();
                role = currentUser.Role;
                return true;
                    
            }
            
            return false;           
            
        }
        public Guid FindIdByUserName(string userName)
        {
            var currentUser = GetUserByName(userName);
            if(currentUser == null)
                return Guid.Empty;
            return currentUser.Id;
        }
    }
}
