using System;

public static class HeronUtil
{
    public static double Calculate(double a, double b, double c)
    {
        double cosTheta = ((a * a) + (b * b) - (c * c)) / (2 * a * b);
        double sinTheta = Math.Sqrt(1 - (cosTheta * cosTheta));
        return (a * b * sinTheta) / 2;
    }
}
