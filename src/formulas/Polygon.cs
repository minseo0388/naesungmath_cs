using System;

namespace NaesungMath.Formulas
{
    public static class Polygon
    {
        // General Polygon Formulas

        public static double Area(double n, double sideLength)
        {
            return (n * Math.Pow(sideLength, 2)) / (4 * Math.Tan(Math.PI / n));
        }

        public static double DiagonalCount(double n)
        {
            return n * (n - 3) / 2;
        }

        public static bool EulerTheorem(double v, double e, double f)
        {
            return (v - e + f) == 2;
        }

        public static double HexagonArea(double side)
        {
            return (3 * Math.Sqrt(3) * Math.Pow(side, 2)) / 2;
        }

        public static double InteriorAngleDeg(double n)
        {
            return 180 * (n - 2) / n;
        }

        public static double InteriorAngleRad(double n)
        {
            return Math.PI * (n - 2) / n;
        }

        public static double InteriorAngleSumDeg(double n)
        {
            return 180 * (n - 2);
        }

        public static double InteriorAngleSumRad(double n)
        {
            return Math.PI * (n - 2);
        }

        public static double PentagonArea(double side)
        {
            return (Math.Sqrt(5 * (5 + 2 * Math.Sqrt(5))) * Math.Pow(side, 2)) / 4;
        }

        public static double PentagonDiagonal(double side)
        {
            return (1 + Math.Sqrt(5)) / 2 * side;
        }

        public static double PentagonHeight(double side)
        {
            return (Math.Sqrt(5 + 2 * Math.Sqrt(5)) * side) / 2;
        }
    }
}
