public static class GeometricProgressionSum
{
    public static double Calculate(double a, double r, double n)
    {
        return a * (1 - Math.Pow(r, n)) / (1 - r);
    }
}
