using System;

class Program {
    static int LexicographicRank(int n, int k, int[] team) {
        int rank = 1;
        for (int i = 0; i < k; i++) {
            for (int j = (i == 0 ? 0 : team[i - 1]); j < team[i]; j++) {
                rank += CountCombinations(n, k - i - 1, j);
            }
        }
        return rank;
    }

    static int CountCombinations(int n, int k, int minRole) {
        long result = 1;
        for (int i = 1; i <= k; i++){
            result = result * (n - minRole + i - 1) / i;
        }
        
        return (int)result;
    }

    static void Main() {
        string[] inputs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        int n = int.Parse(inputs[0]);
        int k = int.Parse(inputs[1]);

        int[] team = Array.ConvertAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);

        Console.WriteLine(LexicographicRank(n, k, team));
    }
}