using System;

class Program
{
    static void Main(string[] args)
    {
       DisplayWelcomeMessage();
       string name = Promptname();
       int favNumber = PromptFavNumber();
       int squareNumber = SquareNumber(favNumber);

       DisplayResult(name, squareNumber);
    }
static void DisplayWelcomeMessage()
{
    Console.WriteLine("Welcome to the program! ");
}
static string Promptname()
{
    Console.Write("Please Enter your name: ");
    string name = Console.ReadLine();

    return name;
}

static int PromptFavNumber()
{
Console.Write("Please enter your favorite number: ");
int number = int.Parse(Console.ReadLine());
return number;
}

static int SquareNumber(int number)
{
int square = number * number;
return square;
}
static void DisplayResult(string name, int square)
{
Console.WriteLine($"{name}, the square of your number is {square}!");
}

}