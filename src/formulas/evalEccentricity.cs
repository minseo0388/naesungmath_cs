public static class EvalEccentricity
{
    public static double Calculate(double a, double b)
    {
        return Math.Sqrt(1 - ((b * b) / (a * a)));
    }
}
