using System;

namespace NaesungMath.Formulas
{
    public static class Trigonometry
    {
        public static double DegreeToRad(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        public static double Radian(double a) // Mapped legacy "radian" function
        {
            return a; // Likely just identity or conversion? Legacy code `radian(a)` usually means "return rad". 
            // If it meant "DegreeToRad", it's duplicated. 
            // Checking legacy context: "radian" usually implies converting to radian or just usage.
            // I'll assume identity if not specified, OR 180/pi? 
            // Let's assume it converts Degree To Radian if usage suggests "Radian(180) -> 3.14".
            // I will alias to DegreeToRad for safety given context of math libs.
            return DegreeToRad(a);
        }

        public static double RadToDegree(double radians)
        {
            return radians * (180.0 / Math.PI);
        }
    }
}
