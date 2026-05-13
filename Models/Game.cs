using System.ComponentModel.DataAnnotations;

namespace GameList.Models;

public class Game
{
    public int Id {get;set;}
    [Required]
    public string? Name {get;set;}
    [Required]
    public string? DisplayName {get;set;}
    [Required]
    public string? Desc {get;set;}
    public string? ImgUrl {get;set;}
    public string? BannerUrl {get;set;}
    public float BannerOffset{get;set;} = 50;
    public string? ReleaseYear {get;set;}
    public string? Publisher {get;set;}
    public List<string>? Platforms {get;set;}
    public int FanCount {get;set;} = 0;
}