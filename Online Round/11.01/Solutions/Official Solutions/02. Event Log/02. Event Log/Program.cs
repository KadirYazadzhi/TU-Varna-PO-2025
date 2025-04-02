using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    public static void Main(string[] args) {
        int T = int.Parse(Console.ReadLine());
        
        for (int t = 0; t < T; t++) {
            string input = Console.ReadLine();
            Console.WriteLine(IsValid(input) ? "Valid" : "Invalid");
        }
    }
    
    private static bool IsValid(string s) {
        int balance = 0;

        foreach (char ch in s) {
            if (ch == '(') {
                balance++;
            }
            else if (ch == ')') {
                balance--;
                if (balance < 0) return false; 
            }
        }

        return balance == 0; 
    }
}