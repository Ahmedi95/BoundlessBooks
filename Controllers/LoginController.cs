using Microsoft.AspNetCore.Mvc;
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

    // default action to return the login view
    public IActionResult Index()
    {
        return View("~/Views/UserAuth/login.cshtml");
    }

    [HttpPost]
    // post method to register a user
    public IActionResult Login(string userName, string password)
    {
        try
        {
            // Attempting to register the user using the SaveUser method in RegisterService
            bool isValidLogin = _loginService.LoginUser(userName, password);

            if (isValidLogin)
            {
                // clearing the session
                HttpContext.Session.Clear();
                // adding the username in the session for user authentication
                HttpContext.Session.SetString("Username", userName);

                return Json(new { success = true, message = "Login Successful" });
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
