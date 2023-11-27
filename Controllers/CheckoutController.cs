using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BoundlessBooks.Models;
using BoundlessBooks.Services;
using BoundlessBooks.Helpers;

namespace BoundlessBooks.Controllers;

public class CheckoutController : Controller
{
    // Private field to store an instance of CheckoutService
    private readonly CheckoutService _CheckoutService;
    private readonly UserService _UserService;

    // Constructor for CheckoutController, taking both CheckoutService and UserService as dependencies
    public CheckoutController(CheckoutService checkoutService, UserService userService)
    {
        // Assigning the provided instances to the private fields
        _CheckoutService = checkoutService;
        _UserService = userService;
    }

    // default action to return the checkout view
    public IActionResult Index()
    {
        return View("~/Views/checkout.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> CompletePurchase(string address)
    {
        var username = HttpContext.Session.GetString("Username");

        // Check if the user is logged in
        if (string.IsNullOrEmpty(username))
        {
            return RedirectToAction("Index", "Login");
        }

        // Getting user details
        var user = _UserService.GetUserByUsername(username);

        // Getting cart items from the session
        var cartItems = HttpContext.Session.GetObjectFromJson<List<Book>>("CartItems") ?? new List<Book>();

        // Calculating the total amount
        var totalAmount = cartItems.Sum(item => item.Price);

        // Inserting a new order

        int orderId = await _CheckoutService.PlaceOrder(user.Id, totalAmount, address);

        // Inserting order details for each book in the cart
        foreach (var book in cartItems)
        {
            await _CheckoutService.AddOrderDetail(orderId, book.Id, book.Price);

            // Updating the book stock quantity
            await _CheckoutService.UpdateBookStock(book.Id);
        }

        // Clearing cart items in the session
        HttpContext.Session.SetObjectAsJson("CartItems", new List<Book>());

        // Returning true to the view as a success response
        return Json(new { success = true, message = "Order placed Successful" });
    }


}