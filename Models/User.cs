using Microsoft.AspNetCore.Identity;

namespace GameList.Models;

public class User : IdentityUser
{
    public string? ImgUrl {get;set;}
}