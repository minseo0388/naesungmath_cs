using System;

public static class GeometryUtil
{
    public static double AreaCircle(double radius)
    {
        return Math.PI * Math.Pow(radius, 2);
    }
    public static double PerimeterRectangle(double length, double width)
    {
        return 2 * (length + width);
    }
}
