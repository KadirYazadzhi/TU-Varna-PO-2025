import sys
from collections import defaultdict

sys.setrecursionlimit(1 << 25)

def main():
    input = sys.stdin.read().split()
    ptr = 0
    N = int(input[ptr])
    ptr += 1
    M = int(input[ptr])
    ptr += 1
    
    graph = defaultdict(list)
    
    for _ in range(M):
        u = int(input[ptr])
        ptr += 1
        v = int(input[ptr])
        ptr += 1
        graph[u].append(v)
        graph[v].append(u)
    
    visited = [False] * (N + 1)
    parent = [-1] * (N + 1)
    cycle = []

    def dfs(u):
        nonlocal cycle
        visited[u] = True
        for v in graph[u]:
            if not visited[v]:
                parent[v] = u
                if dfs(v):
                    return True
            elif parent[u] != v:  # Cycle detected
                # Reconstruct the cycle
                cycle = []
                cycle.append(v)
                current = u
                while current != v:
                    cycle.append(current)
                    current = parent[current]
                cycle.append(v)
                
                # Reversing the cycle to get the correct order
                cycle = cycle[::-1]
                return True
        return False

    for u in range(1, N + 1):
        if not visited[u]:
            if dfs(u):
                print("YES")
                print(" ".join(map(str, cycle)))
                return

    print("NO")

if __name__ == "__main__":
    main()
