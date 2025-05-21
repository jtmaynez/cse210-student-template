using System.Xml.Schema;


///Represents a fraction with a numerator and a denominator
/// this is more accurate than storing numbers un a double 
public class Fraction
{
    private int _numer, _denom;

    public Fraction() // Default constructer is the same name as the class
    {
        _numer = 1;
        _denom = 1;
    }

    public Fraction(int whole)
    {
        _numer = whole;
        _denom = 1;

    }
    public Fraction(int numer, int denom)
    {

        _numer = numer;
        _denom = denom;
    }

    public string GetFractionString()
    {
        string representation = $"{_numer}/{_denom}";
        return representation;
    }
    public double GetDecimalValue()
    {
        double value = (double)_numer / (double)_denom; // make one of them a double to avoid int division
        return value;
    }
}