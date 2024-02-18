using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string Description { get; set; }
    public bool Completed { get; set; }

    public Goal(string description)
    {
        Description = description;
        Completed = false;
    }

    public abstract int CalculatePoints();
    public abstract string GetStatus();
}
public class SimpleGoal : Goal
{
    public int Points { get; set; }

    public SimpleGoal(string description, int points) : base(description)
    {
        Points = points;
    }

    public override int CalculatePoints()
    {
        if (Completed)
        {
            return Points;
        }
        else
        {
            return 0;
        }
    }
        public override string GetStatus()
    {
        if (Completed)
        {
            return "[X] Completed";
        }
        else
        {
            return "[ ] Incomplete";
        }
    }
}

public class EternalGoal : Goal
{
    public int Points { get; set; }

    public EternalGoal(string description, int points) : base(description)
    {
        Points = points;
    }

    public override int CalculatePoints()
    {
        if (Completed)
        {
            return Points;
        }
        else
        {
            return 0;
        }
    }

    public override string GetStatus()
    {
        return "[ ] Incomplete";
    }
}

public class ChecklistGoal : Goal
{
    public int PointsPerCompletion { get; set; }
    public int RequiredCompletions { get; set; }
    public int BonusPoints { get; set; }
    public int Completions { get; set; }

    public ChecklistGoal(string description, int pointsPerCompletion, int requiredCompletions, int bonusPoints) : base(description)
    {
        PointsPerCompletion = pointsPerCompletion;
        RequiredCompletions = requiredCompletions;
        BonusPoints = bonusPoints;
        Completions = 0;
    }

    public override int CalculatePoints()
    {
        int points = Completions * PointsPerCompletion;
        if (Completions >= RequiredCompletions)
        {
            points += BonusPoints;
        }
        return points;
    }

    public override string GetStatus()
    {
        return $"[ ][X] Completed {Completions}/{RequiredCompletions} times";
    }

    public void Complete()
    {
        Completions++;
        Completed = (Completions >= RequiredCompletions);
    }
}

public class Program
{
    public static List<Goal> goals = new List<Goal>();

    public static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("W05 Prove: Developer—Eternal Quest");
            Console.WriteLine("");
            Console.WriteLine("Daniel Espitia");
            Console.WriteLine("");
            Console.WriteLine("=== Goal Tracker ===");
            Console.WriteLine("1. Show goals");
            Console.WriteLine("2. Register event");
            Console.WriteLine("3. Create new goal");
            Console.WriteLine("4. Save goals and score");
            Console.WriteLine("5. Load goals and score");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowGoals();
                    break;
                case "2":
                    RegisterEvent();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    public static void ShowGoals()
    {
        Console.Clear();
        Console.WriteLine("=== Goals ===");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals registered.");
        }
        else
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Description} - {goals[i].GetStatus()}");
            }
        }
    }

    public static void RegisterEvent()
    {
        Console.Clear();
        Console.WriteLine("=== Register Event ===");
        ShowGoals();

        Console.Write("Select the goal number: ");
        string goalNumberStr = Console.ReadLine();
        if (int.TryParse(goalNumberStr, out int goalNumber) && goalNumber > 0 && goalNumber <= goals.Count)
        {
            Goal goal = goals[goalNumber - 1];
            goal.Completed = true;
            Console.WriteLine("Event registered successfully.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }
    public static void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("=== Create New Goal ===");
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");
        Console.Write("Enter goal type number: ");
        string goalTypeStr = Console.ReadLine();

        if (!int.TryParse(goalTypeStr, out int goalType))
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        switch (goalType)
        {
            case 1:
                Console.Write("Enter goal points: ");
                string pointsStr = Console.ReadLine();
                if (int.TryParse(pointsStr, out int points))
                {
                    Goal simpleGoal = new SimpleGoal(description, points);
                    goals.Add(simpleGoal);
                    Console.WriteLine("Simple goal created successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid points value.");
                }
                break;
            case 2:
                Console.Write("Enter goal points: ");
                string eternalPointsStr = Console.ReadLine();
                if (int.TryParse(eternalPointsStr, out int eternalPoints))
                {
                    Goal eternalGoal = new EternalGoal(description, eternalPoints);
                    goals.Add(eternalGoal);
                    Console.WriteLine("Eternal goal created successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid points value.");
                }
                break;
            case 3:
                Console.Write("Enter points per completion: ");
                string pointsPerCompletionStr = Console.ReadLine();
                if (!int.TryParse(pointsPerCompletionStr, out int pointsPerCompletion))
                {
                    Console.WriteLine("Invalid points per completion value.");
                    return;
                }

                Console.Write("Enter required completions: ");
                string requiredCompletionsStr = Console.ReadLine();
                if (!int.TryParse(requiredCompletionsStr, out int requiredCompletions))
                {
                    Console.WriteLine("Invalid required completions value.");
                    return;
                }

                Console.Write("Enter bonus points: ");
                string bonusPointsStr = Console.ReadLine();
                if (!int.TryParse(bonusPointsStr, out int bonusPoints))
                {
                    Console.WriteLine("Invalid bonus points value.");
                    return;
                }

                Goal checklistGoal = new ChecklistGoal(description, pointsPerCompletion, requiredCompletions, bonusPoints);
                goals.Add(checklistGoal);
                Console.WriteLine("Checklist goal created successfully.");
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public static void SaveGoals()
    {
        Console.WriteLine("Goals and score saved successfully.");
    }

    public static void LoadGoals()
    {
        Console.WriteLine("Goals and score loaded successfully.");
    }
}