using System;
using System.Collections.Generic;
using System.Linq;

public class Restaurant
{
    private int nextOrderId = 1;

    public Menu Menu { get; } = new Menu();

    private List<Order> orders = new List<Order>();

    public Order CreateOrder(int table)
    {
        Order order = new Order(nextOrderId++, table);
        orders.Add(order);
        return order;
    }

    public void DisplayAllOrders()
    {
        Console.WriteLine("\n--- ÓÑ² ÇÀÌÎÂËÅÍÍß ---");

        foreach (var order in orders)
        {
            Console.WriteLine(order.Info());

            foreach (var item in order.GetItems())
            {
                Console.WriteLine("  - " + item.GetInfo());
            }
        }
    }

    public Order FindOrder(int id)
    {
        return orders.FirstOrDefault(o => o.Id == id);
    }
}
