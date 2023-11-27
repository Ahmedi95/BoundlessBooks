using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BoundlessBooks.Models;
using BoundlessBooks.Services;

namespace BoundlessBooks.Controllers;

public class HomeController : Controller
{
    // Private field to store an instance of HomeService
    private readonly HomeService _HomeService;

    // Constructor for LoginController, taking HomeService as a dependency
    public HomeController(HomeService HomeService)
    {
        // Assigning the provided HomeService instance to the private field
        _HomeService = HomeService;
    }

    // displays the home view and returns the books list
    public async Task<IActionResult> Index()
    {
        var books = await _HomeService.PopulateBooks();
        return View(books);
    }

    // search by title
    public async Task<IActionResult> Search(string searchQuery)
    {
        var books = await _HomeService.SearchBooks(searchQuery);
        return PartialView("_BookListPartial", books);
    }

}
