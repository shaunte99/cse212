using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1: FindPairs
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            // Skip words with identical letters
            if (word[0] == word[1]) continue;

            var reversed = new string(new char[] { word[1], word[0] });

            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    // Problem 2: SummarizeDegrees
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            if (fields.Length > 3)
            {
                var degree = fields[3].Trim();
                if (!string.IsNullOrEmpty(degree))
                {
                    if (degrees.ContainsKey(degree))
                    {
                        degrees[degree]++;
                    }
                    else
                    {
                        degrees[degree] = 1;
                    }
                }
            }
        }
        return degrees;
    }

    // Problem 3: IsAnagram
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize: remove spaces and lower case
        string w1 = word1.Replace(" ", "").ToLower();
        string w2 = word2.Replace(" ", "").ToLower();

        if (w1.Length != w2.Length)
            return false;

        var letterCounts = new Dictionary<char, int>();

        foreach (char c in w1)
        {
            if (letterCounts.ContainsKey(c))
                letterCounts[c]++;
            else
                letterCounts[c] = 1;
        }

        foreach (char c in w2)
        {
            if (!letterCounts.ContainsKey(c))
                return false;

            letterCounts[c]--;

            if (letterCounts[c] < 0)
                return false;
        }

        return true;
    }

    // Problem 5: EarthquakeDailySummary
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.Send(getRequestMessage);
        using var jsonStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summaries = new List<string>();
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                var place = feature.Properties?.Place ?? "Unknown location";
                var mag = feature.Properties?.Mag ?? 0.0;

                summaries.Add($"{place} - Mag {mag}");
            }
        }
        return summaries.ToArray();
    }
}

// JSON classes for Earthquake JSON (Problem 5)
public class FeatureCollection
{
    public string Type { get; set; }
    public Metadata Metadata { get; set; }
    public Feature[] Features { get; set; }
    public double[] Bbox { get; set; }
}

public class Metadata
{
    public long Generated { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
    public string Api { get; set; }
    public int Count { get; set; }
}

public class Feature
{
    public string Type { get; set; }
    public Properties Properties { get; set; }
    public Geometry Geometry { get; set; }
    public string Id { get; set; }
}

public class Properties
{
    public double Mag { get; set; }
    public string Place { get; set; }
    public long Time { get; set; }
    public long Updated { get; set; }
    public int Tz { get; set; }
    public string Url { get; set; }
    public string Detail { get; set; }
    public int Felt { get; set; }
    public double Cdi { get; set; }
    public double Mmi { get; set; }
    public string Alert { get; set; }
    public string Status { get; set; }
    public int Tsunami { get; set; }
    public int Sig { get; set; }
    public string Net { get; set; }
    public string Code { get; set; }
    public string Id { get; set; }
    public string Sources { get; set; }
    public string Types { get; set; }
    public int Nst { get; set; }
    public double Dmin { get; set; }
    public double Rms { get; set; }
    public double Gap { get; set; }
    public string MagType { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
}

public class Geometry
{
    public string Type { get; set; }
    public double[] Coordinates { get; set; }
}
