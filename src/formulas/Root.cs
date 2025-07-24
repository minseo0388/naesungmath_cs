using System;

public class Root
{
    public double[] Data { get; private set; }
    public Root()
    {
        Data = new double[11];
        for (int i = 2; i < 11; i++)
            Data[i] = Get(i, 10);
    }
    public double Get(double val, int digit = 10)
    {
        double result = Math.Sqrt(val);
        return Math.Round(result, digit);
    }
}
