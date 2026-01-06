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

            while (changed && loopCount < 5)
            {
                changed = false;

                if (an == null && a != null && r != null && n != null)
                {
                    an = a.Value * Math.Pow(r.Value, n.Value);
                    changed = true;
                }

                if (s == null && a != null && r != null && n != null)
                {
                    if (r.Value != 1)
                    {
                        s = a.Value * (1 - Math.Pow(r.Value, n.Value)) / (1 - r.Value);
                        changed = true;
                    }
                }

                if (infinitySum == null && a != null && r != null)
                {
                    if (r.Value > -1 && r.Value < 1)
                    {
                        infinitySum = a.Value / (1 - r.Value);
                        changed = true;
                    }
                }
                
                // Inverse a
                if (a == null && an != null && r != null && n != null)
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
