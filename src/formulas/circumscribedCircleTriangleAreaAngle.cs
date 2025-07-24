using System;

public static class CircumscribedCircleTriangleAreaAngle
{
    public static double Calculate(double a, double b, double c, double r)
    {
        return 2 * r * r * Math.Sin(a) * Math.Sin(b) * Math.Sin(c);
    }
}
