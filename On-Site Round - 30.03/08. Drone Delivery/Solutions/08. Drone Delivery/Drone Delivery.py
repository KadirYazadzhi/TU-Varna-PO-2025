def min_energy_cost(n, m, energy):
    dp = [[float('inf')] * m for _ in range(n)]


    for j in range(m):
        dp[0][j] = energy[0][j]

    for i in range(1, n):
        for j in range(m):
            left = dp[i-1][max(0, j-1)]
            middle = dp[i-1][j]
            right = dp[i-1][min(m-1, j+1)]
            dp[i][j] = min(left, middle, right) + energy[i][j]

    return min(dp[-1])

n, m = map(int, input().split())
energy = [list(map(int, input().split())) for _ in range(n)]

result = min_energy_cost(n, m, energy)

print(result)
