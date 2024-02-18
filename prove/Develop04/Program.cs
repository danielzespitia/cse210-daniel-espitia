using System;
using System.Threading;
public abstract class MindfulnessActivity
{
    protected int duration;

    public MindfulnessActivity(int duration)
    {
        this.duration = duration;
    }
    public abstract string GetDescription();
    public virtual void Start()
    {
        Console.WriteLine("");
        Console.WriteLine("Getting ready to start...");
        Console.WriteLine("");
        Thread.Sleep(1000);
    }
    public virtual void End()
    {
        Console.WriteLine("");
        Console.WriteLine("Good job!");
        Thread.Sleep(1000);
        Console.WriteLine("");
        Console.WriteLine($"Activity completed. {GetDescription()}");
        Thread.Sleep(1000);
        Console.WriteLine("");
        Console.WriteLine("----------------------------------------------------------------------");
    }
    public virtual void DisplayMessageWithCountdown(string message, int delay)
    {
        Console.WriteLine(message);
        for (int i = delay; i > 0; i--)
        {
            Console.WriteLine($"{i}...");
            Thread.Sleep(1000);
        }
    }
    public abstract void PerformActivity();
}

// Breathing Activity Class
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration)
    {
    }

    public override string GetDescription()
    {
        return "";
    }

    public override void PerformActivity()
    {
        int iterations = duration / 6;
        for (int i = 0; i < iterations; i++)
        {
            DisplayMessageWithCountdown("Breath In ...", 3); 
            Thread.Sleep(1000);
            DisplayMessageWithCountdown("Breath Out...", 3);
            Thread.Sleep(1000);
        }

        int remainder = duration % 6;
        if (remainder >= 3)
        {
            DisplayMessageWithCountdown("Breath In...", 3);
            Thread.Sleep(1000);
            remainder -= 3;
        }

        if (remainder > 0)
        {
            DisplayMessageWithCountdown("Breath Out...", remainder);
            Thread.Sleep(remainder * 1000);
        }

    }

     private void DisplayMessageWithCountdown(string message, int seconds)
    {
        Console.Write($"{message} ");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            if (i > 1)
            {
                Console.Write(", ");
            }
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Class Reflection Activity
public class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "------Think of a time when you stood up for someone else------",
        "------Think of a time when you did something really difficult------",
        "------Think of a time when you helped someone in need------",
        "------Think of a time when you did something truly selfless------"
    };
        private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration)
    {
    }

    public override string GetDescription()
    {
        return "";
    }

    public override void PerformActivity()
    {

        int iterations = duration / 6;
        for (int i = 0; i < iterations; i++);

        
        Console.WriteLine("Consider the following promt:");
        Console.WriteLine("");
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        DisplayMessageWithCountdown(prompt, 3);
        Thread.Sleep(1000);
        Console.WriteLine("");
        Console.WriteLine("When you have something in mind, press enter to start...");
        Console.ReadLine();
        Console.WriteLine("");
        {
            foreach (string question in questions)
            {
                DisplayMessageWithCountdown(question, 3);
                Thread.Sleep(1000);
            }
        }
    }

    private void DisplayMessageWithCountdown(string message, int seconds)
    {
        Console.Write($"{message} ");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            if (i > 1)
            {
                Console.Write(", ");
            }
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Listing Activity Class
public class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are the people you appreciate?. Start at: ",
        "What are your personal strengths?. Start at: ",
        "Who are the people you've helped this week?. Start at: ",
        "When does the Holy Spirit make sense this month?. Start at: ",
        "Who are some of your personal heroes?. Start at: ",
    };

   public ListingActivity(int duration) : base(duration)
    {
    }

    public override string GetDescription()
    {
        return "";
    }

    public override void PerformActivity()
    {
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine("");

        int iterations = duration / 6;
        for (int i = 0; i < iterations; i++);
        Random random = new Random();

        string prompt = prompts[random.Next(prompts.Length)];
        DisplayMessageWithCountdown(prompt, 3);
        Thread.Sleep(1000);
        Console.WriteLine("");
        Console.WriteLine("You can start typing (If you press enter without typing anything, the program will end): ");
        Console.WriteLine("");
        List<string> elements = new List<string>();

        while (true)
        {
            string entry = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(entry)) 
            {
                break;
            }

            elements.Add(entry);
        }

        int quantityElements = elements.Count;
        Console.WriteLine($"You entered {quantityElements} elements in total. Thanks for participating!");

        
    }

     private void DisplayMessageWithCountdown(string message, int seconds)
    {
        Console.Write($"{message} ");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            if (i > 1)
            {
                Console.Write(", ");
            }
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
         bool exit = false;

        while (!exit)
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome. W04 Prove: Developer—Mindfulness. Daniel Espitia.");
            Console.WriteLine("");
            Console.WriteLine("Menu Options");
            Console.WriteLine("");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Save answers from activity 3 to a file");
            Console.WriteLine("5. Exit");
            Console.WriteLine("");
            Console.Write("Option: ");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    StartBreathingActivity();
                    break;
                case 2:
                    StartReflectionActivity();
                    break;
                case 3:
                    StartListingActivity();
                    break;
                case 4:
                    SaveActivity3ResponsesToFile();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        }

        Console.WriteLine("Program completed. Thanks for participating.");
    }

    static void StartBreathingActivity()
    {
        Console.WriteLine("");
        Console.WriteLine("Welcome to the Breathing Activity.");
        Console.WriteLine("");
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.WriteLine("");
        Console.Write("How long do you want the activity to run (Amount in SECONDS): ");
        int duration = int.Parse(Console.ReadLine());

        MindfulnessActivity activity = new BreathingActivity(duration);

        Console.WriteLine("");
        Console.WriteLine("Starting the activity...");
        Thread.Sleep(1000);

        activity.Start();
        activity.PerformActivity();
        activity.End();
    }

    static void StartReflectionActivity()
    {
        Console.WriteLine("");
        Console.WriteLine("Welcome to the Reflection Activity.");
        Console.WriteLine("");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine("");
        Console.Write("How long do you want the activity to run (Amount in SECONDS): ");
        int duration = int.Parse(Console.ReadLine());

        MindfulnessActivity activity = new ReflectionActivity(duration);

        Console.WriteLine("");
        Console.WriteLine("Starting the activity...");
        Thread.Sleep(1000);

        activity.Start();
        activity.PerformActivity();
        activity.End();
    }

    static void StartListingActivity()
    {
        Console.WriteLine("");
        Console.WriteLine("Welcome to the Listing Activity.");
        Console.WriteLine("");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("");
        Console.Write("How long do you want the activity to run (Amount in SECONDS): ");
        int duration = int.Parse(Console.ReadLine());

        MindfulnessActivity activity = new ListingActivity(duration);

        Console.WriteLine("");
        Console.WriteLine("Starting the activity...");
        Thread.Sleep(1000);

        activity.Start();
        activity.PerformActivity();
        activity.End();
    }

    static void SaveActivity3ResponsesToFile()
    {
        Console.WriteLine("");
        Console.WriteLine("Saving answers from activity 3 to a file...");
        Console.WriteLine("");
        Console.WriteLine("Please enter your answers one by one. Press Enter without entering text to finish.");
        Console.WriteLine("");

        List<string> answers = new List<string>();

        while (true)
        {
            string answer = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(answer)) 
            {
                break;
            }

            answers.Add(answer);
        }

        Console.Write("Enter the name of the file to save the answers: ");
        Console.WriteLine("");
        string fileName = Console.ReadLine();
        Console.WriteLine("");
        string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string answer in answers)
            {
                writer.WriteLine(answer);
            }
        }

        Console.WriteLine($"Answers successfully saved to file: {filePath}");
    }
}