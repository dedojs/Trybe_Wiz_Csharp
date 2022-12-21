using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Services
{
    public class PokemonDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }

        public PokemonDto(int? id, string? name, string? type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public PokemonDto()
        {

        }
    }
}
