using System;
using NaesungMath.Formulas;

namespace NaesungMath.Examples
{
    class SmartUsage
    {
        public static void Run()
        {
            Console.WriteLine("--- C# Smart Solver Examples ---");

            // 1. Before vs After
            double baseSide = 5;
            double height = 10;
            
            // After (Function with Named Arguments enforced by style)
            double volNew = Solid3D.SquarePyramidVolume(baseSide: 5, height: 10);
            Console.WriteLine($"Volume: {volNew}");

            // 2. Smart Logic (Different Inputs)
            // Using Slant Edge
            double volSlant = Solid3D.SquarePyramidVolume(baseSide: 5, slantEdge: 12);
            Console.WriteLine($"Volume from Slant: {volSlant}");

            // 3. Nesting
            // Height from Equilateral Triangle
            double complexVol = Solid3D.SquarePyramidVolume(
                baseSide: 6, 
                height: Triangle.EquilateralHeight(side: 8) // Explicit name
            );
            Console.WriteLine($"Complex Volume: {complexVol}");
            
            // 4. Geometry Chain
            double totalArea = BasicMath.Add(
                Circle.Area(radius: 5), // Single param, explict name good style
                Quadrilateral.SquareArea(side: 5)
            );
            Console.WriteLine($"Total Combined Area: {totalArea}");
        }
    }
}
