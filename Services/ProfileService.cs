using GameList.Repositories;
using GameList.ViewModels;

namespace GameList.Services;

public interface IProfileService
{
    Task<ProfileViewModel> GetUserByUsername(string username);
}

public class ProfileService : IProfileService
{
    public IUserRepository _userRepository;
    public ProfileService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<ProfileViewModel> GetUserByUsername(string username)
    {
        var userModel = await _userRepository.GetUserByUsername(username);
        var ProfileViewModel = new ProfileViewModel
        {
            UserName = userModel.UserName,
            ImgUrl = userModel.ImgUrl
        };
        return ProfileViewModel;
    }
}