using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine().Trim());
        while (T-- > 0) {
            var counts = Console.ReadLine()?.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray() ?? new int[2];
            int N1 = counts.Length > 0 ? counts[0] : 0;
            int N2 = counts.Length > 1 ? counts[1] : 0;

            HashSet<int> student1 = new HashSet<int>(Console.ReadLine()?.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse) ?? Enumerable.Empty<int>());
            HashSet<int> student2 = new HashSet<int>(Console.ReadLine()?.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse) ?? Enumerable.Empty<int>());

            var allCourses = student1.Union(student2).OrderBy(x => x);
            var commonCourses = student1.Intersect(student2).OrderBy(x => x);
            var onlyStudent1 = student1.Except(student2).OrderBy(x => x);
            var symmetricDifference = student1.Except(student2).Union(student2.Except(student1)).OrderBy(x => x);

            Console.WriteLine(string.Join(" ", allCourses));
            Console.WriteLine(string.Join(" ", commonCourses));
            Console.WriteLine(string.Join(" ", onlyStudent1));
            Console.WriteLine(string.Join(" ", symmetricDifference));
        }
    }
}