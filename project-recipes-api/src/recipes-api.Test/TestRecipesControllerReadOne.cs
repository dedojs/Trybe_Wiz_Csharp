using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System;
using recipes_api.Models;
using recipes_api.Services;
using recipes_api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace recipes_api.Test;

public class TestRecipesControllerReadOne
{
    public readonly RecipesController _controller;
    public readonly RecipeService _service;

    public TestRecipesControllerReadOne()
    {
        _service = new RecipeService();
        _controller = new RecipesController(_service);
    }
    public static IEnumerable<object[]> RecipeServiceTestData()
    {
        yield return new object[]
        {
            "coxinha",
            new Recipe { Name = "Coxinha",
                        RecipeType = RecipesType.salty,
                        PreparationTime = 0.4,
                        Ingredients = new List<string> {"4 xícaras de trigo", "4 xícaras de leite", "1 caldo de galinha", "1/2 colher de margarina"},
                        Directions = "Leve ao fogo o leite, a margarina e o caldo. Deixe ferver. Despeje de uma só vez o trigo e mexa bem. Depois retire da panela e coloque sobre a mesa. Sove um pouco e comece a modelar as coxinhas. Coloque para fritar em óleo quente, espere dourar, retire e sirva.",
                        Rating = 7
            }
        };
        yield return new object[]
        {
            "pudim de leite",
            new Recipe { Name = "Pudim de Leite",
                        RecipeType = RecipesType.sweet,
                        PreparationTime = 1.1,
                        Ingredients = new List<string> {"1 xícara (chá) de açúcar", "1 lata de leite condensado", "2 latas de leite (medida da lata de leite condensado)", "3 ovos"},
                        Directions = "Bata todos os ingredientes do pudim no liquidificador e despeje na forma reservada. Asse em banho-maria, em forno médio (180º C), por cerca de 1 hora e 30 minutos. Depois de frio, leve para gelar por cerca de 6 horas. Desenforme e sirva a seguir.",
                        Rating = 9
            }
        };
       
    }

    [Theory]
    [MemberData(nameof(RecipeServiceTestData))]
    public void TestReadOne(string entryName, Recipe expected)
    {
        var result = _controller.Get(entryName);
        var response = result.Should().BeOfType<OkObjectResult>().Subject;
        response.Value.Should().BeEquivalentTo(expected);
    }
}