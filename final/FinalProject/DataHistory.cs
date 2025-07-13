public class DataHistory
{
    protected Dictionary<int, int[]> _data;


    // get single month plus year
    // get qaurter plus year and quarter we want
    // get year
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
        public int GetQuarterly(int year, int quarter)
    {
        int[] months = _data[year];
        int month = (quarter - 1)* 3; // this line creates the 4 quarters
        return months[month..(month+3)].Sum();

    }
    public int GetMonth(int year, int month)
    {
        int[] months = _data[year];
        month --; 
        return months[month];

    }

}