using System.Security.Principal;

public class Breathing:Activity
{


    public Breathing() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {

    }
    public void Run()
    {

        base.StartMessage();
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(base.GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("Breath in...");
            base.CountDown(3);
            Console.WriteLine();
            Console.Write("Breath Out...");
            base.CountDown(4);
            Console.WriteLine();
            Console.WriteLine();

        }
       
        base.EndMessage();
        base.Spinner(3);
}

    
}