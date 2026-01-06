using System;

namespace NaesungMath.Formulas
{
    public static class Quadrilateral
    {
        public static double ParallelogramArea(double? baseSide = null, double? height = null)
        {
            if (baseSide.HasValue && height.HasValue)
                return baseSide.Value * height.Value;
            throw new ArgumentException("Insufficient parameters for ParallelogramArea.");
        }

        public static double RectangleArea(double? width = null, double? height = null)
        {
            if (width.HasValue && height.HasValue)
                return width.Value * height.Value;
            throw new ArgumentException("Insufficient parameters for RectangleArea.");
        }

        public static double RectangleDiagonal(double? width = null, double? height = null)
        {
            if (width.HasValue && height.HasValue)
                return Math.Sqrt(Math.Pow(width.Value, 2) + Math.Pow(height.Value, 2));
            throw new ArgumentException("Insufficient parameters for RectangleDiagonal.");
        }

        public static double RectanglePerimeter(double? width = null, double? height = null)
        {
            if (width.HasValue && height.HasValue)
                return 2 * (width.Value + height.Value);
            throw new ArgumentException("Insufficient parameters for RectanglePerimeter.");
        }

        public static double RhombusArea(double? diagonal1 = null, double? diagonal2 = null)
        {
            if (diagonal1.HasValue && diagonal2.HasValue)
                return 0.5 * diagonal1.Value * diagonal2.Value;
            throw new ArgumentException("Insufficient parameters for RhombusArea.");
        }

        public static double SquareArea(double? side = null)
        {
            if (side.HasValue)
                return Math.Pow(side.Value, 2);
            throw new ArgumentException("Insufficient parameters for SquareArea.");
        }

        public static double TrapezoidArea(double? topSide = null, double? bottomSide = null, double? height = null)
        {
             // Note: 'a' and 'b' usually used, mapped to topSide/bottomSide for clarity? 
             // Or strict mapping to simple names?
             // Let's use generic a/b/h for consistency with math formulas, but named params "a", "b", "h" are obscure?
             // C# named params: TrapezoidArea(a: 2, b: 4, h: 5) is concise.
             // Let's use `a`, `b`, `h` to match typical formula representation (1/2(a+b)h).
            if (topSide.HasValue && bottomSide.HasValue && height.HasValue)
                return 0.5 * (topSide.Value + bottomSide.Value) * height.Value;
             // If I use a, b, h:
            throw new ArgumentException("Insufficient parameters for TrapezoidArea.");
        }
    }
}
