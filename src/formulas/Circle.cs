using System;

namespace NaesungMath.Formulas
{
    public static class Circle
    {
        public static double ArcLength(double? radius = null, double? angle = null)
        {
            if (radius.HasValue && angle.HasValue)
            {
                // angle in degrees? or radians?
                // Original: 2 * pi * r * (angle/360)
                return 2 * Math.PI * radius.Value * (angle.Value / 360.0);
            }
            throw new ArgumentException("Insufficient parameters for ArcLength.");
        }

        public static double Area(double? radius = null)
        {
            if (radius.HasValue)
                return Math.PI * Math.Pow(radius.Value, 2);
            throw new ArgumentException("Insufficient parameters for Area.");
        }

        public static double Perimeter(double? radius = null)
        {
            if (radius.HasValue)
                return 2 * Math.PI * radius.Value;
            throw new ArgumentException("Insufficient parameters for Perimeter.");
        }

        public static double SectorAngle(double? radius = null, double? arcLength = null)
        {
            if (radius.HasValue && arcLength.HasValue)
            {
                // (arcLength * 180) / (pi * r)
                return (arcLength.Value * 180.0) / (Math.PI * radius.Value);
            }
            throw new ArgumentException("Insufficient parameters for SectorAngle.");
        }

        public static double SectorArea(double? radius = null, double? angle = null)
        {
            if (radius.HasValue && angle.HasValue)
            {
                // pi * r^2 * (angle/360)
                return Math.PI * Math.Pow(radius.Value, 2) * (angle.Value / 360.0);
            }
            throw new ArgumentException("Insufficient parameters for SectorArea.");
        }
    }
}
