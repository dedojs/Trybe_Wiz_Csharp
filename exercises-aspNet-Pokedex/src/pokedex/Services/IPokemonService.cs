using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Services
{
    public interface IPokemonService
    {
        public IEnumerable<PokemonCatched> GetAllItems();
        public PokemonCatched Add(PokemonDto request);
        public PokemonCatched GetById(int id);
        public void Put(int id, PokemonDto request);
        public void Remove(int id);
    }
}
