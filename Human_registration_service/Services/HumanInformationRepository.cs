using Human_Registration_Service.Context;
using Human_Registration_Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public bool AddNewHuman(string userName, string name, string lastName, ulong personalNumber, ulong phoneNumber, string email, byte[] profileImage)
        {
            // Paklausk Sergejaus del ko neveikia sitas metodas. (Nemato ankciau issaugotu yrasu)
            var userInformationRepository = new UserInformationRepository(_context);
            var currentUser = userInformationRepository.GetUserByName(userName);
            if (currentUser.HumanInformationLink != null)
                return false;
            //var userId = userInformationRepository.FindIdByUserName(userName);
            HumanInformation humanInformation = new HumanInformation(name, lastName, personalNumber, phoneNumber, email, profileImage); 
            _context.Add(humanInformation);
            _context.SaveChanges();
            
            currentUser.HumanInformationLink = humanInformation;
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
        public byte[] GetHumanInformationPhotoBytes(string UserName)
        {

            var users = _context.UserInformation.Where(x => x.UserName == UserName).Include(x => x.HumanInformationLink);
            if (users.ToArray().Count() == 0)
            {
                return null;
            }
            return users.ToArray()[0].HumanInformationLink.ProfileImage;
        }

        public IEnumerable<HumanInformation> GetUser()
        {
            return _context.HumanInformation;
        }

        public void UpdateName(string userName, string name)
        {

            var users = _context.UserInformation.Where(x => x.UserName == userName).Include(x => x.HumanInformationLink);
            users.ToArray()[0].HumanInformationLink.Name = name;

            _context.SaveChanges();
            
        }

        public void UpdatePhoneNumber(UInt64 phoneNumber, UInt64 newPhoneNumber)
        {
            var information = _context.HumanInformation.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefault();
            information.PhoneNumber = newPhoneNumber;
            _context.SaveChanges();            
        }
        public void UpdatePersonalNumber(UInt64 personalNumber, UInt64 newPersonalNumber)
        {
            var information = _context.HumanInformation.Where(x => x.PersonalNumber == personalNumber).FirstOrDefault();
            information.PersonalNumber = newPersonalNumber;
            _context.SaveChanges();
        }

        public void UpdateEmail(string email, string newEmail)
        {
            var information = _context.HumanInformation.Where(x=> x.Email == email).FirstOrDefault();
            information.Email = newEmail;
            _context.SaveChanges();
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
