public static class IsInRangeUtil
{
    public static Func<double, bool> Create(double a, double b)
    {
        return x => a <= x && x <= b;
    }
}
