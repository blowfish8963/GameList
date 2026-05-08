using GameList.Models;
using GameList.Repositories;

namespace GameList.Services;

public interface IProfileService
{
    Task<User> GetUserByUsername(string username);
}

public class ProfileService : IProfileService
{
    public IUserRepository _userRepository;
    public ProfileService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> GetUserByUsername(string username)
    {
        return await _userRepository.GetUserByUsername(username);
    }
}