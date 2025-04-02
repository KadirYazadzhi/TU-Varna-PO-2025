using System;
using System.Collections.Generic;
using System.Linq;


class Program {
    private static long[] memo;
    private static long[] results;
    
    public static void Main() {
        int n = int.Parse(Console.ReadLine());
        results = new long[n];
        
        memo = new long[1001];
        memo[0] = 1;

        ReadData(n);
        PrintResults();
    }

    private static void ReadData(int n) {
        for (int i = 0; i < n; i++) {
            string[] line = Console.ReadLine().Split().ToArray();
            
            int P = int.Parse(line[0]);
            int R = int.Parse(line[1]);
            int N = int.Parse(line[2]);
            int M = int.Parse(line[3]);
            
            results[i] = SumResult(P, R, N, M);
        }
    }

    private static void PrintResults() {
        foreach (var result in results) {
            Console.WriteLine(result);
        }
    }

    private static long CalculateFactorial(int n) {
        if (memo[n] != 0) return memo[n];
        
        memo[n] = n * CalculateFactorial(n - 1);
        
        return memo[n];
    }

    private static long CalculateCombination(int n, int k) {
        if (k > n) return 0;
        
        return CalculateFactorial(n) / (CalculateFactorial(k) * CalculateFactorial(n - k)); 
    }

    private static long SumResult(int P, int R, int N, int M) {
        return CalculateCombination(N, P) * CalculateCombination(M, R);
    }
}
