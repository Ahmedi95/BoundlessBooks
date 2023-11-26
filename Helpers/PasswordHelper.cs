using System.Security.Cryptography;

namespace BoundlessBooks.Helpers;

public class PasswordHelper
{
    // generating the salt for each user
    public static byte[] GenerateSalt()
    {
        using var rng = RandomNumberGenerator.Create();
        byte[] salt = new byte[32];
        rng.GetBytes(salt);
        return salt;
    }

    // hashing the password for security purposes
    public static byte[] HashPassword(string password, byte[] salt)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
        return pbkdf2.GetBytes(32);
    }
}