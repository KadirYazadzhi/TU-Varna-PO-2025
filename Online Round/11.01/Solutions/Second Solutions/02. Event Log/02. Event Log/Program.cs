using System;
using System.Collections.Generic;

class Program {
    public static void Main() {
        int t = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < t; i++) {
            string input = Console.ReadLine();
            Console.WriteLine(IsValid(input) ? "Valid" : "Invalid");
        }
    }
    
    private static bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        
        foreach (char c in s) {
            if (c == '(') {
                stack.Push(c); 
            }
            else if (c == ')') {
                if (stack.Count == 0) return false;
                
                stack.Pop();
            }
        }
        
        return stack.Count == 0; 
    }
}
