def count_routes(grid):
    rows, cols = len(grid), len(grid[0])
    directions = [(0, 1), (1, 0)]

    def dfs(r, c, visited):
        if r == rows - 1 and c == cols - 1:
            return 1

        if (r, c) in visited:
            return 0

        visited.add((r, c))
        
        count = 0
        for dr, dc in directions:
            nr, nc = r + dr, c + dc

            if 0 <= nr < rows and 0 <= nc < cols and grid[nr][nc] != -1:
                count += dfs(nr, nc, visited)
        
        visited.remove((r, c))
        return count

    return dfs(0, 0, set())

t = int(input())
for _ in range(t):
    n, m = map(int, input().split())
    grid = [list(map(int, input().split())) for _ in range(n)]
    print(count_routes(grid))

