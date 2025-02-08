using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        int T = int.Parse(Console.ReadLine().Trim());
        while (T-- > 0) {
            int[] nk = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            int n = nk[0], k = nk[1];
            int[] sequence = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

            var allPermutations = GetPermutations(Enumerable.Range(0, n).ToArray(), k)
                .OrderBy(p => p, Comparer<int[]>.Create((a, b) => {
                    for (int i = 0; i < k; i++)
                        if (a[i] != b[i]) return a[i].CompareTo(b[i]);
                    return 0;
                }))
                .ToList();

            int position = allPermutations.FindIndex(p => p.SequenceEqual(sequence)) + 1;
            Console.WriteLine(position);
        }
    }

    static IEnumerable<int[]> GetPermutations(int[] array, int length) {
        return Permute(array, 0, length);
    }

    static IEnumerable<int[]> Permute(int[] array, int start, int length) {
        if (start == length) {
            yield return array.Take(length).ToArray();
        }
        else {
            for (int i = start; i < array.Length; i++) {
                (array[start], array[i]) = (array[i], array[start]);
                foreach (var perm in Permute(array, start + 1, length))
                    yield return perm;
                (array[start], array[i]) = (array[i], array[start]);
            }
        }
    }
}