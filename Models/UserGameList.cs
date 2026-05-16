namespace GameList.Models;

public class UserGameList
{
    public int Id {get;set;}
    public int UserId {get;set;}
    public List<Game>? Games {get;set;}
    public List<string>? FavoriteGames {get;set;}
    public List<string>? FavoritePlatforms {get;set;}
    public List<string>? FavoriteCharacters {get;set;}
}