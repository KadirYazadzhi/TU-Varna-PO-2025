using System;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < T; i++) {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int X = int.Parse(input[0]);
            int N = int.Parse(input[1]);
            
            int result = X ^ (1 << N);
            Console.WriteLine(result);
        }
    }
}