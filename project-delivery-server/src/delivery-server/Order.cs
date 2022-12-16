using System;
using System.Threading;

namespace delivery_server;

public class Order
{
    public Item Item { get; set; }
    public int Quantity { get; set; }
    public double OrderPrice { get; }
    public bool IsReady { get; set; }
    public bool IsSend { get; set; }
    public int Delay { get; set; }

    public Order(Item item, int quantity)
    {
        Item = item;
        Quantity = quantity;
        OrderPrice = item.Price * quantity;
        IsReady = false;
        IsSend = false;

        Task.Run(() => this.Process());
    }

    public async Task Process()
    {
        var delay = Item.TimeToPrepare * Quantity;
        Thread.Sleep(delay);
        IsReady = true;
        Delay = delay;
    }
}
