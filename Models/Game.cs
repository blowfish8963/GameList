namespace GameList.Models;

public class Game
{
    public int Id {get;set;}
    public string? Name {get;set;}
    public string? DisplayName {get;set;}
    public string? Desc {get;set;}
    public string? ImgUrl {get;set;}
    public string? BannerUrl {get;set;}
    public List<Platform>? Platforms {get;set;}
    public int FanCount {get;set;}
}