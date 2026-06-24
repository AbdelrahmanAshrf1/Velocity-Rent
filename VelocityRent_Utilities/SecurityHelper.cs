using System;
using System.Linq;
using System.Security.Cryptography;

namespace VelocityRent_Utilities
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;      // 128 bit
        private const int HashSize = 32;      // 256 bit
        private const int Iterations = 100000;

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                return Convert.ToBase64String(salt)
                       + ":"
                       + Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(
            string password,
            string storedPassword)
        {
            string[] parts = storedPassword.Split(':');

            if (parts.Length != 2)
                return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedHash = Convert.FromBase64String(parts[1]);

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                byte[] computedHash = pbkdf2.GetBytes(HashSize);

                return storedHash.SequenceEqual(computedHash);
            }
        }
    }
}