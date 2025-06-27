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
                            Console.Write