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

    public async Task<List<Book>> SearchBooks(string searchQuery)
    {
        if (string.IsNullOrEmpty(searchQuery))
        {
            // Return all books if no search query is provided
            return await _dbContext.Books.Include(b => b.AuthorNavigation).ToListAsync();
        }

        // Return books with titles containing the search query
        return await _dbContext.Books
            .Where(b => b.Title.Contains(searchQuery))
            .Include(b => b.AuthorNavigation)
            .ToListAsync();
    }
}