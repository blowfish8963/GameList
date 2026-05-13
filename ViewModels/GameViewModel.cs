using GameList.Models;

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
    public string? Publisher {get;set;}
    public List<string>? Platforms {get;set;}
    public int FanCount {get;set;} = 0;
}