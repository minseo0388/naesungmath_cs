using System;

public static class Diff
{
    public static Func<double, double> Create(Func<double, double> f, int density = 5)
    {
        double dx = 2 * Math.Pow(10, -density);
        return x => (f(x + Math.Pow(10, -density)) - f(x - Math.Pow(10, -density))) / dx;
    }
}
