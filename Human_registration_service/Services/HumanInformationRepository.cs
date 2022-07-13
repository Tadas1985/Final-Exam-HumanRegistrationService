using Human_Registration_Service.Context;
using Human_Registration_Service.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Human_Registration_Service.Services
{
    public class HumanInformationRepository :IHumanInformationRepository
    {
        private readonly ApplicationDbContext _context;

        public HumanInformationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddNewHuman(string name, string lastName, ulong personalNumber, ulong phoneNumber, string email, byte[] profileImage)
        {
            HumanInformation humanInformation = new HumanInformation(name, lastName, personalNumber, phoneNumber, email, profileImage); 
            _context.Add(humanInformation);
            _context.SaveChanges();
            return true;
        }

        public HumanInformation GetHumanInformation(string UserName)
        {
            
            var users =_context.UserInformation.Where(x => x.UserName == UserName).Include(x =>x.HumanInformationLink);
            if (users.ToArray().Count() == 0)
            {
                return null;
            }
            return users.ToArray()[0].HumanInformationLink;
        }

        public IEnumerable<HumanInformation> GetUser()
        {
            return _context.HumanInformation;
        }
        //public HumanInformation CreateAccount(string userName, string lastName, string email, string password)
        //{
        //    CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        //    var user = new HumanInformation();
        //    user.Name = userName;
        //    user.Email = email;
        //    user.LastName = lastName;
        //    user.PasswordSalt = passwordSalt;
        //    user.PasswordHash = passwordHash;
        //    return user;
        //}

    }
}
