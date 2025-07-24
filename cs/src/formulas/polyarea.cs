using System;

public static class PolyAreaUtil
{
    public static double Calculate(double n, double a)
    {
        return n * a * a / (4 * Math.Tan(a / Math.PI));
    }
}
