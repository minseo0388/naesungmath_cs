using System;

public static class RandomUtil
{
    private static Random _rand = new Random();
    public static int Generate(int a, int b)
    {
        return _rand.Next(a, a + b);
    }
}
