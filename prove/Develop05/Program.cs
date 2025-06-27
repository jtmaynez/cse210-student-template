using System;

// Create Menu, prompt users for the specific goals, 
class Program
{
    public static void Main(string[] args)
    {
        List<Goal> goals = new();
        int totalPoints = 0; // Only when I call the save goal call total points

        bool running = true;
        while (running)
        {
            Console.WriteLine($"You have {totalPoints} points ");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Add New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("The types of Goals are:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    Console.Write("What type of Goal do you want to add: ");
                    string goalType = Console.ReadLine();

                    Console.Write("What is the name of your Goal? ");
                    string goalName = Console.ReadLine();

                    Console.Write("What is the description of your goal? ");
                    string goalDescription = Console.ReadLine();

                    Console.Write("How many points is this goal? ");
                    int goalPoints = int.Parse(Console.ReadLine());

                    switch (goalType)
                    {
                        case "1":
                            Console.Write("Is this goal completed? ");
                            string userInput = Console.ReadLine();
                            bool isComplete = string.Equals(userInput, "yes", StringComparison.OrdinalIgnoreCase);
                            SimpleGoal sg = new SimpleGoal(goalName, goalDescription, goalPoints, isComplete);
                            goals.Add(sg);
                            break;

                        case "2":
                            EternalGoal eg = new EternalGoal(goalName, goalDescription, goalPoints);
                            goals.Add(eg);
                            break;

                        case "3":
                            Console.Write("How many bonus points when completed? ");
                            int bonusPoint = int.Parse(Console.ReadLine());
                            Console.Write("How many times will you complete this goal? ");
                            int iteration = int.Parse(Console.ReadLine());

                            ChecklistGoal cg = new ChecklistGoal(goalName, goalDescription, goalPoints, bonusPoint, iteration, 0);
                            goals.Add(cg);
                            break;
                    }
                    break;

                case "2":
                    foreach (Goal goal in goals)
                    {
                        goal.Display();
                    }
                    break;

                case "3":
                    SaveGoals(goals, totalPoints);
                    break;

                case "4":
                    (List<Goal> goals, int points) load = LoadGoals();
                    goals = load.goals;
                    totalPoints = load.points;
                    break;

                case "5":
                    Console.WriteLine("What goal do you want to record? ");
                    string listedGoal = Console.ReadLine();

                    // Code to find the listed goal and then call record event
                    //which goal you want
                    // for loop
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Thread.Sleep(1500);
                    break;
            }
        }

    }
    static void SaveGoals(List<Goal> goals, int totalPoints)
    {
        Console.WriteLine("What is the name of the file you want to save?");
        string SaveResponse = Console.ReadLine();

        using (StreamWriter file = new(SaveResponse))
        {
            file.WriteLine(totalPoints);
            foreach (Goal goal in goals)
            {
                file.WriteLine(goal.GetFormat());
            }
        }
    }
    static (List<Goal> goals, int points) LoadGoals()
    {
        Console.WriteLine("What is the name of the file you want to load?");
        string SaveResponse = Console.ReadLine();
        int points = int.Parse(File.ReadLines(SaveResponse).First()); // Returns current points
        List<Goal> goals = new();
        foreach (string line in File.ReadLines(SaveResponse).Skip(0))
        {
            string[] parts = line.Split("|"); // string[] = is a list of strings
            string type = parts[0];
            switch (type)
            {
                case "Simple Goal":
                    goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;
                case "Eternal Goal":
                    goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "CheckList Goal":
                    goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                    break;
            }
        }
        return (goals, points);
    }
}