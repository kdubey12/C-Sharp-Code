// See https://aka.ms/new-console-template for more information.

static void CheckEquality()
{
    Console.WriteLine("Enter two numbers space separated to check equality.");
    string inp = Console.ReadLine();
    string[] parts = inp.Split(' ');

    double a, b;

    if (parts.Length != 2 || !double.TryParse(parts[0], out a) || !double.TryParse(parts[1], out b))
    {
        Console.WriteLine("Error.");
        return;
    }

    string result = (a == b) ? "Equal" : "Not equal";
    Console.WriteLine(result);
}

static void IsEven()
{
    Console.WriteLine("Enter a number (integer).");
    string num = Console.ReadLine();
    if (!int.TryParse(num, out int n))
    {
        Console.WriteLine("Error - not a number.");
        return;
    }

    if (n % 2 == 0)
    {
        Console.WriteLine($"{n} is even.");
    }
    else
    {
        Console.WriteLine($"{n} is odd.");
    }
    
}

static void IsLeapYear()
{
    Console.WriteLine("Enter a year.");
    string y = Console.ReadLine();
    bool leap_year = false;

    if (!int.TryParse(y, out int year))
    {
        Console.WriteLine("Invalid year.");
        return;
    }

    if (year % 4 == 0 && year % 100 == 0)
    {
        leap_year = false;
    }
    else if (year % 4 == 0 && year % 400 == 0)
    {
        leap_year = true;
    }
    else if (year % 4 == 0)
    {
        leap_year = true;
    }

    string result = (leap_year == true) ? $"{year} is a leap year" : $"{year} is not a leap year.";
    Console.WriteLine(result);
}

static void FizzBuzzReturn()
{
    Console.WriteLine("Enter a number to check its fizzbuzz");
    string inp = Console.ReadLine();
    if (!int.TryParse(inp, out int n))
    {
        Console.WriteLine("error!");
        return;
    }
    if (n % 3 == 0 && n % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (n % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (n % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(n.ToString());
    }
}

static void NumFactors()
{
    Console.WriteLine("Enter a number to find the number of factors.");
    string inp = Console.ReadLine();
    if (!int.TryParse(inp, out int n))
    {
        Console.WriteLine("Error");
        return;
    }

    double n_root = Math.Sqrt(n);
    int factor_count = 0;

    for (int i = 1; i <= n_root; i++)
    {
        if (n % i == 0)
        {
            if (i * i == n)
            {
                factor_count++;
            }
            else
            {
                factor_count += 2;
            }
        }
    }

    Console.WriteLine($"{n} has {factor_count} factors.");
}

static void CheckVowel()
{
    Console.WriteLine("Enter a character to check if it is a vowel.");
    string s = Console.ReadLine();
    switch (s)
    {
        case "a":
            Console.WriteLine("This is a vowel.");
            break;
        case "e":
            Console.WriteLine("This is a vowel.");
            break;
        case "i":
            Console.WriteLine("This is a vowel.");
            break;
        case "o":
            Console.WriteLine("This is a vowel.");
            break;
        case "u":
            Console.WriteLine("This is a vowel.");
            break;
        default:
            Console.WriteLine("This is not a vowel.");
            break;
    }
}

static void CalcBlocks()
{
    Console.WriteLine("Enter a file size to find the number of blocks.");
    string inp = Console.ReadLine();

    if (!double.TryParse(inp, out double file_size))
    {
        Console.WriteLine("Error - invalid input.");
        return;
    }

    Console.WriteLine($"The number of blocks required is {Math.Round(file_size * 2, 0)}."); // multiply by 1024 and divide by 512 == multiply by 2
}

static void PocketMoney()
{
    Console.WriteLine("Enter how much you get weekly and a percentage you want to save (space separated).");
    string inp = Console.ReadLine();

    string[] parts = inp.Split(' ');
    double weekly, percentage;

    if (parts.Length != 2 || !double.TryParse(parts[0], out weekly) || !double.TryParse(parts[1], out percentage))
    {
        Console.WriteLine("Error");
        return;
    }

    double percentage_mult = percentage / 100;
    double weekly_saving = weekly * percentage_mult;

    double yearly_saving = weekly_saving * 52;

    Console.WriteLine($"Weekly Saving {Math.Round(weekly_saving, 2)}, Yearly Saving {Math.Round(yearly_saving, 2)}");
}

static void FindGreatest()
{
    Console.WriteLine("Enter a list of numbers (space separated) to find the greatest.");
    string inp = Console.ReadLine();

    string[] parts = inp.Split(' ');
    List<int> nums = new List<int>();

    Console.WriteLine(parts[0]);

    foreach (string s in parts)
    {
        int num;
        if (int.TryParse(s, out num))
        {
            nums.Add(num);    
        }
        else
        {
            Console.WriteLine("Error - not an integer.");
            return;
        }
    }

    int maxnum = nums.Max();

    Console.WriteLine(maxnum);
}

static void CoordQ()
{
    Console.WriteLine("Enter cartesian coordinate (integers) of form (x,y) - no space.");
    string input = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Error no input");
        return;
    }

    input = input.Replace("(", "").Replace(")", "").Replace(" ", "");

    string[] parts = input.Split(',');
    int x, y;

    if (parts.Length != 2 || !int.TryParse(parts[0], out x) || !int.TryParse(parts[1], out y))
    {
        Console.WriteLine("Wrong format.");
        return;
    }

    if (x >= 0 && y >= 0)
        Console.WriteLine("Top Right Quadrant");
    else if (x >= 0 && y <= 0)
        Console.WriteLine("Bottom Right Quadrant");
    else if (x <= 0 && y <= 0)
        Console.WriteLine("Bottom Left Quadrant");
    else
        Console.WriteLine("Top Left Quadrant");

    Console.WriteLine("Enter a radius to determine whether the point is within.");
    string r = Console.ReadLine();

    if (!double.TryParse(r, out double radius))
    {
        Console.WriteLine("Error.");
        return;
    }

    Console.WriteLine("Would you like the circle to be centred on a point other than 0,0? Enter a coordinate or leave it blank.");
    string c_inp = Console.ReadLine()?.Trim();

    int c_x, c_y;

    if (string.IsNullOrWhiteSpace(c_inp))
    {
        c_x = 0;
        c_y = 0;
    }
    else
    {
        input = input.Replace("(", "").Replace(")", "").Replace(" ", "");

        string[] c_parts = input.Split(',');

        if (parts.Length != 2 || !int.TryParse(c_parts[0], out c_x) || !int.TryParse(c_parts[1], out c_y))
        {
            Console.WriteLine("Wrong format.");
            return;
        }
    }



    double point_dist = Math.Sqrt(Math.Pow(Math.Abs(x - c_x), 2) + Math.Pow(Math.Abs(y - c_y), 2));

    if (point_dist < radius)
    {
        Console.WriteLine("Point is within circle.");
    }
    else
    {
        Console.WriteLine("Point is not within circle.");
    }
}

static void Grading()
{
    Console.WriteLine("Enter 3 grades (without percentage symbol %) space separated.");
    string scores = Console.ReadLine();

    string[] parts = scores.Split(' ');
    double quiz_score, block_score, final_score;

    if (parts.Length != 3 ||
        !double.TryParse(parts[0], out quiz_score) ||
        !double.TryParse(parts[1], out block_score) ||
        !double.TryParse(parts[2], out final_score))
    {
        Console.WriteLine("Error - invalid format.");
        return;
    }

    double average_score = (quiz_score + block_score + final_score) / 3.0;
    string grade;

    if (average_score >= 90)
    {
        grade = "A*";
    }
    else if (average_score >= 80)
    {
        grade = "A";
    }
    else if (average_score >= 70)
    {
        grade = "B";
    }
    else if (average_score >= 50)
    {
        grade = "C";
    }
    else
    {
        grade = "F";
    }

    Console.WriteLine($"The grade is {grade}.");
}

static void AgeVerification()
{
    Console.WriteLine("Enter your date of birth in form (DD/MM/YYYY).");
    string inp = Console.ReadLine();

    string[] parts = inp.Split('/');

    if (parts.Length != 3 ||
        !int.TryParse(parts[0], out int day) ||
        !int.TryParse(parts[1], out int month) ||
        !int.TryParse(parts[2], out int year))
    {
        Console.WriteLine("Error - invalid format.");
        return;
    }
    DateTime birth_date = new DateTime(year, month, day);
    DateTime today = DateTime.Now;

    int age = today.Year - birth_date.Year;

    if (birth_date.Date > today.AddYears(-age)) age--;

    if (age >= 18)
    {
        Console.WriteLine("You are eligible to be paid.");
    }
    else if (age >= 16)
    {
        Console.WriteLine("You can volunteer!");
    }
    else if (age >= 13)
    {
        Console.WriteLine("You can go to the activity camp.");
    }
    else
    {
        Console.WriteLine("You are not eligible for anything.");
    }
}

static void TriangleClassification()
{
    Console.WriteLine("Enter 3 side lengths (can be floating point) space separated to see if the triangle exists.");
    string inp = Console.ReadLine();

    string[] parts = inp.Split(' ');
    if (parts.Length != 3 ||
        !int.TryParse(parts[0], out int a) ||
        !int.TryParse(parts[1], out int b) ||
        !int.TryParse(parts[2], out int c))
    {
        Console.WriteLine("Error - invalid format.");
        return;
    }

    if (a <= 0 || b <= 0 || c <= 0)
    {
        Console.WriteLine("Error - negative/zero sides is not possible.");
        return;
    }

    if (a == b && b == c && a == c)
    {
        Console.WriteLine("The triangle is equilateral.");
    }

    else if (a == b || b == c || a == c)
    {
        Console.WriteLine("The triangle is isoceles.");
    }
    else
    {
        Console.WriteLine("The triangle is scalene.");
    }
}

static void Menu()
{
    int q_num;

    while (true)
    {
        Console.WriteLine("Select a question number from 1-13 (0 to quit).");
        string inp = Console.ReadLine();

        if (!int.TryParse(inp, out q_num))
        {
            Console.WriteLine("Error - invalid question number (NaN).");
            continue;
        }

        if (q_num == 0)
        {
            break;
        }

        if (q_num < 1 || q_num > 13)
        {
            Console.WriteLine("Error - invalid question number (out of range).");
            continue;
        }

        switch (q_num)
        {
            case 1:
                CheckEquality();
                break;
            case 2:
                IsEven();
                break;
            case 3:
                IsLeapYear();
                break;
            case 4:
                FizzBuzzReturn();
                break;
            case 5:
                NumFactors();
                break;
            case 6:
                CheckVowel();
                break;
            case 7:
                CalcBlocks();
                break;
            case 8:
                PocketMoney();
                break;
            case 9:
                FindGreatest();
                break;
            case 10:
                CoordQ();
                break;
            case 11:
                Grading();
                break;
            case 12:
                AgeVerification();
                break;
            case 13:
                TriangleClassification();
                break;
            default:
                continue;
        }
    }
}

Menu();