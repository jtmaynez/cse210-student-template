using System;


class Program
{
    static void Main(string[] args)
    {

// This is a program to  compute area of a circle
// Get the radius of the circle from the user
        console.Write("Please Enter the radius: ");
        string text = Console.ReadLine();
        double radius = double.Parse(text);

        // compute the area
        double area = Math.PI * radius * radius
        Console.WriteLine($"Area of the circle: {area}");
        int x = 3;
        string s = "goodbye";
        float f = 3.14F;
        double d = 5.21;
        long n = 25;
        Console.WriteLine($"Hello, {s} Sandbox World! {x} {f} {d}");
    }
}