using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

internal sealed record Student(
    int Number,
    string FullName,
    int MidtermGrade,
    int FinalGrade,
    double Average,
    string LetterGrade);

internal static class Program
{
    private const double MidtermWeight = 0.40;
    private const double FinalWeight = 0.60;

    private static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Student Grade Portal");
        Console.WriteLine("--------------------");

        int studentCount = ReadPositiveInt("Enter the number of students: ");
        List<Student> students = new();

        for (int i = 1; i <= studentCount; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"Student {i}");

            int number = ReadPositiveInt("Student number: ");
            string fullName = ReadRequiredText("Full name: ");
            int midtermGrade = ReadGrade("Midterm grade (0-100): ");
            int finalGrade = ReadGrade("Final grade (0-100): ");

            double average = CalculateAverage(midtermGrade, finalGrade);
            string letterGrade = GetLetterGrade(average);

            students.Add(new Student(number, fullName, midtermGrade, finalGrade, average, letterGrade));

            Console.WriteLine($"Average: {average:F2} | Letter grade: {letterGrade}");
        }

        PrintSummary(students);
    }

    private static int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? string.Empty;

            if (int.TryParse(input, out int value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a valid positive number.");
        }
    }

    private static int ReadGrade(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? string.Empty;

            if (int.TryParse(input, out int grade) && grade >= 0 && grade <= 100)
            {
                return grade;
            }

            Console.WriteLine("Please enter a valid grade between 0 and 100.");
        }
    }

    private static string ReadRequiredText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine("Name cannot be empty.");
        }
    }

    private static double CalculateAverage(int midtermGrade, int finalGrade)
    {
        return midtermGrade * MidtermWeight + finalGrade * FinalWeight;
    }

    private static string GetLetterGrade(double average)
    {
        if (average >= 85) return "AA";
        if (average >= 70) return "BA";
        if (average >= 60) return "BB";
        if (average >= 50) return "CB";
        if (average >= 40) return "CC";
        if (average >= 30) return "DC";
        if (average >= 20) return "DD";
        if (average >= 10) return "FD";
        return "FF";
    }

    private static void PrintSummary(IReadOnlyCollection<Student> students)
    {
        double classAverage = students.Average(student => student.Average);
        double highestAverage = students.Max(student => student.Average);
        double lowestAverage = students.Min(student => student.Average);

        string highestStudents = string.Join(", ",
            students.Where(student => student.Average == highestAverage).Select(student => student.FullName));

        string lowestStudents = string.Join(", ",
            students.Where(student => student.Average == lowestAverage).Select(student => student.FullName));

        Console.WriteLine();
        Console.WriteLine("Class Summary");
        Console.WriteLine("-------------");
        Console.WriteLine($"{"No",-10} {"Full Name",-24} {"Midterm",8} {"Final",8} {"Average",9} {"Letter",8}");
        Console.WriteLine(new string('-', 75));

        foreach (Student student in students)
        {
            Console.WriteLine(
                $"{student.Number,-10} {student.FullName,-24} {student.MidtermGrade,8} {student.FinalGrade,8} {student.Average,9:F2} {student.LetterGrade,8}");
        }

        Console.WriteLine(new string('-', 75));
        Console.WriteLine($"Class average: {classAverage:F2}");
        Console.WriteLine($"Highest average: {highestAverage:F2} ({highestStudents})");
        Console.WriteLine($"Lowest average: {lowestAverage:F2} ({lowestStudents})");
    }
}
