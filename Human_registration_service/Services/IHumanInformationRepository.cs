using Human_Registration_Service.Models;
using System;
using System.Collections.Generic;

namespace Human_Registration_Service.Services
{
    public interface IHumanInformationRepository

    {
        //public HumanInformationRepository SignUpNewAccount(string name, string lastName, string email, string password, int phoneNumber, int personalNumber);
        //public HumanInformationRepository CreateAccount(string userName, string lastName, string email, string password);
        //public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        //public bool Login(string userName, string password);
        //public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        //public IEnumerable<HumanInformationRepository> GetUser();

        public bool AddNewHuman(string userName, string name, string lastName, UInt64 personalNumber, UInt64 phoneNumber, string email, byte[] profileImage);
        public HumanInformation GetHumanInformation(string UserName);
        public byte[] GetHumanInformationPhotoBytes(string UserName);
        public void UpdateName(string userName, string name);
        public void UpdatePhoneNumber(string userName, UInt64 newPhoneNumber);
        public void UpdatePersonalNumber(string userName, UInt64 newPersonalNumber);
        public void UpdateEmail(string userName, string newEmail);

    }
}
