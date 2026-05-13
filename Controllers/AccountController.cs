using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GameList.Models;
using GameList.ViewModels;

namespace GameList.Controllers;

public class AccountController : Controller
{    
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }
        var user = new User()
        {
            UserName = viewModel.Username,
            Email = viewModel.Email
        };
        var result = await _userManager.CreateAsync(user, viewModel.Password);

        if (result.Succeeded)
        {
            return RedirectToAction("Login", "Account");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(viewModel);
        }
    }

    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }
        var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, viewModel.RememberMe, lockoutOnFailure: false);
        
        if (result.Succeeded) 
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError("", "Incorrect username or password.");
            return View(viewModel);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}