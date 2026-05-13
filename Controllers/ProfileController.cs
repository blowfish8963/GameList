using Microsoft.AspNetCore.Mvc;
using GameList.Services;

namespace GameList.Controllers;

[ApiController]
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
        var profile = await _profileService.GetUserByUsername(username);
        return View(profile);
    }
}