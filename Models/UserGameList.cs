using System.ComponentModel.DataAnnotations;

namespace GameList.Models;

public class UserGameList
{
    [Key]
    public string? Username {get;set;}
    public List<GameListEntry>? Entries{get;set;} = new List<GameListEntry>();
    public List<string>? FavoriteGames {get;set;}
    public List<string>? FavoritePlatforms {get;set;}
    public List<string>? FavoriteCharacters {get;set;}
}