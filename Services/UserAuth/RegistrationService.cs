using BoundlessBooks.Models;
using BoundlessBooks.Data;
using Microsoft.EntityFrameworkCore;
using BoundlessBooks.Helpers;

namespace BoundlessBooks.Services;

public class RegisterService
{
    // Private field to hold the reference to the database context
    private readonly BoundlessBooksDBContext _dbContext;

    // Constructor for RegisterService, which takes a BoundlessBooksDBContext as a dependency
    public RegisterService(BoundlessBooksDBContext dbContext)
    {
        // Assigning the provided database context to the private field
        _dbContext = dbContext;
    }

    // validates the user details for registration
    public static List<string> ValidateUserDetails(User user)
    {
        List<string> errors = new();

        // Validate First Name
        if (string.IsNullOrEmpty(user.FirstName))
        {
            errors.Add("First Name is required.");
        }

        // Validate Last Name
        if (string.IsNullOrEmpty(user.LastName))
        {
            errors.Add("Last Name is required.");
        }

        // Validate UserName
        if (string.IsNullOrEmpty(user.UserName))
        {
            errors.Add("UserName is required.");
        }

        // Validate Password
        if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 8)
        {
            errors.Add("Password must be at least 8 characters.");
        }

        // Validate Email
        if (string.IsNullOrEmpty(user.Email))
        {
            errors.Add("Email is required and must be a valid email address.");
        }

        // Validate PhoneNumber
        if (string.IsNullOrEmpty(user.PhoneNumber))
        {
            errors.Add("PhoneNumber is required and must be a valid 10-digit phone number.");
        }

        return errors;
    }

    // saving a new user in the database
    public async Task<bool> SaveUser(User user)
    {
        List<string> validationErrors = ValidateUserDetails(user);

        if (validationErrors.Count > 0)
        {
            throw new ArgumentException("Invalid user details");
        }

        // Checks if a user with the same username already exists
        if (_dbContext.Users.Any(u => u.UserName == user.UserName))
        {
            // User with the same username already exists, return false
            return false;
        }

        // Generating a unique salt for each user
        byte[] salt = PasswordHelper.GenerateSalt();

        // Hashing the password with the generated salt
        byte[] hashedPassword = PasswordHelper.HashPassword(user.Password, salt);

        // Updating the user's salt and hashed password
        user.Salt = Convert.ToBase64String(salt);
        user.Password = Convert.ToBase64String(hashedPassword);

        _dbContext.Users.Add(user);

        try
        {
            await _dbContext.SaveChangesAsync();
            return true; // Registration successful
        }
        catch (DbUpdateException)
        {
            return false; // Registration failed
        }
    }


}