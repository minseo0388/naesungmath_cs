using System;

public static class ConeVolume
{
    public static double Calculate(double r, double h)
    {
        return (1.0 / 3.0) * Math.PI * r * r * h;
    }
}
