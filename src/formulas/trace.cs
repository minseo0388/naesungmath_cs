public static class Trace
{
    public static double Calculate(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        double res = 0;
        for (int i = 0; i < n; i++)
            res += matrix[i, i];
        return res;
    }
}
