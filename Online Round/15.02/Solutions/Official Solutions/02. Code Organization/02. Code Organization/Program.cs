using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine());

        for (int t = 0; t < T; t++) {
            string input = Console.ReadLine();
            
            Console.WriteLine(IsValidBrackets(input) ? "Valid" : "Invalid");
        }
    }
    
    static bool IsValidBrackets(string s) {
        Stack<char> stack = new Stack<char>();
        
        foreach (char ch in s) {
            if (ch == '(' || ch == '[' || ch == '{') {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == ']' || ch == '}') {
                if (stack.Count == 0 || !IsMatchingPair(stack.Pop(), ch)) return false;
            }
        }
        
        return stack.Count == 0;
    }
    
    static bool IsMatchingPair(char opening, char closing) {
        return (opening == '(' && closing == ')') ||
               (opening == '[' && closing == ']') ||
               (opening == '{' && closing == '}');
    }
}