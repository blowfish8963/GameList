using GameList.Repositories;
using GameList.ViewModels;

namespace GameList.Services;

public interface IGameService
{
    public Task<GameViewModel> GetGameByName(string name, string? username);
    Task<PlatformViewModel> GetPlatformByName(string name);
    Task<List<PopularViewModel>> GetPopularGames();
}
public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    public async Task<GameViewModel> GetGameByName(string name, string? username)
    {
        var game = await _gameRepository.GetGameByName(name);
        var plaftorms = new List<GameViewPlatform>();
        foreach (var p in game.Platforms.OrderBy(x => x.ReleaseYear))
        {
            plaftorms.Add(new GameViewPlatform
            {
                Name = p.Name,
                DisplayName = p.DisplayName
            });
        }
        return new GameViewModel
        {
            Name = game.Name,
            DisplayName = game.DisplayName,
            Desc = game.Desc,
            ImgUrl = game.ImgUrl,
            BannerUrl = game.BannerUrl,
            BannerOffset = game.BannerOffset,
            Platforms = plaftorms,
            FanCount = game.FanCount,
            Developer = game.Developer,
            Publisher = game.Publisher,
            ReleaseYear = game.ReleaseYear,
            IsOnList = username == null ? false : await IsOnList(game.Name, username)
        };
    }

    public async Task<bool> IsOnList(string game, string username)
    {
        return await _gameRepository.IsOnList(game, username);
    }
    
    public async Task<PlatformViewModel> GetPlatformByName(string name)
    {
        var platform = await _gameRepository.GetPlatformByName(name);
        return new PlatformViewModel
        {
            Name = platform.Name,
            DisplayName = platform.DisplayName,
            Desc = platform.Desc,
            ImgUrl = platform.ImgUrl,
            BannerUrl = platform.BannerUrl,
            BannerOffset = platform.BannerOffset,
            ReleaseYear = platform.ReleaseYear,
            Company = platform.Company,
            FanCount = platform.FanCount
        };
    }

    public async Task<List<PopularViewModel>> GetPopularGames()
    {
        var games = await _gameRepository.GetPopularGames();
        var popularViewModels = new List<PopularViewModel>();
        foreach (var g in games)
        {
            popularViewModels.Add(new PopularViewModel()
            {
                Name = g.Name,
                DisplayName = g.DisplayName,
                ImgUrl = g.ImgUrl,
                FanCount = g.FanCount.ToString()
            });
        }
        return popularViewModels;
    }
}