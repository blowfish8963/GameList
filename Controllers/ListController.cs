using GameList.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameList.Controllers;

[ApiController]
[Route("List")]
public class ListController : Controller
{
    private readonly IListService _listService;
    public ListController (IListService listService)
    {
        _listService = listService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToList([FromForm] string game, string status = "testing")
    {
        string? username = User.Identity.Name.ToString();
        if (username is null) RedirectToAction("Login", "Account");
        await _listService.AddToList(game, username, status);
        return Redirect("~/Game/"+game);
    }
}