public static class Maclaurin
{
    public static double[] Series(Func<double, double> f, int count)
    {
        return Taylor.Series(f, 0, count);
    }
}
