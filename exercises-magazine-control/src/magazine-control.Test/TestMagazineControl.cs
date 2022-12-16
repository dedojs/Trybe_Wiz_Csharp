using Xunit;
using FluentAssertions;
using System;
using System.Collections.Generic;

namespace magazine_control.Test;

public class TestMagazineControl
{
    [Theory(DisplayName = "Deveria adicionar a revista na lista")]
    [MemberData(nameof(TestSaveMagazineData))]
    public void TestSaveMagazine(List<string> magazines, string name, List<string> expectedMagazines, int expectedReturn)
    {
        var instance = new MagazineControl(magazines);

        var indiceRevistaInserida = instance.SaveMagazine(name);

        instance.Magazines.Should().BeEquivalentTo(expectedMagazines);
        indiceRevistaInserida.Should().Be(expectedReturn);

    }
    public static TheoryData<List<string>, string, List<string>, int> TestSaveMagazineData = new()
    {
        {
            new List<string>(){ "Mundo TI", "Natureza Espetacular" },
            "Escola Nova",
            new List<string>(){ "Mundo TI", "Natureza Espetacular", "Escola Nova" },
            2
        },
        {
            new List<string>(){ "Mundo TI", "Natureza Espetacular" }, 
            "Casa Bela",
            new List<string>(){ "Mundo TI", "Natureza Espetacular", "Casa Bela" },
            2
        },
        {
            new List<string>(){ "Natureza Espetacular" },
            "Aviação Civil",
            new List<string>(){ "Natureza Espetacular", "Aviação Civil" },
            1
        },
    };


    [Theory(DisplayName = "Deveria retornar o índice da revista")]
    [MemberData(nameof(TestFindMagazinePositionData))]
    public void TestFindMagazinePosition(List<string> magazines, string name, int expectedValue)
    {
        var instance = new MagazineControl(magazines);

        var indiceRevistaInserida = instance.FindMagazinePosition(name);

        indiceRevistaInserida.Should().Be(expectedValue);
    }
    public static TheoryData<List<string>, string, int> TestFindMagazinePositionData = new TheoryData<List<string>, string, int>
    {
        { new List<string>(){ "Mundo TI", "Escola Nova", "Casa Bonita", "Natureza Espetacular" }, "Escola Nova", 1 },
        { new List<string>(){ "Mundo TI", "Escola Nova", "Casa Bonita", "Natureza Espetacular" }, "Casa Bela", -1 },
        { new List<string>(){ "Mundo TI", "Escola Nova", "Casa Bonita", "Natureza Espetacular" }, "Aviação Civil", -1 },
    };
}