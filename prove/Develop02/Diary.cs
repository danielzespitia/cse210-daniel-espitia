using System;
using System.Collections.Generic;
using System.IO;

class Diary
{
    private List<Entry> entries;

    public Diary()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(string message, string response)
    {
        Entry entry = new Entry
        {
            Message = message,
            Response = response,
            Date = DateTime.Now
        };

        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Message: {entry.Message}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Message}|~|~{entry.Response}|~|~{entry.Date}");
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        entries.Clear();

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(new string[] { "|~|~" }, StringSplitOptions.None);

                Entry entry = new Entry
                {
                    Message = parts[0],
                    Response = parts[1],
                    Date = DateTime.Parse(parts[2])
                };

                entries.Add(entry);
            }
        }
    }
}