using System;
using System.Collections.Generic;

namespace LeetCode.ArrayTopics
{
    internal class Class1
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0;
            int maxCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    count += 1;
                }
                else
                {
                    if (count > maxCount) maxCount = count;
                    count = 0;
                }
            }
            return count > maxCount ? count : maxCount;
        }

        //Find Numbers with Even Number of Digits
        public int FindNumbers(int[] nums)
        {
            int res = 0;
            foreach (int x in nums)
            {
                if (x.ToString().Length % 2 == 0)
                {
                    res++;
                }
            }
            return res;
        }

        //Find Numbers with Even Number of Digits
        public int FindNumbers_Optimal(int[] nums)
        {
            int res = 0;
            foreach (int x in nums)
            {
                if (Digits_IfChain(x) % 2 == 0)
                {
                    res++;
                }
            }
            return res;
        }

        // IF-CHAIN:
        private static int Digits_IfChain(int n)
        {
            if (n >= 0)
            {
                return n switch
                {
                    < 10 => 1,
                    < 100 => 2,
                    < 1000 => 3,
                    < 10000 => 4,
                    < 100000 => 5,
                    < 1000000 => 6,
                    < 10000000 => 7,
                    < 100000000 => 8,
                    < 1000000000 => 9,
                    _ => 10
                };
            }
            else
            {
                return n switch
                {
                    > -10 => 2,
                    > -100 => 3,
                    > -1000 => 4,
                    > -10000 => 5,
                    > -100000 => 6,
                    > -1000000 => 7,
                    > -10000000 => 8,
                    > -100000000 => 9,
                    > -1000000000 => 10,
                    _ => 11
                };
            }
        }

        // USING LOG10:
        public static int Digits_Log10( int n) =>
            n == 0 ? 1 : (n > 0 ? 1 : 2) + (int)Math.Log10(Math.Abs((double)n));

        // WHILE LOOP:
        public static int Digits_While( int n)
        {
            int digits = n < 0 ? 2 : 1;
            while ((n /= 10) != 0) ++digits;
            return digits;
        }

        // STRING CONVERSION:
        public static int Digits_String(int n) =>
            n.ToString().Length;

        //Squares of a Sorted Array
        public int[] SortedSquares_TwoPointer_For(int[] nums)
        {
            int n = nums.Length;
            int[] squares = new int[n];
            int left = 0, right = n - 1;
            for (int i = n - 1; i >= 0; i--)
            {
                if (Math.Abs(nums[left]) < Math.Abs(nums[right]))
                {
                    squares[i] = nums[right] * nums[right];
                    right--;
                }
                else
                {
                    squares[i] = nums[left] * nums[left];
                    left++;
                }
            }
            return squares;
        }

        //Squares of a Sorted Array
        public int[] SortedSquares_TwoPointer_While(int[] nums)
        {
            int n = nums.Length;
            int[] squares = new int[n];
            int left = 0, right = n - 1;
            while (left <= right)
            {
                if (Math.Abs(nums[left]) < Math.Abs(nums[right]))
                {
                    squares[n-1] = nums[right] * nums[right];
                    right--;
                }
                else
                {
                    squares[n-1] = nums[left] * nums[left];
                    left++;
                }
                n--;
            }
            return squares;
        }
    }
}
