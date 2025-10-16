using System.Diagnostics;
using System.Globalization;

static int GetRightMostBits(int n, int count)
{
    return n & Convert.ToInt32(Math.Pow(2, count)) - 1;
}

Debug.Assert(GetRightMostBits(123, 4) == 11); // 123 = 1111011, 11 = 1011

static int GetLeftMostBits(int n, int count)
{
    return n >> Convert.ToInt32(Math.Floor(Math.Log2(n)))-(count-1);
}

Debug.Assert(GetLeftMostBits(23, 3) == 5); // 23 = 10111, 5 = 101

static int RemoveRightMostBits(int n, int count)
{
    return (n >> count) << count;
}

Debug.Assert(RemoveRightMostBits(23, 2) == 20); // 23 = 10111, 20 = 10100

static int RemoveLeftMostBits(int n, int count)
{
    return n & Convert.ToInt32(Math.Pow(2, Math.Floor(Math.Log2(n))-(count-1))-1);
}

Debug.Assert(RemoveLeftMostBits(123, 2) == 27); // 123 = 1111011, 27 = 0011011

static int Get4RemLast(int n)
{
    return RemoveRightMostBits(GetRightMostBits(n, 4), 1);
}

Debug.Assert(Get4RemLast(123) == 10);

static int RemFirstAppend(int n)
{
    return n + 1; // Not really worth - first bit will always be a 1, therefore this has the same effect.
}

Debug.Assert(RemFirstAppend(24) == 25);

static void PrettyFormat(int n)
{
    string bin = Convert.ToString(n, 2);

    for (int i = bin.Length - 1; i >= 0; i--)
    {
        Console.Write(bin[i]);
        if (i % 4 == 0) Console.Write(" ");
    }
}

static int GetBits(int n, int length, int pos)
{
    return (n & (Convert.ToInt32(Math.Pow(2, Convert.ToInt32(Math.Ceiling(Math.Log2(n))) - (pos - 1))) - 1)) >> (Convert.ToInt32(Math.Ceiling(Math.Log2(n))) - (pos - 1) - length);
}

Debug.Assert(GetBits(54, 2, 1) == 3);

static int CountSetBits(int n)
{
    int count = 0;
    while (n != 0)
    {
        n = n & (n - 1);
        count++;
    }

    return count;
}

Debug.Assert(CountSetBits(1) == 1);
Debug.Assert(CountSetBits(2) == 1);
Debug.Assert(CountSetBits(4) == 1);
Debug.Assert(CountSetBits(7) == 3);
Debug.Assert(CountSetBits(-1) == 32);
Debug.Assert(CountSetBits(-2) == 31);
