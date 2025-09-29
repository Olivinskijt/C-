using System;

class StudentGrades
{
    static void Main()
    {
        Console.Write("Введіть кількість груп (3-5): ");
        int groupCount = int.Parse(Console.ReadLine());

        if (groupCount < 3 || groupCount > 5)
        {
            Console.WriteLine("Кількість груп повинна бути від 3 до 5.");
            return;
        }

        int[][] groups = new int[groupCount][];

        for (int i = 0; i < groupCount; i++)
        {
            Console.Write($"Введіть кількість студентів у групі {i + 1} (10-30): ");
            int studentCount = int.Parse(Console.ReadLine());

            if (studentCount < 10 || studentCount > 30)
            {
                Console.WriteLine("Кількість студентів повинна бути від 10 до 30.");
                return;
            }

            groups[i] = new int[studentCount];

            for (int j = 0; j < studentCount; j++)
            {
                Console.Write($"Оцінка студента {j + 1} у групі {i + 1}: ");
                groups[i][j] = int.Parse(Console.ReadLine());
            }
        }

        PrintGroupStatistics(groups);
    }

    static double GetAverage(int[] marks)
    {
        int sum = 0;
        foreach (int mark in marks)
            sum += mark;
        return (double)sum / marks.Length;
    }

    static int GetMin(int[] marks)
    {
        int min = marks[0];
        foreach (int mark in marks)
            if (mark < min) min = mark;
        return min;
    }

    static int GetMax(int[] marks)
    {
        int max = marks[0];
        foreach (int mark in marks)
            if (mark > max) max = mark;
        return max;
    }

    static void PrintGroupStatistics(int[][] groups)
    {
        for (int i = 0; i < groups.Length; i++)
        {
            double avg = GetAverage(groups[i]);
            int min = GetMin(groups[i]);
            int max = GetMax(groups[i]);
            Console.WriteLine($"Група {i + 1}: Середній = {avg:F0}, Мінімальний = {min}, Максимальний = {max}");
        }
    }
}
