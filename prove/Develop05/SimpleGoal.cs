public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override string GetFormat()
    {
        return string.Join("|", "Simple Goal", base.GetFormat(), _isComplete);
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override void Display()
    {
        Console.WriteLine($"[{(IsComplete() ? 'X' : ' ')}] {GetName()} ({GetDescription()})");
    }

    public override int RecordEvent()
    {
        if (_isComplete == true)
        {
            Console.WriteLine("Congrats you completed this simple goal.");
            return 0;
        }
        _isComplete = true;
        return base.RecordEvent();
    }
}