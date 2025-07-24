using System;

public static class Algebra
{
    public static double SolveLinear(double a, double b)
    {
        if (a == 0)
            throw new ArgumentException("Coefficient 'a' cannot be zero.");
        return -b / a;
    }

    public static (double, double) QuadraticRoots(double a, double b, double c)
    {
        double discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
            throw new ArgumentException("No real roots.");
        double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
        double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        return (root1, root2);
    }
}
