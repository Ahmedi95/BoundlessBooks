using BoundlessBooks.Models;
using BoundlessBooks.Data;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBooks.Services;

public class HomeService
{
    // Private field to hold the reference to the database context
    private readonly BoundlessBooksDBContext _dbContext;

    // Constructor for HomeService, which takes a BoundlessBooksDBContext as a dependency
    public HomeService(BoundlessBooksDBContext dbContext)
    {
        // Assigning the provided database context to the private field
        _dbContext = dbContext;
    }

    // populates the list of books
    public async Task<List<Book>> PopulateBooks()
    {
        var books = await _dbContext.Books.Include(b => b.AuthorNavigation).ToListAsync();
        return books;
    }
}