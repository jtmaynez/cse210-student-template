#nullable enable // dont know if this is correct
public abstract class Forecast
{

    protected DataHistory _data;

    public Forecast() // Put filename in paramater if asking user for a filename
    {
        _data = new("QtySold.csv");
    }
    public abstract int Calculate(int year, int? month = null, int? quarter = null, double[]? weights = null, double? alpha = null
    );

    public double MAD(int forecast, int year, int? month = null, int? quarter = null)
    { // bellow is a shortcut for if statements
        int actual = month.HasValue
            ? _data.GetMonth(year, month.Value)
            : quarter.HasValue
                ? _data.GetQuarterly(year, quarter.Value)
                : _data.GetYear(year);

        return Math.Abs(actual - forecast);
    }

    public double MAPE(int forecast, int year, int? month = null, int? quarter = null)
    {
        int actual = month.HasValue
            ? _data.GetMonth(year, month.Value)
            : quarter.HasValue
                ? _data.GetQuarterly(year, quarter.Value)
                : _data.GetYear(year);

        return actual != 0 ? Math.Abs((double)(actual - forecast) / actual) : 0;
    }
    protected (int year, int quarter) GetPreviousQuarter(int year, int quarter, int stepsBack)
//Tuple
    {
    int newQuarter = quarter - stepsBack;
    while (newQuarter <= 0)
    {
        year--;
        newQuarter += 4;
    }
    return (year, newQuarter);
}
protected (int year, int month) GetPreviousMonth(int year, int month, int stepsBack)
{
    int newMonth = month - stepsBack;
    while (newMonth <= 0)
    {
        year--;
        newMonth += 12;

        if (year < 2015)
            throw new ArgumentException("Cannot forecast before January 2015 — not enough historical data.");
    }
    return (year, newMonth);
}

}
