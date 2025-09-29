using System;

class TriangleProgram
{
    static void Main()
    {
        Console.Write("Введіть сторону a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть сторону b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть сторону c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        if (a <= 0 || b <= 0 || c <= 0)
        {
            Console.WriteLine("Сторони повинні бути додатніми числами.");
            return;
        }

        if (!IsValidTriangle(a, b, c))
        {
            Console.WriteLine("Трикутник з такими сторонами не існує.");
            return;
        }

        double perimeter = GetPerimeter(a, b, c);
        Console.WriteLine($"Периметр трикутника: {perimeter}");

        double area = GetArea(a, b, c);
        Console.WriteLine($"Площа трикутника: {area}");

        string type = GetTriangleType(a, b, c);
        Console.WriteLine($"Вид трикутника: {type}");
    }

    static bool IsValidTriangle(double a, double b, double c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }

    static double GetPerimeter(double a, double b, double c)
    {
        return a + b + c;
    }

    static double GetArea(double a, double b, double c)
    {
        double s = GetPerimeter(a, b, c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    static string GetTriangleType(double a, double b, double c)
    {
        if (a == b && b == c)
            return "Рівносторонній";
        else if (a == b || a == c || b == c)
            return "Рівнобедрений";
        else if (IsRightTriangle(a, b, c))
            return "Прямокутний";
        else
            return "Довільний";
    }

    static bool IsRightTriangle(double a, double b, double c)
    {
        double[] sides = { a, b, c };
        Array.Sort(sides);
        return Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) < 1e-10;
    }
}
