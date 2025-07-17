using System;
using System.Collections.Generic;

public static class DisplaySums
{
    public static void Run()
    {
        DisplaySumPairs(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        // Expected Output (order may vary):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs(new int[] { -20, -15, -10, -5, 0, 5, 10, 15, 20 });
        // Expected Output:
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs(new int[] { 5, 11, 2, -4, 6, 8, -1 });
        // Expected Output:
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time. Assumes the input list has no duplicates.
    /// </summary>
    /// <param name="numbers">Array of integers</param>
    private static void DisplaySumPairs(int[] numbers)
    {
        var seen = new HashSet<int>();
        var printed = new HashSet<string>(); // To avoid printing duplicates like 3+7 and 7+3

        foreach (var num in numbers)
        {
            int complement = 10 - num;

            if (seen.Contains(complement))
            {
                // Create a consistent string key for the pair (min, max)
                int min = Math.Min(num, complement);
                int max = Math.Max(num, complement);
                string pairKey = $"{min},{max}";

                if (!printed.Contains(pairKey))
                {
                    Console.WriteLine($"{num} {complement}");
                    printed.Add(pairKey);
                }
            }

            seen.Add(num);
        }
    }
}
