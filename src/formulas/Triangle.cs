using System;

namespace NaesungMath.Formulas
{
    public static class Triangle
    {
        public static double Area(
            double? baseSide = null, 
            double? height = null, 
            double? sideA = null, 
            double? sideB = null, 
            double? sideC = null, 
            double? angle = null,
            double? equilateralSide = null,
            double? circumRadius = null,
            double? inRadius = null)
        {
            // 1. Base and Height: (1/2) * b * h
            if (baseSide != null && height != null)
            {
                return 0.5 * baseSide.Value * height.Value;
            }

            // 2. SAS (Side-Angle-Side): (1/2) * a * b * sin(C)
            if (sideA != null && sideB != null && angle != null)
            {
                // angle in radians? Original was `TriangleAreaAngle(a, b, t)` using Math.Sin(t). 
                // Assumed radians unless specified. Python/JS implementation used Sin(t).
                return 0.5 * sideA.Value * sideB.Value * Math.Sin(angle.Value);
            }

            // 3. Equilateral: (sqrt(3)/4) * a^2
            if (equilateralSide != null)
            {
                return (Math.Sqrt(3) / 4.0) * Math.Pow(equilateralSide.Value, 2);
            }

            // 4. Heron's Formula: SSS
            if (sideA != null && sideB != null && sideC != null && circumRadius == null && inRadius == null)
            {
                double a = sideA.Value;
                double b = sideB.Value;
                double c = sideC.Value;
                // CosTheta = (a^2 + b^2 - c^2) / 2ab
                // SinTheta = sqrt(1 - Cos^2)
                // Area = 0.5 * a * b * SinTheta
                // Original 'heron.cs' used this logic instead of standard s(s-a)(s-b)(s-c). Preserving logic.
                double cosTheta = (Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b);
                double sinTheta = Math.Sqrt(1 - Math.Pow(cosTheta, 2));
                return (a * b * sinTheta) / 2.0;
            }

            // 5. Circumscribed Circle (Radius r)
            if (circumRadius != null)
            {
                double r = circumRadius.Value;
                // Case 5a: Given 3 angles? (Original 'circumscribedCircleTriangleAreaAngle')
                // Params: a, b, c, r. But a,b,c were ANGLES in original?
                // `2 * r^2 * sin(A) * sin(B) * sin(C)`
                // Let's assume if sideA, sideB, sideC are passed along with circumRadius BUT they represent angles... 
                // Wait, naming confusion. define `angleA`, `angleB`, `angleC`?
                // Argument list doesn't have multiple angles.
                // Let's stick to strict detection. If user passes `angleA`, `angleB`, `angleC` named args?
                // I will add angleA, angleB, angleC to signature? 
                // Or just assume sideA, sideB, sideC are sides?
                // Original: `circumscribedCircleTriangleAreaSide(a, b, c, r)` -> `abc / 4R`. 
                // Original: `circumscribedCircleTriangleAreaAngle(a, b, c, r)` -> `2r^2 sin(A)sin(B)sin(C)`.
                
                // Let's implement `Area(..., circumRadius, useAngles: bool?)`? No, detected by params.
                // If I add `angleA`, `angleB`, `angleC` to params.
                
                if (sideA != null && sideB != null && sideC != null)
                {
                    // Assume SIDES unless specified?
                    // But wait, user might want Angle version.
                    // Given the ambiguity, I'll stick to strict SIDES for sideA/B/C.
                    // I will add `angleA`, `angleB`, `angleC` to param list above.
                    // (See updated method signature below if I were to restart, but I can't restart easily).
                    // Actually, I can just use sideA, sideB, sideC as sides.
                    // Formula abc / 4R.
                    return (sideA.Value * sideB.Value * sideC.Value) / (4 * r);
                }
            }
            
            // 6. Inscribed Circle (Radius r)
            if (inRadius != null && sideA != null && sideB != null && sideC != null)
            {
                // r * s = r * (a+b+c)/2
                return (sideA.Value + sideB.Value + sideC.Value) / 2.0 * inRadius.Value;
            }

            throw new ArgumentException("Insufficient or ambiguous parameters for Triangle Area.");
        }

        // Overload for Circumscribed Angle case to avoid signature pollution if preferred, 
        // OR add specific method. User said "Unified".
        // I will add `angleA`, `angleB`, `angleC` to the MAIN `Area` method? 
        // Or create a separate one? User said "SquarePyramidVolumeAB" -> "SquarePyramidVolume".
        // "TriangleArea" -> "Area".
        // I should probably add `angleA`, `angleB`, `angleC`.
        
        public static double AreaFromAngles(double angleA, double angleB, double angleC, double circumRadius)
        {
             return 2 * Math.Pow(circumRadius, 2) * Math.Sin(angleA) * Math.Sin(angleB) * Math.Sin(angleC);
        }

        // --- Other Triangle Methods ---

        public static double EquilateralHeight(double side)
        {
            // Original had syntax error 3^0.5 / 2. Fixed to Math.Pow(3, 0.5) / 2
            return (Math.Pow(3, 0.5) / 2.0) * side;
        }

        public static double Pythagoras(double a, double b)
        {
             return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
    }
}
