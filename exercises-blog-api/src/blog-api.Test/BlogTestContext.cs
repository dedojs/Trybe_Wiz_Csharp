namespace blog_api.Test;

using Microsoft.EntityFrameworkCore;
using blog_api.Models;
using Microsoft.Extensions.DependencyInjection;

public class BlogTestContext : DbContext
{
  public DbSet<Post> Posts { get; set; } = default!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        //usamos a função UseInMemoryDatabase() para indicar que usaremos um banco de dados utilizando a memória interna 
        optionsBuilder.UseInMemoryDatabase("Posts").UseInternalServiceProvider(serviceProvider);
    }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
        modelBuilder.Entity<Post>()
            .HasKey(b => b.PostId);

        modelBuilder.Entity<Post>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Posts)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}