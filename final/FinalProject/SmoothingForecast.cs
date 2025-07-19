public class SmoothingForecast : Forecast
{
    private double _alpha;

    public SmoothingForecast(double alpha) : base()
    {
        _alpha = alpha;
    }

    public override int Calculate(int year)
    {
        int prev;
        try
        {
            prev = _data.GetPrevYear(year - 1); // STOP the recursion
        }
        catch (ArgumentException)
        {
            prev = _data.GetPrevYear(year);
        }

        return (int)Math.Ceiling(_alpha * _data.GetPrevYear(year) + (1 - _alpha) * prev);
    }

    public override int Calculate(int year, Month month)
    {
        int prev;
        try
        {
            prev = _data.GetPrevMonth(year - 1, month); 
        }
        catch (ArgumentException)
        {
            prev = _data.GetPrevMonth(year, month);
        }

        return (int)Math.Ceiling(_alpha * _data.GetPrevMonth(year, month) + (1 - _alpha) * prev);
    }

    public override int Calculate(int year, Quarter quarter)
    {
        int qPrev = _data.GetPrevQuarter(year, quarter);
        Quarter oneBeforePrev = (Quarter)(((int)quarter - 2 + 4) % 4);
        int prevYear = year;

        if ((int)quarter <= 1) // Q1 or Q2 means we’re wrapping into previous year
            prevYear--;

        int qPrev2 = _data.GetQuarterly(prevYear, oneBeforePrev);

        return (int)Math.Ceiling(_alpha * qPrev + (1 - _alpha) * qPrev2);
    }

}
