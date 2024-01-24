using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Daniel Espitia - CSE210");

        Console.Write("What is the magic number?: ") ;
        int magic_number = int.Parse(Console.ReadLine ()) ;

        int guess = -1;

        while (guess != magic_number)
        {
            Console.Write("What is your guess?: ") ; 
            guess = int.Parse(Console.ReadLine ()) ;

            if (guess > magic_number)
            {
                Console.WriteLine ("Higher");
            }

            else if (guess < magic_number)
            {
                Console.WriteLine ("Lower");
            }

            else 
            {
                Console.WriteLine("You guessed it!");
            }

        }
    
    }


}