public static class GcdUtil
{
    public static int Calculate(int a, int b)
    {
        if (b == 0)
            return a;
        else
            return Calculate(b, a % b);
    }
}
