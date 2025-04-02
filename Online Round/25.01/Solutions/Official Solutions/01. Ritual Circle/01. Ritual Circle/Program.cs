using System;
using System.Numerics;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine());
        
        int[] inputs = new int[T];
        for (int i = 0; i < T; i++) {
            inputs[i] = int.Parse(Console.ReadLine());
        }


        foreach (int N in inputs) {
            Console.WriteLine(CircularPermutations(N));
        }
    }

    static BigInteger CircularPermutations(int N) {
        if (N == 1) return 1; 

        return Factorial(N - 1);
    }

    static BigInteger Factorial(int n) {
        BigInteger result = 1;
        for (int i = 2; i <= n; i++) {
            result *= i;
        }
        return result;
    }
}