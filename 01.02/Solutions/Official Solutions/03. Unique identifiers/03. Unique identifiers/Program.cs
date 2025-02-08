using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine()); 

        for (int t = 0; t < T; t++) {
            int N = int.Parse(Console.ReadLine()); 
            Dictionary<string, int> usernameToId = new Dictionary<string, int>();
            Dictionary<int, string> idToUsername = new Dictionary<int, string>();
            int uniqueId = 0;
            
            for (int i = 0; i < N; i++) {
                string username = Console.ReadLine();
                if (!usernameToId.ContainsKey(username)) {
                    usernameToId[username] = uniqueId;
                    idToUsername[uniqueId] = username;
                    uniqueId++;
                }
            }

            int Q = int.Parse(Console.ReadLine()); 
            
            for (int q = 0; q < Q; q++) {
                string query = Console.ReadLine();
                if (int.TryParse(query, out int id)) {
                    if (idToUsername.ContainsKey(id)) {
                        Console.WriteLine(idToUsername[id]);
                    }
                }
                else {
                    if (usernameToId.ContainsKey(query)) {
                        Console.WriteLine(usernameToId[query]);
                    }
                }
            }
        }
    }
}