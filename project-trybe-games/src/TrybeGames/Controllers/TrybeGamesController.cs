using System.Globalization;

namespace TrybeGames;
public class TrybeGamesController
{
    public TrybeGamesDatabase database;

    public IConsole Console;

    public TrybeGamesController(TrybeGamesDatabase database, IConsole console)
    {
        this.database = database;
        this.Console = console;
    }

    public void RemovePlayerFromGame(Game game)
    {
        var playersPlayingGame = database.Players.Where(p => game.Players.Contains(p.Id)).ToList();
        var player = SelectPlayer(playersPlayingGame);
        if (player == null)
        {
            Console.WriteLine("Pessoa jogadora não encontrado!");
            return;
        }
        game.RemovePlayer(player);
        Console.WriteLine("Pessoa jogadora removido com sucesso!");
    }

    public void AddPlayerToGame(Game gameToAdd)
    {
        var playersNotPlayingGame = database.Players.Where(p => !gameToAdd.Players.Contains(p.Id)).ToList();
        var player = SelectPlayer(playersNotPlayingGame);
        if (player == null)
        {
            Console.WriteLine("Pessoa jogadora não encontrada!");
            return;
        }
        gameToAdd.AddPlayer(player);
        Console.WriteLine("Pessoa jogadora adicionada com sucesso!");
    }

    public void QueryGamesFromStudio()
    {
        var gameStudio = SelectGameStudio(database.GameStudios);
        if (gameStudio == null)
        {
            Console.WriteLine("Opção inválida! Tente novamente.");
            return;
        }

        try
        {
            var games = database.GetGamesDevelopedBy(gameStudio);
            Console.WriteLine("Jogos do estúdio de jogos " + gameStudio.Name + ":");
            foreach (var game in games)
            {
                Console.WriteLine(game.Name);
            }
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("Ainda não é possível realizar essa funcionalidade!");
            return;
        }
    }

    public void QueryGamesPlayedByPlayer()
    {
        var player = SelectPlayer(database.Players);
        if (player == null)
        {
            Console.WriteLine("Pessoa jogadora não encontrada!");
            return;
        }
        try {
            var games = database.GetGamesPlayedBy(player);
            if (games.Count() == 0)
            {
                Console.WriteLine("Pessoa jogadora não jogou nenhum jogo!");
                return;
            }
            Console.WriteLine("Jogos jogados pela pessoa jogadora " + player.Name + ":");
            foreach (var game in games)
            {
                Console.WriteLine(game.Name);
            }
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("Ainda não é possível realizar essa funcionalidade!");
            return;
        }

    }

    public void QueryGamesBoughtByPlayer()
    {
        var player = SelectPlayer(database.Players);
        if (player == null)
        {
            Console.WriteLine("Pessoa jogadora não encontrada!");
            return;
        }
        try {
            var games = database.GetGamesOwnedBy(player);
            Console.WriteLine("Jogos comprados pela pessoa jogadora " + player.Name + ":");
            foreach (var game in games)
            {
                Console.WriteLine(game.Name);
            }
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("Ainda não é possível realizar essa funcionalidade!");
            return;
        }
    }

    public void AddPlayer()
    {
        Player jogador = new Player();
        string namePlayer = "";

        while (string.IsNullOrEmpty(namePlayer))
        {
            System.Console.Write("Digite o Nome do Jogador: ");
            namePlayer = Console.ReadLine();
        }
        
        jogador.Id = database.Players.Count + 1;
        jogador.Name = namePlayer;

        try
        {
            database.Players.Add(jogador);
            System.Console.WriteLine($"\nJogador {jogador.Name} adicionado com sucesso\n");
        }
        catch(Exception err)
        {
            System.Console.WriteLine(err.Message);
        }
       
    }

    public void AddGameStudio()
    {
        GameStudio studio = new GameStudio();
        string nameStudio = "";

        while (string.IsNullOrEmpty(nameStudio))
        {
            System.Console.Write("Digite o Nome do Studio: ");
            nameStudio = Console.ReadLine();
        }

        studio.Id = database.GameStudios.Count + 1;
        studio.Name = nameStudio;

        try
        {
            database.GameStudios.Add(studio);
            System.Console.WriteLine($"\nStudio {studio.Name} adicionado com sucesso\n");
        }
        catch (Exception err)
        {
            System.Console.WriteLine(err.Message);
        }
    }

    public void AddGame()
    {
        Game newGame = new Game();
        string nameGame = "";
        DateTime releaseDate = new();
        GameType type = GameType.Other;

        while (string.IsNullOrEmpty(nameGame))
        {
            System.Console.Write("Digite o Nome do Game: ");
            nameGame = Console.ReadLine();
        }

        System.Console.Write("Digite a data de lançamento do Game ex: (dd/mm/aaaa): ");
        string date = Console.ReadLine();
        releaseDate = DateTime.Parse(date, new CultureInfo("pt-BR"));
        
        System.Console.WriteLine("Informe o gênero do Game: ");
        List<string> types = new List<string>()
        {
            "Ação", "Aventura", "Puzzle", "Estratégia", "Simulação", "Esportes", "Outro"
        };

        for (int i = 0; i < types.Count; i++)
        {
            System.Console.WriteLine($"{i + 1} - {types[i]}");
        }
        string option = Console.ReadLine();
        var enumType = Enum.TryParse(option, out type);

        //System.Console.WriteLine("Informe o studio do Game: ");
        //foreach (var item in database.GameStudios)
        //{
        //    System.Console.WriteLine($"{item.Id} - {item.Name}");
        //}
        //int idDeveloperStudio = int.Parse(Console.ReadLine());

        newGame.Id = database.Games.Count + 1;
        newGame.Name = nameGame;
        newGame.ReleaseDate = releaseDate;
        newGame.GameType = type;
        // newGame.DeveloperStudio = idDeveloperStudio;

        try
        {
            database.Games.Add(newGame);
            System.Console.WriteLine($"\nGame {newGame.Id} - {newGame.Name} adicionado com sucesso\n");
        }
        catch (Exception err)
        {
            System.Console.WriteLine(err.Message);
        }
    }

    public void ChangeGameStudio(Game game)
    {
        var gameStudio = SelectGameStudio(database.GameStudios);
        if (gameStudio == null)
        {
            Console.WriteLine("Opção inválida! Tente novamente.");
            return;
        }
        game.DeveloperStudio = gameStudio.Id;
        Console.WriteLine("Estúdio de jogos alterado com sucesso!");
    }

    public void AddGameStudioToFavorites(Player player)
    {
        var notFavoriteStudios = database.GameStudios.Where(s => !player.FavoriteGameStudios.Contains(s.Id)).ToList();
        var gameStudio = SelectGameStudio(notFavoriteStudios);
        if (gameStudio == null)
        {
            Console.WriteLine("Nenhum estúdio de jogos encontrado!");
            return;
        }
        player.AddGameStudioToFavorites(gameStudio);
    }

    public void BuyGame(Player player)
    {
        var gamesNotOwned = database.Games.Where(g => !player.GamesOwned.Contains(g.Id)).ToList();
        var game = SelectGame(gamesNotOwned);
        if (game == null)
        {
            Console.WriteLine("Jogo não encontrado!");
            return;
        }
        player.BuyGame(game);
        Console.WriteLine("Jogo comprado com sucesso!");
    }

    public Player SelectPlayer(List<Player> players)
    {
        Console.WriteLine("Selecione o jogador:");
        PrintPlayers(players);
        var playerId = int.Parse(Console.ReadLine() ?? "0");
        return players.FirstOrDefault(p => p.Id == playerId);
    }

    public Game SelectGame(List<Game> games)
    {
        Console.WriteLine("Selecione o jogo:");
        PrintGames(games);
        var gameId = int.Parse(Console.ReadLine() ?? "0");
        return games.FirstOrDefault(g => g.Id == gameId);
    }

    public GameStudio SelectGameStudio(List<GameStudio> gameStudios)
    {
        Console.WriteLine("Selecione o estúdio de jogos:");
        PrintGameStudios(gameStudios);
        var gameStudioId = int.Parse(Console.ReadLine() ?? "0");
        return gameStudios.FirstOrDefault(gs => gs.Id == gameStudioId);
    }

    public void PrintGames(List<Game> games)
    {
        foreach (var game in games)
        {
            Console.WriteLine(game.Id + " - " + game.Name);
        }
    }

    public void PrintGameStudios(List<GameStudio> gameStudios)
    {
        foreach (var gameStudio in gameStudios)
        {
            Console.WriteLine(gameStudio.Id + " - " + gameStudio.Name);
        }
    }

    public void PrintPlayers(List<Player> players)
    {
        foreach (var player in players)
        {
            Console.WriteLine(player.Id + " - " + player.Name);
        }
    }

    public void PrintGameTypes()
    {
        Console.WriteLine("1 - Ação");
        Console.WriteLine("2 - Aventura");
        Console.WriteLine("3 - Puzzle");
        Console.WriteLine("4 - Estratégia");
        Console.WriteLine("5 - Simulação");
        Console.WriteLine("6 - Esportes");
        Console.WriteLine("7 - Outro");
    }
}