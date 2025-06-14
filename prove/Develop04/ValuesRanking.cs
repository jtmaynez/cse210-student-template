public class ValuesRanking : Activity
{
    private List<string> _values = new List<string>
    {
        "Faith", "Family", "Friendship", "Freedom", "Growth",
        "Honesty", "Kindness", "Learning", "Love", "Success"
    };

    public ValuesRanking() : base(
        "What Matters Most Activity",
        "This activity helps you reflect on what matters most by ranking personal values.")
    {
    }

    public void Run()
    {
        base.StartMessage();

        Console.WriteLine("\nHere are 10 common personal values:");
        for (int i = 0; i < _values.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_values[i]}");
        }

        List<string> top3 = new List<string>();

        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"\nEnter the number for your #{i} most important value: ");
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > _values.Count)
            {
                Console.Write("Invalid number. Try again: ");
            }

            top3.Add(_values[index - 1]);
        }

        Console.WriteLine("\nYour Top 3 Values:");
        for (int i = 0; i < top3.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {top3[i]}");
        }

        DateTime endTime = DateTime.Now.AddSeconds(base.GetDuration());
        List<string> reflections = new List<string>();

        int currentIndex = 0;

        while (DateTime.Now < endTime && currentIndex < top3.Count)
        {
            Console.Write($"\nWhy is \"{top3[currentIndex]}\" important to you? ");
            string reason = Console.ReadLine();

            reflections.Add($"#{currentIndex + 1}: {top3[currentIndex]} — {reason}");
            currentIndex++;

            base.Spinner(2);
        }

        // Display summary
        Console.WriteLine("\nReflection Summary:");
        foreach (string line in reflections)
        {
            Console.WriteLine(line);
        }


        base.EndMessage();
        base.Spinner(3);
    }
}