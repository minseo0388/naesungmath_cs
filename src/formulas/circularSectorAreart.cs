public static class CircularSectorAreart
{
    public static double Calculate(double r, double? t = null, double? l = null)
    {
        if (r != null)
        {
            if (t != null || l != null)
            {
                if (t != null)
                    return 0.5 * r * Math.Pow((double)t, 2);
                else
                    return 0.5 * r * (double)l;
            }
        }
        throw new ArgumentException("Invalid arguments.");
    }
}
