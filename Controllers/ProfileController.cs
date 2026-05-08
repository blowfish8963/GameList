using Microsoft.AspNetCore.Mvc;
using GameList.Services;

namespace GameList.Controllers;

public class ProfileController : Controller
{
    private readonly IProfileService _profileService;
    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [Route("Profile/{username}")]
    public async Task<IActionResult> Profile(string username)
    {
        var user = await _profileService.GetUserByUsername(username);

        return View();
    }
}