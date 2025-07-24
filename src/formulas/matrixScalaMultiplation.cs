public static class MatrixScalaMultiplation
{
    public static double[,] Multiply(double[,] matrix, double k)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
            double[,] res = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    res[i, j] = matrix[i, j] * k;
                }
            }
            return res;
    }
}
