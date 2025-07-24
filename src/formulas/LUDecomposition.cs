public static class LUDecomposition
{
    public static (double[,], double[,]) Decompose(double[,] matrix)
    {
        int length = matrix.GetLength(0);
        if (length != matrix.GetLength(1))
            throw new ArgumentException("Matrix must be square.");
        double[,] L = new double[length, length];
        double[,] U = new double[length, length];
        for (int i = 0; i < length; i++)
        {
            for (int k = i; k < length; k++)
            {
                double sum = 0;
                for (int j = 0; j < i; j++)
                    sum += L[i, j] * U[j, k];
                U[i, k] = matrix[i, k] - sum;
            }
            for (int k = i; k < length; k++)
            {
                if (i == k)
                    L[i, i] = 1;
                else
                {
                    double sum = 0;
                    for (int j = 0; j < i; j++)
                        sum += L[k, j] * U[j, i];
                    L[k, i] = (matrix[k, i] - sum) / U[i, i];
                }
            }
        }
        return (L, U);
    }
}
