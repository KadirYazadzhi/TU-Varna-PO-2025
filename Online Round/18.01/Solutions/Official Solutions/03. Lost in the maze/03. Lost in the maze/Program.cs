using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine());

        for (int t = 0; t < T; t++) {
            var dimensions = Console.ReadLine().Split(' ');
            int N = int.Parse(dimensions[0]);
            int M = int.Parse(dimensions[1]);

            char[,] maze = new char[N, M];
            (int, int) start = (-1, -1);
            (int, int) end = (-1, -1);

            for (int i = 0; i < N; i++) {
                string row = Console.ReadLine();
                for (int j = 0; j < M; j++) {
                    maze[i, j] = row[j];
                    
                    if (row[j] == 'S') start = (i, j);
                    if (row[j] == 'E') end = (i, j);
                }
            }

            Console.WriteLine(FindPath(maze, start, end, N, M) ? "Yes" : "No");
        }
    }

    static bool FindPath(char[,] maze, (int, int) start, (int, int) end, int N, int M) {
        bool[,] visited = new bool[N, M];
        int[] dRow = { -1, 1, 0, 0 };
        int[] dCol = { 0, 0, -1, 1 };

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue(start);
        visited[start.Item1, start.Item2] = true;

        while (queue.Count > 0) {
            var current = queue.Dequeue();

            if (current == end) return true;

            for (int i = 0; i < 4; i++) {
                int newRow = current.Item1 + dRow[i];
                int newCol = current.Item2 + dCol[i];

                if (IsValid(newRow, newCol, N, M, maze, visited)) {
                    visited[newRow, newCol] = true;
                    queue.Enqueue((newRow, newCol));
                }
            }
        }

        return false;
    }

    static bool IsValid(int row, int col, int N, int M, char[,] maze, bool[,] visited) {
        return row >= 0 && row < N && col >= 0 && col < M && maze[row, col] != '#' && !visited[row, col];
    }
}
