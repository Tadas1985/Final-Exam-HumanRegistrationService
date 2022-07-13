using System;
using System.Security.Cryptography;

namespace Human_Registration_Service.Authentication
{
    public class Password
    {
        public static void Encrypt(string password, out byte[] passwordHash, out byte[] passwordSalt )
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }
        public static void EncryptWithSalt(string password, out byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            hmac.Key = passwordSalt;
           // passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }
    }
}
