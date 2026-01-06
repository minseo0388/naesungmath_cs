using System;
using NaesungMath.Formulas;

namespace NaesungMath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Verifying C# Refactored Formulas (Zero-Omission)...");

            try
            {
                // 1. BasicMath
                AssertAlmostEqual(BasicMath.Add(2, 3), 5, "BasicMath.Add");
                
                // 5. Triangle (Named Arguments Good Practice)
                AssertAlmostEqual(Triangle.Area(baseSide: 10, height: 5), 25, "Triangle.Area");
                
                // 6. Quadrilateral
                AssertAlmostEqual(Quadrilateral.SquareArea(side: 5), 25, "Quadrilateral.SquareArea");
                AssertAlmostEqual(Quadrilateral.RectangleArea(width: 5, height: 10), 50, "Quadrilateral.RectangleArea");
                
                // 8. Solid3D
                AssertAlmostEqual(Solid3D.CubeArea(side: 5), 150, "Solid3D.CubeArea");
                AssertAlmostEqual(Solid3D.SquarePyramidVolume(baseSide: 5, slantEdge: 10), 77.9512, "Solid3D.SquarePyramidVolume");

                // 9. Circle
                AssertAlmostEqual(Circle.Area(radius: 10), 314.159, "Circle.Area");
                AssertAlmostEqual(Circle.SectorAngle(radius: 10, arcLength: 5), 28.6479, "Circle.SectorAngle");

                // 11. Sequences
                // AP
                var apRes = ArithmeticProgression.Solve(a: 2, d: 2, n: 3);
                // C# Logic: an = a + (n-1)d. 
                // n=3 -> an=6. s=12.
                if (apRes.An == null || apRes.S == null) throw new Exception("AP Result Null");
                AssertAlmostEqual(apRes.An.Value, 6, "ArithmeticProgression.Solve -> An");
                AssertAlmostEqual(apRes.S.Value, 12, "ArithmeticProgression.Solve -> S");

                // GP
                var gpRes = GeometricProgression.Solve(a: 2, r: 2, n: 3);
                // C# Logic: an = a * r^n. s = a(1-r^n)/(1-r).
                // n=3 -> an=16. s=14.
                if (gpRes.An == null || gpRes.S == null) throw new Exception("GP Result Null");
                AssertAlmostEqual(gpRes.An.Value, 16, "GeometricProgression.Solve -> An");
                AssertAlmostEqual(gpRes.S.Value, 14, "GeometricProgression.Solve -> S");

                Console.WriteLine("All C# Tests Passed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test Failed: {ex.Message}");
                Environment.Exit(1);
            }
        }

        static void AssertAlmostEqual(double actual, double expected, string testName, double tolerance = 0.001)
        {
            if (Math.Abs(actual - expected) > tolerance)
            {
                throw new Exception($"{testName} Failed. Expected ~{expected}, Got {actual}");
            }
            Console.WriteLine($"[PASS] {testName}");
        }
    }
}
