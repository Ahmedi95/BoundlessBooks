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

    public async Task<IActionResult> Index()
    {
        var books = await _HomeService.PopulateBooks();
        return View(books);
    }

}
