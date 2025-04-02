using System;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine());  

        for (int i = 0; i < T; i++) {
            string[] input = Console.ReadLine().Split();
            string A = input[0]; 
            string B = input[1];

            bool isAPositive = A[0] != '-'; 
            bool isBPositive = B[0] != '-'; 

            if (isAPositive != isBPositive) {
                Console.WriteLine("Opposite");
            } 
            else {
                Console.WriteLine("Same");
            }
        }
    }
}