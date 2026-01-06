using System;

namespace NaesungMath.Formulas
{
    public static class BasicMath
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }

        public static long Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("Factorial undefined for negative numbers.");
            if (n == 0 || n == 1) return 1;
            long result = 1;
            for (int i = 2; i <= n; i++) result *= i;
            return result;
        }

        public static double Gcd(double a, double b)
        {
            while (b != 0)
            {
                double temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        public static double Minus(double a, double b) // Legacy name mapping support if we want strict name? User said "Use intuitive names". "Subtract" is better, but mapping had "minus". I will provide "Subtract" and maybe alias? Plan said "Subtract".
        {
             return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Plus(double a, double b)
        {
            return a + b;
        }

        public static double Pow(double a, double b)
        {
            return Math.Pow(a, b);
        }

        public static double Round(double a)
        {
            return Math.Round(a);
        }

        public static double Sqrt(double a)
        {
            return Math.Sqrt(a);
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }
    }
}
