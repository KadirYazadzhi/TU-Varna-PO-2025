using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine());
        
        while (T-- > 0) {
            var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int N = nm[0], M = nm[1];
            
            var graph = new Dictionary<int, List<(int, int)>>();
            for (int i = 1; i <= N; i++) {
                graph[i] = new List<(int, int)>();
            }
            
            for (int i = 0; i < M; i++) {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int u = edge[0], v = edge[1], w = edge[2];
                graph[u].Add((v, w));
                graph[v].Add((u, w));
            }
            
            Console.WriteLine(Dijkstra(graph, N));
        }
    }
    
    static int Dijkstra(Dictionary<int, List<(int, int)>> graph, int target) {
        var dist = new Dictionary<int, int>();
        var pq = new SortedSet<(int, int)>(); 
        
        foreach (var key in graph.Keys) {
            dist[key] = int.MaxValue;
        }
        dist[1] = 0;
        pq.Add((0, 1));
        
        while (pq.Count > 0) {
            var (d, node) = pq.Min;
            pq.Remove(pq.Min);
            
            if (node == target) return d;
            
            foreach (var (neighbor, weight) in graph[node]) {
                int newDist = d + weight;
                if (newDist < dist[neighbor]) {
                    pq.Remove((dist[neighbor], neighbor));
                    dist[neighbor] = newDist;
                    pq.Add((newDist, neighbor));
                }
            }
        }
        
        return dist[target] == int.MaxValue ? -1 : dist[target];
    }
}