using BoundlessBooks.Models;
using Microsoft.AspNetCore.Mvc;
using BoundlessBooks.Services;

namespace BoundlessBooks.Controllers;

public class RegisterController : Controller
{
    // Private field to store an instance of RegisterService
    private readonly RegisterService _registerService;

    // Constructor for RegisterController, taking RegisterService as a dependency
    public RegisterController(RegisterService registerService)
    {
        // Assigning the provided RegisterService instance to the private field
        _registerService = registerService;
    }

    // default action that displays the register view
    public IActionResult Index()
    {
        // returns the registration view
        return View("~/Views/UserAuth/register.cshtml");
    }

    [HttpPost]
    // registering a new user
    public async Task<IActionResult> RegisterUser(User user)
    {
        try
        {
            // registering the user using the SaveUser method in RegisterService
            bool isRegisteredUser = await _registerService.SaveUser(user);

            if (isRegisteredUser)
            {
                return Json(new { success = true, message = "Registration Successful" });
            }
            else
            {
                return Json(new { success = false, message = "Registration failed" });
            }
        }
        catch (ArgumentException ex)
        {

            return Json(new { success = false, message = ex });
        }
    }

}
