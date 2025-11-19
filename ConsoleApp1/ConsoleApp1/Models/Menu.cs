using System;
using System.Collections.Generic;
using System.Linq;

public class Menu : IMenuSearch
{
    private List<MenuItem> items = new List<MenuItem>();

    public void Add(MenuItem item)
    {
        items.Add(item);
    }

    public void Display()
    {
        Console.WriteLine("\n--- лемч ---");
        int i = 1;
        foreach (var item in items)
        {
            Console.Write($"{i++}. ");
            item.Display();
        }
    }

    public MenuItem FindItemByName(string name)
    {
        return items.FirstOrDefault(i =>
            i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public List<MenuItem> FindItemsByCategory(string category)
    {
        return items
            .Where(i => i.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
