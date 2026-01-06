using System;

namespace NaesungMath.Formulas
{
    public static class Equation
    {
        public static double CubicRoots(double a, double b, double c, double d)
        {
            // Original 'cubicEquationFirst' logic
            double term1 = 2 * Math.Pow(b, 3) - (9 * a * b * c) + (27 * Math.Pow(a, 2) * d);
            double term2 = Math.Pow(b, 2) - 3 * a * c;
            double discriminantRoot = Math.Pow(Math.Pow(term1, 2) - 4 * Math.Pow(term2, 3), 0.5);

            double x = Math.Pow(0.5 * (term1 + discriminantRoot), 1.0 / 3.0);
            double y = Math.Pow(0.5 * (term1 - discriminantRoot), 1.0 / 3.0);

            return -(b / (3 * a)) - ((1.0 / (3 * a)) * x) - ((1.0 / (3 * a)) * y);
        }

        public static double Newton(Func<double, double> f, int count, double initx = 2)
        {
            double Diff(Func<double, double> func, double x, double density = 5)
            {
                double dx = 2 * Math.Pow(10, -density);
                double dy = func(x + Math.Pow(10, -density)) - func(x - Math.Pow(10, -density));
                return dy / dx;
            }

            double x_curr = initx;
            for (int i = 0; i < count; i++)
            {
                x_curr = x_curr - f(x_curr) / Diff(f, x_curr);
            }
            return x_curr;
        }

        public static (double x1, double x2) QuadraticRoots(double a, double b, double c)
        {
            // Standard Formula: (-b +/- sqrt(b^2 - 4ac)) / 2a
            double discriminant = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
            double x1 = (-b + discriminant) / (2 * a);
            double x2 = (-b - discriminant) / (2 * a);
            return (x1, x2);
        }

        public static double? RootAndCoefficient(double a, double b, double c, int type)
        {
            if (type == 1) return -(b / a);
            if (type == 2) return (b / c); // Logic preservation: b/c logic from original
            return null;
        }
    }
}
