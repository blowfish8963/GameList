using GameList.Data;
using GameList.Models;
using Microsoft.EntityFrameworkCore;

namespace GameList.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByUsername(string username);
}

public class UserRepository : IUserRepository
{
    private MyDbContext _dbContext;
    public UserRepository(MyDbContext myDbContext)
    {
        _dbContext = myDbContext;
    }

    public async Task<User> GetUserByUsername(string username)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);
        if (user == null) throw new KeyNotFoundException();
        return user;
    }
}