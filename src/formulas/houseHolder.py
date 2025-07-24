import math

def householder(vec: list[float]) -> list[list[float]]:
    n = len(vec)
    norm = math.sqrt(sum(x ** 2 for x in vec))
    v = [x for x in vec]
    v[0] += math.copysign(norm, vec[0])
    v_norm = math.sqrt(sum(x ** 2 for x in v))
    if v_norm == 0:
        raise ValueError("Zero vector encountered in Householder transformation.")
    v = [x / v_norm for x in v]
    H = [[-2 * v[i] * v[j] for j in range(n)] for i in range(n)]
    for i in range(n):
        H[i][i] += 1
    return H