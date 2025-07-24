public static class LQDecomposition
{
    public static (double[,], double[,]) Decompose(double[,] mat)
    {
        var AT = Transpose.Do(mat);
        var (Q, R) = QRDecomposition.Decompose(AT);
        var L = Transpose.Do(R);
        var Q2 = Transpose.Do(Q);
        return (L, Q2);
    }
}
