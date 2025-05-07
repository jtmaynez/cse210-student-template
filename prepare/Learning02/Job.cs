
public class Job{
public string _company;
public string _jobTitle;
public int _startYear, endYear;

public void Display()
{
    Console.WriteLine($"{_jobTitle} ({_company}) {_startYear} - {endYear}");
}
}


