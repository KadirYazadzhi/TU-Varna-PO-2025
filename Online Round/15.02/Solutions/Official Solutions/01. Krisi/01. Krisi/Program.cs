using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine() ?? "0"); 
        
        for (int t = 0; t < T; t++) {
            string[] input = Console.ReadLine()?.Split();
            if (input == null || input.Length != 3) continue;

            int S = int.Parse(input[0]);
            int L = int.Parse(input[1]);
            int M = int.Parse(input[2]);
            
            List<(int, int, int, int)> routes = new List<(int, int, int, int)>();
            int maxCost = 0;

            for (int i = 0; i < L; i++) {
                input = Console.ReadLine()?.Split();
                if (input == null || input.Length != 4) continue;

                int X = int.Parse(input[0]);
                int Y = int.Parse(input[1]);
                int C = int.Parse(input[2]);
                int Tt = int.Parse(input[3]);

                routes.Add((X, Y, C, Tt));
                maxCost = Math.Max(maxCost, C); 
            }
            
            int low = 0, high = maxCost, result = 0;
            while (low <= high) {
                int mid = (low + high) / 2;
                if (CanReachDestinationWithCost(routes, S, M, mid)) {
                    result = mid; 
                    high = mid - 1; 
                }
                else {
                    low = mid + 1; // Try with higher cost
                }
            }

            Console.WriteLine(result);
        }
    }
    
    static bool CanReachDestinationWithCost(List<(int, int, int, int)> routes, int S, int M, int maxCost) {
        List<List<(int, int)>> graph = new List<List<(int, int)>>();

        for (int i = 0; i <= S; i++)
            graph.Add(new List<(int, int)>());

        foreach (var (X, Y, C, T) in routes) {
            if (C <= maxCost) graph[X].Add((Y, T));
            
        }
        
        int[] time = new int[S + 1];
        Array.Fill(time, int.MaxValue);
        time[1] = 0;

        PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();

        pq.Enqueue((0, 1), 0); 

        while (pq.Count > 0) {
            var current = pq.Dequeue(); 
            int currTime = current.Item1; 
            int stop = current.Item2; 

            if (currTime > M) break;

            if (currTime > time[stop]) continue;

            foreach (var (nextStop, travelTime) in graph[stop]) {
                int newTime = currTime + travelTime;
                if (newTime <= M && newTime < time[nextStop]) {
                    time[nextStop] = newTime;
                    pq.Enqueue((newTime, nextStop), newTime); 
                }
            }
        }

        return time[S] <= M;
    }
}
