public static class SqrtDotProduct
{
    public static double Calculate(double[] row1, double[] row2)
    {
        double res = 0;
        for (int i = 0; i < row1.Length; i++)
        {
            res += row1[i] * row2[i];
        }
        return Math.Sqrt(res);
    }
}
