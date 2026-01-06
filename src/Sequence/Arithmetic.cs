using System;

namespace NaesungMath.Sequence
{
    /// <summary>
    /// Arithmetic Progression Solver
    /// 
    /// Provides methods to calculate the nth term, sum, and missing variables 
    /// of an arithmetic progression.
    /// </summary>
    public static class Arithmetic
    {
        public class Result
        {
            public double A { get; set; }
            public double D { get; set; }
            public double N { get; set; }
            public double An { get; set; }
            public double S { get; set; }
        }

        /// <summary>
        /// Calculates the nth term of an arithmetic progression.
        /// Formula: an = a + (n - 1)d
        /// </summary>
        public static double NthTerm(double a, double d, double n)
        {
            return a + (n - 1) * d;
        }

        /// <summary>
        /// Calculates the first term given d, n, an.
        /// Formula: a = an - (n - 1)d
        /// </summary>
        public static double FirstTerm(double d, double n, double an)
        {
            return an - (n - 1) * d;
        }

        /// <summary>
        /// Calculates the common difference given a, n, an.
        /// Formula: d = (an - a) / (n - 1)
        /// </summary>
        public static double CommonDifference(double a, double n, double an)
        {
            if (n == 1) throw new ArgumentException("Cannot determine common difference with only 1 term.");
            return (an - a) / (n - 1);
        }

        /// <summary>
        /// Calculates the number of terms given a, d, an.
        /// Formula: n = (an - a) / d + 1
        /// </summary>
        public static double NumberOfTerms(double a, double d, double an)
        {
            if (d == 0) throw new ArgumentException("Common difference is 0; infinite terms or invalid input.");
            return (an - a) / d + 1;
        }

        /// <summary>
        /// Calculates the sum of an arithmetic progression.
        /// Formula: S = n(a + an) / 2
        /// </summary>
        public static double Sum(double a, double an, double n)
        {
            return (n * (a + an)) / 2;
        }

        /// <summary>
        /// Smart Solver: Analyzes the arithmetic progression and calculates missing variables.
        /// Input must have at least 3 distinct variables to solve for the others.
        /// </summary>
        public static Result Solve(double? a = null, double? d = null, double? n = null, double? an = null, double? s = null)
        {
            bool changed = true;
            while (changed)
            {
                changed = false;

                // 1. Relations involving a, d, n, an
                if (an == null && a != null && n != null && d != null)
                {
                    an = NthTerm(a.Value, d.Value, n.Value);
                    changed = true;
                }
                if (a == null && an != null && n != null && d != null)
                {
                    a = FirstTerm(d.Value, n.Value, an.Value);
                    changed = true;
                }
                if (d == null && a != null && an != null && n != null && n != 1)
                {
                    d = CommonDifference(a.Value, n.Value, an.Value);
                    changed = true;
                }
                if (n == null && a != null && an != null && d != null && d != 0)
                {
                    n = NumberOfTerms(a.Value, d.Value, an.Value);
                    changed = true;
                }

                // 2. Relations involving Sum
                if (s == null && n != null && a != null && an != null)
                {
                    s = Sum(a.Value, an.Value, n.Value);
                    changed = true;
                }
                if (n == null && s != null && a != null && an != null && (a + an) != 0)
                {
                    n = (2 * s.Value) / (a.Value + an.Value);
                    changed = true;
                }
                if (a == null && s != null && n != null && an != null)
                {
                    a = (2 * s.Value) / n.Value - an.Value;
                    changed = true;
                }
                if (an == null && s != null && n != null && a != null)
                {
                    an = (2 * s.Value) / n.Value - a.Value;
                    changed = true;
                }

                // 3. Relations involving Sum and D (Derived variations)
                // a = S/n - (n-1)d/2
                if (a == null && s != null && n != null && d != null && n != 0)
                {
                    a = (s.Value / n.Value) - ((n.Value - 1) * d.Value) / 2;
                    changed = true;
                }

                // d = (2S/n - 2a) / (n-1)
                if (d == null && s != null && n != null && a != null && n != 0 && n != 1)
                {
                    d = ((2 * s.Value) / n.Value - 2 * a.Value) / (n.Value - 1);
                    changed = true;
                }

                // Solve for n (Quadratic): dn^2 + (2a-d)n - 2S = 0
                if (n == null && s != null && a != null && d != null && d != 0)
                {
                    double discriminant = Math.Pow(2 * a.Value - d.Value, 2) + 8 * d.Value * s.Value;
                    if (discriminant >= 0)
                    {
                        double root = (-(2 * a.Value - d.Value) + Math.Sqrt(discriminant)) / (2 * d.Value);
                        if (root > 0 && Math.Abs(root - Math.Round(root)) < 1e-9)
                        {
                            n = Math.Round(root);
                            changed = true;
                        }
                    }
                }

                // an = S/n + (n-1)d/2
                if (an == null && s != null && n != null && d != null && n != 0)
                {
                    an = (s.Value / n.Value) + ((n.Value - 1) * d.Value) / 2;
                    changed = true;
                }

                if (a != null && d != null && n != null && an != null && s != null) break;
            }

            if (a == null || d == null || n == null || an == null || s == null)
            {
                throw new InvalidOperationException("Insufficient data to solve the arithmetic progression.");
            }

            return new Result
            {
                A = a.Value,
                D = d.Value,
                N = n.Value,
                An = an.Value,
                S = s.Value
            };
        }
    }
}
