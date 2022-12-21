using pokedex.Models;
using pokedex.Controllers;
using pokedex.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
using pokemon.Test;
using FluentAssertions;
using System.Xml.Linq;

namespace pokedex.Test
{
    public class PokemonsControllerTest
    {
        public readonly PokemonsController _controller;
        public readonly PokemonServiceFake _service;
        public PokemonsControllerTest()
        {
            _service = new PokemonServiceFake();
            _controller = new PokemonsController(_service);
        }

        // Testes GET
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var pokemonsList = _controller.Get();

            pokemonsList.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllPokemons()
        {
            var pokemonList = _controller.Get();
            var list = _service.GetAllItems();

            //list.Should().HaveCount(6);
            var result = pokemonList.Result.Should().BeOfType<OkObjectResult>().Subject; // tranforma em algo concreto
            var resultList = result.Value.Should().BeAssignableTo<IEnumerable<PokemonCatched>>().Subject;
            resultList.Should().HaveCount(list.Count());
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var pokemonList = _controller.GetById(7);

            pokemonList.Result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            var pokemonList = _controller.GetById(6);

            pokemonList.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            var pokemonList = _controller.GetById(6);
            var list = _service.GetById(6);

            var result = pokemonList.Result.Should().BeOfType<OkObjectResult>().Subject; // tranforma em algo concreto
            var resultList = result.Value.Should().BeAssignableTo<PokemonCatched>().Subject;
            resultList.Should().Be(list);
            resultList.Name.Should().Be("Alakazam");
        }

        // Testes POST
        [Fact]
        public void Add_PokemonWithoutId_ReturnsBadRequest()
        {
            var newPokemon = new PokemonDto() { Name = "testename", Type = "testetipo" };
            var response = _controller.Post(newPokemon);

            response.Should().BeOfType<BadRequestResult>(); // tranforma em algo concreto
        }

        [Fact]
        public void Add_ValidPokemonPassed_ReturnsCreatedResponse()
        {
            var newPokemon = new PokemonDto(12, "testename", "testetipo");
            var response = _controller.Post(newPokemon);

            response.Should().BeOfType<CreatedAtActionResult>(); // tranforma em algo concreto
        }

        [Fact]
        public void Add_ValidPokemonPassed_ReturnedResponseHasCreatedItem()
        {
            var newPokemon = new PokemonDto(12, "testename", "testetipo");
            var response = _controller.Post(newPokemon);

            var responseObject = response.Should().BeOfType<CreatedAtActionResult>().Subject; // tranforma em algo concreto
            var responseObjectValue = responseObject.Value.Should().BeAssignableTo<PokemonCatched>().Subject;
            responseObjectValue.Name.Should().Be("testename");
            responseObjectValue.Type.Should().Be("testetipo");
        }

        // Testes PUT
        [Fact]
        public void PutById_ExistingIdPassed_ReturnsOkResult()
        {
            var pokemon = _service.GetById(1);
            pokemon.Name.Should().Be("Charizard");

            var newPokemon = new PokemonDto(1, "Picachu", "Eletric");

            var resultPokemon = _controller.Put(1, newPokemon);
            var resultPokemonStatus = resultPokemon.Should().BeOfType<NoContentResult>().Subject;
            var newRequest = _service.GetById(1);
            newRequest.Name.Should().Be("Picachu");
        }

        [Fact]
        public void PutById_IdNotFound_ReturnsNotFoundResult()
        {
            var newPokemon = new PokemonDto(1, "Picachu", "Eletric");
            var resultPokemon = _controller.Put(9, newPokemon);
            resultPokemon.Should().BeOfType<NotFoundObjectResult>();
        }


        // Testes DELETE
        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            var resultPokemon = _controller.Remove(9);
            resultPokemon.Should().BeOfType<NotFoundObjectResult>();
        }
        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            var pokemonList = _service.GetAllItems();
            pokemonList.Should().HaveCount(6);

            var resultPokemon = _controller.Remove(1);
            resultPokemon.Should().BeOfType<NoContentResult>();
            _service.GetAllItems().Should().HaveCount(5);
        }

    }
}