using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    private static readonly long[] Factorials = PrecomputeFactorials(1000);
    
    private static long[] PrecomputeFactorials(int maxLimit) {
        long[] factorials = new long[maxLimit + 1];
        factorials[0] = 1;
        for (int i = 1; i <= maxLimit; i++) {
            factorials[i] = factorials[i - 1] * i;
        }
        return factorials;
    }

    private static long CalculateCombination(int n, int k) {
        if (k > n) return 0;
        return Factorials[n] / (Factorials[k] * Factorials[n - k]);
    }

    public static void Main(string[] args) {
        int T = int.Parse(Console.ReadLine());
        long[] results = new long[T];
        int testIndex = 0;

        while (testIndex < T) {
            string[] inputs = Console.ReadLine().Split();
            int P = int.Parse(inputs[0]);
            int R = int.Parse(inputs[1]);
            int N = int.Parse(inputs[2]);
            int M = int.Parse(inputs[3]);

            long participantsCombination = CalculateCombination(N, P);
            long awardsCombination = CalculateCombination(M, R);
            
            results[testIndex++] = participantsCombination * awardsCombination;
        }

        foreach (var result in results) {
            Console.WriteLine(result);
        }
    }
}