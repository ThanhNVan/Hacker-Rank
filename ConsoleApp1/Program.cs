namespace ConsoleApp1;

public class Program
{
    static void Main(string[] args) {
        //var result = kangaroo(23,9867,9814,5861);
        //Console.WriteLine(result);

        //var result = getTotalX( new List<int> { 1 }, new List<int> { 72, 48 });

        //var result = birthday(new List<int> { 2, 5, 1, 3, 4, 4, 3, 5, 1, 1, 2, 1, 4, 1, 3, 3, 4, 2, 1, }, 18, 7);

        //var result = divisibleSumPairs(100, 96, new List<int> { 34, 38, 30, 27, 1, 81, 37, 19, 74, 73, 32, 13, 44, 99, 7, 88, 50, 52, 32, 82, 29, 1, 55, 85, 89, 58, 35, 19, 76, 55, 45, 37, 41, 74, 80, 46, 38, 74, 56, 18, 86, 23, 57, 27, 52, 9, 69, 78, 52, 8, 62, 85, 65, 2, 11, 70, 34, 26, 72, 11, 20, 32, 9, 75, 74, 85, 29, 6, 87, 81, 40, 11, 31, 49, 66, 91, 99, 85, 18, 54, 81, 93, 52, 9, 72, 89, 85, 66, 24, 11, 85, 3, 14, 36, 72, 3, 76, 99, 88, 8, });

        var result = migratoryBirds(new List<int>() { 1, 2, 3, 4, 5, 2, 2, 2, 4, 4, 4, 1 });

        Console.WriteLine(result);
        Console.WriteLine("Hello, World!");

        Console.ReadLine();
    }

    public static int migratoryBirds(List<int> arr) {
        var result = 0;

        var countedList = arr.GroupBy(x => x)
                            .Select( x =>  new { Key = x.Key, Count = x.Count() })
                            .OrderByDescending(x => x.Count)
                            .ToList();

        if (countedList[0].Count == countedList[1].Count ) {
            result = countedList[0].Key <= countedList[1].Key ? countedList[0].Key : countedList[1].Key;
            return result;
        }

        result = countedList[0].Key;

        return result;
    }

    public static int divisibleSumPairs(int n, int k, List<int> ar) {
        var result = 0;

        for (int i = 0; i < n - 1; i++) {

            for (var j = i; j < n - 1; j++) {
                var sum = ar[i] + ar[j + 1];
                if (sum % k == 0) {
                    result++;
                }
            }

        }

        return result;
    }


    public static int birthday(List<int> s, int d, int m) {
        var result = 0;

        if (m == 1) {
            result = s.Where(x => x == d).Count();

            return result;
        }

        for (int i = 0; i < s.Count - m; i++) {
            var sum = 0;
            for (var j = i; j < i + m + 1; j++) {
                sum += s[j];
            };

            if (sum == d) {
                result++;
            }

            sum = 0;
        };

        return result;
    }


    public static double superFunctionalStrings(string s) {
        double result = 0;
        var length = s.Length;
        var subString = new HashSet<string>();

        for (int i = 0; i <= length; i++) {
            for (int j = i + 1; j <= length; j++) {
                subString.Add(s.Substring(i, j - i));
            }
        }

        foreach (var item in subString) {
            result += GetValueFromString(item);
        }

        result = result % (Math.Pow(10, 9) + 7);

        //var bb = 8 Mod 3;

        return result;
    }

    public static double GetValueFromString(string s) {
        var length = s.Count();
        var distinct = s.Distinct().Count();
        double answer = Math.Pow(length, distinct) % (Math.Pow(10, 9) + 7);

        return answer;
    }

    public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges) {
        var appleList = apples.Where(x => x > 0);

        var orangeList = oranges.Where(x => x < 0).Select(x => Math.Abs(x));

        appleList = appleList.Where(x => x >= s && x <= t);

        orangeList = orangeList.Where(x => x >= t && x <= s);
        Console.WriteLine(appleList.Count());
        Console.WriteLine(orangeList.Count());
    }

    public static string kangaroo(int x1, int v1, int x2, int v2) {
        if (v1 <= v2) {
            return "NO";
        }

        double time = (double)(x2 - x1) / (double)(v1 - v2);

        var isInteger = int.TryParse(time.ToString(), out _);

        if (time > 0 && isInteger) {
            return "YES";
        }

        return "NO";
    }

    public static int getTotalX(List<int> a, List<int> b) {
        var lcm = GetLCM(a);
        var value = lcm;
        var count = 0;
        var minPoint = b.Min(x => x);

        while (true) {
            if (IsDevidable(b, value)) {
                count++;
            }
            value += lcm;

            if (value > minPoint) {
                break;
            }
        }

        return count;
    }

    public static int GetLCM(List<int> a) {
        var result = 1;
        int sum = 0;
        while (true) {
            foreach (var item in a) {
                sum += result % item;
            }

            if (sum == 0) {
                break;
            }

            sum = 0;

            result++;
        }

        return result;
    }

    public static bool IsDevidable(List<int> ints, int value) {
        var sum = 0;

        foreach (var item in ints) {
            sum += item % value;
        }

        return sum == 0;
    }
}
