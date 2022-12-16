using Moq;
using FluentAssertions;

namespace stock_options.Test;
public class TestStock
{
  [Theory]
  [InlineData("GOOG", "GOOG")]
  public void HasStock(string symbol, string findStock)
  {
        var stock = new Stock("Name", symbol, "5.27", "Change", "Type");

        var mockStockService = new Mock<IStockService>();
        mockStockService.Setup(s => s.stocks()).Returns(new List<IStock> { stock });

        var instance = new StockOptions(mockStockService.Object);

        var result = instance.getStock(symbol);
        
        result.symbol.Should().Be(findStock);
        
    }

  [Theory]
  [InlineData("Common", "Common", 1030.00, 1000.00, 1500.00)]
  public void HasStockRecomend(string mockType, string findType, double price, double minValue, double maxValue)
  {
        var stock = new Stock("Name", "symbol", price.ToString(), "change", mockType);

        var mockStockService = new Mock<IStockService>();
        mockStockService.Setup(s => s.stocks()).Returns(new List<IStock> { stock });

        var instance = new StockOptions(mockStockService.Object);

        var result = instance.recomendStock(findType, minValue, maxValue);
        result.Should().BeEquivalentTo(stock);
        
    }
}
