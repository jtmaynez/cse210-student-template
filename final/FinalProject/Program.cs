using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Supply Chain Management System!");
        Console.WriteLine("1. Create a Forecast ");
        Console.WriteLine("2. Calculate Inventory Equation ");
        Console.WriteLine("3. Manage A Project ");
        Console.Write("What do you want to do: ");
        string menuChoice = Console.ReadLine();
        switch (menuChoice)
        {
            case "1":
                ForecastType(); // Encapilization
                ForecastTime();
                break;

            case "2":
                break;

            case "3":
                break;

        }



    }
    static int ForecastType()
    {
        Console.WriteLine("Welcome to Forecasting!");
        Console.WriteLine("1. Moving Average ");
        Console.WriteLine("2. Moving Weighted Average ");
        Console.WriteLine("3. Smoothing ");
        Console.Write("What do you want to do: ");
        return int.Parse(Console.ReadLine());
        //Try and catch so that if tyler puts banana it doesn't crash
    }

    static int ForecastTime()
    {
            
        Console.WriteLine("1. Monthly ");
        Console.WriteLine("2. Quarterly ");
        Console.WriteLine("3. Yearly ");
        Console.Write("What do you want to do: ");
        string timeChoice = Console.ReadLine();
        return int.Parse(Console.ReadLine());
        //Try and catch so that if tyler puts banana it doesn't crash

    }
}