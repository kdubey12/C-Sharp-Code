// See https://aka.ms/new-console-template for more information

static int SlowSum(`int n)
{
    int total = 0;
    for (int i = 1; i <= n; i++)
    {
        total += i;
    }

    return total;
}

static int GaussSum(int n)
{
    return n * (n + 1) / 2;
}

static double EstimatePi(int k)
{
    double total = 3.0;
    int count = 2;
    double next_term;

    for (int i = 0; i < k; i++)
    {
        next_term = 4.0 / (count * (count + 1) * (count + 2)) - 4.0 / ((count+2)*(count+3)*(count+4));
        total += next_term;
        count += 4;
    }
    return total;
}

int n = 100;

Console.WriteLine(SlowSum(n));
Console.WriteLine(GaussSum(n));
Console.WriteLine(EstimatePi(n));