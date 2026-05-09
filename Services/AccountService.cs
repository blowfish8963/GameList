using GameList.Models;
using Microsoft.AspNetCore.Identity;
using ViewModels;

namespace GameList.Services;

public interface IAccountService
{
    Task<IdentityResult> Register(RegisterViewModel registerViewModel);
}

public class AccountService : IAccountService
{
    private UserManager<User> _userManager;
    public AccountService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task<IdentityResult> Register(RegisterViewModel viewModel)
    {
        var user = new User()
        {
            UserName = viewModel.Username,
            Email = viewModel.Email
        };
        return await _userManager.CreateAsync(user, viewModel.Password);
    }
}