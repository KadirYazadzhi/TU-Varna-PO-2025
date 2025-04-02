using System;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine());
        
        for (int t = 0; t < T; t++) {
            int N = int.Parse(Console.ReadLine());
            int Q = int.Parse(Console.ReadLine());
            
            for (int q = 0; q < Q; q++) {
                int P = int.Parse(Console.ReadLine());
                
                N ^= (1 << (P - 1));
            }
            
            Console.WriteLine(N);
        }
    }
}