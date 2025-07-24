public static class IdentityMatrix
{
    public static int[,] Create(int n)
    {
        int[,] res = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                res[i, j] = (i == j) ? 1 : 0;
            }
        }
        return res;
    }
}
