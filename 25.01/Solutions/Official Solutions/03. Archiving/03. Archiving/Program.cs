using System;
using System.Linq;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine());

        for (int t = 0; t < T; t++) {
            string[] firstLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int N = int.Parse(firstLine[0]);
            int K = int.Parse(firstLine[1]);
            
            int[] fileSizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            var smallestFiles = fileSizes.OrderBy(size => size).Take(K);
            
            Console.WriteLine(string.Join(" ", smallestFiles));
        }
    }
}