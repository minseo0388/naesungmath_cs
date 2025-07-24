using System;

public static class RandomVector
{
    public static double[] Generate(int length, double norm = 1)
    {
        var rand = new Random();
        double[] x = new double[length];
        double currentNorm = 0;
        for (int i = 0; i < length; i++)
        {
            x[i] = rand.NextDouble();
            currentNorm += Math.Abs(x[i]) * Math.Abs(x[i]);
        }
        currentNorm = Math.Sqrt(currentNorm);
        for (int i = 0; i < length; i++)
            x[i] *= norm / currentNorm;
        return x;
    }
}
