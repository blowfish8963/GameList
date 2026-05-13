using GameList.Models;
using GameList.Repositories;
using GameList.ViewModels;

namespace GameList.Services;

public interface IGameService
{
    public Task<GameViewModel> GetGameByName(string name);
}
public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    public async Task<GameViewModel> GetGameByName(string name)
    {
        var game = await _gameRepository.GetGameByName(name);
        return new GameViewModel
        {
            Name = game.Name,
            DisplayName = game.DisplayName,
            Desc = game.Desc,
            ImgUrl = game.ImgUrl,
            BannerUrl = game.BannerUrl,
            BannerOffset = game.BannerOffset,
            Platforms = game.Platforms,
            FanCount = game.FanCount
        };
    }
}