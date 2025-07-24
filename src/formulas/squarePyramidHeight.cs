using System;

public static class SquarePyramidHeightUtil
{
    public static double Calculate(double a, double b)
    {
        return Math.Sqrt(b * b - (a * a) / 2);
    }
}
