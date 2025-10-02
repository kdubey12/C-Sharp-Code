using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

static void PrintList<T>(List<T> n)
{
    Console.WriteLine($"[ {String.Join(", ", n)} ]");
}

static void Wave(string s)
{
    List<string> output = new List<string>() { String.Concat(s[0].ToString().ToUpper(), s.Substring(1)) };

    for (int i = 1; i < s.Length; i++)
    {
        if (s[i] == ' ') continue;

        output.Add(String.Concat(s.Substring(0, i), s[i].ToString().ToUpper(), s.Substring(i + 1)));
    }

    PrintList<string>(output);
}

static void ToCode(string s)
{
    List<int> output = new List<int>();

    foreach (char i in s)
    {
        output.Add((int)i);
    }

    Console.WriteLine(String.Join(" ", output));
}

static void ToByteArray(string s)
{
    byte[] ns = Encoding.Default.GetBytes(s);

    PrintList<byte>(ns.ToList());
}

static void CodeToString(List<int> n)
{
    StringBuilder sb = new StringBuilder();

    foreach (int i in n)
    {
        sb.Append((char)i);
    }

    Console.WriteLine(sb.ToString());
}

static void ByteToString(byte[] b)
{
    Console.WriteLine(Encoding.UTF8.GetString(b));
}

static int Anagram(string s, List<string> n)
{
    int total = 0;

    Console.WriteLine(s);

    foreach (string i in n)
    {
        if (String.Concat(i.OrderBy(i => i)) == s)
        {
            total += 1;
        }
    }

    return total;
}

static void VarNamer()
{
    Console.WriteLine("Enter variable name.");
    string[] parts = Console.ReadLine().Split(' ');

    Console.WriteLine("Pick naming convention: 1 - camelCase, 2 - Pascalcase, 3 - snake_case");
    if (!int.TryParse(Console.ReadLine(), out int n))
    {
        Console.WriteLine("Error.");
        return;
    }

    StringBuilder sb = new StringBuilder();
    string f;

    switch (n)
    {
        case 1:
            f = String.Concat(parts[0][0].ToString().ToLower(), parts[0].Substring(1).ToLower());
            sb.Append(f);

            for (int i = 1; i < parts.Length; i++)
            {
                string s = parts[i];
                sb.Append(String.Concat(s[0].ToString().ToUpper(), s.Substring(1)));
            }
            break;
        case 2:
            f = String.Concat(parts[0][0].ToString().ToUpper(), parts[0].Substring(1).ToLower());
            sb.Append(f);

            for (int i = 1; i < parts.Length; i++)
            {
                string s = parts[i];
                sb.Append(String.Concat(s[0].ToString().ToUpper(), s.Substring(1).ToLower()));
            }
            break;
        case 3:
            f = parts[0].ToLower();
            sb.Append(f);

            for (int i = 1; i < parts.Length; i++)
            {
                string s = String.Concat("_", parts[i].ToLower());
                sb.Append(s);
            }
            break;
    }

    Console.Write(sb.ToString());
}

static void PigLatin(string s)
{
    List<string> words = s.Split(' ').ToList();
    List<string> output = new List<string>();

    foreach (string word in words)
    {

        List<int> punctuation_pos = new List<int>();
        List<string> punctuation = new List<string>();
        for (int i = 0; i < word.Length; i++)
        {
            if (Char.IsPunctuation(word[i]) == true)
            {
                punctuation_pos.Add(i);
                punctuation.Add(word[i].ToString());
            }
        }

        string filtered_word = String.Concat(word.Where(c => Char.IsLetter(c)));
        string new_word = String.Concat(filtered_word.Substring(1), filtered_word[0], "ay");
        
        for (int i = 0; i < punctuation_pos.Count; i++)
        {
            new_word = new_word.Insert(punctuation_pos[i] + i, punctuation[i]);
        }

        output.Add(new_word);
    }

    PrintList<string>(output);
}

Wave("hello");
ToCode("你好");
ToByteArray("你好");
CodeToString([67, 69, 71]);

byte[] b = [206, 188, 206, 174, 206, 187, 206, 191];
ByteToString(b);

Console.WriteLine(Anagram("star", ["rats", "arts", "arc"]));

VarNamer();

PigLatin("The man said \"Hello\". The cat sat on the mat.");
