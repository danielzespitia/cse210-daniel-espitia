using System;
using System.Collections.Generic;
using System.IO;

public abstract class Activity
{
    public DateTime Time { get; set; }
    public string Description { get; set; }

    public Activity(DateTime time, string description)
    {
        Time = time;
        Description = description;
    }

    public abstract void ShowDetails();
}

public class Task : Activity
{
    public Task(DateTime time, string description) : base(time, description)
    {
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"Task: {Time} - {Description}");
    }
}

public class Meeting : Activity
{
    public Meeting(DateTime time, string description) : base(time, description)
    {
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"Meeting: {Time} - {Description}");
    }
}

public class Diary
{
    private List<Activity> activities;

    public Diary()
    {
        activities = new List<Activity>();
    }

    public void AddActivity(Activity activity)
    {
        activities.Add(activity);
        Console.WriteLine("The activity has been added successfully.");
    }

    public void RemoveActivity(int index)
    {
        if (index >= 0 && index < activities.Count)
        {
            activities.RemoveAt(index);
            Console.WriteLine("The activity has been removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid index provided.");
        }
    }

    public void ShowActivities()
    {
        Console.WriteLine("Scheduled activities:");
        foreach (Activity activity in activities)
        {
            activity.ShowDetails();
        }
    }

    public void SaveToExternalFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Activity activity in activities)
            {
                writer.WriteLine($"{activity.Time} - {activity.Description}");
            }
        }

        Console.WriteLine("Activities have been saved to the external file successfully.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Diary diary = new Diary();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("");
            Console.WriteLine("W06 - FINAL PROJECT");
            Console.WriteLine("");
            Console.WriteLine("Daniel Espitia");
            Console.WriteLine("");
            Console.WriteLine("Record the time like this: 18:00. Don't forget the : ");
            Console.WriteLine("");
            Console.WriteLine("----- DIARY -----");
            Console.WriteLine("");
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. Add meeting");
            Console.WriteLine("3. Show activities");
            Console.WriteLine("4. Remove activity");
            Console.WriteLine("5. Save activities to external file");
            Console.WriteLine("6. Exit");
            Console.WriteLine("");
            Console.WriteLine("----------------");

            Console.Write("Enter the desired option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter the task time (yyyy-MM-dd HH:mm): ");
                    DateTime taskTime;
                    if (DateTime.TryParse(Console.ReadLine(), out taskTime))
                    {
                        Console.Write("Enter the task description: ");
                        string taskDescription = Console.ReadLine();
                        Task task = new Task(taskTime, taskDescription);
                        diary.AddActivity(task);
                    }
                    else
                    {
                        Console.WriteLine("Invalid time. Please try again.");
                    }
                    break;

                case "2":
                    Console.Write("Enter the meeting time (yyyy-MM-dd HH:mm): ");
                    DateTime meetingTime;
                    if (DateTime.TryParse(Console.ReadLine(), out meetingTime))
                    {
                        Console.Write("Enter the meeting description: ");
                        string meetingDescription = Console.ReadLine();
                        Meeting meeting = new Meeting(meetingTime, meetingDescription);
                        diary.AddActivity(meeting);
                    }
                    else
                    {
                        Console.WriteLine("Invalid time. Please try again.");
                    }
                    break;

                case "3":
                    diary.ShowActivities();
                    break;

                case "4":
                    Console.Write("Enter the index of the activity to remove: ");
                    int index;
                    if (int.TryParse(Console.ReadLine(), out index))
                    {
                        diary.RemoveActivity(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index. Please try again.");
                    }
                    break;

                case "5":
                    Console.Write("Enter the file path to save the activities: ");
                    string filePath = Console.ReadLine();
                    diary.SaveToExternalFile(filePath);
                    break;

                case "6":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}