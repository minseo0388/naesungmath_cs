using System;

namespace NaesungMath.CS.Formulas {
    public static class Triangle {
        public static double AreaByAngle(double a, double b, double t) {
            return 0.5 * a * b * Math.Sin(t);
        }
    }
}
