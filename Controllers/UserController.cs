using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BoundlessBooks.Models;
using BoundlessBooks.Services;

using BoundlessBooks.Helpers;
namespace BoundlessBooks.Controllers;

public class UserController : Controller
{
    // Private field to store an instance of UserService
    private readonly UserService _UserService;

    // Constructor for UserController, taking UserService as a dependency
    public UserController(UserService UserService)
    {
        // Assigning the provided UserService instance to the private field
        _UserService = UserService;
    }

    // Add this action to your controller
    [HttpGet]
    public IActionResult GetUserDetails(string username)
    {
        var user = _UserService.GetUserByUsername(username);
        return Json(user);
    }



}