public static class FactorialUtil
{
    public static int Calculate(int n)
    {
        int result = 1;
        for (int i = 1; i <= n; i++)
            result *= i;
        return result;
    }
}
