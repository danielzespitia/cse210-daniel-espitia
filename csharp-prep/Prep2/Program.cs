using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Daniel Espitia - CSE210");

        Console.Write("Enter your grade: ") ;
        string userInput = Console.ReadLine () ;
        int number = int.Parse(userInput) ;

        if (int.TryParse(userInput, out number))
        {

        /* A >= 90
           B >= 80
           C >= 70
           D >= 60
           F < 60
        */
            if (number >= 101)
            {
                Console.WriteLine ("Invalid input. Please enter a valid grade.");
            }

            else if (number >= 90)
            {
                Console.WriteLine ("Your Grade is A");
                Console.WriteLine("You passed!");
            }

            else if (number >= 80)
            {
                Console.WriteLine("Your Grade is B");
                Console.WriteLine("You passed!");
            }

            else if (number >=70)
            {
                Console.WriteLine("Your Grade is C");
                Console.WriteLine("You barely passed, you must improve!");
            }

            else if (number >=60)
            {
                Console.WriteLine("Your Grade is D");
                Console.WriteLine("You failed!");
            }

            else 
            {
                Console.WriteLine("Your Grade is F");
                Console.WriteLine("You failed!");
            }
        }

        else 
        {
            Console.WriteLine("Invalid input. Please enter a valid grade.");
        }
    }
}