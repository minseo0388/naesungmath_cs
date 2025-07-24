public static class OutterProductMatrixUtil
{
    public static double[,] Calculate(double[,] u, double[,] v)
    {
        // Transpose v
        int rowsV = v.GetLength(0);
        int colsV = v.GetLength(1);
        double[,] vT = new double[cols, rows];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                vT[j, i] = v[i, j];
        // Multiply u and vT
        double[,] res = new double[u.GetLength(0), colsV];
        for (int i = 0; i < uRows; i++)
            for (int j = 0; j < cols; j++)
            {
                double sum = 0;
                for (int k = 0; k < uCols; k++)
                    sum += u[i, k] * vT[k, j];
                result[i, j] = sum;
            }
        return res;
    }
}
