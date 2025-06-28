public abstract class Goal
{
    private string _name;
    protected string _description;
    protected int _points;


    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;

    }
    public virtual int RecordEvent()
    {
        if (IsComplete())
        {

            return _points;
        }
        else
        {
            return 0;
        }
    }

    public abstract bool IsComplete();


    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    // Get format method to make it clean
    public virtual string GetFormat()
    {
        return string.Join("|", _name, _description, _points);
    }

    public abstract void Display();
    public int GetPoints() => _points; 
}

