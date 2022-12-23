using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System;
using recipes_api.Models;
using recipes_api.Services;
using recipes_api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace recipes_api.Test;

public class TestRecipesControllerUpdate
{
    public readonly RecipesController _controller;
    public readonly RecipeService _service;

    public TestRecipesControllerUpdate()
    {
        _service = new RecipeService();
        _controller = new RecipesController(_service);
    }
    public static IEnumerable<object[]> RecipeServiceTestData()
    {
        yield return new object[]
        {
            "Coxinha",
            new Recipe {
                        Name = "Coxinha",
                        RecipeType = RecipesType.sweet,
                        PreparationTime = 1.4,
                        Ingredients = new List<string> {"4 x�caras de trigo", "4 x�caras de leite", "1 caldo de galinha", "1/2 colher de margarina"},
                        Directions = "Leve ao fogo o leite, a margarina e o caldo. Deixe ferver. Despeje de uma s� vez o trigo e mexa bem. Depois retire da panela e coloque sobre a mesa. Sove um pouco e comece a modelar as coxinhas. Coloque para fritar em �leo quente, espere dourar, retire e sirva.",
                        Rating = 7
                        },
            new List<Recipe>
            {
                new Recipe { Name = "Bolo de cenoura",
                            RecipeType = RecipesType.sweet,
                            PreparationTime = 0.4,
                            Ingredients = new List<string> {"1/2 x�cara (ch�) de �leo", "3 cenouras m�dias raladas", "4 ovos", "2 x�caras (ch�) de a��car", "2 e 1/2 x�caras (ch�) de farinha de trigo", "1 colher (sopa) de fermento em p�"},
                            Directions = "Em um liquidificador, adicione a cenoura, os ovos e o �leo, depois misture. Acrescente o a��car e bata novamente por 5 minutos. Em uma tigela ou na batedeira, adicione a farinha de trigo e depois misture novamente. Acrescente o fermento e misture lentamente com uma colher. Asse em um forno preaquecido a 180� C por aproximadamente 40 minutos.",
                            Rating = 10},
                new Recipe { Name = "Coxinha",
                            RecipeType = RecipesType.sweet,
                            PreparationTime = 1.4,
                            Ingredients = new List<string> {"4 x�caras de trigo", "4 x�caras de leite", "1 caldo de galinha", "1/2 colher de margarina"},
                            Directions = "Leve ao fogo o leite, a margarina e o caldo. Deixe ferver. Despeje de uma s� vez o trigo e mexa bem. Depois retire da panela e coloque sobre a mesa. Sove um pouco e comece a modelar as coxinhas. Coloque para fritar em �leo quente, espere dourar, retire e sirva.",
                            Rating = 7},
                new Recipe { Name = "Pudim de Leite",
                            RecipeType = RecipesType.sweet,
                            PreparationTime = 1.1,
                            Ingredients = new List<string> {"1 x�cara (ch�) de a��car", "1 lata de leite condensado", "2 latas de leite (medida da lata de leite condensado)", "3 ovos"},
                            Directions = "Bata todos os ingredientes do pudim no liquidificador e despeje na forma reservada. Asse em banho-maria, em forno m�dio (180� C), por cerca de 1 hora e 30 minutos. Depois de frio, leve para gelar por cerca de 6 horas. Desenforme e sirva a seguir.",
                            Rating = 9}
            }
        };
    }

    [Theory]
    [MemberData(nameof(RecipeServiceTestData))]
    public void TestUpdate(string entryName, Recipe entryRecipe, List<Recipe> expected)
    {
        var response = _controller.Update(entryName, entryRecipe);
        response.Should().BeOfType<NoContentResult>();
        var listRecipes = _service.GetRecipes();
        listRecipes.Should().BeEquivalentTo(expected);
        
    }
}