public static class RootFormulaMinus
{
    public static double Calculate(double a, double b, double c)
    {
        return (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
    }
}
