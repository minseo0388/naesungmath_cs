using System;
using naesungmath;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"NaesungMath v{NaesungMath.VERSION}");

        int a = 1;
        int b = 2;

        int result = NaesungMath.plus(a, b);

        Console.WriteLine($"{a} + {b} = {result}");
    }
}
