using Xunit;
using System.IO;
using System;
using TikTakToe;
using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;

namespace TikTakToe.Test;

[Collection("Sequential")]
public class TestTikTakToeGame
{
    [Theory(DisplayName = "Deve preencher o tabuleiro com o caractere correto na posição adequada")]
    [InlineData(
        1,
        1,
        'x',
        new char[] {
            ' ', ' ', ' ',
            ' ', 'x', ' ',
            ' ', ' ', ' '
        }
    )]
    public void TestMakeMove(int lineEntry, int columnEntry, char playerEntry, char[] expected)
    {
        var instance = new TikTakToeGame();
        instance.makeMove(lineEntry, columnEntry, playerEntry);
        instance.board.Should().BeEquivalentTo(expected);
    }
    
    [Theory(DisplayName = "Deve imprimir o tabuleiro")]
    [InlineData(
        new char[] {
            'x', 'x', 'x',
            'x', 'x', 'x',
            'x', 'x', 'x'
        },
        new string[] {
            "x x x",
            "x x x",
            "x x x"
        }
    )]
    public void TestPrintBoard(char[] entry, string[] expected)
    {
        var game = new TikTakToeGame();
        game.board = fromArrayToMultiDimArray(entry, 3, 3);
        using var sw = new StringWriter();
        Console.SetOut( sw );
        game.printBoard();

        string[] arrayResult = sw.ToString().Split(Environment.NewLine);
        arrayResult[0].Should().Be(expected[0]);
        arrayResult[1].Should().Be(expected[1]);
        arrayResult[2].Should().Be(expected[2]);

    }

    [Theory(DisplayName = "Deve retornar corretamente se o jogo acabou ou não")]
    [InlineData(
        new char[] {
            'x', 'x', 'x',
            'x', 'x', 'x',
            'x', 'x', 'x'
        },
        'x',
        true
    )]
    public void TestIsGameOver(char[] entry, char expectedWinner, bool expectedReturn)
    {
        var game = new TikTakToeGame();
        game.board = fromArrayToMultiDimArray(entry, 3, 3); ;
        var result = game.isGameOver();
        result.Should().Be(expectedReturn);
        game.winner.Should().Be(expectedWinner);
    }

    [Theory(DisplayName = "Deve imprimir o vencedor correto do jogo")]
    [InlineData(' ', "Empate! Deu velha!")]
    public void TestPrintResults(char entry, string expected)
    {
        var game = new TikTakToeGame();
        game.winner = entry;
        using var sw = new StringWriter();
        Console.SetOut(sw);
        game.printResults();
        string result = sw.ToString().Trim();
        result.Should().Be(expected);
    }

    public static char[,] fromArrayToMultiDimArray(char[] array, int lines, int columns)
    {
        char[,] result = new char[lines, columns];
        for (int i = 0; i < array.Length; i++)
        {
            result[i / columns, i % columns] = array[i];
        }
        return result;
    }
}
