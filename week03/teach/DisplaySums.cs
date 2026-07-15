using System;
using System.Collections.Generic;

public static class DisplaySums {
    public static void Run() {
        Console.WriteLine("------------");
        var test1 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        DisplaySumPairs(test1); // Expect: 9 & 1, 8 & 2, 7 & 3, 6 & 4 (or similar pairs)

        Console.WriteLine("------------");
        var test2 = new[] { 5, 10, 2, 8, 4, 1, 9 };
        DisplaySumPairs(test2); // Expect: 8 & 2, 9 & 1

        Console.WriteLine("------------");
        var test3 = new[] { 1, 2, 3, 4, 5 };
        DisplaySumPairs(test3); // Expect: nothing printed
    }

    /// <summary>
    /// Display show pairs of numbers that sum to 10 using a set of O(n) efficiency.
    /// </summary>
    private static void DisplaySumPairs(int[] numbers) {
        // Create a set to store numbers we have already evaluated
        var seenNumbers = new HashSet<int>();

        foreach (var number in numbers) {
            int target = 10 - number;

            // If the target number we need was already seen, we found a matching pair
            if (seenNumbers.Contains(target)) {
                Console.WriteLine($"{number} & {target}");
            }

            // Add the current number to our set of seen numbers
            seenNumbers.Add(number);
        }
    }
}
