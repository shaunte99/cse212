using System;
using System.Collections.Generic;

public static class UniqueLetters
{
    public static void Run()
    {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters are unique
        Console.WriteLine($"Test 1: {AreUniqueLetters(test1)}");

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine($"Test 2: {AreUniqueLetters(test2)}");

        var test3 = ""; // Expect True because it's an empty string
        Console.WriteLine($"Test 3: {AreUniqueLetters(test3)}");
    }

    /// <summary>
    /// Determine if all letters in the text are unique using a set for O(n) performance.
    /// </summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text)
    {
        var seen = new HashSet<char>();

        foreach (var letter in text)
        {
            if (seen.Contains(letter))
            {
                return false;
            }
            seen.Add(letter);
        }

        return true;
    }
}
