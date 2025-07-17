using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // Skip header row

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields();
            if (fields == null || fields.Length < 9) continue;

            var playerId = fields[0];
            var pointsStr = fields[8];

            if (int.TryParse(pointsStr, out int points))
            {
                if (!players.ContainsKey(playerId))
                {
                    players[playerId] = points;
                }
                else
                {
                    players[playerId] += points; // Add up career points
                }
            }
        }

        // Sort by total points (descending) and take top 10
        var top10 = players
            .OrderByDescending(pair => pair.Value)
            .Take(10)
            .ToList();

        Console.WriteLine("Top 10 Players by Total Points:");
        Console.WriteLine("-------------------------------");
        foreach (var (playerId, totalPoints) in top10)
        {
            Console.WriteLine($"{playerId}: {totalPoints} points");
        }
    }
}
