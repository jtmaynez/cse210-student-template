using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Supply Chain Management System!");
        Console.WriteLine("1. Create a Forecast ");
        Console.WriteLine("2. Calculate Inventory Equation ");
        Console.Write("What do you want to do: ");
        string menuChoice = Console.ReadLine();

        switch (menuChoice)
        {
            case "1":
                RunForecast();
                break;

            case "2":
                // Inventory feature coming soon
                Console.WriteLine("Inventory section coming soon");
                break;
        }
    }

    static void RunForecast()
    {
        int forecastChoice = PromptForecastType();
        int timeChoice = PromptTimeFrame();
        int year = PromptYear();

        int? month = null;
        int? quarter = null;
        double[] weights = null;
        double? alpha = null;

        if (timeChoice == 1)
            month = PromptMonth();
        else if (timeChoice == 2)
            quarter = PromptQuarter();

        Forecast forecast = forecastChoice switch
        {
            1 => new MovingForecast(),
            2 => new WeightedAverageForecast(),
            3 => new SmoothingForecast(),
            _ => throw new Exception("Invalid Forecast Choice")
        };

        if (forecast is WeightedAverageForecast)
            weights = PromptWeights();
        else if (forecast is SmoothingForecast)
            alpha = Pro