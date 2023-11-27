using BoundlessBooks.Models;
using BoundlessBooks.Data;
using BoundlessBooks.Helpers;

namespace BoundlessBooks.Services;

public class CheckoutService
{
    // Private field to hold the reference to the database context
    private readonly BoundlessBooksDBContext _dbContext;

    // Constructor for CheckoutService, which takes a BoundlessBooksDBContext as a dependency
    public CheckoutService(BoundlessBooksDBContext dbContext)
    {
        // Assigning the provided database context to the private field
        _dbContext = dbContext;
    }

}