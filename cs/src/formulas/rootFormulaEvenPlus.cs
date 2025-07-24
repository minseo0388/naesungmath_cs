public static class RootFormulaEvenPlus
{
    public static double Calculate(double a, double b, double c)
    {
        return (-(0.5 * b) + Math.Sqrt((0.5 * b) * (0.5 * b) - a * c)) / a;
    }
}
