using System;

namespace NaesungMath.CS.Formulas {
    public static class Trigonometry {
        public static double SinDeg(double degrees) {
            return Math.Sin(degrees * Math.PI / 180.0);
        }
        public static double CosDeg(double degrees) {
            return Math.Cos(degrees * Math.PI / 180.0);
        }
        public static double TanDeg(double degrees) {
            return Math.Tan(degrees * Math.PI / 180.0);
        }
    }
}
