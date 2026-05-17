using GameList.Data;
using GameList.Models;
using Microsoft.EntityFrameworkCore;

namespace GameList.Repositories;

public interface IGameRepository
{
    Task<Game> GetGameByName(string name);
    Task<Platform> GetPlatformByName(string name);
    Task<List<Game>> GetPopularGames();
    Task<UserGameList> GetGameListByUsername(string username);
}

public class GameRepository : IGameRepository
{
    private MyDbContext _dbContext;
    public GameRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Game> GetGameByName(string name)
    {
        var game = await _dbContext.Games.Include(x => x.Platforms).FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        if (game == null) throw new KeyNotFoundException();
        return game;
    }

    public async Task<Platform> GetPlatformByName(string name)
    {
        var platform = await _dbContext.Platforms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        if (platform == null) throw new KeyNotFoundException();
        return platform;
    }

     public async Task<List<Game>> GetPopularGames()
    {
        var games = await _dbContext.Games
            .OrderBy(x => x.FanCount)
            .ThenBy(x => x.DisplayName)
            .ToListAsync();
        return games;
    }   

    public async Task<UserGameList> GetGameListByUsername(string username)
    {
        var list = await _dbContext.UserGameLists.FirstOrDefaultAsync(x => x.Username == username);
        return list;
    }
}