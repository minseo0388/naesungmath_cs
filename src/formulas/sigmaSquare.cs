public static class SigmaSquare
{
    public static double Calculate(double n, double k)
    {
        return (1.0 / 6.0) * n * (n + 1) * (2 * n + 1) - (1.0 / 6.0) * k * (k + 1) * (2 * k + 1);
    }
}
