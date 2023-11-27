using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BoundlessBooks.Models;
using BoundlessBooks.Services;
using BoundlessBooks.Helpers;


namespace BoundlessBooks.Controllers;

public class CartController : Controller
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    public async Task AddToCart(int bookId)
    {
        Book book = await _cartService.GetBookDetails(bookId);

        // Get the existing cart items from the session
        var cartItems = HttpContext.Session.GetObjectFromJson<List<Book>>("CartItems") ?? new List<Book>();

        // Add the new book to the cart
        cartItems.Add(book);

        // Save the updated cart items back to the session
        HttpContext.Session.SetObjectAsJson("CartItems", cartItems);

    }

    public IActionResult RemoveItem(int bookId)
    {
        // Get the existing cart items from the session
        var cartItems = HttpContext.Session.GetObjectFromJson<List<Book>>("CartItems") ?? new List<Book>();

        // Remove the item with the specified bookId
        var itemToRemove = cartItems.FirstOrDefault(item => item.Id == bookId);
        if (itemToRemove != null)
        {
            cartItems.Remove(itemToRemove);

            // Save the updated cart items back to the session
            HttpContext.Session.SetObjectAsJson("CartItems", cartItems);

            // Optionally, you can return a success message or any relevant data
            return Json(new { success = true, message = "Item removed successfully" });
        }
        else
        {
            // Return an error message if the item was not found
            return Json(new { success = false, message = "Item not found in the cart" });
        }
    }
}
