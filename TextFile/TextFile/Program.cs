using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
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
            output.Add(line.Split(", ")[0]);

        }
    }

    fileStr.Close();

    return output;
}

Debug.Assert(FindStationsByFilter("station", "stations.txt").SequenceEqual(new List<string>() { "Battersea Power Station" }));

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

Debug.Assert(FindStationsByException("Mackerel", "stations.txt").SequenceEqual(new List<string>() { "St. John's Wood" }));
Debug.Assert(FindStationsByException("Piranha", "stations.txt").SequenceEqual(new List<string>() { "Stockwell" }));
Debug.Assert(FindStationsByException("Sturgeon", "stations.txt").SequenceEqual(new List<string>() { "Balham", "Blackwall" }));
Debug.Assert(FindStationsByException("Bacteria", "stations.txt").SequenceEqual(new List<string>() {}));

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

Debug.Assert(FindStationsByRepeat("stations.txt").SequenceEqual(new List<string>() { "Charing Cross", "Clapham Common", "Golders Green", "Seven Sisters", "Sloane Square" }));

static string FindMostStationsOnLine(string filename)
{
    StreamReader fileStr = File.OpenText(filename);
    string line;

    Dictionary<string, int> station_vals = new Dictionary<string, int>();

    while ((line = fileStr.ReadLine()) != null)
    {
        string[] parts = line.Split(", ");

        List<string> tube_lines = parts.Skip(1).Take(parts.Length).ToList();

        foreach (string tube_line in tube_lines)
        {

            station_vals.TryGetValue(tube_line, out int current_count);
            station_vals[tube_line] = current_count + 1;
        }
    }

    string max = station_vals.MaxBy(KeyValuePair => KeyValuePair.Value).Key;

    return $"{max}: {station_vals[max]}";

}

Debug.Assert(FindMostStationsOnLine("stations.txt") == "District: 60"); 

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
            string new_word = word.ToLowerInvariant();
            words.TryGetValue(new_word, out int current_count);
            words[new_word] = current_count + 1;
        }
    }

    Dictionary<string, int> sortedWords = words.OrderByDescending(k => k.Value).ToDictionary(o => o.Key, o => o.Value);

    return sortedWords;
}

Dictionary<string, int> words = WordFrequency("stations.txt");

Dictionary<string, int> top5words = words.Take(5).ToDictionary();

Debug.Assert(top5words.SequenceEqual(new Dictionary<string, int>() { { "district", 60 }, { "piccadilly", 54 }, { "central", 54 }, { "northern", 52 }, { "docklands", 45 } }));


Dictionary<string, int> words_val_1 = words.Where(k => k.Value == 1).ToDictionary();
// Dict is too long for debug.assert - am not making a testing dict.


// Q7

Dictionary<string, int> book_words = WordFrequency("thirty-nine-steps.txt");
List<string> book_word_vals = book_words.Keys.Order().ToList();
// Again, cannot realistically Debug.Assert a list of this size.

static List<char> GetAllNonAlphanumericChars(string filename)
{
    StreamReader fileStr = File.OpenText(filename);
    string line;

    HashSet<char> chars = new HashSet<char>();

    while ((line = fileStr.ReadLine()) != null) foreach (char i in line) if (!char.IsLetterOrDigit(i)) chars.Add(i);

    return chars.ToList();
}

Console.WriteLine(String.Join(" ", GetAllNonAlphanumericChars("thirty-nine-steps.txt").Select(k => k.ToString())));

//Q8

static List<string> ReadFile(string filename)
{
    StreamReader fileStr = File.OpenText(filename);
    string line;

    List<string> lines = new List<string>();

    while ((line = fileStr.ReadLine()) != null) lines.Add(line);

    return lines;
}

static void InvertFileByChar(string filename)
{
    List<string> lines = ReadFile($"{filename}.txt");

    StreamWriter sw = File.CreateText($"{filename}-invertchar.txt");

    for (int i = 0; i < lines.Count; i++)
    {
        char[] arr = lines[i].ToCharArray();
        Array.Reverse(arr);
        string reversed = new string(arr);

        sw.WriteLine(reversed);
    }

    sw.Close();
}

static void InvertFileByLine(string filename)
{
    List<string> lines = ReadFile($"{filename}.txt");

    StreamWriter sw = File.CreateText($"{filename}-invertline.txt");

    for (int i = lines.Count - 1; i >= 0; i--) sw.WriteLine(lines[i]);

    sw.Close();
}

static void InvertFileByWord(string filename)
{
    List<string> lines = ReadFile($"{filename}.txt");

    StreamWriter sw = File.CreateText($"{filename}-invertword.txt");

    for (int i = 0; i < lines.Count; i++)
    {
        string[] line = lines[i].Split(' ');

        Array.Reverse(line);

        sw.WriteLine(String.Join(" ", line));
    }

    sw.Close();
}

InvertFileByChar("thirty-nine-steps");
InvertFileByLine("thirty-nine-steps");
InvertFileByWord("thirty-nine-steps");
