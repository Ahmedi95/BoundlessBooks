using BoundlessBooks.Models;
using BoundlessBooks.Data;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBooks.Services;

public class CartService
{
    // Private field to hold the reference to the database context
    private readonly BoundlessBooksDBContext _dbContext;

    // Constructor for CartService, which takes a BoundlessBooksDBContext as a dependency
    public CartService(BoundlessBooksDBContext dbContext)
    {
        // Assigning the provided database context to the private field
        _dbContext = dbContext;
    }

    // returning the book details of the parsed bookId
    public async Task<Book> GetBookDetails(int bookId)
    {
        // Assuming _dbContext is your Entity Framework DbContext
        Book? book = await _dbContext.Books
            .Where(b => b.Id == bookId)
            .FirstOrDefaultAsync();

        return book ?? new Book();
    }
}