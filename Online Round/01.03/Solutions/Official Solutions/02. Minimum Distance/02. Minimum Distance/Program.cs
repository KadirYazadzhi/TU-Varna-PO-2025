using System;

class Solution {
    static void Main(string[] args) {
        int T = int.Parse(Console.ReadLine());
        for (int t = 0; t < T; t++) {
            string[] input = Console.ReadLine().Split();
            int xA = int.Parse(input[0]), yA = int.Parse(input[1]);
            int xB = int.Parse(input[2]), yB = int.Parse(input[3]);
            int xX = int.Parse(input[4]), yX = int.Parse(input[5]);

            double distance = DistanceFromPointToSegment(xA, yA, xB, yB, xX, yX);
            Console.WriteLine($"{distance:F2}");
        }
    }

    static double DistanceFromPointToSegment(int xA, int yA, int xB, int yB, int xX, int yX) {
        double ABx = xB - xA;
        double ABy = yB - yA;
        double AXx = xX - xA;
        double AXy = yX - yA;

        double dot = ABx * AXx + ABy * AXy;
        double lengthAB = ABx * ABx + ABy * ABy;

        if (lengthAB == 0) return Math.Sqrt(AXx * AXx + AXy * AXy); 
        
        double t = dot / lengthAB;

        if (t < 0) {
            return Math.Sqrt(AXx * AXx + AXy * AXy);
        }
        else if (t > 1) {
            double BXx = xX - xB;
            double BXy = yX - yB;
            return Math.Sqrt(BXx * BXx + BXy * BXy);
        }
        else {
            double crossProduct = ABx * AXy - ABy * AXx;
            return Math.Abs(crossProduct) / Math.Sqrt(lengthAB);
        }
    }
}