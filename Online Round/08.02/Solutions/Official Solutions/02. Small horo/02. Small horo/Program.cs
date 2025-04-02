using System;
using System.Linq;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine());
        
        while (T-- > 0) {
            string s = Console.ReadLine();
            Console.WriteLine(CountValidSplits(s));
        }
    }

    static int CountValidSplits(string s) {
        int n = s.Length;
        int[] balance = new int[n * 2 + 1];
        int minBalance = 0, count = 0;

 
        for (int i = 0; i < n; i++) {
            balance[i + 1] = balance[i] + (s[i] == '(' ? 1 : -1);
            minBalance = Math.Min(minBalance, balance[i + 1]);
        }


        if (balance[n] != 0) return 0;

        for (int i = 0; i < n; i++) {
            if (balance[i] == minBalance) count++;
        }

        return count;
    }
}