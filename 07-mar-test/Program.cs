namespace _07_mar_test;

internal class Program
{
    static void Main(string[] args) {
        var n = 5;

        var result = superFunctionalStrings("aaabbb");
        Console.WriteLine("Hello, World!");

        Console.WriteLine(result);
        Console.ReadKey();
    }

    // Fibonacy at n position : 0 + 1 + 1 + 2 + 3 + 5 + 8

    public static int superFunctionalStrings(string s) {
        var distinct = s.Distinct().Count();
        var length = s.Count();

        var answer = Math.Pow(length, distinct) % (Math.Pow(10, 9) + 7);

        var result = int.Parse(answer.ToString());

        return result;
    }


}
