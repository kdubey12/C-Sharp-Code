// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

const double mph_conversion = 2.2369362920544;

static List<double> SpeedConversion(int m, int s)
{
    int total_seconds = s + (60 * m);
    int distance = 10000;
    double ms = (double)distance / (double)total_seconds;
    double mph = ms * mph_conversion;

    return [ms, mph];
}

static void MultiplicationTable()
{
    Console.WriteLine("Enter a number for a multiplication table.");
    string inp = Console.ReadLine();
    int n;
    if (Int32.TryParse(inp, out n)) { }
    else
    {
        Console.WriteLine("Error - not a number.");
        return;
    }

    Console.WriteLine("Enter the length of the multiplication table.");
    string len = Console.ReadLine();
    int l;
    if (Int32.TryParse(len, out l)) { }
    else
    {
        Console.WriteLine("Error - not a number.");
        return;
    }

    for (int i = 1; i <= l; i++)
    {
        Console.WriteLine(i * n);
    }
}

static List<double> CircleParse(double r)
{
    double pi = Math.PI;
    double area = pi * r * r;
    double circumference = 2 * pi * r;

    return [area, circumference];

}

static double EstimatePi(int k)
{
    Random rnd = new Random();
    List<double> current;
    double radius = 0.5;
    int count_inside = 0;

    for (int i = 0; i < k; i++)
    {
        current = [rnd.NextDouble(), rnd.NextDouble()];
        double distance = Math.Sqrt(Math.Pow(current[1] - 0.5, 2) + Math.Pow(current[0] - 0.5, 2));
        if (distance <= radius)
        {
            count_inside++;
        }
    }
    double res = 4.0 * ((float)count_inside / (float)k);
    return res;
}

while (true)
{
    Console.WriteLine("Select from questions 1, 2, 3 (0 to quit)");
    string inp = Console.ReadLine();
    int q_num;
    if (Int32.TryParse(inp, out q_num)) { }
    else
    {
        Console.WriteLine("That was not a number.");
        continue;
    }

    if (q_num == 1)
    {
        int m;
        int s;

        Console.WriteLine("Enter the minutes taken");
        string minutes = Console.ReadLine();

        if (Int32.TryParse(minutes, out m)) { }
        else
        {
            Console.WriteLine("That was not a number.");
        }

        Console.WriteLine("Enter seconds taken");
        string seconds = Console.ReadLine();

        if (Int32.TryParse(seconds, out s)) { }
        else
        {
            Console.WriteLine("That was not a number.");
        }

        List<double> speed_results = SpeedConversion(m, s);

        speed_results.ForEach(Console.WriteLine);
    }
    else if (q_num == 2)
    {
        MultiplicationTable();
    }
    else if (q_num == 3)
    {
        Console.WriteLine("Enter a radius to find area and circumference.");
        string radius_inp = Console.ReadLine();
        double r;

        if (Double.TryParse(radius_inp, out r)) { }
        else
        {
            Console.WriteLine("That was not a number.");
            continue;
        }

        List<double> circle_data = CircleParse(r);

        foreach (double val in circle_data)
        {
            double rounded_val = Math.Round(val, 2);
            Console.WriteLine(rounded_val);
        }

        Console.WriteLine("Enter a value for depth to estimate pi.");
        string depth = Console.ReadLine();
        int k_depth;

        if (Int32.TryParse(depth, out k_depth)) { }
        else
        {
            Console.WriteLine("That was not a number.");
            continue;
        }

        Console.WriteLine(EstimatePi(k_depth));
    }
    else if (q_num == 0)
    {
        Console.WriteLine("Goodbye.");
        break;
    }
    else
    {
        continue;
    }
}
