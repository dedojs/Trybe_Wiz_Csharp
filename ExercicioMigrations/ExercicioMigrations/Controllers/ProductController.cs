using ExercicioMigrations.Data;
using ExercicioMigrations.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioMigrations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult AdicionarProduto([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpGet]
        public ActionResult ListarProdutos()
        {
            return Ok(_context.Products.ToList());
        }

        
    }
}
