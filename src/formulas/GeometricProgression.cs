using System;

namespace NaesungMath.Formulas
{
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

        public static Result Solve(double? a = null, double? r = null, double? n = null, double? an = null, double? s = null, double? infinitySum = null)
        {
            bool changed = true;
            int loopCount = 0;

            // Helper to check if value has value
            bool IsDef(double? v) => v.HasValue;

            while (changed && loopCount < 5)
            {
                changed = false;

                if (!IsDef(an) && IsDef(a) && IsDef(r) && IsDef(n))
                {
                    an = a.Value * Math.Pow(r.Value, n.Value);
                    changed = true;
                }

                if (!IsDef(s) && IsDef(a) && IsDef(r) && IsDef(n))
                {
                    if (r.Value != 1)
                    {
                        s = a.Value * (1 - Math.Pow(r.Value, n.Value)) / (1 - r.Value);
                        changed = true;
                    }
                }

                if (!IsDef(infinitySum) && IsDef(a) && IsDef(r))
                {
                    if (r.Value > -1 && r.Value < 1)
                    {
                        infinitySum = a.Value / (1 - r.Value);
                        changed = true;
                    }
                }
                
                // Inverse a
                if (!IsDef(a) && IsDef(an) && IsDef(r) && IsDef(n))
                {
                    a = an.Value / Math.Pow(r.Value, n.Value);
                    changed = true;
                }

                loopCount++;
            }

            return new Result { A = a, R = r, N = n, An = an, S = s, InfinitySum = infinitySum };
        }
    }
}
