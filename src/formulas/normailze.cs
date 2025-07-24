using System;

public static class NormalizeUtil
{
    public static double[] Normalize(double[] row)
    {
        double norm = SqrtDotProduct.Calculate(row, row);
        double[] result = new double[row.Length];
        for (int i = 0; i < row.Length; i++)
        {
            result[i] = row[i] / norm;
        }
        return result;
    }
}
