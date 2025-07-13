#nullable enable
public class WeightedAverageForecast : Forecast
{
public override int Calculate(int year, int? month = null, int? quarter = null, double[]? weights = null, double? alpha = null)
{
    if (weights == null || weights.Length != 3)
        throw new ArgumentException("Weights must contain exactly 3 values.");

    int[] data;

    if (month.HasValue)
    {
        var m1 = GetPreviousMonth(year, month.Value, 3);
        var m2 = GetPreviousMonth(year, month.Value, 2);
        var m3 = GetPreviousMonth(year, month.Value, 1);

        data = new int[] {
            _data.GetMonth(m1.year, m1.month),
            _data.GetMonth(m2.year, m2.month),
            _data.GetMonth(m3.year, m3.month)
        };
    }
    else if (quarter.HasValue)
    {
        var q1 = GetPreviousQuarter(year, quarter.Value, 3);
        var q2 = GetPreviousQuarter(year, quarter.Value, 2);
        var q3 = GetPreviousQuarter(year, quarter.Value, 1);

        data = new int[] {
            _data.GetQuarterly(q1.year, q1.quarter),
            _data.GetQuarterly(q2.year, q2.quarter),
            _data.GetQuarterly(q3.year, q3.quarter)
        };
    }
    else
    {
        data = new int[] {
            _dat