using System;
using System.Collections.Generic;

public static class Determinant
{
    public static double Calculate(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        if (n != m)
            throw new ArgumentException("Matrix must be square.");
        if (n > 2)
        {
            double result = 0;
            for (int i = 0; i < n; i++)
            {
                double K = matrix[0, i];
                double[,] mat = Minor(matrix, 0, i);
                if (i % 2 == 0)
                    result += K * Calculate(mat);
                else
                    result -= K * Calculate(mat);
            }
            return result;
        }
        else
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }
    }

    private static double[,] Minor(double[,] matrix, int row, int col)
    {
        int n = matrix.GetLength(0);
        double[,] result = new double[n - 1, n - 1];
        int r = 0;
        for (int i = 0; i < n; i++)
        {
            if (i == row) continue;
            int c = 0;
            for (int j = 0; j < n; j++)
            {
                if (j == col) continue;
                result[r, c] = matrix[i, j];
                c++;
            }
            r++;
        }
        return result;
    }
}
