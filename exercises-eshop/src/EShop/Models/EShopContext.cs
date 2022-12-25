using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace EShop.Models
{
    public class EShopContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        public EShopContext(DbContextOptions<EShopContext> options)
             : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseInMemoryDatabase("EShopDb");
            
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Client>().HasKey(client => client.ClientIdentity);

            mb.Entity<Order>().HasKey(order => order.Id);

            mb.Entity<Order>()
                .HasOne(c => c.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(p => p.ClientIdentity);




        }
    }
}
