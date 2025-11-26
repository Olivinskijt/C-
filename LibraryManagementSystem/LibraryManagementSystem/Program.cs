// Олівінський Максим ПД-23, індивідуальна основа

using System;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryManager manager = new LibraryManager();

            manager.AddItem(new Book("C#", 2025, "Olivinskiy Maksym"));
            manager.AddItem(new Magazine("C# book", 2024, 15));

            foreach (var item in manager.GetAllItems())
            {
                Console.WriteLine(item.GetDisplayInfo());
            }
        }
    }
}
