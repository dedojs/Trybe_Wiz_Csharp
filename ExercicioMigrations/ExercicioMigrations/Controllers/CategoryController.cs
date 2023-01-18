using ExercicioMigrations.Data;
using ExercicioMigrations.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioMigrations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private ProductContext _context;
        public CategoryController(ProductContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult AdicionarCategory([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpGet]
        public ActionResult ListarCategories()
        {
            return Ok(_context.Categories.ToList());
        }
    }
}
