using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Daniel Espitia - CSE210");

        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine ()) ;

            if (input == 0)
                break;

            numbers.Add(input);

        }

        int sum = 0;
        int max = int.MinValue;

        foreach (int number in numbers)
        {
            sum += number;
            if (number > max)
                max = number;
        }

        float average = (float)sum / numbers.Count;

        numbers.Sort(); 

        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + max);
    }
}