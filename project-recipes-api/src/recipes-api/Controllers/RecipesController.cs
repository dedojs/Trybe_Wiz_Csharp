using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace recipes_api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipesController : ControllerBase
{    
    public readonly IRecipeService _service;
    
    public RecipesController(IRecipeService service)
    {
        this._service = service;        
    }

    //Read
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetRecipes());
    }

    //Read
    [HttpGet("{name}", Name = "GetRecipe")]
    public IActionResult Get(string name)
    {                
        var recipe = _service.GetRecipe(name);
        if (recipe == null)
        {
            return NotFound();
        }
        return Ok(recipe);
    }

    [HttpPost]
    public IActionResult Create([FromBody]Recipe recipe)
    {
        if (recipe == null)
        {
            return BadRequest();
        }

        _service.AddRecipe(recipe);

        return CreatedAtRoute("GetRecipe", new { name = recipe.Name }, recipe);
    }

    [HttpPut("{name}")]
    public IActionResult Update(string name, [FromBody]Recipe recipe)
    {
        var newRecipe = _service.GetRecipe(name);

        if (newRecipe == null || recipe == null)
        {
            return BadRequest();
        }

        _service.UpdateRecipe(recipe);
        return NoContent();
    }

    [HttpDelete("{name}")]
    public IActionResult Delete(string name)
    {   
        var recipe = _service.GetRecipe(name);
        if (recipe == null)
        {
            return NotFound();
        }
        _service.DeleteRecipe(name);
        return NoContent();
    }    
}
