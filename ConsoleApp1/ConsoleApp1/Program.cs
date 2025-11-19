using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Restaurant restaurant = new Restaurant();

        // Додавання меню
        restaurant.Menu.Add(new Dish("Борщ", 120, "Перше"));
        restaurant.Menu.Add(new Dish("Паста", 150, "Гаряче"));
        restaurant.Menu.Add(new Dish("Деруни", 110, "Гаряче"));

        restaurant.Menu.Add(new Drink("Кава", 60, "Напій", 200, false));
        restaurant.Menu.Add(new Drink("Сік апельсиновий", 70, "Напій", 250, false));
        restaurant.Menu.Add(new Drink("Вино", 120, "Напій", 150, true));

        restaurant.Menu.Display();

        Order order101 = restaurant.CreateOrder(5);

        order101.AddItem(restaurant.Menu.FindItemByName("Борщ"));
        order101.AddItem(restaurant.Menu.FindItemByName("Кава"));

        Console.WriteLine($"Сума замовлення {order101.Id}: {order101.CalculateTotal()} грн");

        order101.UpdateStatus(OrderStatus.InProgress);
        order101.UpdateStatus(OrderStatus.Ready);
        order101.UpdateStatus(OrderStatus.Paid);

        Order order102 = restaurant.CreateOrder(2);
        order102.AddItem(restaurant.Menu.FindItemByName("Деруни"));
        order102.AddItem(restaurant.Menu.FindItemByName("Вино"));

        order102.UpdateStatus(OrderStatus.InProgress);

        restaurant.DisplayAllOrders();

        Console.WriteLine("\n--- ДЕМОНСТРАЦІЯ DOWNCAST ---");

        MenuItem juice = restaurant.Menu.FindItemByName("Сік апельсиновий");

        if (juice is Drink d)
        {
            Console.WriteLine($"Напій: {d.Name}, об'єм {d.Volume} мл.");
        }

        Console.ReadLine();
    }
}
