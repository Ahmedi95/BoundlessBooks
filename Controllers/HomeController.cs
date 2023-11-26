using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BoundlessBooks.Models;

namespace BoundlessBooks.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
