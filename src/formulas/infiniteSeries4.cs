public static class InfiniteSeries4
{
    public static double Calculate(double x)
    {
        if (x > 1 || x < -1 || x == 1 || x == -1)
            throw new ArgumentException("Check |x| < 1");
        return x / Math.Pow(1 - x, 2);
    }
}
