using pokedex.Models;
using pokedex.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace pokedex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private readonly IPokemonService _service;
        public PokemonsController(IPokemonService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PokemonDto>> Get()
        {
            var pokemonList = _service.GetAllItems();
            return Ok(pokemonList);
        }

        [HttpGet("{id: int}")]
        public ActionResult<PokemonDto> GetById(int id)
        {
            var pokemon = _service.GetById(id);
            if(pokemon == null)
            {
                return NotFound("Pokemon não localizado");
            }
            return Ok(pokemon);
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] PokemonDto request)
        {   
            if (request.Id == null)
            {
                return BadRequest();
            }
            var newPokemon = _service.Add(request);
            return CreatedAtAction("GetById", new { location = request.Id }, newPokemon);
        }

        
        [HttpPut("{id: int}")]
        public ActionResult Put(int id, [FromBody] PokemonDto request)
        {
            var pokemon = _service.GetById(id);
            if (pokemon == null)
            {
                return NotFound("Pokemon não localizado");
            }

            _service.Put(id, request);

            return NoContent();
        }
        

        [HttpDelete("{id: int}")]
        public ActionResult Remove(int id)
        {
            var pokemon = _service.GetById(id);
            if (pokemon == null)
            {
                return NotFound("Pokemon não localizado");
            }
            _service.Remove(id);
            return NoContent();
        }
    }
}