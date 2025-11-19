namespace DeliverySystem
{
    public class Van : Car
    {
        private double loadCapacity;
        private double currentLoad;

        public Van(string brand, int year, double mileage, int doors, double loadCapacity)
            : base(brand, year, mileage, 140.0, doors) // Виклик захищеного конструктора Car з maxSpeed = 140.0
        {
            this.loadCapacity = loadCapacity;
            this.currentLoad = 0;
        }

        public override string GetInfo()
        {
            // Використовуємо :F0 для форматування числа з двома знаками після коми (для точності, хоча в тестах ціле)
            return $"Van: {brand} ({year}), Doors: {doors}, Load: {currentLoad:F0}/{loadCapacity:F0}kg, Fuel: {fuelLevel:F0}L";
        }

        public void LoadCargo(double weight)
        {
            if (currentLoad + weight <= loadCapacity)
            {
                currentLoad += weight;
                Console.WriteLine($"{weight} kg loaded into the van.");
            }
            else
            {
                Console.WriteLine("Too heavy! Cannot load more cargo.");
            }
        }

        public void UnloadCargo()
        {
            currentLoad = 0;
            Console.WriteLine("Van unloaded.");
        }
    }
}