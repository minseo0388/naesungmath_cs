using System;

public static class CubicEquationFirst
{
    public static double Calculate(double a, double b, double c, double d)
    {
        double part1 = 2 * Math.Pow(b, 3) - 9 * a * b * c + 27 * Math.Pow(a, 2) * d;
        double part2 = Math.Pow(part1, 2) - 4 * Math.Pow(Math.Pow(b, 2) - 3 * a * c, 3);
        double x = Math.Pow(0.5 * (part1 + Math.Sqrt(part2)), 1.0 / 3.0);
        double y = Math.Pow(0.5 * (part1 - Math.Sqrt(part2)), 1.0 / 3.0);
        return -(b / (3 * a)) - ((1.0 / (3 * a)) * x) - ((1.0 / (3 * a)) * y);
    }
}
