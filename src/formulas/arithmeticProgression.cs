using System;
using System.Collections.Generic;

namespace NaesungMath.Formulas
{
    public static class ArithmeticProgression
    {
        public static Dictionary<string, double?> Solve(double? a = null, double? d = null, double? n = null, double? an = null, double? s = null)
        {
            // Calculate N
            if (n == null)
            {
                if (a != null && d != null && an != null && d != 0) n = (an - a) / d + 1;
                else if (a != null && an != null && s != null && (a + an) != 0) n = 2 * s / (a + an);
                else if (d != null && a != null && s != null)
                {
                    if (d != 0)
                    {
                        double delta = Math.Pow(2 * a.Value - d.Value, 2) - 4 * d.Value * (-2 * s.Value);
                        if (delta >= 0)
                        {
                            double n1 = (-(2 * a.Value - d.Value) + Math.Pow(delta, 0.5)) / (2 * d.Value);
                            double n2 = (-(2 * a.Value - d.Value) - Math.Pow(delta, 0.5)) / (2 * d.Value);
                            if (n1 > 0 && Math.Abs(n1 - Math.Round(n1)) < 1e-9) n = n1;
                            else if (n2 > 0 && Math.Abs(n2 - Math.Round(n2)) < 1e-9) n = n2;
                        }
                    }
                }
            }

            // Calculate A
            if (a == null)
            {
                if (an != null && n != null && d != null) a = an - (n - 1) * d;
                else if (s != null && n != null && an != null) a = 2 * s / n - an;
                else if (s != null && n != null && d != null) a = (2 * s / n - (n - 1) * d) / 2;
            }

            // Calculate D
            if (d == null)
            {
                if (an != null && a != null && n != null && n != 1) d = (an - a) / (n - 1);
                else if (s != null && n != null && a != null && n != 1) d = (2 * s / n - 2 * a) / (n - 1);
            }

            // Calculate AN
            if (an == null)
            {
                if (a != null && n != null && d != null) an = a + (n - 1) * d;
            }

            // Calculate S
            if (s == null)
            {
                if (n != null && a != null && an != null) s = n * (a + an) / 2;
                else if (n != null && a != null && d != null) s = n * (2 * a + (n - 1) * d) / 2;
            }

            return new Dictionary<string, double?>
            {
                { "a", a },
                { "d", d },
                { "n", n },
                { "an", an },
                { "sum", s }
            };
        }
    }
}
