public class DataHistory
{
    protected Dictionary<int, int[]> _data;
    public DataHistory(string fileName)
    {
        _data = [];
        foreach (string line in File.ReadLines(fileName).Skip(1))
        {
            string[] parts = line.Split(","); // string[] = is a list of strings
            string stringYear = parts[0];
            int intYear = int.Parse(stringYear);
            int[] months = [.. parts[1..].Select(i => int.Parse(i))]; // the first .. converts it to the int array
            _data[intYear] = months; // [key, year] = months are the values
        }

    }

    public int GetYear(int year) // dont forget to call this method in program
    {


        int[] months = _data[year]; // clarify the yeaer to get the int months
        return months.Sum();

    }
    public int GetPrevYear(int year)
    {
        year--;
        if (!_data.ContainsKey(year))
            throw new ArgumentException($"{year} not in dataset!");

        return GetYear(year);
    }
    public int[] GetPrev3Years(int year)
    {
        return [
            GetYear(year -1),
            GetYear(year -2),
            GetYear(year -3),
        ];
    }
   public int GetQuarterly(int year, Quarter quarter)
{
    if (!_data.ContainsKey(year))
        throw new ArgumentException($"{year} not in dataset!");

    int startIndex = ((int)quarter) * 3;
    return _data[year].Skip(startIndex).Take(3).Sum();
}

public int[] GetPrev3Quarters(int year, Quarter quarter)
{
    List<int> values = new();
    int qIndex = (int)quarter;

    for (int i = 1; i <= 3; i++)
    {
        qIndex--;
        if (qIndex < 0)
        {
            qIndex = 3;
            year--;
        }

        Quarter prevQuarter = (Quarter)qIndex;
        values.Add(GetQuarterly(year, prevQuarter));
    }

    return values.ToArray();
}

public int GetPrevQuarter(int year, Quarter quarter)
{
    int qIndex = (int)quarter - 1;
    if (qIndex < 0)
    {
        qIndex = 3;
        year--;
    }

    Quarter prevQuarter = (Quarter)qIndex;
    return GetQuarterly(year, prevQuarter);
}


    public int GetMonth(int year, Month month)
    {
        if (!_data.ContainsKey(year))
            throw new ArgumentException($"{year} not in dataset!");
        int[] months = _data[year];
        int idx = (int)month;
        if (idx < 0 || idx >= months.Length)
            throw new ArgumentOutOfRangeException("Month index out of range");
        return months[idx];
    }
    public int GetPrevMonth(int year, Month month)
    {
        while (month <= 0)
        {
            year--;
            if (!_data.ContainsKey(year))
                throw new ArgumentException($"{year} not in dataset!");
            month += 12;
        }
        return GetMonth(year, month);        
    }
    public int[] GetPrev3Months(int year, Month month)
    {
        List<int> values = new();
        for (int i = 1; i <= 3; i++)
        {
            int offset = (int)month - i;
            int targetYear = year;
            int targetMonth = offset;

            if (offset < 0)
            {
                targetYear = year - 1;
                targetMonth = 12 + offset; // wrap to previous year's December, etc.
            }
            values.Add(GetMonth(targetYear, (Month)targetMonth));
        }
        return values.ToArray();
    }

}