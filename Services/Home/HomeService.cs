using BoundlessBooks.Models;
using BoundlessBooks.Data;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBooks.Services;

public class HomeService
{

    private readonly BoundlessBooksDBContext _dbContext;

    public HomeService(BoundlessBooksDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Book>> PopulateBooks()
    {
        var books = await _dbContext.Books.Include(b => b.AuthorNavigation).ToListAsync();
        return books;
    }
}