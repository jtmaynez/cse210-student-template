public class WeightedAverageForecast : Forecast
{
    private double[] _weights;
    public WeightedAverageForecast(double[] weights) : base()
    {
        _weights = weights;
    }
    public override int Calculate(int year)
    {
        return (int)Math.Ceiling(((double[])[.._data.GetPrev3Years(year).Zip(_weights,(a,b)=>a*b)]).Sum());
    }

    public override int Calculate(int year, Month month)
    {
        return (int)Math.Ceiling(((double[])[.._data.GetPrev3Months(year, month).Zip(_weights,(a,b)=>a*b)]).Sum());

    }
    public override int Calculate(int year, Quarter quarter)
    {
        return (int)Math.Ceiling(((double[])[.._data.GetPrev3Quarters(year, quarter).Zip(_weights,(a,b)=>a*b)]).Sum());

    }

}
