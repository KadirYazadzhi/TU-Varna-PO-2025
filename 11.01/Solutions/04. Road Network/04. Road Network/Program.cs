using System;
using System.Linq;
using System.Collections.Generic;

class Program {
    class UnionFind {
        private int[] parent;
        private int[] rank;

        public UnionFind(int n) {
            parent = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++) {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int Find(int x) {
            if (parent[x] != x) {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }
        
        public void Union(int x, int y) {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY) {
                if (rank[rootX] > rank[rootY]) {
                    parent[rootY] = rootX;
                }
                else if (rank[rootX] < rank[rootY]) {
                    parent[rootX] = rootY;
                }
                else {
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
            }
        }
    }

    public static void Main(string[] args) {
        int t = int.Parse(Console.ReadLine());  

        for (int test = 0; test < t; test++) {
            var nm = Console.ReadLine().Split();
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            
            List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>();
            
            for (int i = 0; i < m; i++) {
                var edge = Console.ReadLine().Split();
                int a = int.Parse(edge[0]);
                int b = int.Parse(edge[1]);
                int c = int.Parse(edge[2]);
                edges.Add(new Tuple<int, int, int>(c, a, b));  
            }
            
            edges.Sort();

            UnionFind uf = new UnionFind(n);
            int totalCost = 0;
            List<Tuple<int, int>> mstEdges = new List<Tuple<int, int>>();
            
            foreach (var edge in edges) {
                int cost = edge.Item1;
                int a = edge.Item2;
                int b = edge.Item3;
                
                if (uf.Find(a) != uf.Find(b)) {
                    uf.Union(a, b);
                    totalCost += cost;
                    mstEdges.Add(new Tuple<int, int>(a, b));
                    
                    if (mstEdges.Count == n - 1) {
                        break;
                    }
                }
            }
            
            if (mstEdges.Count == n - 1) {
                Console.WriteLine(totalCost);
                foreach (var edge in mstEdges)
                {
                    Console.WriteLine($"{edge.Item1} {edge.Item2}");
                }
            }
            else {
                Console.WriteLine(-1);  
            }
        }
    }
}
