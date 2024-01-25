using System;

class Program
{
    static void Main(string[] args)
    {
        Diary diary = new Diary();

        string[] messages = {
            "What activities did they have for me today at the university?",
            "What pending tasks do I have to deliver at work?",
            "What things should I buy for my home and my family?",
            "What interviews should I do at church?",
            "What can i say to my wife to make her feel loved?"
        };

        Random random = new Random();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Select an option: ");
            Console.WriteLine();
            Console.WriteLine("1. Write a new entry ");
            Console.WriteLine("2. Show the diary");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Logout");
            Console.WriteLine();
            Console.Write("You choose: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string message = messages[random.Next(messages.Length)];
                    Console.WriteLine(message);
                    string response = Console.ReadLine();
                    diary.AddEntry(message, response);
                    Console.WriteLine("Saved entry.");
                    Console.WriteLine();
                    break;

                case "2":
                    diary.DisplayEntries();
                    break;

                case "3":
                    Console.WriteLine("Enter the file name:");
                    string saveFileName = Console.ReadLine();
                    diary.SaveToFile(saveFileName);
                    Console.WriteLine("Diary saved to file.");
                    Console.WriteLine();
                    break;

                case "4":
                    Console.WriteLine("Enter the file name:");
                    string loadFileName = Console.ReadLine();
                    diary.LoadFromFile(loadFileName);
                    Console.WriteLine("Diary saved to file.");
                    Console.WriteLine();
                    break;

                case "5":
                    Console.WriteLine("Thanks for participating, come back soon.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}