using System;

namespace NaesungMath.Formulas
{
    public static class Solid3D
    {
        // --- Cone ---

        public static double ConeArea(double? radius = null, double? height = null)
        {
            if (radius != null && height != null)
            {
                // pi * r * (r + sqrt(h^2 + r^2))
                return Math.PI * radius.Value * (radius.Value + Math.Sqrt(Math.Pow(height.Value, 2) + Math.Pow(radius.Value, 2)));
            }
            throw new ArgumentException("Insufficient parameters for ConeArea.");
        }

        public static double ConeVolume(double? radius = null, double? height = null)
        {
            if (radius != null && height != null)
            {
                // (1/3) * pi * r^2 * h
                return (1.0 / 3.0) * Math.PI * Math.Pow(radius.Value, 2) * height.Value;
            }
            throw new ArgumentException("Insufficient parameters for ConeVolume.");
        }

        // --- Cube ---

        public static double CubeArea(double side)
        {
            return 6 * Math.Pow(side, 2);
        }

        public static double CubeVolume(double side)
        {
            return Math.Pow(side, 3);
        }

        // --- Cuboid ---

        public static double CuboidArea(double length, double width, double height)
        {
            // 2(lw + wh + hl)
            return 2 * ((length * width) + (width * height) + (height * length));
        }

        public static double CuboidDiagonal(double length, double width, double height)
        {
            // sqrt(l^2 + w^2 + h^2)
            return Math.Sqrt(Math.Pow(length, 2) + Math.Pow(width, 2) + Math.Pow(height, 2));
        }

        public static double CuboidVolume(double length, double width, double height)
        {
            return length * width * height;
        }

        // --- Cylinder ---

        public static double CylinderArea(double? radius = null, double? height = null)
        {
            if (radius != null && height != null)
            {
                // 2*pi*r*h + 2*pi*r^2
                return (2 * Math.PI * radius.Value * height.Value) + (2 * Math.PI * Math.Pow(radius.Value, 2));
            }
            throw new ArgumentException("Insufficient parameters for CylinderArea.");
        }

        public static double CylinderVolume(double? radius = null, double? height = null)
        {
            if (radius != null && height != null)
            {
                // pi * r^2 * h
                return Math.PI * Math.Pow(radius.Value, 2) * height.Value;
            }
            throw new ArgumentException("Insufficient parameters for CylinderVolume.");
        }

        // --- Sphere ---

        public static double SphereArea(double radius)
        {
            return 4 * Math.PI * Math.Pow(radius, 2);
        }

        public static double SphereVolume(double radius)
        {
            // (4/3) * pi * r^3
            return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
        }

        // --- SquarePyramid ---

        public static double SquarePyramidArea(double? baseSide = null, double? height = null, double? slantEdge = null)
        {
            // 'a' = baseSide
            // 'b' = slantEdge (side edge length in original 'ab' file)
            // 'h' = height

            // Case 1: baseSide (a) and slantEdge (b) known (Original 'squarePyramidAreaab')
            /* Formula: a * sqrt(4b^2 - a^2) + a^2
               Wait, is "slantEdge" b in original code?
               Original: ((a * ((4 * (b ** 2) - (a ** 2)) ** (0.5))) + (a ** 2))
               If b is 'lateral edge', slant height l = sqrt(b^2 - (a/2)^2) = sqrt(b^2 - a^2/4) = 0.5 * sqrt(4b^2 - a^2)
               Area = a^2 + 4 * (1/2 * a * l) = a^2 + 2 * a * l = a^2 + 2 * a * 0.5 * sqrt... = a^2 + a * sqrt(4b^2 - a^2).
               Yes, matches original formula.
            */
            if (baseSide != null && slantEdge != null)
            {
                double a = baseSide.Value;
                double b = slantEdge.Value;
                return (a * Math.Sqrt(4 * Math.Pow(b, 2) - Math.Pow(a, 2))) + Math.Pow(a, 2);
            }

            // Case 2: baseSide (a) and height (h) known (Original 'squarePyramidAreaah')
            /* Original: ((a * ((4 * (h ** 2) - (a ** 2)) ** (0.5))) + (a ** 2)) 
               Wait, this original formula looks WRONG if logic preservation is strict.
               Slant height l = sqrt(h^2 + (a/2)^2) = sqrt(h^2 + a^2/4) = 0.5 * sqrt(4h^2 + a^2).
               Area = a^2 + 2al = a^2 + a * sqrt(4h^2 + a^2).
               Original code had MINUS: 4 * h^2 - a^2.  
               CHECK: js file `SquarePyramidAreaFromHeight`: `4 * (h ** 2) - (a ** 2)`.
               If user said "100% logic preservation", I MUST use the original code even if suspicious.
               HOWEVER, user also said "실패 사례 수정".
               "실패 사례 수정: squarePyramidVolumeAB, squarePyramidVolumeAH를 ... 통합하라."
               Maybe correct it?
               User said: "수식 불변: 함수는 통합되지만, 내부에서 사용하는 수식 자체는 기존 라이브러리의 식과 100% 동일해야 한다. (절대 임의로 공식을 수정하지 말 것)"
               OK, strict adherence to original logic even if it is `4*h^2 - a^2`.
            */
            if (baseSide != null && height != null)
            {
                double a = baseSide.Value;
                double h = height.Value;
                return (a * Math.Sqrt(4 * Math.Pow(h, 2) - Math.Pow(a, 2))) + Math.Pow(a, 2);
            }

            throw new ArgumentException("Insufficient parameters for SquarePyramidArea.");
        }

        public static double SquarePyramidHeight(double? baseSide = null, double? slantEdge = null)
        {
            if (baseSide != null && slantEdge != null)
            {
                double a = baseSide.Value;
                double b = slantEdge.Value;
                // sqrt(b^2 - a^2/2)
                return Math.Sqrt(Math.Pow(b, 2) - (Math.Pow(a, 2) / 2));
            }
             throw new ArgumentException("Insufficient parameters for SquarePyramidHeight.");
        }

        public static double SquarePyramidVolume(double? baseSide = null, double? height = null, double? slantEdge = null)
        {
            // Case 1: baseSide (a) and height (h) known
            if (baseSide != null && height != null)
            {
                double a = baseSide.Value;
                double h = height.Value;
                // (1/3) * a^2 * h
                return (1.0 / 3.0) * Math.Pow(a, 2) * h;
            }

            // Case 2: baseSide (a) and slantEdge (b) known (Original 'ab')
            /* Formula: 1/3 * a^2 * sqrt(b^2 - a^2/2) */
            if (baseSide != null && slantEdge != null)
            {
                double a = baseSide.Value;
                double b = slantEdge.Value;
                return (1.0 / 3.0) * Math.Pow(a, 2) * Math.Sqrt(Math.Pow(b, 2) - (Math.Pow(a, 2) / 2.0));
            }

            throw new ArgumentException("Insufficient parameters for SquarePyramidVolume.");
        }

        // --- Tetrahedron ---

        public static double TetrahedronArea(double side)
        {
            return Math.Sqrt(3) * Math.Pow(side, 2);
        }

        public static double TetrahedronHeight(double side)
        {
            // sqrt(2/3) * a
            return Math.Sqrt(2.0 / 3.0) * side;
        }

        public static double TetrahedronVolume(double side)
        {
            // (sqrt(2)/12) * a^3
            return (Math.Sqrt(2) / 12.0) * Math.Pow(side, 3);
        }

        // --- Triangular Pyramid ---
        
        public static double TriangularPyramidVolume(double? baseArea = null, double? height = null)
        {
            // Note: Original was (a, h) where a was likely 'base area'.
            // Original: 1/3 * a * h
            if (baseArea != null && height != null)
            {
                return (1.0 / 3.0) * baseArea.Value * height.Value;
            }
             throw new ArgumentException("Insufficient parameters for TriangularPyramidVolume.");
        }
    }
}
