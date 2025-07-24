public static class GeometricProgressionN
{
    public static double Calculate(double an, double a, double r)
    {
        return Math.Log(an / a) / Math.Log(r);
    }
}
