using System;
using System.Linq;

namespace LeetCode.BitOperations
{
    internal class BitOperations
    {
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
                if (last_bit > 0)
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
    }
}