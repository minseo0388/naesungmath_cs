using System;

namespace NaesungMath.Formulas
{
    public static class Quadrilateral
    {
        public static double ParallelogramArea(double baseSide, double height)
        {
            return baseSide * height;
        }

        public static double RectangleArea(double width, double height)
        {
            return width * height;
        }

        public static double RectangleDiagonal(double width, double height)
        {
            return Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));
        }

        public static double RectanglePerimeter(double width, double height)
        {
            return 2 * (width + height);
        }

        public static double RhombusArea(double diagonal1, double diagonal2)
        {
            return 0.5 * diagonal1 * diagonal2;
        }

        public static double SquareArea(double side)
        {
            return Math.Pow(side, 2);
        }

        public static double TrapezoidArea(double a, double b, double h)
        {
            return 0.5 * (a + b) * h;
        }
    }
}
