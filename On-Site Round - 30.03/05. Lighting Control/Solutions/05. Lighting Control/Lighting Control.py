def invert_bit(n, p):
    return n ^ (1 << (p - 1))

t = int(input())
for _ in range(t):
    n = int(input())
    q = int(input())
    for _ in range(q):
        p = int(input())
        n = invert_bit(n, p)
    print(n)
