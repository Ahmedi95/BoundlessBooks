using BoundlessBooks.Models;
using BoundlessBooks.Data;
using BoundlessBooks.Helpers;

namespace BoundlessBooks.Services;

public class LoginService
{
    // Private field to hold the reference to the database context
    private readonly BoundlessBooksDBContext _dbContext;

    // Constructor for LoginService, which takes a BoundlessBooksDBContext as a dependency
    public LoginService(BoundlessBooksDBContext dbContext)
    {
        // Assigning the provided database context to the private field
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

    // method to check if user exits and validate
    public bool LoginUser(string userName, string password)
    {
        // Validate username and password
        List<string> validationErrors = ValidateUserDetails(userName, password);

        if (validationErrors.Count > 0)
        {
            throw new Exception(validationErrors.ToString());
        }

        // Checks if a user with the same username already exists
        if (_dbContext.Users.Any(u => u.UserName == userName))
        {
            // extracting existing user details
            User? existingUser = _dbContext.Users.FirstOrDefault(u => u.UserName == userName);

            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            byte[] salt = Convert.FromBase64String(existingUser.Salt);

            // Hashing the provided password with the retrieved salt
            byte[] hashedPassword = PasswordHelper.HashPassword(password, salt);

            // Checking if the hashed password matches the existing user's hashed password
            if (Convert.ToBase64String(hashedPassword) == existingUser.Password)
            {
                // Passwords match, no need to update
                return true;
            }
            else
            {
                throw new Exception("Passwords do not match");

            }
        }
        else
        {
            throw new Exception("User not found");

        }
    }
}