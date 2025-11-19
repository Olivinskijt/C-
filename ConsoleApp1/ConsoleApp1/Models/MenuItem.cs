public abstract class MenuItem
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

    public virtual void Display()
    {
        Console.WriteLine(GetInfo());
    }
}
