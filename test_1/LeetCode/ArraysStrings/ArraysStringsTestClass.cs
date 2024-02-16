using System;
using System.Collections.Generic;
using System.Numerics;

namespace LeetCode.ArraysStrings
{
    internal class ArraysStringsTestClass
    {
        public int PivotIndex(int[] nums)
        {
            int sum = 0;
            foreach (var item in nums)
            {
                sum += item;
            }
            int leftSum = 0;
            for (int i = 0; i < nums.Length; leftSum += nums[i++])
            {
                if (leftSum == (sum - nums[i] - leftSum))
                    return i;
            }
            return -1;
        }

        public int DominantIndex(int[] nums)
        {
            int maxIndex = 0, max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    maxIndex = i;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != max && nums[i] * 2 > max)
                {
                    return -1;
                }
            }

            return maxIndex;
        }

        public int[] PlusOne(int[] digits)
        {
            int n = digits.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }
            int[] newNumber = new int[n + 1];
            newNumber[0] = 1;

            return newNumber;
        }

        public int[] PlusOne_Naive(int[] digits)
        {
            int i;
            BigInteger k = 0;
            for (i = 0; i < digits.Length; i++)
            {
                k = 10 * k + digits[i];
            } // Converting the array to an int
            k += 1;

            string num = k.ToString();
            int[] result = new int[num.Length];
            for (i = 0; i < result.Length; i++)
            {
                result[i] = num[i] - '0';
            }

            return result;
        }


        public int[] FindDiagonalOrder(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return Array.Empty<int>();
            }

            int N= matrix.Length;
            int M = matrix[0].Length;

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i = 0;i < N;i++)
            {
                for (int j = 0; j < M;j++)
                {
                    int sum = i + j;
                    if(dict.ContainsKey(sum))
                    {
                        dict[sum].Add(matrix[i][j]);
                    }
                    else
                    {
                        dict[sum] = new List<int>() { matrix[i][j] };
                    }
                }
            }

            var res = new List<int>();

            foreach (var item in dict)
            {
                if(item.Key %2 ==0)
                {
                    dict[item.Key].Reverse();
                }

                for (int i = 0; i < item.Value.Count; i++)
                {
                    res.Add(item.Value[i]);
                }
            }

            return res.ToArray();
        }
    }
}