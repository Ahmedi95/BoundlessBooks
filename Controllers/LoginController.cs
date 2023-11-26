using Microsoft.AspNetCore.Mvc;
using BoundlessBooks.Models;
using BoundlessBooks.Services;

namespace BoundlessBooks.Controllers;

public class LoginController : Controller
{
    // Private field to store an instance of LoginService
    private readonly LoginService _loginService;

    // Constructor for LoginController, taking LoginService as a dependency
    public LoginController(LoginService loginService)
    {
        // Assigning the provided LoginService instance to the private field
        _loginService = loginService;
    }

    public IActionResult Index()
    {
        // Assuming that "Login" view is in the "Views/UserAuth" folder
        return View("~/Views/UserAuth/login.cshtml");
    }

    [HttpPost]
    public IActionResult Login(string userName, string password)
    {
        try
        {
            // Attempting to register the user using the SaveUser method in RegisterService
            bool isValidLogin = _loginService.LoginUser(userName, password);

            if (isValidLogin)
            {
                return Json(new { success = true, message = "Login successful" });
            }
            else
            {
                return Json(new { success = false, message = "Login failed" });
            }
        }
        catch (ArgumentException ex)
        {

            return Json(new { success = false, message = ex });
        }
    }
}
