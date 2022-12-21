using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Models
{
    public class PokemonCatched
    {
        
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public PokemonCatched(int? id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;

        }
    }
}
