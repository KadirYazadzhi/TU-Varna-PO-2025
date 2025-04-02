using System;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < T; i++) {
            long N = long.Parse(Console.ReadLine());
            int D = int.Parse(Console.ReadLine());
            
            if (D < 1 || D > 31) continue;
            
            string binaryRepresentation = Convert.ToString(N, 2);
            
            binaryRepresentation = binaryRepresentation.PadLeft(31, '0');
            
            if (binaryRepresentation[31 - D] == '1') Console.WriteLine("Operational");
            else Console.WriteLine("Off");
        }
    }
}