abstract class Forecast
{

    protected List<int[]> _data;

    // read data first
    // Extract Monthly
    // Extract Qrty
    // Extract Yearly
    public abstract int MovingAverage();

    public abstract int WeightedAverage();


    public abstract int Smoothing();

    public int Solve();

    public virtual int MAD(int type)
    {
        int avg = type switch
        {
            0 => MovingAverage(),
            1 => WeightedAverage(),
            2 => Smoothing(),
            _ => throw new ArgumentException("no")


        };
        //return Math.Abs(_data - int)

    }
    public int MAPE(int type)
    {
        int avg = type switch
        {
            0 => MovingAverage(),
            1 => WeightedAverage(),
            2 => Smoothing(),
            _ => throw new ArgumentException("no")
        };
    }

}
