using System;

public static class TetrahedronVolumeUtil
{
    public static double Calculate(double a)
    {
        return Math.Sqrt(2) / 12 * Math.Pow(a, 3);
    }
}
