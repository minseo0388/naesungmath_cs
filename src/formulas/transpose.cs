using System.Collections.Generic;

namespace NaesungMath.CS.Formulas {
    public static class Matrix {
        public static double[,] Transpose(double[,] mat) {
            int rows = mat.GetLength(0);
            int cols = mat.GetLength(1);
            double[,] res = new double[cols, rows];
            for (int i = 0; i < cols; i++) {
                for (int j = 0; j < rows; j++) {
                    res[i, j] = mat[j, i];
                }
            }
            return res;
        }
    }
}
