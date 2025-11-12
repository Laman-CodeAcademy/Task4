using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static void Main(string[] args)
    {
        // Task1
        //    int[] nums = { 1, 2, 2, -3, -4, -4, 5, 6, -7, 8 };
        //    Console.WriteLine("Sum of positives: " + SumOfPositives(nums));

        //    // Task2
        //    List<int> ints = new List<int> { 1, 2, 22, 3, 4, 5, 6, 5, 5 };
        //    List<int> result = UniquePreserveOrder(ints);
        //    Console.WriteLine("Unique numbers: " + string.Join(", ", result));

        //    // Task3
        //    List<string> strings = new List<string>
        //    {
        //        "laman:20",
        //        "samaya:20",
        //        "khanim19:",
        //        "fatima:20"
        //    };

        //    List<Person> people = new List<Person>();

        //    foreach (var s in strings)
        //    {
        //        var parts = s.Split(':');
        //        if (parts.Length == 2 && int.TryParse(parts[1], out int age))
        //        {
        //            people.Add(new Person { Name = parts[0], Age = age });
        //        }
        //    }

        //    Console.WriteLine("People:");
        //    foreach (var person in people)
        //    {
        //        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        //    }

        //    // Task4
        //    string text = "salam dostlar salam salam";
        //    string[] words = text.Split(' ');
        //    Dictionary<string, int> WordFrequency = new Dictionary<string, int>();

        //    foreach (string word in words)
        //    {
        //        string lowerWord = word.ToLower();

        //        if (WordFrequency.ContainsKey(lowerWord))
        //        {
        //            WordFrequency[lowerWord]++;
        //        }
        //        else
        //        {
        //            WordFrequency[lowerWord] = 1;
        //        }
        //    }

        //    Console.WriteLine("Word Frequencies:");
        //    foreach (var pair in WordFrequency)
        //    {
        //        Console.WriteLine($"Word: {pair.Key}, Count: {pair.Value}");
        //    }
        //}



        //// Task1
        //public static int SumOfPositives(int[] nums)
        //{
        //    int sum = 0;
        //    if (nums == null || nums.Length == 0)
        //    {
        //        return 0;
        //    }
        //    foreach (int num in nums)
        //    {
        //        if (num < 0) continue;
        //        sum += num;
        //    }
        //    return sum;
        //}

        //// Task2
        //public static List<int> UniquePreserveOrder(List<int> ints)
        //{
        //    List<int> uniqueNums = new List<int>();
        //    foreach (int num in ints)
        //    {
        //        if (!uniqueNums.Contains(num))
        //        {
        //            uniqueNums.Add(num);
        //        }
        //    }
        //    return uniqueNums;
        //}

        //Task6
        Student student = new Student("laman", new List<int> { 100, 89, 56 });
        Student student2 = new Student("fatima", new List<int> { 98, 97, 56 });

        List<Student> students = new List<Student> { student, student2 };
        List<Student> filtered = FilterByAverage(students, 51);

        // Print the filtered students
        Console.WriteLine("Students with average above 51:");
        foreach (var s in filtered)
        {
            Console.WriteLine($"{s.Name} - Average: {s.Grades.Average()}");
        }

        //Task7
        string text = "absccc";
        Console.WriteLine(Compress(text));



        //Task8
        Product p1 = new Product(0, "pear", 1.00, 4);
        p1.AddStock(-1);
        p1.AddStock(2);
        Console.WriteLine($"Name: {p1.Name}, TotalValue:{p1.TotalValue()}, Stock: {p1.Stock}");

        Product p2 = new Product(1, "banana", 5.00, 10);
        p2.Sell(12);
        Console.WriteLine($"Name: {p2.Name}, TotalValue:{p2.TotalValue()}, Stock: {p2.Stock}");

        Product p3 = new Product(2, "cherry", 10.25, 4);
        Console.WriteLine($"Name: {p3.Name}, TotalValue:{p3.TotalValue()}, Stock: {p3.Stock}");

    }

    public static List<Student> FilterByAverage(List<Student> students, double threshold)
    {
        List<Student> result = new List<Student> ();

       foreach(var student in students)
        {
            if (student.Grades.Count == 0) continue;
            double avg = student.Grades.Average(); 
            if(avg>threshold) result.Add(student);
        }
        return result;
    }

    public static string Compress(string text)
    {
        text = text.Trim();
        string result = "";
        int count = 1;
        for (int i = 0; i < text.Length; i++)
        {
            if(i+1<text.Length && text[i] == text[i + 1])
            {
                count++;
            }
            else
            {
                result += text[i]+count.ToString();
                count = 1;
            }
        }
        return result;
    }


}

// Task3 - Person class
//class Person
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//}

//Task6
class Student
{
    public string Name { get; set; }
    public List<int> Grades { get; set; }

    public Student(string name, List<int> grades)
    {
        Name = name;
        Grades = grades;
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public Product(int id, string name, double price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public double TotalValue()
    {
        return Price * Stock;
    }

    public void AddStock(int qty)
    {
        if (qty > 0)
        {
            Stock += qty;
        }
    }

    public int Sell(int qty)
    {
        if (qty < Stock)
        {
            Stock -= qty;
        }
        else
        {
            Stock = 0;
        }
        return Stock;
    }

}