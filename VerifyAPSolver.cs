using System;
using NaesungMath.Sequence;

class VerifyAPSolver
{
    static void Main()
    {
        Console.WriteLine("Verifying Sequence.Arithmetic Solver (C#)...");

        try
        {
            // Case 1: Given a, d, n -> Find an, s
            var res1 = Arithmetic.Solve(a: 2, d: 3, n: 4);
            Console.WriteLine($"Case 1: A={res1.A}, D={res1.D}, N={res1.N}, An={res1.An}, S={res1.S}");
            if (res1.An != 11 || res1.S != 26) throw new Exception("Case 1 failed");

            // Case 2: Given d, n, s -> Find a, an
            var res2 = Arithmetic.Solve(d: 3, n: 4, s: 26);
            Console.WriteLine($"Case 2: A={res2.A}, D={res2.D}, N={res2.N}, An={res2.An}, S={res2.S}");
            if (res2.A != 2 || res2.An != 11) throw new Exception("Case 2 failed");

            // Case 3: Given a, an, s -> Find n, d
            var res3 = Arithmetic.Solve(a: 2, an: 11, s: 26);
            Console.WriteLine($"Case 3: A={res3.A}, D={res3.D}, N={res3.N}, An={res3.An}, S={res3.S}");
            if (res3.N != 4 || res3.D != 3) throw new Exception("Case 3 failed");

            // Case 4: Given a, d, s -> Find n (Quadratic)
            var res4 = Arithmetic.Solve(a: 2, d: 3, s: 26);
            Console.WriteLine($"Case 4: A={res4.A}, D={res4.D}, N={res4.N}, An={res4.An}, S={res4.S}");
            if (res4.N != 4 || res4.An != 11) throw new Exception("Case 4 failed");

            Console.WriteLine("All C# Solver tests passed!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }
}
