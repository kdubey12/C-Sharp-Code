using System.Data.Common;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

static void WriteToFile(string filename)
{
    List<string> vals = new List<string>();

    while (true)
    {
        string s = Console.ReadLine();

        if (s == "") break;

        vals.Add(s);
    }

    if (vals.Count == 0) return;

    StreamWriter fileStr;

    if (File.Exists(filename))
    {
        Console.WriteLine("Notice - File exists. Appending instead...");
        fileStr = File.AppendText(filename);
    }

    else
    {
        Console.WriteLine("File not found. Creating new file...");
        fileStr = File.CreateText(filename);
    }

    foreach (string i in vals)
    {
        fileStr.WriteLine(i);
    }

    fileStr.Close();
}

WriteToFile("sentences.txt");

static List<string> FindStationsByFilter(string s, string filename)
{
    StreamReader fileStr = File.OpenText(filename);

    string line;

    List<string> output = new List<string>();

    while ((line = fileStr.ReadLine()) != null)
    {
        if (line.ToLowerInvariant().Contains(s))
        {
            output.Add(line);

        }
    }

    fileStr.Close();

    return output;
}

static List<string> FindStationsByException(string s, string filename)
{
    StreamReader fileStr = File.OpenText(filename);

    string line;
    bool valid = true;

    List<string> output = new List<string>();

    while ((line = fileStr.ReadLine()) != null)
    {
        valid = true;
        string name = line.Split(", ")[0];

        string check_name = name.ToLowerInvariant();

        foreach (char i in s.ToLowerInvariant()) if (check_name.Contains(i)) valid = false;

        if (valid == true) output.Add(name);
    }

    fileStr.Close();

    return output;
}

static List<string> FindStationsByRepeat(string filename)
{
    StreamReader fileStr = File.OpenText(filename);
    string line;

    List<string> output = new List<string>();

    while ((line = fileStr.ReadLine()) != null)
    {
        string[] parts = line.Split(", ");

        string[] name_parts = parts[0].Split(' ');

        if (name_parts.Length != 2) continue;

        if (name_parts[0][0] != name_parts[1][0]) continue;

        output.Add(parts[0]);
    }

    fileStr.Close();

    return output;
}

static string FindMostStationsOnLine(string filename)
{
    StreamReader fileStr = File.OpenText(filename);
    string line;

    Dictionary<string, int> station_vals = new Dictionary<string, int>();

    while ((line = fileStr.ReadLine()) != null)
    {
        string[] parts = line.Split(", ");

        string tube_line = parts[1];

        station_vals.TryGetValue(tube_line, out int current_count);
        station_vals[tube_line] = current_count + 1;
    }

    string max = station_vals.MaxBy(KeyValuePair => KeyValuePair.Value).Key;

    return $"{max}: {station_vals[max]}";

}

static Dictionary<string, int> WordFrequency(string filename)
{
    StreamReader fileStr = File.OpenText(filename);
    string line;

    Dictionary<string, int> words = new Dictionary<string, int>();

    while ((line = fileStr.ReadLine()) != null)
    {
        line = String.Concat(line.ToList().Where(c => !char.IsPunctuation(c)).ToList());
        string[] parts = line.Split(' ');

        foreach (string word in parts)
        {
            words.TryGetValue(word, out int current_count);
            words[word] = current_count + 1;
        }
    }

    return words;
}

Console.WriteLine(String.Join(" ", FindStationsByFilter("station", "stations.txt")));

Console.WriteLine(String.Join(" ", FindStationsByException("Mackerel", "stations.txt")));
Console.WriteLine(String.Join(" ", FindStationsByException("Piranha", "stations.txt")));
Console.WriteLine(String.Join(" ", FindStationsByException("Sturgeon", "stations.txt")));
Console.WriteLine(String.Join(" ", FindStationsByException("Bacteria", "stations.txt")));

Console.WriteLine(String.Join(" ", FindStationsByRepeat("stations.txt")));

Console.WriteLine(FindMostStationsOnLine("stations.txt"));

Dictionary<string, int> words = WordFrequency("stations.txt");

foreach (KeyValuePair<string, int> kvp in words)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}