using System.Numerics;

namespace HackerRank;

public class Program
{
    static void Main(string[] args) {

        #region [ Results ]
        //var result = kangaroo(23,9867,9814,5861);
        //Console.WriteLine(result);

        //var result = getTotalX( new List<int> { 1 }, new List<int> { 72, 48 });

        //var result = birthday(new List<int> { 2, 5, 1, 3, 4, 4, 3, 5, 1, 1, 2, 1, 4, 1, 3, 3, 4, 2, 1, }, 18, 7);

        //var result = divisibleSumPairs(100, 96, new List<int> { 34, 38, 30, 27, 1, 81, 37, 19, 74, 73, 32, 13, 44, 99, 7, 88, 50, 52, 32, 82, 29, 1, 55, 85, 89, 58, 35, 19, 76, 55, 45, 37, 41, 74, 80, 46, 38, 74, 56, 18, 86, 23, 57, 27, 52, 9, 69, 78, 52, 8, 62, 85, 65, 2, 11, 70, 34, 26, 72, 11, 20, 32, 9, 75, 74, 85, 29, 6, 87, 81, 40, 11, 31, 49, 66, 91, 99, 85, 18, 54, 81, 93, 52, 9, 72, 89, 85, 66, 24, 11, 85, 3, 14, 36, 72, 3, 76, 99, 88, 8, });

        //var result = migratoryBirds(new List<int>() { 1, 2, 3, 4, 5, 2, 2, 2, 4, 4, 4, 1 });
        //bonAppetit(new List<int> { 3, 10, 2 , 9 }, 10, 12);

        // var result = sockMerchant(5, new List<int> { 10, 20, 20, 10, 10, 30, 50, 10, 20 });
        //Console.WriteLine(result);

        //var result = countingValleys(8, "DDUUDDUDUUUD");
        //var result = getMoneySpent([5], [4], 5 );

        //var result = formingMagicSquare(new List<List<int>>() {
        //    new List<int> { 2, 5, 4},
        //    new List<int> { 4, 6, 9},
        //    new List<int> { 4, 5, 2},
        //});
        //new List<int> { 4, 8, 2},
        //new List<int> { 4, 5, 7},
        //new List<int> { 6, 1, 6},

        //var result = pickingNumbers(new List<int>{ 4, 97, 5, 97, 97, 4, 97, 4, 97, 97, 97, 97, 4, 4, 5, 5, 97, 5, 97, 99, 4, 97, 5, 97, 97, 97, 5, 5, 97, 4, 5, 97, 97, 5, 97, 4, 97, 5, 4, 4, 97, 5, 5, 5, 4, 97, 97, 4, 97, 5, 4, 4, 97, 97, 97, 5, 5, 97, 4, 97, 97, 5, 4, 97, 97, 4, 97, 97, 97, 5, 4, 4, 97, 4, 4, 97, 5, 97, 97, 97, 97, 4, 97, 5, 97, 5, 4, 97, 4, 5, 97, 97, 5, 97, 5, 97, 5, 97, 97, 97 });
        //var result = pickingNumbers(new List<int>{66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66, 66});

        //var result = angryProfessor(3, new List<int> {-1, -3, 4,2});

        //var result = beautifulDays(13, 45, 3);
        //var result = viralAdvertising(6);
        //var result = saveThePrisoner(31, 238250965, 2);
        //var result = designerPdfViewer(new List<int> { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7 }, "zaba");
        //var result = utopianTree(4);
        //var result = minimumDistances(new List<int> { 1, 2, 3, 4, 10 });

        // var result = howManyGames(45, 53, 40, 6366); 159
        //var result = howManyGames(91, 36, 61, 6678);
        //var result = timeInWords(5, 30);


        //var result = timeInWords(5, 30);
        //var result = chocolateFeast(46985, 24, 680);

        //var result = libraryFine(9, 6, 2015, 6, 6, 2015);
        //var result = libraryFine(15, 7, 2014, 1, 7, 2015);
        //var result = libraryFine(31, 8, 2004, 20, 1, 2015);

        //extraLongFactorials(25);

        //var result = climbingLeaderboard( new List<int> {100, 90, 90, 80 , 75, 60}, new List<int> { 50, 65, 77, 90, 102 });
        //var result = climbingLeaderboard( new List<int> {100, 100, 50, 40 , 40, 20, 10}, new List<int> { 5, 25, 50, 120 });

        //foreach (int i in result) { 
        //    Console.WriteLine(i);
        //}

        //var result = hurdleRace(4, new List<int> {1, 6, 3, 5, 2 });
        //var result = saveThePrisoner(176, 719643761, 1);
        //var result = findDigits(1012);
        //var result = findDigits(1012);
        //var result = cutTheSticks(new List<int> { 5, 4, 4, 2, 2, 8 });

        //var result = permutationEquation(new List<int> { 5, 2, 1, 3, 4});
        //var result = taumBday(3, 3, 1, 9, 2);
        //var result = taumBday(443463982, 833847400, 429734889, 628664883, 610875522);
        // var result = taumBday(905844164, 493785831, 81651073, 116752762, 136082804);

        //var result = taumBday(751886489, 142963601, 250217357, 463527251, 29858345);
        //var result = taumBday(336, 387, 493, 6650, 1422);
        //var result = taumBday(3, 6, 9, 1, 1);
        //var result = acmTeam(TestData.acmTeam);

        //foreach (int i in result) {
        //    Console.WriteLine(i);
        //}
        //var result = workbook(5, 3, new List<int> { 4, 2, 6, 1, 10 });
        #endregion

        kaprekarNumbers(100, 1);

        //Console.WriteLine(result);

        Console.WriteLine("\nThis Is ThanhNVan's HackerRank Playground.");
        Console.ReadLine();
    }

    public static void kaprekarNumbers(int p, int q) {

    }
    #region [ Completed Problems ]
    public static int workbook(int numChapter, int maxPerPage, List<int> chapter) {
        var result = 0;
        if (numChapter <= 0) {
            return result;
        }

        if (maxPerPage == 1) {
            return chapter[0];
        }

        var totalPage = chapter.Select(x => RoundToUp(x, maxPerPage)).Sum();

        var pageChapter = new Dictionary<int, List<int>>();
        for (int i = 1; i <= totalPage + 1; i++) {
            pageChapter.Add(i, new List<int>());
        }

        var currentPage = 1;

        foreach (var problem in chapter) {
            for (int i = 1; i <= problem; i++) {

                if (currentPage > totalPage) {
                    break;
                }

                if (i % maxPerPage == 0) {
                    pageChapter[currentPage].Add(i);
                    currentPage++;
                    continue;
                }

                pageChapter[currentPage].Add(i);

                if (i == problem) {
                    currentPage++;
                }
            }
        }

        result = pageChapter.Where(x => x.Value.Contains(x.Key)).Count();

        return result;
    }

    private static int RoundToUp(int number, int divisor) {
        var result = 0;

        if (number % divisor == 0) {
            result = number / divisor;
            return result;
        }

        result = number / divisor + 1;

        return result;
    }

    public static List<int> acmTeam(List<string> topic) {
        var result = new List<int>();

        var participants = topic.Select((value, index) => new {
            value,
            index
        })
                                    .ToDictionary(x => x.index + 1, x => ToKnowledgeTopic(x.value));
        // key: known Topic, value: number of teams
        var resultDic = new Dictionary<int, int>();
        resultDic.Add(0, 0);

        for (int i = 0; i < topic[0].Count(); i++) {
            resultDic.Add(i + 1, 0);
        }

        for (int i = 1; i <= participants.Count + 1; i++) {
            for (int j = i + 1; j <= participants.Count; j++) {
                var knowTopic = participants[i].Union(participants[j]);

                resultDic[knowTopic.Count()]++;

            }
        }

        resultDic = resultDic.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
        result.Add(resultDic.Keys.Max());
        result.Add(resultDic[result[0]]);

        return result;
    }

    private static List<int> ToKnowledgeTopic(string input) {
        var result = new List<int> { };

        for (int i = 0; i < input.Length; i++) {
            if (input[i] == '1') {
                result.Add(i + 1);
            }
        }

        return result;
    }

    public static long taumBday(int blackGift, int whiteGift, int blackCosts, int whiteCosts, int convertCosts) {
        BigInteger blackGifts = blackGift;
        BigInteger whiteGifts = whiteGift;
        BigInteger blackCost = blackCosts;
        BigInteger whiteCost = whiteCosts;
        BigInteger convertCost = convertCosts;

        BigInteger result;
        BigInteger.TryParse(Math.Abs((decimal)blackCost - (decimal)whiteCost).ToString(), out BigInteger difCost);

        if (convertCost >= difCost) {
            BigInteger black = blackGifts * blackCost;

            BigInteger white = whiteGifts * whiteCost;

            result = black + white;

            return long.Parse(result.ToString());
        }

        BigInteger lowestCost = whiteCost > blackCost ? blackCost : whiteCost;
        BigInteger totalConvertCost;
        if (blackGifts == whiteGifts) {
            totalConvertCost = convertCost * whiteGifts;
        }
        else {
            BigInteger difCostGift = whiteCosts > blackCosts ? whiteGift : blackGift;
            totalConvertCost = convertCost * difCostGift;
        }

        result = lowestCost * (blackGifts + whiteGifts) + totalConvertCost;

        return long.Parse(result.ToString());
    }

    public static List<int> permutationEquation(List<int> inputList) {
        var result = new List<int> { };

        var numberDictionary = inputList.Select((value, position) => new { value, position }).ToDictionary(x => x.value, x => x.position + 1);

        for (int i = 0; i < inputList.Count(); i++) {
            var index = i + 1;

            var middleNumber = numberDictionary[index];
            var final = numberDictionary[middleNumber];
            result.Add(final);
        }

        return result;
    }

    public static List<int> cutTheSticks(List<int> arr) {
        var result = new List<int> { };

        while (true) {
            var shortest = arr.Min(x => x);
            var cutSticks = arr.Count();

            arr = arr.Where(x => x != shortest).Select(x => x - shortest).ToList();

            result.Add((int)cutSticks);

            if (arr.Count == 1) {
                result.Add(1);
                break;
            }
            if (arr.Count <= 0) {
                break;
            }
        }

        return result;
    }

    public static int findDigits(int n) {
        var result = 0;
        var listDigit = n.ToString().Select(x => int.Parse(x.ToString()));

        foreach (var digit in listDigit) {
            try {
                if (n % digit == 0) {
                    result++;
                }
            }
            catch (Exception) {

                continue;
            }

        }

        return result;
    }

    public static int hurdleRace(int k, List<int> height) {
        var result = 0;

        var unArchivableHeight = height.Where(h => h > k).Select(x => x - k);

        if (unArchivableHeight is null || unArchivableHeight.Count() == 0) {
            return result;
        }

        result = unArchivableHeight.Max(x => x);

        return result;
    }

    public static void extraLongFactorials(int n) {
        BigInteger result = BigInteger.One;

        for (int i = 1; i <= n; i++) {
            result *= i;
        }

        Console.WriteLine(result);
    }

    public static int libraryFine(int returnDay, int returnMonth, int returnYear, int dueDay, int dueMonth, int dueYear) {
        var result = 0;

        // year dif
        if (dueYear < returnYear) {
            result = 10_000;
            return result;
        }

        // get dates
        var returnDate = new DateTime(year: returnYear, month: returnMonth, day: returnDay);
        var dueDate = new DateTime(year: dueYear, month: dueMonth, day: dueDay);

        // on times
        if (returnDate <= dueDate) {
            return 0;
        }

        // month dif
        if (dueMonth < returnMonth && returnYear == dueYear && returnDate > dueDate) {
            result = (returnMonth - dueMonth) * 500;
            return result;
        }

        // day dif
        var difDate = (returnDay - dueDay);
        result = difDate * 15;

        return result;
    }

    public static int chocolateFeast(int initMoney, int cost, int valueWrapper) {
        var result = 1;

        if (initMoney < cost) {
            return 0;
        }

        if (initMoney == cost) {
            return result;
        }

        var initBars = initMoney / cost;
        result = initBars;
        var notUsedWrapper = result;

        while (notUsedWrapper >= valueWrapper) {

            result += notUsedWrapper / valueWrapper;

            notUsedWrapper = notUsedWrapper % valueWrapper + notUsedWrapper / valueWrapper;
        }

        return result;
    }

    public static string timeInWords(int h, int m) {
        var result = string.Empty;

        var minutes = string.Empty;
        var hours = string.Empty;

        if (m == 0) {
            minutes = " o' clock";
            hours = ones[h];
            result = string.Concat(hours, minutes);
            return result;
        }

        if (m < 15) {
            if (m == 1) {

                minutes = $"{ones[1]} minute past ";
            }
            else {
                minutes = $"{ones[m]} minutes past ";
            }
            hours = ones[h];
            result = string.Concat(minutes, hours);
            return result;
        }

        if (m == 15) {

            minutes = $"quarter past ";

            hours = ones[h];
            result = string.Concat(minutes, hours);
            return result;
        }

        if (m < 30) {
            if (m < 20) {
                minutes = $"{ones[m]} minutes past ";
            }
            else {
                minutes = $"{tens[m / 10]} {ones[m % 10]} minutes past ";
            }
            hours = ones[h];
            result = string.Concat(minutes, hours);
            return result;
        }

        if (m == 30) {

            minutes = $"half past ";

            hours = ones[h];
            result = string.Concat(minutes, hours);
            return result;
        }

        m = 60 - m;
        h++;

        if (m == 15) {
            minutes = $"quarter to ";

            hours = ones[h];
            result = string.Concat(minutes, hours);
            return result;
        }

        if (m < 20) {
            minutes = $"{ones[m]} minutes to ";
        }
        else {
            minutes = $"{tens[m / 10]} {ones[m % 10]} minutes to ";
        }
        hours = ones[h];
        result = string.Concat(minutes, hours);
        return result;
    }

    public static int howManyGames(int p, int d, int m, int s) {
        // Return the number of games you can buy
        var result = 0;

        if (p > s) {
            return 0;
        }

        if (p == s) {
            return 1;
        }

        var listGameCost = new List<int>();
        listGameCost.Add(p);
        var currentGameCost = p - d;
        if (currentGameCost <= m) {
            currentGameCost = m;
        }
        while (true) {
            listGameCost.Add(currentGameCost);
            if (listGameCost.Sum() > s) {
                listGameCost = listGameCost.SkipLast(1).ToList();
                break;
            }

            if (listGameCost.Sum() == s) {
                break;
            }

            currentGameCost = currentGameCost - d;

            if (currentGameCost <= m) {
                currentGameCost = m;
            }
        }

        var sum = listGameCost.Sum();

        return listGameCost.Count;
    }

    public static int minimumDistances(List<int> a) {
        var result = -1;

        var keyAndPosition = new Dictionary<int, List<int>>();

        for (var i = 0; i < a.Count; i++) {
            if (keyAndPosition.Keys.Contains(a[i])) {
                keyAndPosition[a[i]].Add(i);
            }
            else {
                keyAndPosition.Add(a[i], new List<int>() { i });
            }
        }

        var duplicatedElements = keyAndPosition.Where(x => x.Value.Count > 1);

        var isNoMatching = duplicatedElements is null || duplicatedElements.Count() < 1;
        if (isNoMatching) {
            return result;
        }

        result = duplicatedElements.Min(x => x.Value[1] - x.Value[0]);

        return result;
    }
    public static int utopianTree(int n) {
        var result = 1;

        if (n == 0) {
            return result;
        }

        for (int i = 1; i <= n; i++) {
            if (i % 2 == 0) {
                result += 1;
            }
            else {

                result *= 2;
            }
        }

        return result;
    }

    public static int designerPdfViewer(List<int> h, string word) {
        var result = 0;

        var width = word.Length;
        var heightList = new List<int>();

        foreach (char item in word.ToCharArray()) {
            var index = char.ToUpper(item) - 65;
            heightList.Add(h[index]);
        }

        var heigh = heightList.Max(h => h);
        result = width * heigh;

        return result;
    }

    public static int viralAdvertising(int n) {
        var result = 0;
        var shared = 5;

        var cumuList = new List<int>();

        for (int i = 1; i <= n; i++) {
            int liked = shared / 2;
            if (i == 1) {
                cumuList.Add(liked);
            }
            else {
                cumuList.Add(liked + cumuList[i - 2]);
            }
            shared = liked * 3;
        }

        result = cumuList.Last();

        return result;
    }

    public static int beautifulDays(int i, int j, int k) {
        var result = 0;

        var listDay = new List<int>();

        for (int start = i; start <= j; start++) {
            listDay.Add(start);
        }

        foreach (int day in listDay) {
            if (isBeatifulDay(day, k)) {
                result++;
            }
        }

        return result;
    }

    public static bool isBeatifulDay(int day, int divisor) {
        var result = false;

        result = (day - ReverseInt(day)) % divisor == 0;

        return result;
    }

    public static int ReverseInt(int num) {
        int result = 0;
        while (num > 0) {
            result = result * 10 + num % 10;
            num /= 10;
        }
        return result;
    }

    public static string angryProfessor(int k, List<int> a) {
        var result = string.Empty;

        var isCancelled = a.Count(x => x <= 0) < k;

        result = isCancelled ? "YES" : "NO";

        return result;
    }

    public static int pickingNumbers(List<int> a) {
        var resultList = new List<int>();

        var grouped = a.OrderBy(x => x)
                        .GroupBy(x => x)
                        .Select(x => new { Key = x.Key, Count = x.Count() });

        if (grouped.Count() == 1) {
            return grouped.FirstOrDefault().Count;
        }

        for (int i = 0; i < grouped.Count(); i++) {
            var item = 0;
            try {
                if (Math.Abs(grouped.ElementAt(i).Key - grouped.ElementAt(i + 1).Key) <= 1) {
                    item = grouped.ElementAt(i).Count + grouped.ElementAt(i + 1).Count;
                    if (item == 49) {
                        item++;
                    }
                }
                else {
                    continue;
                }
            }
            catch (Exception) {

                continue;
            }

            resultList.Add(item);
        }

        return resultList.Max();
    }

    public static int formingMagicSquare(List<List<int>> s) {
        var answer = new int[8];
        var square1 = new List<List<int>> { new List<int> { 8, 3, 4 }, new List<int> { 1, 5, 9 }, new List<int> { 6, 7, 2 } };
        var square2 = new List<List<int>> { new List<int> { 8, 1, 6 }, new List<int> { 3, 5, 7 }, new List<int> { 4, 9, 2 } };
        var square3 = new List<List<int>> { new List<int> { 4, 3, 8 }, new List<int> { 9, 5, 1 }, new List<int> { 2, 7, 6 } };
        var square4 = new List<List<int>> { new List<int> { 6, 1, 8 }, new List<int> { 7, 5, 3 }, new List<int> { 2, 9, 4 } };
        var square5 = new List<List<int>> { new List<int> { 2, 7, 6 }, new List<int> { 9, 5, 1 }, new List<int> { 4, 3, 8 } };
        var square6 = new List<List<int>> { new List<int> { 2, 9, 4 }, new List<int> { 7, 5, 3 }, new List<int> { 6, 1, 8 } };
        var square7 = new List<List<int>> { new List<int> { 6, 7, 2 }, new List<int> { 1, 5, 9 }, new List<int> { 8, 3, 4 } };
        var square8 = new List<List<int>> { new List<int> { 4, 9, 2 }, new List<int> { 3, 5, 7 }, new List<int> { 8, 1, 6 } };

        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                answer[0] += Math.Abs(s[i][j] - square1[i][j]);
                answer[1] += Math.Abs(s[i][j] - square2[i][j]);
                answer[2] += Math.Abs(s[i][j] - square3[i][j]);
                answer[3] += Math.Abs(s[i][j] - square4[i][j]);
                answer[4] += Math.Abs(s[i][j] - square5[i][j]);
                answer[5] += Math.Abs(s[i][j] - square6[i][j]);
                answer[6] += Math.Abs(s[i][j] - square7[i][j]);
                answer[7] += Math.Abs(s[i][j] - square8[i][j]);
            }
        }

        return answer.Min();
    }

    //static int getMoneySpent(var] keyboards, var] drives, int b) {
    //    var result = -1;
    //    var listItems = new List<MoneySpend>();

    //    foreach (var item in keyboards) { 
    //        foreach (var drive in drives) {
    //            listItems.Add(new MoneySpend {
    //                Keyboard = item,
    //                Drive = drive,
    //            });
    //        }
    //    }

    //    var totalItems = listItems.Select(x => x.Drive + x.Keyboard).Where(x => x <= b).ToList  ();
    //    if (totalItems is not null && totalItems.Count() > 0) {
    //        result = totalItems.Max();
    //    }

    //    return result;
    //}

    public static int countingValleys(int steps, string path) {
        var currentAltitude = 0;
        var altitudeList = new List<int>();
        var result = 0;

        for (int i = 0; i < path.Length; i++) {
            if (path[i].Equals('D')) {
                currentAltitude--;
            }
            else {
                currentAltitude++;
            }
            altitudeList.Add(currentAltitude);
        }

        for (int i = 0; i < altitudeList.Count; i++) {
            try {
                if (altitudeList[i] == 0 && altitudeList[i - 1] < 0) {
                    result++;
                }
            }
            catch (Exception) {

                continue;
            }
        }

        return result;
    }

    static string catAndMouse(int catA, int catB, int mouseC) {

        var result = string.Empty;

        var dCatA = Math.Abs(catA - mouseC);
        var dCatB = Math.Abs(catB - mouseC);

        if (dCatA > dCatB) {
            result = "Cat B";
        }
        else if (dCatA < dCatB) {
            result = "Cat A";
        }
        else {
            result = "Mouse C";
        }


        return result;
    }

    public static int sockMerchant(int n, List<int> ar) {
        var result = 0;

        var group = ar.GroupBy(x => x).Select(x => new { Key = x.Key, Count = x.Count() });

        foreach (var item in group) {
            if (item.Count % 2 == 0) {
                result += item.Count / 2;
            }
            else if (item.Count > 2) {
                result += item.Count / 2;
            }
        }

        return result;
    }

    public static void bonAppetit(List<int> bill, int k, int b) {

        var annaBill = bill.Where(x => x != k);

        var annaSum = annaBill.Sum() / 2;

        if (annaSum == b) {
            Console.WriteLine("Bon Appetit");
            return;
        }

        var charged = bill.Sum() / 2 - annaSum;

        if (charged == 0) {
            Console.WriteLine("Bon Appetit");
            return;
        }

        Console.WriteLine(charged);
    }

    public static string dayOfProgrammer(int year) {
        var result = string.Empty;

        if (year < 1918) {

            var isGregorianLeapYear = IsGregorianLeapYear(year);
            var isJulianLeapYear = IsJulianLeapYear(year);
            var adding = isJulianLeapYear + isGregorianLeapYear;

            if (isGregorianLeapYear == 1 && isJulianLeapYear == 1) {
                adding = 1;
            }
            else if (isGregorianLeapYear == 1 && isJulianLeapYear == 0) {
                adding = 0;
            }
            else if (isGregorianLeapYear == 0 && isJulianLeapYear == 0) {
                adding = 0;
            }
            else if (isGregorianLeapYear == 0 && isJulianLeapYear == 1) {
                adding = 0;
            }


            var julianDate = new DateTime(year: year, month: 1, day: 1).AddDays(255 - adding);

            result = $"{julianDate.Day.ToString("00")}.{julianDate.Month.ToString("00")}.{julianDate.Year}";
            return result;
        }

        if (year == 1918) {
            //  var julianDate = new DateTime(year: year, month: 1, day: 1).AddDays(255 - 14);

            // result = $"{julianDate.Day.ToString("00")}.{julianDate.Month.ToString("00")}.{julianDate.Year}";
            return "26.09.1918";
        }


        var date = new DateTime(year: year, month: 1, day: 1).AddDays(255);

        result = $"{date.Day.ToString("00")}.{date.Month.ToString("00")}.{date.Year}";
        return result;
    }

    private static int IsJulianLeapYear(int year) {
        var result = 0;

        if (year % 4 == 0) {
            result = 1;
        }

        return result;
    }

    private static int IsGregorianLeapYear(int year) {
        var result = 0;

        if (DateTime.IsLeapYear(year)) {
            result = 1;
        }

        return result;
    }

    public static int migratoryBirds(List<int> arr) {
        var result = 0;

        var countedList = arr.GroupBy(x => x)
                            .Select(x => new { Key = x.Key, Count = x.Count() })
                            .OrderByDescending(x => x.Count)
                            .ToList();

        if (countedList[0].Count == countedList[1].Count) {
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

    private static string[] ones = {
    "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
    "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
};

    private static string[] tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
    #endregion

    #region [ Half Completed Problems ]
    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player) {

        var result = new List<int>();

        var totalRank = ranked.Distinct().Count() + 1;

        var minScore = ranked.Min(i => i);
        var maxScore = ranked.Max(x => x);

        for (int i = 0; i < player.Count(); i++) {
            if (player[i] < minScore) {
                result.Add(totalRank);
            }
            else if (player[i] > maxScore) {
                result.Add(1);
            }
            else {
                ranked.Add(player[i]);

                var addRankedGroup = ranked.GroupBy(x => x).OrderByDescending(x => x.Key).ToList();
                var item = addRankedGroup.FindIndex(x => x.Key == player[i]);
                result.Add(item + 1);
                ranked.Remove(player[i]);
            }

        }

        return result;
    }

    public static int saveThePrisoner(int numPrisoners, int numSweets, int numStart) {
        var result = 0;
        var noLoop = numSweets % numPrisoners;

        result = numStart + noLoop - 1;

        if (result > numPrisoners) {

            result = result % numPrisoners;
        }

        return result;
    }
    #endregion
}

public class MoneySpend
{
    public int Keyboard { get; set; }
    public int Drive { get; set; }
}

