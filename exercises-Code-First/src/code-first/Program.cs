using code_first.Models;

namespace code_first
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new MarketContext())
            {
                db.Database.EnsureCreated();

                var newCategory = new Category
                {
                    CategoryId = db.Categories.Count() + 1,  
                    Name = "Material de Construção" 
                };

                db.Categories.Add(newCategory);
                db.SaveChanges();

                var newProduct = new Product
                {
                    ProductId = db.Products.Count() + 1,
                    Name = "Tijolo"
                };
                db.Products.Add(newProduct);
                db.SaveChanges();

                var categoriesList = from category in db.Categories
                                     orderby category.CategoryId
                                     select category;

                Console.WriteLine("Categorias: ");
                foreach (var item in categoriesList)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("\n");

                Console.WriteLine("Produtos: ");
                var productsList = from Product in db.Products
                            orderby Product.ProductId
                            select Product;
                
                foreach (var product in productsList)
                {
                    System.Console.WriteLine(product.Name);
                }

            }
        }
    }
}

