// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;

static void DisplayList<T>(IEnumerable<T> n)
{
    Console.WriteLine($"[{String.Join(", ", n)}]");
}

static int GetSum(List<int> n)
{
    int total = 0;

    foreach (int i in n)
    {
        total += i;
    }

    return total;
}

static int GetMax(List<int> n)
{
    int max = 0;

    foreach (int i in n)
    {
        if (i > max)
        {
            max = i;
        }
    }

    return max;

}

static int GetMin(List<int> n)
{
    int min = int.MaxValue;

    foreach (int i in n)
    {
        if (i < min)
        {
            min = i;
        }
    }

    return min;
}

static List<int> GetNegatives(List<int> n)
{
    List<int> negatives = new List<int>();

    foreach (int i in n)
    {
        if (i < 0)
        {
            negatives.Add(i);
        }
    }

    return negatives;
}

static bool SetEquality(List<int> a, List<int> b)
{
    HashSet<int> set_a = a.ToHashSet();
    HashSet<int> set_b = b.ToHashSet();

    if (set_a == set_b)
    {
        return true;
    }

    return false;
}

static bool NaiveSearch(int n, List<int> sorted)
{
    foreach (int i in sorted)
    {
        if (i == n)
        {
            return true;
        }
    }

    return false;
}

static bool BinarySearch(int n, List<int> sorted)
{

    while (true)
    {

        if (n < sorted[0] || n > sorted[sorted.Count -1])
        {
            return false;
        }

        int middle = sorted[(sorted.Count - 1) / 2];

        Console.WriteLine(middle);
        Console.WriteLine(String.Join(", ", sorted));

        if (middle == n)
        {
            return true;
        }

        else if (n > middle)
        {
            return BinarySearch(n, sorted.Skip((sorted.Count - 1) / 2).ToList());
        }
        else
        {
            return BinarySearch(n, sorted.Take((sorted.Count - 1) / 2).ToList());
        }
    }
}

static List<int> FindDuplicates(List<int> n)
{
    List<int> nodupe = new List<int>();
    List<int> dupes = new List<int>();

    foreach (int i in n)
    {
        if (nodupe.Contains(i) == false)
        {
            nodupe.Add(i);
        }
        else
        {
            dupes.Add(i);
        }
    }

    return dupes;
}

static bool IsSubset(List<int> a, List<int> b)
{
    HashSet<int> set_a = a.ToHashSet();
    HashSet<int> set_b = b.ToHashSet();
    HashSet<int> empty = new HashSet<int>();

    if (set_a == set_b || set_a.Intersect(set_b).ToList().Count != 0)
    {
        Console.WriteLine(String.Join(", ", set_a.Intersect(set_b).ToList()));
        return true;
    }

    return false;
}

static void ReverseList(ref List<int> n)
{
    n.Reverse();
}



