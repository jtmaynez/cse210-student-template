public class Listing:Activity
{
   private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public Listing() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {

    }
    public void Run()
    {

        base.StartMessage();
        Console.WriteLine();

        Random rand = new Random();
        string prompt = GetRandomPrompt(_prompts);
        Console.WriteLine($"\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        Console.Write("\nYou may begin in: ");
        base.CountDown(4);
   
        Console.WriteLine("Start listing now (press Enter after each item):");
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(base.GetDuration());

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    responses.Add(input);
                }
            }
        }

        Console.WriteLine($"\nYou listed {responses.Count} items!");

        base.EndMessage();
        base.Spinner(3);
    }


    
}