// the parent class showing the "virtual" keyword included
public abstract class Employee
{
    private string _employeeName;
    public Employee(string employeeName)
    {
        _employeeName = employeeName;
    }
    // Notice the abstract method doesn't have a body at all
    // (not even an empty one) and it is followed by a semicolon.
    public abstract float CalculatePay();
    public string GetEmployeeName()
    {
        
    }

}


// a child class
public class SalaryEmployee : Employee
{
    private float _salary = 100f;
    public SalaryEmployee(string employeeName) :
    base(employeeName)
    {
        
    }

    public override float CalculatePay()
    {
        return _salary;
    }
}


// a child class
public class HourlyEmployee : Employee
{
    private float _rate = 9f;
    private float _hours = 100f;

    public HourlyEmployee(string employeeName, float rate) :
    base(employeeName)
    {

    }

    public override float CalculatePay()
    {
        return _rate * _hours; // pay is calculated differently
    }
}


public class Program
{
    // ...

    // static Employee GetManager()
    // {
    //     // ... code here to find the manager ...
    //     return theManager;
    // }

    // static void DisplayManagerPay()
    // {
    //     Employee manager = GetManager();
    //     float pay = manager.CalculatePay();
    //     // ...
    // }

    public static void Main(string[] args)
    {
        // Create a list of Employees
        List<Employee> employees = new List<Employee>();

        // Create different kinds of employees and add them to the same list
        employees.Add(new SalaryEmployee("Emma Davis"));
        employees.Add(new HourlyEmployee("Micah Earl"));

        // Get a custom calculation for each one
        foreach (Employee employee in employees)
        {
            string name = employee.GetEmployeeName();
            float pay = employee.CalculatePay();
            Console.WriteLine($"{name} {pay}");
        }
    }
}
