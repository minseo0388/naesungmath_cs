public static class RootAndCoefficient
{
    public static double Calculate(double a, double b, double c, int type)
    {
        if (type == 1)
            return -(b / a);
        if (type == 2)
            return b / c;
        throw new ArgumentException("Invalid type");
    }
}
