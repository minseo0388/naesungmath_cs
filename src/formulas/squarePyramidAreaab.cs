using System;

public static class SquarePyramidAreaAbUtil
{
    public static double Calculate(double a, double b)
    {
        return a * Math.Sqrt(4 * b * b - a * a) + a * a;
    }
}
