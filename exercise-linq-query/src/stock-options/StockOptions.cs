namespace stock_options;

using System.Linq;
public class StockOptions
{
  private IStockService stockOptions;
  public StockOptions(IStockService stocks)
  {
    this.stockOptions = stocks;
  }

  /// <summary>
  /// This function find the best stock option for the given stock
  /// </summary>
  /// <param name="symbol"> A string to be find</param>
  /// <returns>A stock</returns>
  public IStock? getStock(string symbol)
  {
        //var result = from stocks in stockOptions.stocks()
        //             where stocks.symbol == symbol
        //             select stocks;

        //return result.FirstOrDefault();

        return stockOptions.stocks().Where(stock => stock.symbol == symbol).FirstOrDefault();
  }

  /// <summary>
  /// This function find the best stock option for the price range given
  /// </summary>
  /// <param name="type"> A string to be find</param>
  /// <param name="minPrice"> A double to be find</param>
  /// /// <param name="maxPrice"> A double to be find</param>
  /// <returns>A stock</returns>

  public IStock? recomendStock(string type, double minPrice, double maxPrice)
  {
    //var result = from stocks in stockOptions.stocks()
    //             where stocks.type == type
    //             where stocks.lastPrice >= minPrice
    //             where stocks.lastPrice <= maxPrice
    //             select stocks;

    var result = stockOptions.stocks()
            .Where(stocks => stocks.type == type && stocks.lastPrice >= minPrice && stocks.lastPrice <= maxPrice);

    return result.FirstOrDefault();
  }
}
