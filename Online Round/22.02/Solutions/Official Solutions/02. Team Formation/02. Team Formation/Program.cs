using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) {

        string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        List<string> employees = new List<string>();
        for (int i = 0; i < n; i++) {
            employees.Add(Console.ReadLine());
        }
        
        employees.Sort();
        
        List<List<string>> teams = GenerateCombinations(employees, k);
        
        foreach (var team in teams) {
            Console.WriteLine(string.Join("", team));
        }
    }

    static List<List<string>> GenerateCombinations(List<string> employees, int k) {
        List<List<string>> result = new List<List<string>>();
        GenerateCombinationsHelper(employees, k, 0, new List<string>(), result);
        return result;
    }

    static void GenerateCombinationsHelper(List<string> employees, int k, int start, List<string> current, List<List<string>> result) {
        if (current.Count == k) {
            result.Add(new List<string>(current));
            return;
        }

        for (int i = start; i < employees.Count; i++) {
            current.Add(employees[i]);
            GenerateCombinationsHelper(employees, k, i + 1, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}