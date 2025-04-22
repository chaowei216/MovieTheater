using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16; // 128 bits
        private const int HashSize = 32; // 256 bits
        private const int Iterations = 10000;

        public (string Hash, string Salt) HashPassword(string password)
        {
            // Generate random salt
            byte[] saltBytes = RandomNumberGenerator.GetBytes(SaltSize);
            string salt = Convert.ToBase64String(saltBytes);

            // Hash password with salt
            using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(HashSize);
            string hash = Convert.ToBase64String(hashBytes);

            return (hash, salt);
        }

        public bool VerifyPassword(string password, string hashedPassword, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(HashSize);
            string computedHash = Convert.ToBase64String(hashBytes);

            return hashedPassword == computedHash;
        }
    }
}
