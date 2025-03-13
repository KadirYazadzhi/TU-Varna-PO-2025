from collections import deque

def is_valid(x, y, n, m, grid):
    return 0 <= x < n and 0 <= y < m and grid[x][y] == 0

def bfs(start_x, start_y, n, m, grid):
    if not is_valid(start_x, start_y, n, m, grid):
        return "Invalid starting point"
    
    visited = [[0 for _ in range(m)] for _ in range(n)]
    queue = deque()
    queue.append((start_x, start_y))
    visited[start_x][start_y] = 1
    
    while queue:
        x, y = queue.popleft()
        
        for dx, dy in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
            nx, ny = x + dx, y + dy
            if is_valid(nx, ny, n, m, grid) and visited[nx][ny] == 0:
                visited[nx][ny] = 1
                queue.append((nx, ny))
    
    for i in range(n):
        for j in range(m):
            if grid[i][j] == 1:
                visited[i][j] = 0
    
    return visited

def main():
    T = int(input())
    for _ in range(T):
        n, m = map(int, input().split())
        grid = [list(map(int, input().split())) for _ in range(n)]
        start_x, start_y = map(int, input().split())
        
        result = bfs(start_x, start_y, n, m, grid)
        
        if result == "Invalid starting point":
            print(result)
        else:
            for row in result:
                print(" ".join(map(str, row)))

if __name__ == "__main__":
    main()
