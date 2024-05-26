using System;
using BCrypt.Net;

namespace CclInventoryApp.Utilities
{
    // CLASE PARA HASHEAR CONTRASEÑAS
    public class PasswordHasher
    {
        // MÉTODO PARA HASHEAR UNA CONTRASEÑA
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 12); // 12 es el costo (rounds)
        }

        // MÉTODO PARA VERIFICAR UNA CONTRASEÑA
        public static bool VerifyPassword(string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
