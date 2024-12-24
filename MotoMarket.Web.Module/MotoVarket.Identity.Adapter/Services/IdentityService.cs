using MotoVarket.Identity.Adapter.Interfaces;
using System.Security.Cryptography;

namespace MotoVarket.Identity.Adapter.Services
{
    public class IdentityService : IIdentityService
    {
        public string HashPassword(string password)
        {
            var salt = GenerateSalt();

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000)) // 100000 итераций
            {
                byte[] hash = pbkdf2.GetBytes(32); // Длина хеша 32 байта
                byte[] hashBytes = new byte[64];
                Buffer.BlockCopy(salt, 0, hashBytes, 0, salt.Length);
                Buffer.BlockCopy(hash, 0, hashBytes, salt.Length, hash.Length);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            throw new NotImplementedException();
        }

        private static byte[] GenerateSalt(int size = 16)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[size];
                rng.GetBytes(salt);
                return salt;
            }
        }
    }
}
