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
            alpha = PromptAlpha();

        int forecasted = forecast.Calculate(year, month, quarter, weights, alpha);
        double mad = forecast.MAD(forecasted, year, month, quarter);
        double mape = forecast.MAPE(forecasted, year, month, quarter);

        Console.WriteLine($"\nForecast: {forecasted}");
        Console.WriteLine($"MAD: {mad}");
        Console.WriteLine($"MAPE: {mape:P1}\n");
    }

    static int PromptForecastType()
    {
        Console.WriteLine("1. Moving Average");
        Console.WriteLine("2. Weighted Average");
        Console.WriteLine("3. Smoothing");
        Console.Write("Choose forecast type: ");
        return int.Parse(Console.ReadLine());
    }

    static int PromptTimeFrame()
    {
        Console.WriteLine("1. Monthly");
        Console.WriteLine("2. Quarterly");
        Console.WriteLine("3. Yearly");
        Console.Write("Choose time frame: ");
        return int.Parse(Console.ReadLine());
    }

    static int PromptYear()
    {
        Console.Write("Enter year (e.g. 2023): ");
        return int.Parse(Console.ReadLine());
    }

    static int PromptMonth()
    {
        Console.Write("Enter month (1–12): ");
        return int.Parse(Console.ReadLine());
    }

    static int PromptQuarter()
    {
        Console.Write("Enter quarter (1–4): ");
        return int.Parse(Console.ReadLine());
    }

    static double[] PromptWeights()
    {
        Console.Write("Enter 3 weights separated by space (e.g. 0.5 0.3 0.2): ");
        return Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
    }


    static double PromptAlpha()
    {
        Console.Write("Enter alpha (0 < α < 1): ");
        return double.Parse(Console.ReadLine());
    }
}
