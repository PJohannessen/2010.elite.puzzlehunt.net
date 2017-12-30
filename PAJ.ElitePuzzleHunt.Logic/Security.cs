using System;
using System.Text;
using System.Security.Cryptography;

namespace PAJ.ElitePuzzleHunt.Logic
{
    public class Security
    {
        public string HashPassword(string unencryptedPassword, Guid salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(salt + unencryptedPassword);
            byte[] inArray = HashAlgorithm.Create("SHA512").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}
