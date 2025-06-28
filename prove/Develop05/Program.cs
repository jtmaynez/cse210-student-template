using System;

// My creative exceed expectation is 6 where it filters and sorts based on code I've looked up. 
//I also created some Error Handling for most of my code where errors can be entered by the user. 
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
            Console.WriteLine("6. Filter & Sort");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
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
                            SimpleGoal sg = new SimpleGoal(goalName, goalDescription, goalPoints);
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
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            Thread.Sleep(1500);
                            break;
                    }
                    Console.Clear();
                    break;

                case "2": //List
                    Console.Clear();
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Goal numberedGoal = goals[i];
                        Console.Write($"{i + 1}.");
                        numberedGoal.Display();
                    }
                    break;

                case "3": // Save
                    Console.Clear();
                    SaveGoals(goals, totalPoints);
                    Console.WriteLine("Goals successfully saved!");
                    break;

                case "4": // Load
                    Console.Clear();
                    try
                    {
                        (List<Goal> loadedGoals, int loadedPoints) = LoadGoals();
                        goals = loadedGoals;
                        totalPoints = loadedPoints;
                        Console.WriteLine("Goals successfully loaded!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading goals: {ex.Message}");
                    }
                    break;


                case "5": // Record
                    // Console.Clear();
                    if (goals.Count == 0)
                    {
                        Console.WriteLine("No goals available to record.");
                        break;
                    }

                    Console.Write("What goal do you want to record? ");
                    string input = Console.ReadLine();
                    try
                    {
                        int goalNumber = int.Parse(input) - 1;

                        if (goalNumber < 0 || goalNumber >= goals.Count)
                        {
                            Console.WriteLine("Invalid goal number.");
                        }
                        else
                        {
                            int earnedPoints = goals[goalNumber].RecordEvent();
                            totalPoints += earnedPoints;
                            Console.WriteLine($"You earned {earnedPoints} points!");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }

                    break;

                case "6": // Filter/Sort
                    Console.Clear();
                    Console.WriteLine("1. Show only completed goals");
                    Console.WriteLine("2. Show only incomplete goals");
                    Console.WriteLine("3. Sort by point value");
                    Console.WriteLine("4. Show only checklist goals");
                    Console.Write("Choose a filter/sort option: ");
                    string filterOption = Console.ReadLine();

                    List<Goal> filtered = new List<Goal>();

                    switch (filterOption)
                    {
                        case "1":
                            filtered = goals.Where(g => g.IsComplete()).ToList();
                            break;
                        case "2":
                            filtered = goals.Where(g => !g.IsComplete()).ToList();
                            break;
                        case "3":
                            filtered = goals.OrderByDescending(g => g.GetPoints()).ToList();
                            break;
                        case "4":
                            filtered = goals.Where(g => g is ChecklistGoal).ToList();
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                    foreach (var goal in filtered)
                    {
                        goal.Display();
                    }
                    break;

                case "7": // Quit
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;     

                default:
                    Console.Clear();
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