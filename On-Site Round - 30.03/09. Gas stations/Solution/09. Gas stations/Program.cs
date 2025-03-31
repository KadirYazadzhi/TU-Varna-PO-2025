using System;
using System.Collections.Generic;

class Program {
    static int TSP(int[,] graph, int N) {
        int VISITED_ALL = (1 << N) - 1;
        int[,] dp = new int[1 << N, N];
        for (int i = 0; i < (1 << N); i++)
        for (int j = 0; j < N; j++) dp[i, j] = int.MaxValue / 2;
        dp[1, 0] = 0;

        for (int mask = 1; mask < (1 << N); mask += 2) {
            for (int u = 0; u < N; u++) {
                if ((mask & (1 << u)) != 0) {
                    for (int v = 0; v < N; v++) {
                        if ((mask & (1 << v)) == 0) {
                            int nextMask = mask | (1 << v);
                            dp[nextMask, v] = Math.Min(dp[nextMask, v], dp[mask, u] + graph[u, v]);
                        }
                    }
                }
            }
        }

        int shortestPath = int.MaxValue;
        for (int i = 1; i < N; i++)
            shortestPath = Math.Min(shortestPath, dp[VISITED_ALL, i] + graph[i, 0]);

        return shortestPath;
    }

    static void Main() {
        int T = int.Parse(Console.ReadLine());
        while (T-- > 0) {
            int N = int.Parse(Console.ReadLine()) + 1;
            int[,] graph = new int[N, N];
            string[] distances = Console.ReadLine().Split();

            for (int j = 1; j < N; j++)
                graph[0, j] = graph[j, 0] = int.Parse(distances[j - 1]);

            for (int i = 1; i < N - 1; i++) {
                distances = Console.ReadLine().Split();
                
                for (int j = 0; j < distances.Length; j++) {
                    graph[i, i + j + 1] = graph[i + j + 1, i] = int.Parse(distances[j]);
                }
            }

            Console.WriteLine(TSP(graph, N));
        }
    }
}