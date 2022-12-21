using CustomerCrud.Core;
using CustomerCrud.Repositories;
using CustomerCrud.Requests;

namespace CustomerCrud.Test;

public class CustomersControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly Mock<ICustomerRepository> _repositoryMock;

    public CustomersControllerTest(WebApplicationFactory<Program> factory)
    {
        _repositoryMock = new Mock<ICustomerRepository>();

        _client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<ICustomerRepository>(st => _repositoryMock.Object);
            });
        }).CreateClient();
    }

    [Fact]
    public async Task GetAllTest()
    {
        var customers = AutoFaker.Generate<Customer>(3);
        _repositoryMock.Setup(st => st.GetAll()).Returns(customers);

        var response = await _client.GetAsync("/customers");
        var content = await response.Content.ReadFromJsonAsync<IEnumerable<Customer>>();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(customers);
        _repositoryMock.Verify(st => st.GetAll(), Times.Once);
    }

    [Fact]
    public async Task GetByIdTest()
    {
        var customers = AutoFaker.Generate<Customer>();
        customers.Id = 1;
        _repositoryMock.Setup(st => st.GetById(1)).Returns(customers);
        
        var response = await _client.GetAsync($"/customers/1");
        var content = await response.Content.ReadFromJsonAsync<Customer>();
        
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(customers);
        _repositoryMock.Verify(st => st.GetById(1), Times.Once);
    }

    [Fact]
    public async Task CreateTest()
    {
        var customer = AutoFaker.Generate<Customer>();
        customer.Id = 1;
        _repositoryMock.Setup(st => st.GetNextIdValue()).Returns(1);
        _repositoryMock.Setup(st => st.Create(customer)).Returns(true);

        var response = await _client.PostAsJsonAsync($"/customers", customer);
        var content = await response.Content.ReadFromJsonAsync<Customer>();

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        content.Id.Should().Be(1);
        content.Name.Should().Be(customer.Name);
        content.CPF.Should().Be(customer.CPF);
        content.Transactions.Should().BeEquivalentTo(customer.Transactions);
        content.CreatedAt.Should().BeCloseTo(content.UpdatedAt, TimeSpan.FromMilliseconds(100));

        _repositoryMock.Verify(st => st.GetNextIdValue(), Times.Once);
        _repositoryMock.Verify(st => st.Create(It.IsAny<Customer>()), Times.Once);
    }

    [Fact]
    public async Task UpdateTest()
    {
        var customer = AutoFaker.Generate<Customer>();
        customer.Id = 1;

        _repositoryMock.Setup(st => st
            .Update(It.Is<int>(id => id == 1), It.IsAny<object>()))
            .Returns(true);

        var response = await _client.PutAsJsonAsync($"/customers/1", customer);
        var content = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().Be($"Customer 1 updated");

        _repositoryMock.Verify(st => st.Update(It.Is<int>(id => id == 1), It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task DeleteTest()
    {
        var customer = AutoFaker.Generate<Customer>();
        customer.Id = 1;

        _repositoryMock.Setup(st => st.Delete(1)).Returns(true);

        var response = await _client.DeleteAsync($"/customers/1");
        var content = await response.Content.ReadAsStringAsync();

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        _repositoryMock.Verify(st => st.Delete(1), Times.Once);
    }
}