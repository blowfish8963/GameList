using System.ComponentModel.DataAnnotations;

namespace GameList.Models;

public class GameListEntry
{
    [Required]
    [Key]
    public string? GameName {get;set;}
    [Required]
    public string? EntryStatus {get;set;}
    public string? EntryRating {get;set;} = null;
    [Required]
    public UserGameList? List {get;set;}
}