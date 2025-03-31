def max_potion(T, test_cases):
    results = []
    for case in test_cases:
        N, M = case
        if N == 1:
            results.append(M[0])
            continue
        
 
        dp = [0] * N
        dp[0] = M[0]
        dp[1] = max(M[0], M[1])
        
        for i in range(2, N):
            dp[i] = max(dp[i-1], dp[i-2] + M[i])
        
        results.append(dp[N-1])
    return results


import sys
input = sys.stdin.read
data = input().splitlines()

T = int(data[0])  
test_cases = []

index = 1
for _ in range(T):
    N = int(data[index])
    M = list(map(int, data[index + 1].split())) 
    test_cases.append((N, M))
    index += 2


output = max_potion(T, test_cases)


for res in output:
    print(res)
