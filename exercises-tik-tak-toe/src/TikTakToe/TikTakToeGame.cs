namespace TikTakToe;

public class TikTakToeGame
{
    public char[,] board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
    public char currentPlayer = 'x';
    public char winner = ' ';

    public void printBoard()
    {
        Console.WriteLine($"{board[0, 0]} {board[0, 1]} {board[0, 2]}");
        Console.WriteLine($"{board[1, 0]} {board[1, 1]} {board[1, 2]}");
        Console.WriteLine($"{board[2, 0]} {board[2, 1]} {board[2, 2]}");
    }

    public void makeMove(int line, int column, char player)
    {
        if (board[line, column] == ' ')
        {
            board[line, column] = player;
        } else {
            Console.WriteLine("Escolha outra posição");
        }
    }

    public bool isWinner(char player)
    {
        if (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player)
        {
            return true;
        }
        if (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player)
        {
            return true;
        }
        if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player)
        {
            return true;
        }
        if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player)
        {
            return true;
        }
        if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player)
        {
            return true;
        }
        if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player)
        {
            return true;
        }
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
        {
            return true;
        }
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
        {
            return true;
        }
        return false;
    }

    public bool isGameOver()
    {
        if (isWinner('x'))
        {
            winner = 'x';
            return true;
        }
        else if (isWinner('o'))
        {
            winner = 'o';
            return true;
        }
        else
        {
            winner = ' ';
            return false;
        }
    }

    public void printResults()
    {
        if(winner == ' ') {
            Console.WriteLine("Empate! Deu velha!");
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
