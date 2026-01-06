using System;

namespace NaesungMath.Formulas
{
    /// <summary>
    /// Geometric Progression Solver
    /// 
    /// Unifies the calculation of geometric progression properties:
    /// - A: First term
    /// - R: Common ratio
    /// - N: Number of terms (0-indexed logic matching formulas)
    /// - An: The term at index n (an = a * r^n)
    /// - S: Sum of first n terms (a, ar, ..., ar^(n-1))
    /// - InfinitySum: Sum to infinity (if -1 < r < 1)
    /// </summary>
    public static class GeometricProgression
    {
        public class Result
        {
            public double? A { get; set; }
            public double? R { get; set; }
            public double? N { get; set; }
            public double? An { get; set; }
            public double? S { get; set; }
            public double? InfinitySum { get; set; }
        }

        /// <summary>
        /// Solves for missing Geometric Progression variables.
        /// </summary>
        public static Result Solve(double? a = null, double? r = null, double? n = null, double? an = null, double? s = null, double? infinitySum = null)
        {
            bool changed = true;
            int loopCount = 0;

            // Helper to check if value has value
            bool IsDef(double? v) => v.HasValue;

            while (changed && loopCount < 5)
            {
                changed = false;

                // 1. Calculate an if a, r, n exist
                if (!IsDef(an) && IsDef(a) && IsDef(r) && IsDef(n))
                {
                    an = a.Value * Math.Pow(r.Value, n.Value);
                    changed = true;
                }

                // 2. Calculate s if a, r, n exist
                if (!IsDef(s) && IsDef(a) && IsDef(r) && IsDef(n))
                {
                    if (r.Value == 1)
                    {
                        s = a.Value * n.Value;
                    }
                    else
                    {
                        s = a.Value * (1 - Math.Pow(r.Value, n.Value)) / (1 - r.Value);
                    }
                    changed = true;
                }

                // 2b. Calculate InfinitySum if a, r exist
                if (!IsDef(infinitySum) && IsDef(a) && IsDef(r))
                {
                    if (Math.Abs(r.Value) < 1)
                    {
                        infinitySum = a.Value / (1 - r.Value);
                        changed = true;
                    }
                }

                // 3. Calculate n if a, an, r exist
                if (!IsDef(n) && IsDef(a) && IsDef(an) && IsDef(r))
                {
                    if (a.Value != 0)
                    {
                        n = Math.Log(an.Value / a.Value) / Math.Log(r.Value);
                        changed = true;
                    }
                }

                // 4. Calculate a if an, r, n exist
                if (!IsDef(a) && IsDef(an) && IsDef(r) && IsDef(n))
                {
                    a = an.Value / Math.Pow(r.Value, n.Value);
                    changed = true;
                }
                // 4b. Calculate a if infinitySum, r exist
                if (!IsDef(a) && IsDef(infinitySum) && IsDef(r))
                {
                    a = infinitySum.Value * (1 - r.Value);
                    changed = true;
                }

                // 5. Calculate r if a, an, n exist
                if (!IsDef(r) && IsDef(a) && IsDef(an) && IsDef(n))
                {
                    if (a.Value != 0 && n.Value != 0)
                    {
                        // Logic similar to JS/Py: simple real root support
                        double val = an.Value / a.Value;
                        if (val >= 0)
                        {
                            r = Math.Pow(val, 1.0 / n.Value);
                            changed = true;
                        }
                        else if (n.Value % 2 != 0) // Odd root of negative number
                        {
                            // Math.Pow(-8, 1/3) returns NaN in C# usually? No, it returns NaN.
                            // C# Math.Pow(x, y) returns NaN if x < 0 and y is not an integer.
                            // We need to handle sign manually.
                            r = -Math.Pow(-val, 1.0 / n.Value);
                            changed = true;
                        }
                    }
                }
                // 5b. Calculate r if a, infinitySum exist
                if (!IsDef(r) && IsDef(a) && IsDef(infinitySum))
                {
                    if (infinitySum.Value != 0)
                    {
                        r = 1 - (a.Value / infinitySum.Value);
                        changed = true;
                    }
                }

                // 6. S related inversions
                // If a, r, s known => find n
                if (!IsDef(n) && IsDef(a) && IsDef(r) && IsDef(s))
                {
                    if (r.Value != 1 && a.Value != 0)
                    {
                        double term = 1 - (s.Value * (1 - r.Value) / a.Value);
                        if (term > 0)
                        {
                            n = Math.Log(term) / Math.Log(r.Value);
                            changed = true;
                        }
                    }
                }

                // If r, n, s known => find a
                if (!IsDef(a) && IsDef(r) && IsDef(n) && IsDef(s))
                {
                    if (r.Value == 1)
                    {
                        if (n.Value != 0)
                        {
                            a = s.Value / n.Value;
                            changed = true;
                        }
                    }
                    else
                    {
                        double denom = 1 - Math.Pow(r.Value, n.Value);
                        if (denom != 0)
                        {
                            a = s.Value * (1 - r.Value) / denom;
                            changed = true;
                        }
                    }
                }

                loopCount++;
            }

            return new Result
            {
                A = a,
                R = r,
                N = n,
                An = an,
                S = s,
                InfinitySum = infinitySum
            };
        }
    }
}
