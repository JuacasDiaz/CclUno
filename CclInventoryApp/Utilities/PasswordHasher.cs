using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CclInventoryApp.Utilities
{
    // CLASE PARA HASHEAR CONTRASEÑAS
    public class PasswordHasher
    {
        // MÉTODO PARA HASHEAR UNA CONTRASEÑA
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        // MÉTODO PARA VERIFICAR UNA CONTRASEÑA
        public static bool VerifyPassword(string hashedPassword, string password)
        {
            var parts = hashedPassword.Split('.');
            if (parts.Length != 2)
            {
                throw new FormatException("Unexpected hash format.");
            }

            var salt = Convert.FromBase64String(parts[0]);
            var storedHash = parts[1];

            var hashToCompare = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return storedHash == hashToCompare;
        }
    }
}
