using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using pokedex.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pokemon.Test
{
    public class PokemonServiceFake : IPokemonService
    {
        private readonly List<PokemonCatched> _db;
        public PokemonServiceFake()
        {
            _db = new List<PokemonCatched>()
            {                
                new PokemonCatched(1, "Charizard", "Fire"),
                new PokemonCatched(2, "Blastoise", "Water"),
                new PokemonCatched(3, "Venusaur", "Monster"),
                new PokemonCatched(4, "Onix", "Rocks"),
                new PokemonCatched(5, "Arcanine", "Fire"),
                new PokemonCatched(6, "Alakazam", "Magic")
            };
        }

        public PokemonCatched Add(PokemonDto request)
        {
            var newPokemon = new PokemonCatched(request.Id, request.Name, request.Type);
            _db.Add(newPokemon);
            return newPokemon;
        }
        public IEnumerable<PokemonCatched> GetAllItems()
        {
            return _db;
        }
        public PokemonCatched GetById(int id)
        {
            var pokemon = _db.FirstOrDefault(x => x.Id == id);
            return pokemon;
        }
        public void Put(int id, PokemonDto newDataPokemon)
        {
            var pokemon = _db.FirstOrDefault(x => x.Id == id);
            pokemon!.Name = newDataPokemon.Name;
            pokemon.Type = newDataPokemon.Type;

        }
        public void Remove(int id)
        {
            var pokemon = _db.FirstOrDefault(x => x.Id == id);
            _db.Remove(pokemon);
        }
    }
}