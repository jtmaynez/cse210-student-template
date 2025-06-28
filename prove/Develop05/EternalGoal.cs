public class EternalGoal : Goal
{



    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {

    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetFormat()
    {
        return string.Join("|", "Eternal Goal", base.GetFormat());
    }
    public override void Display()
    {
        Console.WriteLine($"[ ] {GetName()} ({GetDescription()})");
    }

    public override int RecordEvent()
    {
        return _points;
       
    }
}