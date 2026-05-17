namespace GameList.ViewModels;

public class GameViewModel
{
    public string? Name {get;set;}
    public string? DisplayName {get;set;}
    public string? Desc {get;set;}
    public string? ImgUrl {get;set;}
    public string? BannerUrl {get;set;}
    public float BannerOffset{get;set;} = 50;
    public string? ReleaseYear {get;set;}
    public string? Developer {get;set;}
    public string? Publisher {get;set;}
    public List<GameViewPlatform>? Platforms {get;set;}
    public int FanCount {get;set;} = 0;
    public bool IsOnList {get;set;}
}

public class GameViewPlatform
{
    public string? Name {get;set;}
    public string? DisplayName {get;set;}
}