public class Drink : MenuItem
{
    public int Volume { get; }
    public bool Alcoholic { get; }

    public Drink(string name, decimal price, string category, int volume, bool alcoholic)
        : base(name, price, category)
    {
        Volume = volume;
        Alcoholic = alcoholic;
    }

    public override string GetInfo()
    {
        return $"{Name} ({Volume} мл, {(Alcoholic ? "алк." : "без алк.")}) - {Price} грн";
    }
}
