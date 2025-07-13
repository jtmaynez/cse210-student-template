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
       