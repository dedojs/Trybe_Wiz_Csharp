namespace blog_api.Test;

using blog_api.Models;

public class BlogApiTest
{ 
  
  [Theory]
  [InlineData("Title 1", "Content 1", "Author 1", "Author 1", "author@email.com")]
  public void ShouldCreateAPost(string title, string content, string authorName, string authorAbout, string authorEmail)
  {
        var _context = new BlogTestContext();
        var _repository = new BlogRepository(_context);
        var newAuthor = new Author
        {
            Name = authorName,
            About = authorAbout,
            Email = authorEmail
        };

        var newPost = new Post
        {
            Title = title,
            Content = content,
            Author = newAuthor,
        };
        _repository.Add(newPost);
        _repository.Get<Post>(1).Should().NotBeNull();
        _repository.Get<Post>(1).Author.Name.Should().Be(newAuthor.Name);
        _repository.GetAll<Post>().Should().HaveCount(1);
  }

  [Theory]
  [InlineData(1)]
  public void ShouldDeleteAuthor(int postId)
  {
        var _context = new BlogTestContext();
        var _repository = new BlogRepository(_context);
        var newAuthor = new Author
        {
            Name = "Andre",
            About = "sobre",
            Email = "andre@email.com"
        };

        var newPost = new Post
        {
            Title = "teste",
            Content = "sobre o teste",
            Author = newAuthor,
        };

        _repository.Add(newPost);
        _repository.GetAll<Post>().Should().HaveCount(1);

        var findPost = _repository.Get<Post>(postId);
        _repository.Delete<Post>(findPost);
        _repository.GetAll<Post>().Should().HaveCount(0);
    }
}
