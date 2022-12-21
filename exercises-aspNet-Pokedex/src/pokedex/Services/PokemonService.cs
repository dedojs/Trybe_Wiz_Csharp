using pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private List<PokemonCatched> _db;

        public PokemonService()
        {
            _db = new List<PokemonCatched>();
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
        public void Put (int id, PokemonDto newDataPokemon)
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
