namespace EShop.Models
{
    public class Client
    {
        public int ClientIdentity { get; set; }
        public string Name { get; set; }

        public List<Order> Orders { get; set; }

        public Order Order { get; set; }
    }
}
