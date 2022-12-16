namespace delivery_server;
public class Item
{
    public string Name { get; private set; }
    public double Price { get; private set; }
    public int TimeToPrepare { get; private set; }

    public Item(string name, double price, int timeToPrepare)
    {
        Name = name;
        Price = price;
        TimeToPrepare = timeToPrepare;
    }
}
