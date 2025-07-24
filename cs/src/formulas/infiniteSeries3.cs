public static class InfiniteSeries3
{
    public static double Calculate(double x)
    {
        if (x > 1 || x < -1 || x == 1 || x == -1)
            throw new ArgumentException("Check |x| < 1");
        return 1 / (1 - x);
    }
}
