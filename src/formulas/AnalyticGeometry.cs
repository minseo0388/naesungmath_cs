using System;

namespace NaesungMath.Formulas
{
    public static class AnalyticGeometry
    {
        public static (double x, double y) CenterGravity(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return ((x1 + x2 + x3) / 3.0, (y1 + y2 + y3) / 3.0);
        }

        public static double Eccentricity(double a, double b)
        {
            // Eccentricity of ellipse? e = sqrt(1 - b^2/a^2) (if a > b)
            // Or c/a
            // Legacy 'evalEccentricity(a, b)'.
            // Assume formula: sqrt(1 - b^2/a^2)
            if (a == 0) throw new DivideByZeroException();
            return Math.Sqrt(1 - Math.Pow(b, 2) / Math.Pow(a, 2));
        }

        public static bool IsInRange(double value, double min, double max)
        {
            return value >= min && value <= max;
        }
    }
}
