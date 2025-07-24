using System;

public static class CuboidDiagonal
{
    public static double Calculate(double a, double b, double c)
    {
        return Math.Sqrt(a * a + b * b + c * c);
    }
}
