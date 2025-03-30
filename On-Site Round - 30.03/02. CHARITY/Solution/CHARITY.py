import math

t = int(input())
for _ in range(t):
    h, d, n, m = map(int, input().split())
    print(math.comb(n, h) * math.comb(m, d))
