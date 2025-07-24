using System;

public static class SquarePyramidAreaAhUtil
{
    public static double Calculate(double a, double h)
    {
        return a * Math.Sqrt(4 * h * h - a * a) + a * a;
    }
}
