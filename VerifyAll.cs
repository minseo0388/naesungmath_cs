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
                AssertAlmostEqual(BasicMath.Subtract(5, 3), 2, "BasicMath.Subtract");
                AssertAlmostEqual(BasicMath.Multiply(2, 3), 6, "BasicMath.Multiply");
                AssertAlmostEqual(BasicMath.Divide(6, 3), 2, "BasicMath.Divide");
                AssertAlmostEqual(BasicMath.Pow(2, 3), 8, "BasicMath.Pow");
                AssertAlmostEqual(BasicMath.Sqrt(4), 2, "BasicMath.Sqrt");
                AssertAlmostEqual(BasicMath.Round(2.5), 2, "BasicMath.Round"); // Standard: Round(2.5) -> 2 (even) or 3? Math.Round(2.5) is 2 (ToEven). Py is Round to nearest even? JS is Round to nearest integer (up). This might differ. Let's start with safe non-halves or check specific behavior if failed. Round(2.6)->3.
                AssertAlmostEqual(BasicMath.Round(2.6), 3, "BasicMath.Round");
                AssertAlmostEqual(BasicMath.Factorial(5), 120, "BasicMath.Factorial");
                AssertAlmostEqual(BasicMath.Gcd(12, 18), 6, "BasicMath.Gcd");

                // 2. Equation
                var roots = Equation.QuadraticRoots(1, -3, 2);
                AssertAlmostEqual(roots.x1, 2, "Equation.QuadraticRoots x1");
                AssertAlmostEqual(roots.x2, 1, "Equation.QuadraticRoots x2");
                AssertAlmostEqual(Equation.CubicRoots(1, -6, 11, -6), 3, "Equation.CubicRoots (largest)"); // Logic returns one root? Original logic returned one.
                
                // 3. Calculus
                AssertAlmostEqual(Calculus.Sigma(1, 5, x => x), 15, "Calculus.Sigma");
                AssertAlmostEqual(Calculus.Diff(x => x*x, 2), 4, "Calculus.Diff", 0.01);
                AssertAlmostEqual(Calculus.Integral(x => x*x, 0, 1), 0.333, "Calculus.Integral", 0.01);
                
                // 4. LinearAlgebra
                var matA = new double[][] { new double[] { 1, 2 }, new double[] { 3, 4 } };
                var matB = new double[][] { new double[] { 5, 6 }, new double[] { 7, 8 } };
                var matAdd = LinearAlgebra.Add(matA, matB);
                AssertAlmostEqual(matAdd[0][0], 6, "LinearAlgebra.Add[0][0]");
                AssertAlmostEqual(LinearAlgebra.Determinant(matA), -2, "LinearAlgebra.Determinant");
                AssertAlmostEqual(LinearAlgebra.Trace(matA), 5, "LinearAlgebra.Trace");
                var vec = new double[] { 3, 4 };
                AssertAlmostEqual(LinearAlgebra.SqrtDotProduct(vec, vec), 5, "LinearAlgebra.SqrtDotProduct");

                // 5. Triangle
                AssertAlmostEqual(Triangle.Area(baseSide: 10, height: 5), 25, "Triangle.Area");
                AssertAlmostEqual(Triangle.Pythagoras(3, 4), 5, "Triangle.Pythagoras");

                // 6. Quadrilateral
                AssertAlmostEqual(Quadrilateral.SquareArea(5), 25, "Quadrilateral.SquareArea");
                AssertAlmostEqual(Quadrilateral.RectangleArea(5, 10), 50, "Quadrilateral.RectangleArea");
                AssertAlmostEqual(Quadrilateral.TrapezoidArea(2, 4, 5), 15, "Quadrilateral.TrapezoidArea");
                
                // 7. Polygon
                AssertAlmostEqual(Polygon.PentagonArea(5), 43.0119, "Polygon.PentagonArea");
                AssertAlmostEqual(Polygon.DiagonalCount(5), 5, "Polygon.DiagonalCount");
                AssertAlmostEqual(Polygon.InteriorAngleSumDeg(5), 540, "Polygon.InteriorAngleSumDeg");

                // 8. Solid3D
                AssertAlmostEqual(Solid3D.CubeArea(5), 150, "Solid3D.CubeArea");
                AssertAlmostEqual(Solid3D.SquarePyramidVolume(baseSide: 5, slantEdge: 10), 77.9512, "Solid3D.SquarePyramidVolume");

                // 9. Circle
                AssertAlmostEqual(Circle.Area(10), 314.159, "Circle.Area");
                AssertAlmostEqual(Circle.SectorAngle(10, 5), 28.6479, "Circle.SectorAngle");

                // 10. AnalyticGeometry
                var cg = AnalyticGeometry.CenterGravity(0, 0, 4, 0, 2, 3); // (2, 1) theoretically
                AssertAlmostEqual(cg.x, 2, "AnalyticGeometry.CenterGravity X");
                AssertAlmostEqual(cg.y, 1, "AnalyticGeometry.CenterGravity Y");
                AssertAlmostEqual(AnalyticGeometry.Eccentricity(5, 3), 0.8, "AnalyticGeometry.Eccentricity");

                // 11. Trigonometry
                AssertAlmostEqual(Trigonometry.DegreeToRad(180), Math.PI, "Trigonometry.DegreeToRad");

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
