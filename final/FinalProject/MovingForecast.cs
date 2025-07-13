public class MovingForecast : Forecast
{
    // Don't need constructer because I have the constructer in base
public override int Calculate(int year, int? month = null, int? quarter = null, double[] weights = null, double? alpha = null)
{
    int[] data;

    if (m