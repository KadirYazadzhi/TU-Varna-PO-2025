from itertools import combinations

def min_distance_sum(n, A):
    min_sum = float('inf')
    
    for comb in combinations(range(n), 4):
        dist_sum = 0
        for i in range(4):
            for j in range(i + 1, 4):
                dist_sum += A[comb[i]][comb[j]]
        min_sum = min(min_sum, dist_sum)
    
    return min_sum

n = int(input())
A = [list(map(int, input().split())) for _ in range(n)]

result = min_distance_sum(n, A)

print(result)

