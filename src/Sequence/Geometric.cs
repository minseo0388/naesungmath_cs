using System;

namespace NaesungMath.Sequence
{
    /// <summary>
    /// Geometric Progression Solver
    /// 
    /// Provides methods to calculate the nth term, sum, and missing variables 
    /// of a geometric progression.
    /// </summary>
    public static class Geometric
    {
        public class Result
        {
            public double A { get; set; }
            public double R { get; set; }
            public double N { get; set; }
            public double An { get; set; }
            public double S { get; set; }
        }

        /// <summary>
        /// Calculates the nth term of a geometric progression.
        /// Formula: an = a * r^(n - 1)
        /// </summary>
        public static double NthTerm(double a, double r, double n)
        {
            return a * Math.Pow(r, n - 1);
        }

        /// <summary>
        /// Calculates the first term given r, n, an.
        /// Formula: a = an / r^(n - 1)
        /// </summary>
        public static double FirstTerm(double r, double n, double an)
        {
            if (r == 0) throw new ArgumentException("Common ratio is 0; first term cannot be uniquely determined from nth term.");
            return an / Math.Pow(r, n - 1);
        }

        /// <summary>
        /// Calculates the common ratio given a, n, an.
        /// Formula: r = (an / a)^(1 / (n - 1))
        /// </summary>
        public static double CommonRatio(double a, double n, double an)
        {
            if (a == 0) throw new ArgumentException("First term is 0; common ratio is undefined/indeterminate.");
            if (n == 1) throw new ArgumentException("Cannot determine common ratio with only 1 term.");
            return Math.Pow(an / a, 1.0 / (n - 1));
        }

        /// <summary>
        /// Calculates the number of terms given a, r, an.
        /// Formula: n = log_r(an / a) + 1
        /// </summary>
        public static double NumberOfTerms(double a, double r, double an)
        {
            if (a == 0 || r <= 0 || r == 1) throw new ArgumentException("Invalid inputs for logarithmic calculation of n.");
            return (Math.Log(an / a) / Math.Log(r)) + 1;
        }

        /// <summary>
        /// Calculates the sum of a geometric progression.
        /// Formula: S = a(r^n - 1) / (r - 1) for r != 1
        ///          S = na for r = 1
        /// </summary>
        public static double Sum(double a, double r, double n)
        {
            if (r == 1) return n * a;
            return (a * (Math.Pow(r, n) - 1)) / (r - 1);
        }

        /// <summary>
        /// Smart Solver: Analyzes the geometric progression and calculates missing variables.
        /// Input must have at least 3 distinct variables to solve for the others.
        /// </summary>
        public static Result Solve(double? a = null, double? r = null, double? n = null, double? an = null, double? s = null)
        {
            bool changed = true;
            while (changed)
            {
                changed = false;

                // 1. Relations involving a, r, n, an
                if (an == null && a != null && r != null && n != null)
                {
                    an = NthTerm(a.Value, r.Value, n.Value);
                    changed = true;
                }
                if (a == null && an != null && r != null && n != null && r != 0)
                {
                    a = FirstTerm(r.Value, n.Value, an.Value);
                    changed = true;
                }
                if (r == null && a != null && an != null && n != null && a != 0 && n != 1)
                {
                    r = CommonRatio(a.Value, n.Value, an.Value);
                    changed = true;
                }
                if (n == null && a != null && r != null && an != null && a != 0 && r > 0 && r != 1)
                {
                    n = NumberOfTerms(a.Value, r.Value, an.Value);
                    changed = true;
                }

                // 2. Relations involving Sum
                if (s == null && a != null && r != null && n != null)
                {
                    s = Sum(a.Value, r.Value, n.Value);
                    changed = true;
                }

                // Solve for a: a = S(r-1) / (r^n - 1)
                if (a == null && s != null && r != null && n != null)
                {
                    if (r == 1)
                    {
                        a = s / n;
                        changed = true;
                    }
                    else
                    {
                        double num = Math.Pow(r.Value, n.Value) - 1;
                        if (num != 0)
                        {
                            a = (s.Value * (r.Value - 1)) / num;
                            changed = true;
                        }
                    }
                }

                // Solve for an using Sum: an = (S(r-1) + a) / r
                if (an == null && s != null && r != null && a != null && r != 0 && r != 1)
                {
                    an = (s.Value * (r.Value - 1) + a.Value) / r.Value;
                    changed = true;
                }

                if (a != null && r != null && n != null && an != null && s != null) break;
            }

            if (a == null || r == null || n == null || an == null || s == null)
            {
                throw new InvalidOperationException("Insufficient data to solve the geometric progression.");
            }

            return new Result
            {
                A = a.Value,
                R = r.Value,
                N = n.Value,
                An = an.Value,
                S = s.Value
            };
        }
    }
}
