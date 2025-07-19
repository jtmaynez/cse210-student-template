using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nWelcome to your Supply Chain Management System!");
            Console.WriteLine("1. Create a Forecast");
            Console.WriteLine("2. Calculate Inventory Equation");
            Console.WriteLine("3. Quit");
            Console.Write("What do you want to do: ");
            string menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    RunForecast();
                    break;

                case "2":
                    Console.WriteLine("Inventory section coming soon");
                    break;

                case "3":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }
        }
    }

    static void RunForecast()
    {
        try
        {
            Console.WriteLine("Select Timeframe you want to Forecast:");
            Console.WriteLine("1. Yearly Forecast");
            Console.WriteLine("2. Quarterly Forecast");
            Console.WriteLine("3 . Monthly Forecast");
            Console.Write("Enter Timeframe:");
            string timeframeChoice = Console.ReadLine();

            Console.Write("Enter year (e.g. 2015-2024): ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter 3 weights separated by commas (e.g. 0.2,0.3,0.5): ");
            string[] weightStrings = Console.ReadLine().Split(',');
            double[] weights = Array.ConvertAll(weightStrings, double.Parse);

            Console.Write("Enter smoothing alpha (e.g. 0.25): ");
            double alpha = double.Parse(Console.ReadLine());

            var moving = new MovingForecast();
            var weighted = new WeightedAverageForecast(weights);
            var smoothing = new SmoothingForecast(alpha);
            var dataHistory = new DataHistory("QtySold.csv");

            int actual = 0, mvForecast = 0, wtForecast = 0, smForecast = 0;
            string label = "";

            if (timeframeChoice == "1") // Year
            {
                mvForecast = moving.Calculate(year);
                wtForecast = weighted.Calculate(year);
                smForecast = smoothing.Calculate(year);
                actual = dataHistory.GetYear(year);
                label = year.ToString();
            }
            else if (timeframeChoice == "2") // Quarter
            {
                Console.Write("Enter quarter (1-4): ");
                if (!int.TryParse(Console.ReadLine(), out int qNum) || qNum < 1 || qNum > 4)
                {
                    Console.WriteLine("Invalid quarter. Must be between 1 and 4.");
                    return;
                }

                Quarter quarter = (Quarter)(qNum - 1);
                mvForecast = moving.Calculate(year, quarter);
                wtForecast = weighted.Calculate(year, quarter);
                smForecast = smoothing.Calculate(year, quarter);
                actual = dataHistory.GetQuarterly(year, quarter);
                label = $"Q{qNum} {year}";
            }
            else if (timeframeChoice == "3") // Month
            {
                Console.Write("Enter month number (1-12): ");
                if (!int.TryParse(Console.ReadLine(), out int monthNum) || monthNum < 1 || monthNum > 12)
                {
                    Console.WriteLine("Invalid month number. Please enter a number from 1 to 12.");
                    return;
                }

                Month month = (Month)(monthNum - 1);
                mvForecast = moving.Calculate(year, month);
                wtForecast = weighted.Calculate(year, month);
                smForecast = smoothing.Calculate(year, month);
                actual = dataHistory.GetMonth(year, month);
                label = $"{month} {year}";
            }
            else
            {
                Console.WriteLine("Invalid timeframe selection.");
                return;
            }

            int mvMad = Math.Abs(actual - mvForecast);
            int wtMad = Math.Abs(actual - wtForecast);
            int smMad = Math.Abs(actual - smForecast);

            double mvMape = actual != 0 ? (double)mvMad / actual * 100 : 0;
            double wtMape = actual != 0 ? (double)wtMad / actual * 100 : 0;
            double smMape = actual != 0 ? (double)smMad / actual * 100 : 0;

            Console.WriteLine("\nCalculating forecast...");
            Thread.Sleep(2000); // delay in milliseconds (1200 = 1.2 seconds)

            Console.WriteLine();
            Console.WriteLine($"Forecast Comparison for {label}");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Moving Avg:   Forecast = {mvForecast}, MAD = {mvMad}, MAPE = {mvMape:F2}%");
            Console.WriteLine($"Weighted Avg: Forecast = {wtForecast}, MAD = {wtMad}, MAPE = {wtMape:F2}%");
            Console.WriteLine($"Smoothing:    Forecast = {smForecast}, MAD = {smMad}, MAPE = {smMape:F2}%");
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.WriteLine("Returning to main menu...");
        }
    }
}
