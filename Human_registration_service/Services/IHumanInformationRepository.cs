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

        public bool AddNewHuman(string name, string lastName, UInt64 personalNumber, UInt64 phoneNumber, string email);

    }
}
