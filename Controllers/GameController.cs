using Microsoft.AspNetCore.Mvc;
using GameList.Services;

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
    public async Task<IActionResult> Game(string name)
    {
        var game = await _gameService.GetGameByName(name);
        return View(game);
    }
}