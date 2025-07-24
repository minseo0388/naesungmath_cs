using System;

public static class Taylor
{
    public static Func<double, double> Series(Func<double, double> f, double a, int count)
    {
        Func<double, double>[] diffs = new Func<double, double>[count + 1];
        Func<double, double>[] taylors = new Func<double, double>[count + 1];
        int[] fact = new int[count + 1];
        diffs[0] = x => f(a);
        taylors[0] = x => diffs[0](x);
        fact[0] = 1;
        for (int i = 1; i <= count; i++)
        {
            diffs[i] = Diff(diffs[i - 1]);
            int factorial = 1;
            for (int j = 1; j <= i; j++)
                factorial *= j;
            fact[i] = factorial;
            int idx = i;
            taylors[i] = x => diffs[idx](a) / fact[idx] * Math.Pow(x - a, idx);
        }
        return x =>
        {
            double result = 0;
            for (int i = 0; i <= count; i++)
                result += taylors[i](x);
            return result;
        };
    }
    private static Func<double, double> Diff(Func<double, double> fun, int density = 5)
    {
        double dx = 2 * Math.Pow(10, -density);
        return x => (fun(x + Math.Pow(10, -density)) - fun(x - Math.Pow(10, -density))) / dx;
    }
}
