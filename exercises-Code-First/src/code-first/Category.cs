namespace code_first.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
        
    }
}
