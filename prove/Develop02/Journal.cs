using System.IO;
public class Journal
{
    public List<Entry> Entries = new List<Entry>();
    public void AddEntry(Entry journalEntry)
    {
        Entries.Add(journalEntry);
    }
    public void DisplayJournal()
    {
        foreach (Entry journalEntry in Entries)
        {
            journalEntry.Display();
        }
    }
    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry journalEntry in Entries)
            {
                string isoDate = journalEntry._date.ToString("s"); // ISO 8601 format
                string line = $"{isoDate}|{journalEntry._prompt}|{journalEntry._response}";
                writer.WriteLine(line);
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            Entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                if (parts.Length == 3)
                {
                    DateTime date = DateTime.Parse(parts[0]);
                    string prompt = parts[1];
                    string response = parts[2];

                    Entry entry = new Entry(prompt, response);
                    entry._date = date;
                    Entries.Add(entry);


                }
            }
            Console.WriteLine("journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
    
    // For creativity!
 public void ShowRandomEntryFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        List<Entry> tempEntries = new List<Entry>();

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            if (parts.Length == 3)
            {
                DateTime date = DateTime.Parse(parts[0]);
                string prompt = parts[1];
                string response = parts[2];

                Entry entry = new Entry(prompt, response);
                entry._date = date;
                tempEntries.Add(entry);
            }
        }

        if (tempEntries.Count == 0)
        {
            Console.WriteLine("No entries found in the file.");
            return;
        }

        Random rand = new Random();
        Entry randomEntry = tempEntries[rand.Next(tempEntries.Count)];

        Console.WriteLine("Throwback Entry from File:");
        randomEntry.Display();
    }

}
