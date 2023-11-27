using BoundlessBooks.Models;
using BoundlessBooks.Data;
using BoundlessBooks.Helpers;

namespace BoundlessBooks.Services;

public class UserService
{
    // Private field to hold the reference to the database context
    private readonly BoundlessBooksDBContext _dbContext;

    // Constructor for UserService, which takes a BoundlessBooksDBContext as a dependency
    public UserService(BoundlessBooksDBContext dbContext)
    {
        // Assigning the provided database context to the private field
        _dbContext = dbContext;
    }

    // returns the user by checking for entered Username
    public User GetUserByUsername(string username)
    {
        return _dbContext.Users
            .FirstOrDefault(u => u.UserName == username) ?? new User();
    }

}