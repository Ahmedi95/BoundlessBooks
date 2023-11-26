using BoundlessBooks.Models;
using BoundlessBooks.Data;
using BoundlessBooks.Helpers;

namespace BoundlessBooks.Services;

public class LoginService
{

    private readonly BoundlessBooksDBContext _dbContext;

    public LoginService(BoundlessBooksDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    // validates the user details for login
    public static List<string> ValidateUserDetails(string userName, string password)
    {
        List<string> errors = new();

        // Validate UserName
        if (string.IsNullOrEmpty(userName))
        {
            errors.Add("UserName is required.");
        }

        // Validate Password
        if (string.IsNullOrEmpty(password) || password.Length < 8)
        {
            errors.Add("Password must be at least 8 characters.");
        }

        return errors;
    }

    public bool LoginUser(string userName, string password)
    {
        // Validate username and password
        List<string> validationErrors = ValidateUserDetails(userName, password);

        if (validationErrors.Count > 0)
        {
            throw new ArgumentException("Invalid user details");
        }

        // Checks if a user with the same username already exists
        if (_dbContext.Users.Any(u => u.UserName == userName))
        {
            // extracting existing user details
            User? existingUser = _dbContext.Users.FirstOrDefault(u => u.UserName == userName);

            if (existingUser == null)
            {
                // Handle the case where the user is not found
                return false;
            }

            byte[] salt = Convert.FromBase64String(existingUser.Salt);

            // Hashing the provided password with the retrieved salt
            byte[] hashedPassword = PasswordHelper.HashPassword(password, salt);

            // Checking if the hashed password matches the existing user's password
            if (Convert.ToBase64String(hashedPassword) == existingUser.Password)
            {
                // Passwords match, no need to update
                return true;
            }
            else
            {
                return false; // passwords do not match}
            }
        }
        else
        {
            // User with the same username does not exists, return false
            return false;

        }
    }
}