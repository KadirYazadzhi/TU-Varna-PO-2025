using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine());
        
        for (int t = 0; t < T; t++) {
            int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = nm[0], M = nm[1];
            
            List<(int, int)>[] graph = new List<(int, int)>[N + 1];
            for (int i = 1; i <= N; i++) graph[i] = new List<(int, int)>();
            
            for (int i = 0; i < M; i++) {
                int[] uvw = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int U = uvw[0], V = uvw[1], W = uvw[2];
                
                graph[U].Add((V, W));
                graph[V].Add((U, W));
            }
            
            int S = int.Parse(Console.ReadLine());
            
            int totalTime = Dijkstra(graph, N, S);
            Console.WriteLine(totalTime);
        }
    }
    
    static int Dijkstra(List<(int, int)>[] graph, int N, int start) {
        int[] dist = Enumerable.Repeat(int.MaxValue, N + 1).ToArray();
        bool[] visited = new bool[N + 1];
        dist[start] = 0;
        
        SortedSet<(int, int)> pq = new SortedSet<(int, int)>();
        pq.Add((0, start));
        
        while (pq.Count > 0) {
            var (d, node) = pq.Min;
            pq.Remove(pq.Min);
            
            if (visited[node]) continue;
            visited[node] = true;
            
            foreach (var (neighbor, weight) in graph[node]) {
                if (dist[node] + weight < dist[neighbor]) {
                    dist[neighbor] = dist[node] + weight;
                    pq.Add((dist[neighbor], neighbor));
                }
            }
        }
        
        return dist.Where(x => x != int.MaxValue).Sum();
    }
}