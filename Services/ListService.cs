using GameList.Models;
using GameList.Repositories;

namespace GameList.Services;

public interface IListService
{
    Task AddToList(string gamename, string username, string status);
}
public class ListService : IListService
{
    private readonly IGameRepository _gameRepository;
    private readonly IListRepository _listRepository;
    public ListService(IGameRepository gameRepository, IListRepository listRepository)
    {
        _gameRepository = gameRepository;
        _listRepository = listRepository;
    }

    public async Task AddToList(string gamename, string username, string status)
    {
        var gameList = await _gameRepository.GetGameListByUsername(username);
        gameList.Entries.Add(new GameListEntry
        {
            List = gameList,
            GameName = gamename,
            EntryStatus = status
        });
        await _listRepository.AddToList(gameList);
    }
}