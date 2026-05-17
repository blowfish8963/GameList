using Microsoft.AspNetCore.Mvc;
using GameList.Services;
using Microsoft.AspNetCore.Identity.Data;

namespace GameList.Controllers;

[ApiController]
public class GameController : Controller
{
    private readonly IGameService _gameService;
    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [Route("Game/{name}")]
    public async Task<IActionResult> Game(string name, string? username)
    {
        var uname = User.Identity.Name;
        var game = await _gameService.GetGameByName(name, uname);
        return View(game);
    }

    [Route("Platform/{name}")]
    public async Task<IActionResult> Platform(string name)
    {
        var platform = await _gameService.GetPlatformByName(name);
        return View(platform);
    }
}