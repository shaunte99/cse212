 using System;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Substring(0, i) + letters.Substring(i + 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s < 0)
            return 0;
        if (s == 0)
            return 1;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal result = CountWaysToClimb(s - 1, remember)
                       + CountWaysToClimb(s - 2, remember)
                       + CountWaysToClimb(s - 3, remember);

        remember[s] = result;
        return result;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        if (!maze.IsValidMove(x, y, currPath))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            SolveMaze(results, maze, x + 1, y, currPath); // down
            SolveMaze(results, maze, x - 1, y, currPath); // up
            SolveMaze(results, maze, x, y + 1, currPath); // right
            SolveMaze(results, maze, x, y - 1, currPath); // left
        }

        currPath.RemoveAt(currPath.Count - 1); // backtrack
    }
}
