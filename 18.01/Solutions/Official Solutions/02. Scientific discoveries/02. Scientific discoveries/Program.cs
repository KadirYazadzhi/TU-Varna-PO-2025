using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine().Trim()); 

        for (int t = 0; t < T; t++) {
            int N = int.Parse(Console.ReadLine().Trim()); 
            int[] significance = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);

            int[] result = new int[N];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < N; i++) {
                while (stack.Count > 0 && significance[stack.Peek()] >= significance[i]) {
                    stack.Pop();
                }

                result[i] = stack.Count > 0 ? stack.Peek() + 1 : 0;
                stack.Push(i);
            }

            Console.WriteLine($"{string.Join(" ", result)} ");
        }
    }
}