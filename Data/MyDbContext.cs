using GameList.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameList.Data;

public class MyDbContext : IdentityDbContext<User>
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    public DbSet<Game> Games {get;set;}
    public DbSet<Platform> Platforms {get;set;}
    public DbSet<UserGameList> UserGameLists {get;set;}
}