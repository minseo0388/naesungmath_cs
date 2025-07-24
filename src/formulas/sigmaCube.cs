public static class SigmaCube
{
    public static double Calculate(double n, double k)
    {
        return (0.25 * n * n * (n + 1) * (n + 1)) - (0.25 * k * k * (k + 1) * (k + 1));
    }
}
