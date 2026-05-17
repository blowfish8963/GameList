using System.Formats.Asn1;
using GameList.Data;
using GameList.Models;

namespace GameList.Repositories;

public interface IListRepository
{
    Task UpdateList(UserGameList userGameList);
}
public class ListRepository : IListRepository
{
    private MyDbContext _dbContext;
    public ListRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task UpdateList(UserGameList userGameList)
    {
        _dbContext.UserGameLists.Update(userGameList);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveFromList(string gamename, string username)
    {
        
    }
}