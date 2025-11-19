public class Dish : MenuItem
{
    public Dish(string name, decimal price, string category)
        : base(name, price, category) { }

    public override string GetInfo()
    {
        return $"{Name} ({Category}) - {Price} грн";
    }
}
