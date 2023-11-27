using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BoundlessBooks.Models;
using BoundlessBooks.Services;

namespace BoundlessBooks.Controllers;

public class CheckoutController : Controller
{
    // Private field to store an instance of CheckoutService
    private readonly CheckoutService _CheckoutService;

    // Constructor for LoginController, taking CheckoutService as a dependency
    public CheckoutController(CheckoutService CheckoutService)
    {
        // Assigning the provided CheckoutService instance to the private field
        _CheckoutService = CheckoutService;
    }

    // default action to return the checkout view
    public IActionResult Index()
    {
        return View("~/Views/checkout.cshtml");
    }
}