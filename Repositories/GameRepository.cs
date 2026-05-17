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
    Task<bool> IsOnList (string game, string username);
    Task UpdateFanCount(string game);
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
            .OrderByDescending(x => x.FanCount)
            .ThenBy(x => x.DisplayName)
            .ToListAsync();
        return games;
    }   

    public async Task<UserGameList> GetGameListByUsername(string username)
    {
        var list = await _dbContext.UserGameLists.Include(x => x.Entries).FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower());
        return list;
    }

    public async Task<bool> IsOnList (string game, string username)
    {
        var gameList = await _dbContext.UserGameLists.Include(x => x.Entries).FirstOrDefaultAsync(x => x.Username == username);
        if (gameList is null) return false;

        var onList = gameList.Entries.Any(x => x.GameName == game);
        return onList;
    }

    public async Task UpdateFanCount(string game)
    {
        var fancount = 0;
        var list = await _dbContext.UserGameLists.Include(x => x.Entries).Select(x => x.Entries).ToListAsync();
        foreach (var l in list)
        {
            fancount += l.FindAll(x => x.GameName == game).Count();
        }
        var newGame = await GetGameByName(game);
        newGame.FanCount = fancount;
        _dbContext.Update(newGame);
        await _dbContext.SaveChangesAsync();
    }
}