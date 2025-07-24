using System;

public static class QRDecomposition
{
    public static (double[,], double[,]) Decompose(double[,] mat)
    {
        var X = Transpose.Do(mat);
        int n = X.GetLength(0);
        int m = X.GetLength(1);
        double[,] r = new double[n, m];
        double[,] Q = new double[n, m];
        int k = 0;
        while (true)
        {
            r[k, k] = SqrtDotProduct(GetRow(X, k), GetRow(X, k));
            SetRow(Q, k, MatrixScalaMultiplation.Multiply(GetRow(X, k), 1 / r[k, k]));
            for (int j = k + 1; j < n; j++)
                r[k, j] = DotProduct(GetRow(Q, k), GetRow(X, j));
            for (int j = k + 1; j < n; j++)
                SetRow(X, j, MatrixSub.Subtract(GetRow(X, j), MatrixScalaMultiplation.Multiply(GetRow(Q, k), r[k, j])));
            k++;
            if (k == n)
                return (Transpose.Do(Q), r);
        }
    }
    private static double[] GetRow(double[,] mat, int row)
    {
        int cols = mat.GetLength(1);
        double[] result = new double[cols];
        for (int i = 0; i < cols; i++)
            result[i] = mat[row, i];
        return result;
    }
    private static void SetRow(double[,] mat, int row, double[] values)
    {
        for (int i = 0; i < values.Length; i++)
            mat[row, i] = values[i];
    }
    private static double SqrtDotProduct(double[] row1, double[] row2)
    {
        double res = 0;
        for (int i = 0; i < row1.Length; i++)
            res += row1[i] * row2[i];
        return Math.Sqrt(res);
    }
    private static double DotProduct(double[] row1, double[] row2)
    {
        double res = 0;
        for (int i = 0; i < row1.Length; i++)
            res += row1[i] * row2[i];
        return res;
    }
}
