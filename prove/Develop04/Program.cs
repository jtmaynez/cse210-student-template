using System;

class Program
{
   // My creativity is my 3rd activity where you rank what matters most.
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start What Matters Most Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Breathing b1 = new Breathing();
                    b1.Run();
                    break;

                case "2":
                    Reflection r1 = new Reflection();
                    r1.Run();
                    break;

                case "3":
                    Listing l1 = new Listing();
                    l1.Run();
                    break;

                case "4":
                    ValuesRanking v1 = new ValuesRanking();
                    v1.Run();
                    break;

                case "5":
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
}