using System;

public static class SquarePyramidVolumeAbUtil
{
    public static double Calculate(double a, double b)
    {
        return (1.0 / 3.0) * a * a * Math.Sqrt(b * b - (a * a) / 2);
    }
}
