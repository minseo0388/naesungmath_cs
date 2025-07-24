using System;

public static class Gaussian
{
    public static double[,] Calculate(double[,] matrix, int m, int n)
    {
        double[,] X = (double[,])matrix.Clone();
        for (int i = 0; i < n; i++)
        {
            double k = X[i, i];
            for (int j = 0; j < m; j++)
                X[i, j] /= k;
            for (int j = 0; j < n; j++)
            {
                if (i != j)
                {
                    double ratio = X[j, i];
                    for (int l = 0; l < m; l++)
                        X[j, l] -= ratio * X[i, l];
                }
            }
        }
        return X;
    }
}
