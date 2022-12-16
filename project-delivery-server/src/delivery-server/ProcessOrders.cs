using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace delivery_server;

public class ProcessOrders
{
    public List<Order> OrdersList;
    public int TimeToCheck;

    public ProcessOrders()
    {
        TimeToCheck = 1;
        OrdersList = new List<Order>();
        Console.WriteLine("SERVER:> Controlador de delivery iniciado!");
        this.DeliveryReadyOrders(TimeSpan.FromSeconds(TimeToCheck));    
    }

    public void AddOrder(Item item, int quantity)
    {
        var order = new Order(item, quantity);
        OrdersList.Add(order);
        Console.WriteLine($"SERVER:> {quantity} * {item.Name}");
    }

    async Task DeliveryReadyOrders(TimeSpan timeSpan)
    {
        var periodicTimer = new PeriodicTimer(timeSpan);
        while (await periodicTimer.WaitForNextTickAsync())
        {
            //var orderIsReady = from order in OrdersList
            //                   where order.IsReady == true
            //                   where order.IsSend == false
            //                   select order;

            var orderToSend = OrdersList.Where(order => order.IsReady && !order.IsSend);

            foreach (var order in orderToSend)
            {
                Console.WriteLine($"SERVER:> O pedido de {order.Quantity} {order.Item.Name} no valor de {order.OrderPrice} Reais foi enviado!");
                order.IsSend = true;
            }
            
            if (orderToSend.Count() == 0)
            {
                Console.WriteLine("SERVER:> Nenhum pedido está pronto para enviar!");
            }
            
        }
    }

}
