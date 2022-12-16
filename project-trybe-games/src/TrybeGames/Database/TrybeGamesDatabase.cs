using System.Numerics;

namespace TrybeGames;

public class TrybeGamesDatabase
{
    public List<Game> Games = new List<Game>();

    public List<GameStudio> GameStudios = new List<GameStudio>();

    public List<Player> Players = new List<Player>();

    public List<Game> GetGamesDevelopedBy(GameStudio gameStudio)
    {
        //List<Game> result = new List<Game>();
        //var gameByStudio = from game in Games
        //                   where game.DeveloperStudio == gameStudio.Id
        //                   select game;

        //foreach (var item in gameByStudio)
        //{
        //    result.Add(item);
        //}
        //
        var gameByStudio = Games.Where(game => game.DeveloperStudio == gameStudio.Id).ToList();
        
        return gameByStudio;
    }

    public List<Game> GetGamesPlayedBy(Player player)
    {
        //List<Game> result = new List<Game>();

        //var gamesPlayerBy = from game in Games
        //                    where game.Players.Contains(player.Id)
        //                    select game;

        //foreach (var item in gamesPlayerBy)
        //{
        //    result.Add(item);
        //}

        var result = Games.Where(game => game.Players.Contains(player.Id)).ToList();

        return result;
    }

    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {
        //List<Game> result = new List<Game>();

        //var gamesOwnedBy = from game in Games
        //                   where playerEntry.GamesOwned.Contains(game.Id)
        //                   select game;

        //foreach (var item in gamesOwnedBy)
        //{
        //    result.Add(item);
        //}

        var result = Games.Where(game => playerEntry.GamesOwned.Contains(game.Id)).ToList();

        return result;
    }
}
