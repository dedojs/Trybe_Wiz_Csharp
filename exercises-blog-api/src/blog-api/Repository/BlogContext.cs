using Microsoft.EntityFrameworkCore;
using blog_api.Models;

namespace blog_api.Repository;

public class BlogContext : DbContext
{
  public DbSet<Post> Posts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
        optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=blogapi!;User=sa;Password=Password12;");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
        modelBuilder.Entity<Post>()
            .HasOne(b => b.Author) //Explicita que a entidade Book tem uma referência a Author
            .WithMany(a => a.Posts) // Define a relação como um Author para muitos Book
            .HasForeignKey(b => b.AuthorId); // Define como chave estrangeira a variável AuthorId
    }
}
