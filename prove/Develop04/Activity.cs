// variables base, then the methods, go to the program to prototype, then the derives
using System.Xml;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;


    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
        
    }
    public void StartMessage()
    {
        Console.WriteLine($"\nWelcome to the {_name}.");
        Console.WriteLine($"\n{_description}");
        Console.Write($"\nHow long (Seconds), would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.Write("Get Ready...");
        Spinner(4);
    }
    public int GetDuration()
    {
        return _duration;
    }

    public void EndMessage()
    {
        Console.WriteLine($"\nWell Done!!");
        Spinner(3);
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name}.");
    }

    protected string GetRandomPrompt(List<string> list)
    {
        Random rand = new Random();
        return list[rand.Next(list.Count)];
    }

    public void CountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            if (i >= 10)
            {
                Console.Write("\b\b  \b\b");
            }
            else
            {
                Console.Write("\b \b");
            }
        }

    }
    public void CountPeriods(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(".");
            Thread.Sleep(1000);
            // Console.Write("\b \b");
        }
        
    }



    public void Spinner(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }

        }
    }

}

