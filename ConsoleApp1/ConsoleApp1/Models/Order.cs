using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    public int Id { get; }
    public int Table { get; }
    public OrderStatus Status { get; private set; } = OrderStatus.New;

    private List<MenuItem> items = new List<MenuItem>();

    public Order(int id, int table)
    {
        Id = id;
        Table = table;
    }

    public void AddItem(MenuItem item)
    {
        if (item != null)
            items.Add(item);
    }

    public void RemoveItem(string name)
    {
        items.RemoveAll(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public decimal CalculateTotal()
    {
        return items.Sum(i => i.Price);
    }

    public void UpdateStatus(OrderStatus newStatus)
    {
        Status = newStatus;
    }

    public List<MenuItem> GetItems() => items;

    public string Info()
    {
        return $"ID: {Id} | Стіл {Table} | Статус: {Status} | Сума: {CalculateTotal()} грн";
    }
}
