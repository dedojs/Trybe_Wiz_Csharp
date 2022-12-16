namespace TikTakToe;

public class TikTakToeGame
{
    public char[,] board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
    public char currentPlayer = 'x';
    public char winner = ' ';

    public void printBoard()
    {   
        /*
        for(int x = 0; x < 3; x++)
        {
            string printLine = "";
            for(int y = 0; y < 3; y++)
            {
                printLine += board[x, y];
            }
            Console.WriteLine(printLine.Trim());
        }
        */
        Console.WriteLine($"{board[0, 0]} {board[0, 1]} {board[0, 2]}");
        Console.WriteLine($"{board[1, 0]} {board[1, 1]} {board[1, 2]}");
        Console.WriteLine($"{board[2, 0]} {board[2, 1]} {board[2, 2]}");

    }

    public void makeMove(int line, int column, char player)
    {
        board[line, column] = player;
    }

    public bool isGameOver()
    {
        throw new NotImplementedException();
    }

    public void printResults()
    {
        if(winner == ' ') {
            Console.WriteLine("Empate! Deu Velha!");
        }
        else {
            Console.WriteLine($"O jogador {winner} venceu!");
        }
    }

    public char getCurrentPlayer()
    {
        return currentPlayer;
    }

    public int[] getPlayerEntry()
    {
        Console.WriteLine("Jogador " + currentPlayer + " informe a linha:");
        string input = Console.ReadLine() ?? "";
        int line = int.Parse(input);

        Console.WriteLine("Jogador " + currentPlayer + " informe a coluna:");
        input = Console.ReadLine() ?? "";
        int column = int.Parse(input);

        return new int[] { line, column };
    }

    public void changePlayer()
    {
        if(currentPlayer == 'x')
        {
            currentPlayer = 'o';
        }
        else
        {
            currentPlayer = 'x';
        }
    }
}
