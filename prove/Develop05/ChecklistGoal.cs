public class ChecklistGoal : Goal
{
    private int _bonusPoints;
    private int _iteration;
    private int _currentIteration;


    public ChecklistGoal(string name, string description, int points, int bonusPoint, int iteration, int currentIteration)
    : base(name, description, points)
    {
        _bonusPoints = bonusPoint;
        _iteration = iteration;
        _currentIteration = currentIteration;
    }

    public override bool IsComplete()
    {
        return _iteration == _currentIteration;
    }
    public override string GetFormat()
    {
        return string.Join("|", "CheckList Goal", base.GetFormat(), _bonusPoints, _iteration, _currentIteration);
    }
    public override void Display()
    {
        Console.WriteLine($"[{(_iteration == _currentIteration ? 'X' : ' ')}] {GetName()} ({GetDescription()}) --Currently Completed:{_currentIteration}/{_iteration} ");
    }
        public override int RecordEvent()
    {
        
        if (_currentIteration == _iteration)
        {
            Console.WriteLine("Congrats you completed this checklist goal.");
            return 0;
        }


        _currentIteration = _currentIteration + 1;


        return base.RecordEvent() + _bonusPoints;
    }
}