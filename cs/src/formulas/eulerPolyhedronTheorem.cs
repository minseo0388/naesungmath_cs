public static class EulerPolyhedronTheorem
{
    public static bool Check(double v, double e, double f)
    {
        return (v - e + f) == 2;
    }
}
