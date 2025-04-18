def triangle_area(x1, y1, x2, y2, x3, y3):
    return abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2

T = int(input().strip())

for _ in range(T):
    x1, y1, x2, y2, x3, y3 = map(int, input().split())
    print(f"{triangle_area(x1, y1, x2, y2, x3, y3):.2f}")
