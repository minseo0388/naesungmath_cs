using System;

public static class NewtonsMethod
{
    public static double FindRoot(Func<double, double> f, int count, double initx = 2)
    {
        double Diff(Func<double, double> func, double x, int density = 5)
        {
            double dx = 2 * Math.Pow(10, -density);
            double dy = func(x + Math.Pow(10, -density)) - func(x - Math.Pow(10, -density));
            return dy / dx;
        }
        double NewtonGo(Func<double, double> func, double x, int go = 0)
        {
            double next_ = x - func(x) / Diff(func, x);
            if (go == count - 1)
                return next_;
            return NewtonGo(func, next_, go + 1);
        }
        return NewtonGo(f, initx, 0);
    }
}
