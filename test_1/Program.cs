using BenchmarkDotNet.Attributes;
using System.Text;
using Microsoft.Diagnostics.Tracing.Etlx;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace Prep
{

    public class Kata
    {
        private readonly List<string> _grid = new List<string> {
            "fxaiiapeexfykzmwkhzfezguwlsfwdgdbgvfrwudbxopqrvq",
"zoubrcpjiiumrmnyzygrrvxwyootzvkktnodxtgiavysnhyc",
"payxqkuusdqzilemhmbyiashuqsuftctjphplpvjlvhcetsr",
"etxyjpzdnuqmeucqwlxziorzvsbfdfarspsipnvcymzbmrzd",
"ulyejkxprqqullpweuessprhtqiavfvdmgxmlfemdtxwetjr",
"xqxxyhgjxwsgrgpdosmqcagyrqyauxjxamouftxfrnpumpsf",
"jvebibzicqdrydiimxohfjruconalxyclhfplwbzthdeyege",
"xbjiddimvgywcuhetgeilkralnvibfwbdpkebkeuipvlabxc",
"cofbxukuxousfuognsujnqxyswycxyotpzdreoelnnkmlrzz",
"wictdbdgddyspblvxwkcwiwocwazwifdsmeawqvscvpnhyyk",
"gdfcagizdjqrlpnprpubdsziknwdrzbdshkzizzgdnqhkhsm",
"bugfqttcyaesppoagpalfkzsbplsxmvjqbqiuboztjotbrim",
"mzwzfqgprjcdsvwpmdokrcejrbciqgyzzbouwpwmruobbfyy",
"mdcrsnwdxubgzvmedqoziwhafmzrogbxpzdbcfgvdwyzowoj",
"jourxvdpumbanuikywklqdqbserttbzgdddysdudcrmyfuoa",
"azpdnkraczmwvxrgsptftvhyvwsvtpyatqzxeuzcsafifvdv",
"stspifzwxmrwgexiillhgpqwvnqhflkybbpwnpthnytglwrn",
"zwukrszjcrygfdmfgnfzbtkgvrqfcimkscswudzndgbevkmy",
"phmpmtgbtkmdyrnzocroqbifgkbwawctqzjqsllqxhjrxnzb",
"uxqptljwkpwpucvdvubyqeooxdrlhjdnirrjegmrzxdokxgi",
"jxtsovczgznnrekgoijruepckddbgmlfqhmcbcjdidenokvx",
"diihdbnyuokymosfkgaoycxdyxayhrkqxvazgcbwwbptnplg",
"nbgihonlviucdrqeuymwmufnohagqzvomydnrmljvzuawfbs",
"xwvxhjopjxcbppehvhpmrdtsxagxuuqalfqueaefqpdrrshz",
"yjtlwygqmbusjfsxjpgwvnqixbtcempyegaenpgmsiutcvfk",
"zsweioyvijtleokqqiytlstxdeftptiiyuyedcluoctvmlfs",
"ejosditxwihdfwlpbgsxzjvhqqkxuwlegeueylcsmvlyzneg",
"zhwupmflvifkpoimthfkvnidfbtgumnvcxcjwqmevvlfhauw",
"kpsynsrccextzfyhtqxstrcbizxhciziycdmyooyjdufhpzo",
"drvbalodlnxxkqanhzchjsysihijfwtrutypykwxfhwyodit",
"mrzmttxlouhvmbxufqkzaksilmfickcmgjghhvibqbxatqpu",
"agchidondwxdpqooslrkffjpydihlvrlaeeqoesbpkgvcmia",
"ychtdwjuohipfhedicdlqbmybzddzbxedtcrurudngmyhdzc",
"hrvbfehdommkkfmfdicfikwuunqtnxcpumljclituvjtuccu",
"bcngfgwucpmwkivmazobryzhasrlbwicbuldabdwosxevjld",
"zfcvgauzmslnqmujludtinfcpedudvwypfiwwjssrjsqsxwl",
"qvykoqmqexqftekkstzpiadayggeuohtywzhnntcjdnugdzv",
"pzpfgmjesbpxaukezzyzbtgdkihcnlnotvgwewefuroopciq",
"eozirppdgjxmqyrdxxjejltbetrhcmljnvukvcyphvdabgat",
"kvgpdgbtozemvymrwhkkrafigdbqqrnhipzpatutgzhcynhw",
"mokcfkkeautaqvgbpgqkuggwitvtagmxhgyoopqpzqlxqrev",
"ammrmkafjbejyklfnsqkimzktstpzqfbgrggekenybtxdxqs",
"dlknatvsmaxfqkphsbhxsrlifeokasicbeqfwpogstveydpr",
"odsifnjreepwlxlpszgjnbwvricyoflzskxdvbvkjppckfov",
"hpbpwqzmbetdjkrfbrhasjceebntlzuitigbwnivghalvsvi",
"kgtvleesyfjcnnpochdulppmrnkidhhlqxhaogokfinrvfgb",
"wozegqhukxubthgxlscpxqpnuposurgzmwgvrlehmhjpqpdz",
"dqfqagxzljslpteheprboaddbflywaferhpwxpalzmekaksp"};



        // Return the minimum number of characters to make the password strong
        public int minimumNumber(int n, string password)
        {
            var minLength = 6;
            var noOfCharsToAdd = 0;
            if (!"0123456789".ToCharArray()
                             .Intersect(password.ToCharArray())
                             .Any()) noOfCharsToAdd++;
            if (!"abcdefghijklmnopqrstuvwxyz".ToCharArray()
                                             .Intersect(password.ToCharArray())
                                             .Any()) noOfCharsToAdd++;
            if (!"ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()
                                             .Intersect(password.ToCharArray())
                                             .Any()) noOfCharsToAdd++;
            if (!"!@#$%^&*()-+".ToCharArray()
                               .Intersect(password.ToCharArray())
                               .Any()) noOfCharsToAdd++;
            return (n < minLength) ? Math.Max(noOfCharsToAdd, minLength - n) : noOfCharsToAdd;
        }

        public List<int> dynamicArray(int n, List<List<int>> queries)
        {
            var answers = new List<int>();
            var arr = new List<List<int>>();
            Enumerable.Range(0, n).ToList().ForEach(i => arr.Add(new List<int>() { }));
            int lastAnswer = 0;
            for (int i = 0; i < queries.Count; i++)
            {
                if (queries[i][0] == 1)
                {
                    var idx = (queries[i][1] ^ lastAnswer) % n;
                    arr[idx].Add(queries[i][2]);
                }
                else
                {
                    var idx = (queries[i][1] ^ lastAnswer) % n;
                    lastAnswer = arr[idx][(queries[i][2] % arr[idx].Count)];
                    answers.Add(lastAnswer);
                }
            }
            return answers;
        }

        public int GetFactorCount(int numberToCheck)
        {
            int factorCount = 0;
            int sqrt = (int)Math.Ceiling(Math.Sqrt(numberToCheck));

            // Start from 1 as we want our method to also work when numberToCheck is 0 or 1.
            for (int i = 1; i < sqrt; i++)
            {
                if (numberToCheck % i == 0)
                {
                    factorCount += 2; //  We found a pair of factors.
                }
            }

            // Check if our number is an exact square.
            if (sqrt * sqrt == numberToCheck)
            {
                factorCount++;
            }

            return factorCount;
        }

        //arr: missing elements array
        //brr: source array
        //return missing elementss
        //The most important constraint is max(brr) - min(brr) <= 100
        //
        public List<int> missingNumbers(List<int> arr, List<int> brr)
        {
            var res = new List<int>();
            int min = brr.Min();
            int[] marks = new int[101];
            foreach (int a in arr) marks[a - min]--;
            foreach (int b in brr) marks[b - min]++;

            for (int i = 0; i < 101; i++)
            {
                if (marks[i] > 0) res.Add(min + i);
            }
            return res;

            // Long Solution
            //var res = brr.Except(arr).ToList();
            //var arrCounts = new Dictionary<int, int>();
            //var brrCounts = new Dictionary<int, int>();
            //for (int i = 0; i < arr.Count; i++)
            //{
            //    arrCounts[arr[i]] = arrCounts.ContainsKey(arr[i]) ? arrCounts[arr[i]] + 1 : 1;
            //}
            //for (int i = 0; i < brr.Count; i++)
            //{
            //    brrCounts[brr[i]] = brrCounts.ContainsKey(brr[i]) ? brrCounts[brr[i]] + 1 : 1;
            //}
            //foreach (var brrCount in brrCounts)
            //{
            //    if (arrCounts.TryGetValue(brrCount.Key, out int arrValue))
            //    {
            //        if (arrValue != brrCount.Value)
            //        {
            //            res.Add(brrCount.Key);
            //        }
            //    }
            //    else
            //    {
            //        res.Add(brrCount.Key);
            //    }
            //}
            //res.Sort();
            //return res.Distinct().ToList();
        }

        public void countSort(string[,] arr)
        {
            int count = arr.Length;
            int mid = count / 2;
            var res = new string[count][];
            for (int i = 0; i < count - 1; i++)
            {
                var index = int.Parse(arr[i, 0]);
                if (i + 1 <= mid)
                {
                    res[index] = res[index] == null ? new string[] { "-" } : res[index].Append("-").ToArray();
                }
                else
                {
                    res[index] = res[index] == null ? new string[] { arr[i, 1] } : res[index].Append(arr[i, 1]).ToArray();
                }
            }
            res.Where(re => re != null).SelectMany(re => re).ToList().ForEach(str => Console.Write(str + " "));


            //best approach
            var arrangedDict = new StringBuilder[arr.Length];
            for (int i = 0; i < (arr.Length / 2); i++)
            {
                arr[i, 1] = "-";
            }

            var maxIndex = Convert.ToInt32(arr[0, 0]);
            for (int i = 0; i < arr.Length; i++)
            {
                var strIndexConverted = Convert.ToInt32(arr[i, 0]);
                if (arrangedDict[strIndexConverted] == null)
                    arrangedDict[strIndexConverted] = new StringBuilder(arr[i, 1]);
                else
                    arrangedDict[strIndexConverted].Append(" " + arr[i, 1]);

                if (strIndexConverted > maxIndex)
                    maxIndex = strIndexConverted;
            }

            for (int i = 0; i <= maxIndex; i++)
            {
                if (arrangedDict[i] != null)
                {
                    Console.Write(arrangedDict[i].ToString() + " ");
                }
            }
        }

        [Benchmark]
        public string gridChallenge()
        {
            var rows = _grid.Count;
            var cols = _grid.Max().Length;
            var arr = new char[rows, cols];
            for (int i = 0; i < _grid.Count; i++)
            {
                var chars = _grid[i].ToCharArray();
                Array.Sort(chars);
                for (int j = 0; j < chars.Length; j++)
                {
                    arr[i, j] = chars[j];
                }
            }
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < row - 1; row++)
                {
                    if (arr[row, col] > arr[row + 1, col])
                        return "NO";
                }
            }
            return "YES";
        }

        [Benchmark]
        public string gridChallenge1()
        {
            var list = new List<char[]>();
            for (int i = 0; i < _grid.Count; i++)
            {
                char[] chars = _grid[i].ToCharArray();
                Array.Sort(chars);
                list.Add(chars);
            }
            int cols = list[0].Length;
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < list.Count - 1; row++)
                {
                    if (list[row][col] > list[row + 1][col])
                        return "NO";
                }
            }
            return "YES";
        }
        /*
         * If you are stuck and looking for some hints & clarity, welcome)

First, let's recall XOR properties - it's crucial that you understand these two rules:

XOR of two identical numbers is 0:
001^001 = 000
XOR is not ordering-sensible, so we can omit parentheses:
(001^101)^111 = 001^101^111
We have many variations of subarrays but the values are all the same. If a value appears even number of times, the result of XOR will be zero:

7 ^ 7 ^ 7 ^ 7 = 0
If the number of occurences is odd, the result of XOR is, well, the value:

7 ^ 7 ^ 7 = 7
Now it's time to ask the main question: for every element in the array, does it appear even number of times or odd? Is there any pattern?

Answer: yes, there is.

Consider the array [1, 2, 3, 4, 5]. A contiguous subarray can be of any length from 1 to 5:

[1] [2] [3] [4] [5]

[1, 2] [2, 3] [3, 4] [4, 5]

[1, 2, 3] [2, 3, 4] [3, 4, 5]

[1, 2, 3, 4] [2, 3, 4, 5]

[1, 2, 3, 4, 5]
Let's count occurrences:

Array values:   1 2 3 4 5
Times seen:     5 8 9 8 5
The Times seen metric is symmetrical and correlates with element indices. Notice that odd indices (starting with 1, not 0) like 1,3,5 occur odd number of times. Indices 2,4 are encountered even number of times.

Another array consists of an even number of elements:

[1] [2] [3] [4]

[1, 2] [2, 3] [3, 4]

[1, 2, 3] [2, 3, 4]

[1, 2, 3, 4]
Metric:

Array values:   1 2 3 4
Times seen:     4 6 6 4
Applying XOR to every element gives us 0.

If you play around with different initial arrays, you'll notice this thing:

every array with an even number of elements results in 0 because each element appears even number of times

every array with an odd number of elements results in XORing the values at odd indices because, again, even-indexed elements show up even number of times
         */
        public static int sansaXor(List<int> arr)
        {
            int ans = 0;
            if (arr.Count % 2 == 0)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < arr.Count; i += 2)
                {
                    ans ^= arr[i];
                }
            }
            return ans;
        }

        public static ulong fibonacci_modified(ulong t1, ulong t2, int n)
        {
            int i = 2;
            while (i < n)
            {
                (t1, t2) = (t2, t1 + t2 * t2);
                i += 1;
            }
            return t2;
        }


        public static string balancedSums(List<int> arr)
        {
            //if(arr.Count ==1)
            //{
            //    return "YES";
            //}
            //for (int i = 0; i < arr.Count; i++)
            //{
            //    if(arr.Take(i).Sum() == arr.Skip(i+1).Sum())
            //    {
            //        return "YES";
            //    }
            //}
            //return "NO";

            // better time complexity
            /*
             complete in linear time aka O(n). We first define the initial right and left sides of the array, and add and remove elements respectively as we shift our "middle element" through the array: 
            */
            if (arr.Count == 1) return "YES";
            long left = 0;
            long right = arr.GetRange(1, arr.Count - 1).Sum();
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (right == left) return "YES";
                right -= arr[i + 1];
                left += arr[i];
            }
            return "NO";
        }

        public static string misereNim(List<int> s)
        {
            int sum = s.Aggregate((a, b) => a + b);
            if (sum == s.Count)
            {
                return s.Count % 2 == 0 ? "First" : "Second";
            }

            int nimSum = s.Aggregate((a, b) => a ^ b);
            return nimSum == 0 ? "Second" : "First";
        }

        public static string gamingArray(List<int> arr)
        {
            var max = 0;
            return arr.Aggregate((c, v) =>
            {
                if (v <= max) return c;
                max = v;
                return c + 1;
            }) % 2 == 0 ? "ANDY" : "BOB";
        }

        public static int formingMagicSquare(List<List<int>> s)
        {
            List<int> cst = Enumerable.Repeat(0, 8).ToList();
            List<List<int>> magic = new List<List<int>>{
                new List<int>{ 6,1,8},
                new List<int>{ 7,5,3},
                new List<int>{ 2,9,4},
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cst[0] += Math.Abs(s[i][j] - magic[i][j]);
                    cst[1] += Math.Abs(s[i][j] - magic[i][2 - j]);
                    cst[2] += Math.Abs(s[i][j] - magic[2 - i][2 - j]);
                    cst[3] += Math.Abs(s[i][j] - magic[2 - i][j]);
                    cst[4] += Math.Abs(s[i][j] - magic[j][i]);
                    cst[5] += Math.Abs(s[i][j] - magic[j][2 - i]);
                    cst[6] += Math.Abs(s[i][j] - magic[2 - j][2 - i]);
                    cst[7] += Math.Abs(s[i][j] - magic[2 - j][i]);
                }
            }
            return cst.Min();
        }

        public static int superDigit(string n, int k)
        {
            // int l = n.Select(c => int.Parse(c.ToString())).Sum();
            // if (l % 10 != l || k != 1)
            // {
            //     l = l * k;
            //     return Kata.superDigit(l.ToString(), 1);
            // }
            // else
            // {
            //     return l;
            // }

            //optimized solution

            var sum = 0;
            for (int i = 0; i < n.Length; i++)
            {
                sum += n[i] - '0';
            }
            if (sum < 10)
            {
                if (sum * k < 10) return sum * k;
                return superDigit((sum * k).ToString(), 1);
            }
            return superDigit(sum.ToString(), k);
        }

        public static string counterGame(long n)
        {
            var count = 0;
            if (n == 1) return "Richard";
            while (n > 1)
            {
                if (bIsPowerOf2(n))
                {
                    count += 1;
                    n /= 2;
                }
                else
                {
                    count += 1;
                    n -= (long)Math.Pow(2, bLog2(n));
                }
            }
            return count % 2 == 1 ? "Louise" : "Richard";
        }

        public static int bSum(int a, int b)
        {
            return a | b + a & b;
        }
        public static int bMul2(int n)
        {
            return n << 1;
        }
        public static int bDiv2(int n)
        {
            return n >> 1;
        }

        public static bool bIsOdd(int n)
        {
            return (n & 1) > 0;
        }

        public static bool bIsEven(int n)
        {
            return (n & 1) == 0;
        }

        public static string bIsOddOrEven(int n)
        {
            return (n & 1) > 0 ? "Odd" : "Even";
        }

        public static int bitSet(int num, int pos) // set means turn bit to 1
        {
            int bit = 1 << pos; // left shift '1' to position to form a int
            num = num | bit; // add num with bit to get the bit in the num at pos
            return num;
        }
        
        public static int bitUnSet(int num, int pos) // set means turn bit to 0
        {
            int bit = ~(1 << pos);
            num = num & bit;
            return num;
        }

        public static int bitToggle(int num, int pos) // turn 1 to 0 or 0 to 1
        {
            int bit = 1 << pos;
            num = num ^ bit;
            return num;
        }

        public static bool isBitSet(int num, int pos)// check if 1 in pos
        {
            int bit = 1 << pos;
            return (num & bit) == bit; // return bit, if there's 1 in pos, else & operation returns 0
        }

        public static int bitAllInvert(int num)
        {
            return ~num; // also called 1's compliment of number
        }

        public static int bitTwosCompliment(int num)// which is (onesCompliment + 1), and also equal to -num
        {
            int onesCompliment = ~num;
            int twosCompliment = onesCompliment + 1;
            return twosCompliment; // equals to -num;
        }

        public static int stripLowestSetBit(int num)// 
        {
            int bit = num - 1;//inverts all except lowest set 1
            int afterLowestBitStripped = num & bit;//the lowest bit stripped
            return afterLowestBitStripped;
        }

        public static int getLowestSetBit(int num)
        {
            int twosCompliment = -num;
            int lowestSetBit = num & twosCompliment;
            return lowestSetBit;
        }

        public static char bToLower(char upperCase)
        {
            char mask = ' ';
            int lowerCase = upperCase | mask;
            return Convert.ToChar(lowerCase);
        }

        public static char bToupper(char lowerCase)
        {
            char mask = '_';
            int upperCase = lowerCase & mask;
            return Convert.ToChar(upperCase);
        }

        public static int bNoOfSetBits(int num)
        {
            int count = 0;
            while (num > 0)
            {
                num = num & (num - 1);
                count++;
            }
            return count;
        }

        public static int bLog2(int num)
        {
            int res = 0;
            while ((num >>= 1) > 0)
            {
                res++;
            }
            return res;
        }

        public static long bLog2(long num)
        {
            long res = 0;
            while ((num >>= 1) > 0)
            {
                res++;
            }
            return res;
        }

        public static bool bIsPowerOf2(int num)
        {
            return (num & (num - 1)) == 0;
        }

        public static bool bIsPowerOf2(long num)
        {
            return (num & (num - 1)) == 0;
        }

        public static int bIndexOfLastSetBit(int num)
        {
            return bLog2(num & -num) + 1;
        }

        public static long bPower(long a, long n)
        {
            long ans = 1;
            while (n > 0)
            {
                var last_bit = n & 1;
                if(last_bit >0)
                {
                    ans = ans * a;
                }
                a = a * a;
                n = n >> 1;
            }
            return ans;
        }

        public static long bPow2(int n)
        {
            return 1 << n;
        }

        public static long sumXor(long n)
        {
            if (n == 0) return 1;

            int zeroCount = 0;
            var binary = Convert.ToString(n, 2);
            for (var i = 0; i < binary.Length; i++)
            {
                if (binary.ElementAt(i) == '0')
                {
                    zeroCount++;
                }
            }
            long res1 = bPower(2, zeroCount);
            long res2 = bPow2(zeroCount);
            return res1;
            return 1 << zeroCount;
        }

        private static bool isPalindrome(string s, int start, int end)
        {
            while (start < end && s[start] == s[end])
            {
                start++;
                end--;
            }
            return start >= end;
        }

        /*
         * By first checking whether the original string is a palindrome you can find the spot where it fails, which leaves you with just 2 possibilities for deletion. 
         * So you would only need to try those two. 
         * Moreover, you don't actually have to perform the deletion. 
         * You can just skip the concerned character and continue the palindrome check by skipping the corresponding index.
         */
        public static int palindromeIndex(string s)
        {
            int start = 0;
            int end = s.Length - 1;
            while (start < end && s[start] == s[end])
            {
                start++;
                end--;
            }
            if (start >= end) return -1; // already a palindrome
            // We need to delete here
            if (isPalindrome(s, start + 1, end)) return start;
            if (isPalindrome(s, start, end - 1)) return end;
            return -1;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Kata kata = new Kata();

            #region commented code
            //GC.Collect();

            //var results = dynamicArray(15, new List<List<int>>()
            //{
            //    new List<int>(){1, 345255357, 205970905},
            //    new List<int>(){1 ,570256166, 75865401},
            //    new List<int>(){1 ,94777800 ,645102173},
            //    new List<int>(){1 ,227496730, 16649450},
            //    new List<int>(){1 ,82987157 ,486734305},
            //    new List<int>(){1 ,917920354, 757848208},
            //    new List<int>(){1 ,61379773 ,817694251},
            //    new List<int>(){1 ,330547128, 112869154},
            //    new List<int>(){1 ,328743001, 855677723},
            //    new List<int>(){1 ,407951306, 669798718},
            //    new List<int>(){1 ,21506172 ,676980108},
            //    new List<int>(){1 ,49911390 ,342109400},
            //    new List<int>(){1 ,980306253, 305632965},
            //    new List<int>(){2 ,736380701, 402184046},
            //    new List<int>(){2 ,798108301, 416334323}
            //});
            //var expectedResults = new List<int>()
            //{
            //    630088560,
            //    409348168,
            //    911717531,
            //    65845102,
            //    628337854,
            //    905134312,
            //    347118559,
            //    294233165,
            //    911127056,
            //    894638424,
            //    24916071,
            //    99373047,
            //    316312665,
            //    62879769,
            //    46640814
            //};

            //Console.WriteLine(minimumNumber(3, "Ab1"));
            //Console.WriteLine(minimumNumber(11, "#HackerRank"));


            //var res = missingNumbers(new List<int>() { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206 }, new List<int>() { 203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204 });

            //countSort(new string[,]
            //    {
            //        {"0", "ab"},
            //        {"6", "cd"},
            //        {"0", "ef"},
            //        {"6", "gh"},
            //        {"4", "ij"},
            //        {"0", "ab"},
            //        {"6", "cd"},
            //        {"0", "ef"},
            //        {"6", "gh"},
            //        {"0", "ij"},
            //        {"4", "that"},
            //        {"3", "be"},
            //        {"0", "to"},
            //        {"1", "be"},
            //        {"5", "question"},
            //        {"1", "or"},
            //        {"2", "not"},
            //        {"4", "is"},
            //        {"2", "to"},
            //        {"4", "the"}
            //    });


            //char omegaSymbol = '\u03A9';
            //ushort unShort = omegaSymbol;
            //Console.WriteLine(unShort);
            //Console.WriteLine("Hello, World!\f11");
            //Console.WriteLine("Hello, World!");

            //char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            //char lastElement = vowels[vowels.Length - 1];
            //Console.WriteLine(lastElement);
            //lastElement = vowels[^1];
            //Console.WriteLine(lastElement);

            //Index index = new Index(1, true);
            //Console.WriteLine(vowels[index]);

            //Range firstTwoRange = 0..2;
            //char[] firstTwo = vowels[firstTwoRange];
            //firstTwo.ToList().ForEach(Console.Write);

            //int[,] matrix = new int[3, 3];
            //List<int>[,] twoDArrayOfListsOfInt = new List<int>[3, 3]
            //{
            //    { new List<int>{ 1, 2, 3 }, new List<int>{ 1, 2, 3 }, new List<int>{ 1, 2, 3 }},
            //    { new List<int>{ 1, 2, 3 }, new List<int>{ 1, 2, 3 }, new List<int>{ 1, 2, 3 }},
            //    { new List<int>{ 1, 2, 3 }, new List<int>{ 1, 2, 3 }, new List<int>{ 1, 2, 3 }}
            //};

            //char defaultChar = default;
            //Console.WriteLine(defaultChar);


            //int[] numbers = { 0, 1, 2, 3, 4 };
            //ref int numRef = ref numbers[2];
            //numRef = numbers[1];
            //numbers.ToList().ForEach(Console.Write);



            //Console.WriteLine(gridChallenge(new List<string>() { "ebacd", "fghij", "olmkn", "trpqs", "xywuv" }));

            //Console.WriteLine(gridChallenge(new List<string>() { "hcd", "awc", "shm" }));
            //Console.WriteLine(gridChallenge(new List<string>() { "sur", "eyy", "gxy" }));
            //Console.WriteLine(gridChallenge(new List<string>() { "nyx", "ynx", "xyt" }));
            //Console.WriteLine(gridChallenge(new List<string>() { "vpvv", "pvvv", "vzzp", "zzyy" }));

            //Console.WriteLine();

            //Console.WriteLine(kata.gridChallenge(new List<string>() { "abc", "lmp", "qrt" }));
            //Console.WriteLine(kata.gridChallenge(new List<string>() { "mpxz", "abcd", "wlmf" }));
            //Console.WriteLine(kata.gridChallenge(new List<string>() { "abc", "hjk", "mpq", "rtv" }));


            //Console.WriteLine(kata.gridChallenge());

            //var summary = BenchmarkRunner.Run(typeof(Program).Assembly);


            //Console.WriteLine(Kata.sansaXor(new List<int>() { 4, 5, 6, 7, 8, 9 }));

            //Console.WriteLine(Kata.misereNim(new List<int>() { 2, 8, 3 }));
            //Console.WriteLine(Kata.formingMagicSquare(new List<List<int>>() { new List<int> { 4,9,2}, new List<int> { 3,5,7}, new List<int> { 8,1,5} }));

            //Console.WriteLine(Kata.superDigit("123", 3));
            // int res = Kata.bSum(32, 18);
            // Console.WriteLine(res == 50);
            // Console.WriteLine(Kata.bMul2(4) ==8);
            // Console.WriteLine(Kata.bDiv2(4) ==2);
            // Console.WriteLine(Kata.bIsEven(4));
            // Console.WriteLine(Kata.bIsOdd(5));
            // Console.WriteLine(Kata.bIsOddOrEven(9));
            //Console.WriteLine(Kata.stripLowestSetBit(7));

            //Console.WriteLine(Kata.counterGame(132));

            // Console.WriteLine(Kata.sumXor(1099511627776));
            #endregion

            Console.WriteLine(Kata.palindromeIndex("quyjjdcgsvvsgcdjjyq"));
            Console.WriteLine(Kata.palindromeIndex("hgygsvlfwcwnswtuhmyaljkqlqjjqlqkjlaymhutwsnwcflvsgygh"));
            Console.WriteLine(Kata.palindromeIndex("fgnfnidynhxebxxxfmxixhsruldhsaobhlcggchboashdlurshxixmfxxxbexhnydinfngf"));
            Console.WriteLine(Kata.palindromeIndex("bsyhvwfuesumsehmytqioswvpcbxyolapfywdxeacyuruybhbwxjmrrmjxwbhbyuruycaexdwyfpaloyxbcpwsoiqtymhesmuseufwvhysb"));
            Console.WriteLine(Kata.palindromeIndex("fvyqxqxynewuebtcuqdwyetyqqisappmunmnldmkttkmdlnmnumppasiqyteywdquctbeuwenyxqxqyvf"));
            Console.WriteLine(Kata.palindromeIndex("mmbiefhflbeckaecprwfgmqlydfroxrblulpasumubqhhbvlqpixvvxipqlvbhqbumusaplulbrxorfdylqmgfwrpceakceblfhfeibmm"));
            Console.WriteLine(Kata.palindromeIndex("tpqknkmbgasitnwqrqasvolmevkasccsakvemlosaqrqwntisagbmknkqpt"));
            Console.WriteLine(Kata.palindromeIndex("lhrxvssvxrhl"));
            Console.WriteLine(Kata.palindromeIndex("prcoitfiptvcxrvoalqmfpnqyhrubxspplrftomfehbbhefmotfrlppsxburhyqnpfmqlaorxcvtpiftiocrp"));
            Console.WriteLine(Kata.palindromeIndex("kjowoemiduaaxasnqghxbxkiccikxbxhgqnsaxaaudimeowojk"));
        }
    }
}