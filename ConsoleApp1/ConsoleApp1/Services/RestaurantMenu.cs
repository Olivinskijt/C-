using System;
using System.Collections.Generic;
using System.Linq;

public class RestaurantMenu : IMenuSearch
{
    private List<MenuItem> _items = new List<MenuItem>();

    public void Add(MenuItem item)
    {
        _items.Add(item);
    }

    public void Display()
    {
        Console.WriteLine("\n--- лемч ---");
        int i = 1;
        foreach (var item in _items)
        {
            Console.Write($"{i++}. ");
            item.Display();
        }
    }

    public MenuItem FindItemByName(string name)
    {
        return _items.FirstOrDefault(i =>
            i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public List<MenuItem> FindItemsByCategory(string category)
    {
        return _items
            .Where(i => i.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
