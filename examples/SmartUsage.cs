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
            
            // Before (Manual Formula)
            double volOld = (1.0/3.0) * (baseSide * baseSide) * height; // Easy to typo constants
            
            // After (Function)
            double volNew = Solid3D.SquarePyramidVolume(baseSide: 5, height: 10);
            
            Console.WriteLine($"Volume: Old={volOld}, New={volNew}"); // Identical

            // 2. Smart Logic (Different Inputs, Same Method)
            // Scenario: You only have Slant Edge, not Height.
            double slantEdge = 12;
            double volSlant = Solid3D.SquarePyramidVolume(baseSide: 5, slantEdge: 12); // Logic auto-switches
            Console.WriteLine($"Volume from Slant: {volSlant}");

            // 3. Nesting Functions (Real World)
            // Scenario: Calculate volume of a pyramid where the height is the altitude of an equilateral triangle.
            double equiSide = 8;
            double complexVol = Solid3D.SquarePyramidVolume(
                baseSide: 6, 
                height: Triangle.EquilateralHeight(equiSide) // Nesting
            );
            Console.WriteLine($"Complex Volume: {complexVol}");
            
            // 4. Geometry Chain
            // Area of Circle + Area of Square
            double totalArea = BasicMath.Add(
                Circle.Area(radius: 5),
                Quadrilateral.SquareArea(side: 5)
            );
            Console.WriteLine($"Total Combined Area: {totalArea}");
        }
    }
}
