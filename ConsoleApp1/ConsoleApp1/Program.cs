using System;
using System.Collections.Generic;
using System.Linq;

interface IMenuSearch
{
    List<MenuItem> SearchByName(string name);
    List<MenuItem> SearchByCategory(string category);
}

abstract class MenuItem
{
    public string Name { get; protected set; }
    public decimal Price { get; protected set; }
    public string Category { get; protected set; }

    protected MenuItem(string name, decimal price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

    public abstract string GetInfo();
}

class Dish : MenuItem
{
    public Dish(string name, decimal price, string category) : base(name, price, category) { }

    public override string GetInfo() => $"{Name} ({Category}) - {Price} грн";
}

class Drink : MenuItem
{
    public int Volume { get; private set; }
    public bool Alcoholic { get; private set; }

    public Drink(string name, decimal price, string category, int volume, bool alcoholic)
        : base(name, price, category)
    {
        Volume = volume;
        Alcoholic = alcoholic;
    }

    public override string GetInfo() =>
        $"{Name} ({Volume} мл, {(Alcoholic ? "алк." : "без алк.")}) - {Price} грн";
}

class Menu : IMenuSearch
{
    private List<MenuItem> items = new List<MenuItem>();

    public void Add(MenuItem item) => items.Add(item);

    public List<MenuItem> GetAll() => items;

    public List<MenuItem> SearchByName(string name) =>
        items.Where(i => i.Name.ToLower().Contains(name.ToLower())).ToList();

    public List<MenuItem> SearchByCategory(string category) =>
        items.Where(i => i.Category.ToLower() == category.ToLower()).ToList();
}

enum OrderStatus
{
    New,
    InProgress,
    Ready,
    Paid
}

class Order
{
    public int Id { get; private set; }
    public int Table { get; private set; }
    public OrderStatus Status { get; private set; } = OrderStatus.New;
    private List<MenuItem> items = new List<MenuItem>();

    public Order(int id, int table)
    {
        Id = id;
        Table = table;
    }

    public void AddItem(MenuItem item) => items.Add(item);

    public void RemoveItem(string name) =>
        items.RemoveAll(i => i.Name.ToLower() == name.ToLower());

    public decimal Total() => items.Sum(i => i.Price);

    public void SetStatus(OrderStatus status) => Status = status;

    public List<MenuItem> GetItems() => items;

    public string Info() =>
        $"ID: {Id} | Стіл {Table} | Статус: {Status} | Сума: {Total()} грн";
}

class Restaurant
{
    public Menu Menu { get; private set; } = new Menu();
    private List<Order> orders = new List<Order>();

    public void AddOrder(Order o) => orders.Add(o);

    public List<Order> GetOrders() => orders;

    public Order FindOrder(int id) =>
        orders.FirstOrDefault(o => o.Id == id);
}

class Program
{
    static Restaurant restaurant = new Restaurant();
    static int nextOrderId = 1;

    static void Main()
    {
        restaurant.Menu.Add(new Dish("Борщ", 120, "Перше"));
        restaurant.Menu.Add(new Dish("Паста", 150, "Гаряче"));
        restaurant.Menu.Add(new Drink("Кава", 60, "Напій", 200, false));
        restaurant.Menu.Add(new Drink("Сік", 70, "Напій", 250, false));
        restaurant.Menu.Add(new Drink("Пиво", 80, "Напій", 500, true));

        while (true)
        {
            Console.WriteLine("\n--- ГОЛОВНЕ МЕНЮ ---");
            Console.WriteLine("1. Переглянути меню");
            Console.WriteLine("2. Створити замовлення");
            Console.WriteLine("3. Додати позицію в замовлення");
            Console.WriteLine("4. Видалити позицію з замовлення");
            Console.WriteLine("5. Змінити статус замовлення");
            Console.WriteLine("6. Переглянути всі замовлення");
            Console.WriteLine("7. Пошук позицій у меню");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");

            string c = Console.ReadLine();
            Console.WriteLine();

            switch (c)
            {
                case "1": ShowMenu(); break;
                case "2": CreateOrder(); break;
                case "3": AddItemToOrder(); break;
                case "4": RemoveItemFromOrder(); break;
                case "5": ChangeOrderStatus(); break;
                case "6": ShowAllOrders(); break;
                case "7": SearchMenu(); break;
                case "0": return;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("--- МЕНЮ ---");
        int i = 1;
        foreach (var m in restaurant.Menu.GetAll())
            Console.WriteLine($"{i++}. {m.GetInfo()}");
    }

    static void CreateOrder()
    {
        Console.Write("Введіть номер столика: ");
        int table = int.Parse(Console.ReadLine());
        var order = new Order(nextOrderId++, table);
        restaurant.AddOrder(order);
        Console.WriteLine($"Створено замовлення ID {order.Id}");
    }

    static void AddItemToOrder()
    {
        Console.Write("ID замовлення: ");
        int id = int.Parse(Console.ReadLine());
        var order = restaurant.FindOrder(id);
        if (order == null) { Console.WriteLine("Не знайдено."); return; }

        ShowMenu();
        Console.Write("Назва позиції: ");
        string name = Console.ReadLine();

        var item = restaurant.Menu.SearchByName(name).FirstOrDefault();
        if (item == null) { Console.WriteLine("Немає в меню."); return; }

        order.AddItem(item);
        Console.WriteLine("Додано.");
    }

    static void RemoveItemFromOrder()
    {
        Console.Write("ID замовлення: ");
        int id = int.Parse(Console.ReadLine());
        var order = restaurant.FindOrder(id);
        if (order == null) { Console.WriteLine("Не знайдено."); return; }

        Console.Write("Назва позиції: ");
        string name = Console.ReadLine();
        order.RemoveItem(name);
        Console.WriteLine("Видалено.");
    }

    static void ChangeOrderStatus()
    {
        Console.Write("ID замовлення: ");
        int id = int.Parse(Console.ReadLine());
        var order = restaurant.FindOrder(id);
        if (order == null) { Console.WriteLine("Не знайдено."); return; }

        Console.WriteLine("1. New");
        Console.WriteLine("2. InProgress");
        Console.WriteLine("3. Ready");
        Console.WriteLine("4. Paid");
        Console.Write("Новий статус: ");

        int s = int.Parse(Console.ReadLine());
        order.SetStatus((OrderStatus)(s - 1));
        Console.WriteLine("Статус змінено.");
    }

    static void ShowAllOrders()
    {
        Console.WriteLine("--- УСІ ЗАМОВЛЕННЯ ---");
        foreach (var o in restaurant.GetOrders())
        {
            Console.WriteLine(o.Info());
            foreach (var it in o.GetItems())
                Console.WriteLine("  - " + it.GetInfo());
        }
    }

    static void SearchMenu()
    {
        Console.Write("Введіть назву або категорію: ");
        string q = Console.ReadLine();

        var res = restaurant.Menu.SearchByName(q);
        res.AddRange(restaurant.Menu.SearchByCategory(q));
        res = res.Distinct().ToList();

        if (res.Count == 0) Console.WriteLine("Нічого не знайдено.");
        else foreach (var item in res) Console.WriteLine(item.GetInfo());
    }
}
