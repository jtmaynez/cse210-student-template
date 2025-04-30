using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magic = randomGenerator.Next(1,101);
    //     Console.Write("What is the magic number? ");
    //   int magic = int.Parse(Console.ReadLine());
    int guess = 0;
     while (magic != guess)
        {

        Console.Write("What is your guess? ");
         guess = int.Parse(Console.ReadLine());

        if ( magic < guess)
        {
            Console.WriteLine("Lower");
        }
        else if ( magic > guess)
        {
            Console.WriteLine("Higher");
        }
        else {
            Console.WriteLine("You guessed it!");
        }
        }
    }
}