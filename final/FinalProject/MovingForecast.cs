using System.Diagnostics;
using System.Reflection.Emit;

public class MovingForecast : Forecast
{
    public MovingForecast() : base()
    {

    }

    public override int Calculate(int year)
    {

        return (int)Math.Ceiling(_data.GetPrev3Years(year).Average());
    }

    public override int Calculate(int year, Month month)
    {
        return (int)Math.Ceiling(_data.GetPrev3Months(year, month).Average());
    }
    public override int Calculate(int year, Quarter quarter)
    {
        return (int)Math.Ceiling(_data.GetPrev3Quarters(year, quarter).Average());

    }
    
}


