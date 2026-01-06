using System;

namespace NaesungMath.Formulas
{
    public static class Circle
    {
        public static double Area(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public static double Perimeter(double radius)
        {
            return 2 * Math.PI * radius;
        }

        public static double SectorArea(double radius, double k)
        {
            // Original 'circularSectorAreart': (1/2) * r^2 * k (k in radians likely, or k is theta)
            return 0.5 * Math.Pow(radius, 2) * k;
        }

        public static double SectorAngle(double radius, double arcLength)
        {
            // Original 'circularSectorAngle': (180 * l) / (pi * r) -> Degrees
            return (180 * arcLength) / (Math.PI * radius);
        }

        public static double ArcLength(double radius, double angleDeg)
        {
            // Basic formula implied
            return 2 * Math.PI * radius * (angleDeg / 360.0);
        }
    }
}
