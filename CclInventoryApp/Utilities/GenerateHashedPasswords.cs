using System;
using CclInventoryApp.Utilities;

public class GenerateHashedPasswords
{
    public static void Main()
    {
        var password1Hash = PasswordHasher.HashPassword("Password123");
        var password2Hash = PasswordHasher.HashPassword("Password123");

        Console.WriteLine("Hashed password for user1: " + password1Hash);
        Console.WriteLine("Hashed password for user2: " + password2Hash);
    }
}
