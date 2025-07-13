#nullable enable
public class SmoothingForecast : Forecast
{
public override int Calculate(int year, int? month = null, int? quarter = null, double[]? weights = null, double? alpha = null)
{
    if (alpha == null || alpha <= 0 || alpha >= 1)
        throw new ArgumentException("Alpha must be between 0 and 1.");

    double prevSmoothed;

    if (month.HasValue)
    {
        var m3 = GetPreviousMonth(year, month.Value, 3);
        prevSmoothed = _data.GetMonth(m3.year, m3.month);

        for (int i = 2; i >= 1; i--)
        {
            var mi = GetPreviousMonth(year, month.Value, i);
            int actual = _data.GetMonth(mi.year, mi.month);
            prevSmoothed = prevSmoothed + alpha.Value * (actual - prevSmoothed);
        }
    }
    else if (quarter.HasValue)
    {
        var q3 = GetPreviousQuarter(year, quarter.Value, 3);
        prevSmoothed = _data.GetQuarterly(q3.year, q3.quarter);

        for (int i = 2; i >= 1; i--)
        {
            var qi = GetPreviousQuarter(year, quarter.Value, i);
            int actual = _data.GetQuarterly(qi.year, qi.quarter);
            prevSmoot