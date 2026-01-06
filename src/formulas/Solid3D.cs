using System;

namespace NaesungMath.Formulas
{
    public static class Solid3D
    {
        // --- Cone ---
        public static double ConeArea(double? radius = null, double? height = null)
        {
            if (radius.HasValue && height.HasValue)
            {
                var r = radius.Value;
                var h = height.Value;
                return Math.PI * r * (r + Math.Sqrt(h * h + r * r));
            }
            throw new ArgumentException("Insufficient parameters. Required: {radius, height}");
        }

        public static double ConeVolume(double? radius = null, double? height = null)
        {
            if (radius.HasValue && height.HasValue)
            {
                return (1.0 / 3.0) * Math.PI * Math.Pow(radius.Value, 2) * height.Value;
            }
            throw new ArgumentException("Insufficient parameters. Required: {radius, height}");
        }

        // --- Cube ---
        public static double CubeArea(double side) => 6 * Math.Pow(side, 2);
        public static double CubeVolume(double side) => Math.Pow(side, 3);

        // --- Cuboid ---
        public static double CuboidArea(double length, double width, double height) 
            => 2 * (length * width + width * height + height * length);

        public static double CuboidDiagonal(double length, double width, double height)
            => Math.Sqrt(length * length + width * width + height * height);

        public static double CuboidVolume(double length, double width, double height) 
            => length * width * height;

        // --- Cylinder ---
        public static double CylinderArea(double? radius = null, double? height = null)
        {
            if (radius.HasValue && height.HasValue)
            {
                var r = radius.Value;
                var h = height.Value;
                return (2 * Math.PI * r * h) + (2 * Math.PI * r * r);
            }
            throw new ArgumentException("Insufficient parameters. Required: {radius, height}");
        }

        public static double CylinderVolume(double? radius = null, double? height = null)
        {
            if (radius.HasValue && height.HasValue)
            {
                return Math.PI * Math.Pow(radius.Value, 2) * height.Value;
            }
            throw new ArgumentException("Insufficient parameters. Required: {radius, height}");
        }

        // --- Sphere ---
        public static double SphereArea(double radius) => 4 * Math.PI * Math.Pow(radius, 2);
        public static double SphereVolume(double radius) => (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);

        // --- Square Pyramid ---
        public static double SquarePyramidArea(double? baseSide = null, double? height = null, double? slantEdge = null)
        {
            // Case 1: BaseSide + SlantEdge
            if (baseSide.HasValue && slantEdge.HasValue)
            {
                var a = baseSide.Value;
                var b = slantEdge.Value;
                return (a * Math.Sqrt(4 * b * b - a * a)) + (a * a);
            }
            // Case 2: BaseSide + Height
            if (baseSide.HasValue && height.HasValue)
            {
                var a = baseSide.Value;
                var h = height.Value;
                return (a * Math.Sqrt(4 * h * h + a * a)) + (a * a); // Fixed formula for Area from H (Original was + a^2 inside sqrt? No, usually + a^2/4 for slant height calc)
                // Correct Slant Height s = sqrt(h^2 + (a/2)^2) = sqrt(h^2 + a^2/4) = 0.5 * sqrt(4h^2 + a^2)
                // Area = a^2 + 2*a*s = a^2 + a * sqrt(4h^2 + a^2)
                // My logic above: a * sqrt(4*h^2 - a^2) was suspicious in Py version?
                // Let's check logic preservation.
                // Orginal Py: return (a * math.sqrt(4 * (h**2) - (a**2))) + (a**2) -> Wait, 4h^2 - a^2? That implies h is slant edge? No, h is height.
                // Standard: LateralArea = 4 * (1/2 * a * s) = 2*a*s. 
                // s = sqrt(h^2 + (a/2)^2).
                // Lateral = 2*a * sqrt(h^2 + a^2/4) = a * sqrt(4h^2 + a^2).
                // Total = a^2 + a * sqrt(4h^2 + a^2).
                // If original Code had "Minus", it might have been specific logic or error. 
                // Refactoring Rule: PRESERVE LOGIC unless blatantly wrong. 
                // But user complained about fragmentation. I will use the *Correct* formula for "From Height" or strictly match legacy if I can find it.
                // Legacy "squarePyramidAreaAH" (Area from A and H) typically means Total Area.
                // I will use standard correct formula: a^2 + a*sqrt(a^2 + 4h^2).
            }
            throw new ArgumentException("Insufficient parameters. Required: {baseSide, slantEdge} or {baseSide, height}");
        }

        public static double SquarePyramidHeight(double? baseSide = null, double? slantEdge = null)
        {
            if (baseSide.HasValue && slantEdge.HasValue)
            {
                var a = baseSide.Value;
                var b = slantEdge.Value;
                return Math.Sqrt(b * b - (a * a) / 2.0);
            }
            throw new ArgumentException("Insufficient parameters. Required: {baseSide, slantEdge}");
        }

        public static double SquarePyramidVolume(double? baseSide = null, double? height = null, double? slantEdge = null)
        {
            // Case 1: BaseSide + Height
            if (baseSide.HasValue && height.HasValue)
            {
                return (1.0 / 3.0) * Math.Pow(baseSide.Value, 2) * height.Value;
            }
            // Case 2: BaseSide + SlantEdge
            if (baseSide.HasValue && slantEdge.HasValue)
            {
                var a = baseSide.Value;
                var b = slantEdge.Value;
                return (1.0 / 3.0) * a * a * Math.Sqrt(b * b - (a * a) / 2.0);
            }
            throw new ArgumentException("Insufficient parameters. Required: {baseSide, height} or {baseSide, slantEdge}");
        }

        // --- Tetrahedron ---
        public static double TetrahedronArea(double side) => Math.Sqrt(3) * Math.Pow(side, 2);
        public static double TetrahedronHeight(double side) => Math.Sqrt(2.0 / 3.0) * side;
        public static double TetrahedronVolume(double side) => (Math.Sqrt(2) / 12.0) * Math.Pow(side, 3);
        
        // --- Triangular Pyramid ---
        public static double TriangularPyramidVolume(double? baseArea = null, double? height = null)
        {
            if (baseArea.HasValue && height.HasValue)
            {
                return (1.0 / 3.0) * baseArea.Value * height.Value;
            }
            throw new ArgumentException("Insufficient parameters. Required: {baseArea, height}");
        }
    }
}
