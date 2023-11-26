using Microsoft.AspNetCore.Mvc;

namespace BoundlessBooks.Controllers;

public class LogoutController : Controller
{
    public IActionResult Logout()
    {
        // clearing the session
        HttpContext.Session.Clear();

        // Redirecting to the login page
        return RedirectToAction("Index", "Login");
    }
}