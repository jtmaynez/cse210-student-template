public abstract class Forecast
{

    protected DataHistory _data;
    protected int _year;
    protected int? _month;
    protected int? _quarter;

    public Forecast() // Put filename in paramater if asking user for a filename
    {
        _data = new("QtySold.csv");
    }

    public abstract int Calculate(int year);

    public abstract int Calculate(int year, Month month);
    public abstract int Calculate(int year, Quarter quarter);
}
