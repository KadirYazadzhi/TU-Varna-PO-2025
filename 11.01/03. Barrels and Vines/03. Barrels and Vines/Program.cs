using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    public static void Main(string[] args) {
        int T = int.Parse(Console.ReadLine()); 

        for (int t = 0; t < T; t++) {
            int N = int.Parse(Console.ReadLine());
            
            int oneThird = N / 3;  
            int half = N / 2;      

            int totalBottles = (oneThird * 2) + (half * 1);  
            
            if (totalBottles % 2 != 0) {
                totalBottles -= 1;
            }
            
            int remainingBottles = totalBottles / 2;

            Console.WriteLine(N + remainingBottles); 
        }
    }
}