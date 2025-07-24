using System;

public static class IntegralUtil
{
    public static double Integrate(Func<double, double> f, double a, double b, int density = 5)
    {
        double sum = 0;
        double step = Math.Pow(10, -density);
        for (double k = a; k < b; k += step)
        {
            sum += (f(k + step) + f(k)) / 2 * step;
        }
        return sum;
    }
}
