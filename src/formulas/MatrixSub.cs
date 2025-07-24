using System;
public static class MatrixSubUtil
{
    public static double[,] Subtract(double[,] matrixA, double[,] matrixB)
    {
        int rows = matrixA.GetLength(0);
        int cols = matrixA.GetLength(1);
        if (rows != matrixB.GetLength(0) || cols != matrixB.GetLength(1))
            throw new ArgumentException("Matrix dimensions must match.");
        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrixA[i, j] - matrixB[i, j];
            }
        }
        return result;
    }
}
