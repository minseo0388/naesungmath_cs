using System;

public static class HouseHolder
{
    public static double[,] Transform(double[] vec)
    {
        int n = vec.Length;
        double norm = Math.Sqrt(vec.Sum(x => x * x));
        double[] v = (double[])vec.Clone();
        v[0] += Math.Sign(vec[0]) * norm;
        double v_norm = Math.Sqrt(v.Sum(x => x * x));
        if (v_norm == 0)
            throw new ArgumentException("Zero vector encountered in Householder transformation.");
        for (int i = 0; i < n; i++)
            v[i] /= v_norm;
        double[,] H = new double[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                H[i, j] = -2 * v[i] * v[j];
        for (int i = 0; i < n; i++)
            H[i, i] += 1;
        return H;
    }
}
