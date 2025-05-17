public class Entry
{
    public string _prompt;
    public string _response;
    public DateTime _date;
    public Entry(string prompt, string response)
    {
        _prompt = prompt;
        _response = response;
        _date = DateTime.Now;
    }
    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine($"Date: {_date.ToShortDateString()}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
   
    }
}