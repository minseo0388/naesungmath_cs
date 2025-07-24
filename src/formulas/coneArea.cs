using System;

public static class ConeArea
{
    public static double Calculate(double r, double h)
    {
        return (Math.PI * r * Math.Sqrt(r * r + h * h)) + (Math.PI * r * r);
    }
}
