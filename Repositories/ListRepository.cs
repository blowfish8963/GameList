using GameList.Data;
using GameList.Models;

namespace GameList.Repositories;

public interface IListRepository
{
    Task AddToList(UserGameList userGameList);
}
public class ListRepository : IListRepository
{
    private MyDbContext _dbContext;
    public ListRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddToList(UserGameList userGameList)
    {
        _dbContext.UserGameLists.Update(userGameList);
        await _dbContext.SaveChangesAsync();
    }
}