using System;
using NaesungMath.Formulas;

class VerifyGPSolver
{
    static void Main()
    {
        Console.WriteLine("Verifying GeometricProgression Solver (C#)...");
        int errors = 0;

        void AssertClose(double? actual, double expected, string name)
        {
            if (!actual.HasValue)
            {
                Console.WriteLine($"[FAIL] {name} is null, expected {expected}");
                errors++;
                return;
            }
            if (Math.Abs(actual.Value - expected) > 1e-9)
            {
                Console.WriteLine($"[FAIL] {name}: got {actual.Value}, expected {expected}");
                errors++;
            }
            else
            {
                // Console.WriteLine($"[PASS] {name}");
            }
        }

        try
        {
            // Case 1: Given a, r, n -> Find an, s
            // a=2, r=3, n=4 -> an=162, s=80
            var res1 = GeometricProgression.Solve(a: 2, r: 3, n: 4);
            Console.WriteLine($"Case 1 (a=2, r=3, n=4) -> an={res1.An}, s={res1.S}");
            AssertClose(res1.An, 162, "Case 1 an");
            AssertClose(res1.S, 80, "Case 1 s");

            // Case 2: Given a, n, an -> Find r
            // a=2, n=4, an=162 -> r=3
            var res2 = GeometricProgression.Solve(a: 2, n: 4, an: 162);
            Console.WriteLine($"Case 2 (a=2, n=4, an=162) -> r={res2.R}");
            AssertClose(res2.R, 3, "Case 2 r");

            // Case 3: Given a, r, s -> Find n
            // a=2, r=3, s=80 -> n=4
            var res3 = GeometricProgression.Solve(a: 2, r: 3, s: 80);
            Console.WriteLine($"Case 3 (a=2, r=3, s=80) -> n={res3.N}");
            AssertClose(res3.N, 4, "Case 3 n");

            // Case 4: Infinity Sum
            // a=10, r=0.5 -> infinitySum=20
            var res4 = GeometricProgression.Solve(a: 10, r: 0.5);
            Console.WriteLine($"Case 4 (a=10, r=0.5) -> infinitySum={res4.InfinitySum}");
            AssertClose(res4.InfinitySum, 20, "Case 4 infinitySum");

            // Case 5: Find a from infinitySum
            // infinitySum=20, r=0.5 -> a=10
            var res5 = GeometricProgression.Solve(infinitySum: 20, r: 0.5);
            Console.WriteLine($"Case 5 (inf=20, r=0.5) -> a={res5.A}");
            AssertClose(res5.A, 10, "Case 5 a");

            if (errors == 0)
            {
                Console.WriteLine("All C# Solver tests passed!");
            }
            else
            {
                Console.WriteLine($"{errors} tests failed.");
                Environment.Exit(1);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error running validation: {ex.Message}");
            Environment.Exit(1);
        }
    }
}
