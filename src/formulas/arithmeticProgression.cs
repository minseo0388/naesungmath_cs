using System;

namespace NaesungMath.Formulas
{
    public static class ArithmeticProgression
    {
        public class Result
        {
            public double? A { get; set; }
            public double? D { get; set; }
            public double? N { get; set; }
            public double? An { get; set; }
            public double? S { get; set; }
        }

        public static Result Solve(double? a = null, double? d = null, double? n = null, double? an = null, double? s = null)
        {
            bool changed = true;
            int loopCount = 0;
            
            bool IsDef(double? v) => v.HasValue;

            while (changed && loopCount < 5)
            {
                changed = false;

                if (!IsDef(an) && IsDef(a) && IsDef(n) && IsDef(d))
                {
                    an = a.Value + (n.Value - 1) * d.Value;
                    changed = true;
                }

                if (!IsDef(s) && IsDef(n) && IsDef(a) && IsDef(an))
                {
                    s = n.Value * (a.Value + an.Value) / 2;
                    changed = true;
                }

                if (!IsDef(s) && IsDef(n) && IsDef(a) && IsDef(d))
                {
                    s = n.Value * (2 * a.Value + (n.Value - 1) * d.Value) / 2;
                    changed = true;
                }
                
                // Inverses
                if (!IsDef(a) && IsDef(an) && IsDef(n) && IsDef(d))
                {
                    a = an.Value - (n.Value - 1) * d.Value;
                    changed = true;
                }

                loopCount++;
            }

            return new Result { A = a, D = d, N = n, An = an, S = s };
        }
    }
}
