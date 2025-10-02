// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

static int SumInt(int a, int b)
{
    return a + b;
}

static double SumDouble(double a, double b)
{
    return a + b;
}

static decimal SumDecimal(decimal a, decimal b)
{
    return a + b;
}

static int SumDigits(int n)
{
    int total = 0;
    while (n != 0)
    {
        total += n % 10;
        n /= 10;
    }
    return total;
}

static bool IsPrime(int n)
{
    double n_root = Math.Sqrt(n);
    int count = 0;

    for (int i = 1; i <= n_root; i++)
    {
        if (n % i == 0)
        {
            if (i * i == n)
            {
                count++;
            }
            else
            {
                count += 2;
            }
        }
    }

    if (count == 2)
    {
        return true;
    }

    return false;
}

static int NumSpaces(string s)
{
    int count = 0;
    foreach (char i in s)
    {
        if (i == ' ')
        {
            count++;
        }
    }

    return count;
}

static void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = a;
}

static string Translate(int n, int p)
{
    return Convert.ToString(n, p);
}

static string TranslateNew(int n, int p)
{
    int remainder;
    string hex_value;
    string output = "";
    int c = 65;

    while (n != 0)
    {

        n = Math.DivRem(n, p, out remainder);
        if (remainder < 10)
        {
            hex_value = remainder.ToString();
        }
        else
        {
            hex_value = ((char)(c + (remainder - 10))).ToString();
        }

        output = hex_value + output;
    }
    return output;
}

static void MultiplicationTable(int a = 12, int b = 12)
{
    for (int i = 1; i <= a; i++)
    {
        Console.WriteLine(i * b);
    }
}

//Console.WriteLine(Translate(383, 16));
//Console.WriteLine(TranslateNew(383, 6));
//MultiplicationTable();
//Console.WriteLine(NumSpaces("This Has 3 Spaces."));
//Console.WriteLine(IsPrime(13));
//Console.WriteLine(SumDigits(345));
