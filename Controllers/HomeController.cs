using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GameList.Models;
using GameList.Services;
using GameList.ViewModels;

namespace GameList.Controllers;

public class HomeController : Controller
{
    private readonly IGameService _gameService;
    public HomeController (IGameService gameService)
    {
        _gameService = gameService;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Route("Popular")]
    public async Task<IActionResult> Popular()
    {
        var popularViewModels = await _gameService.GetPopularGames();
        return View(popularViewModels);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
