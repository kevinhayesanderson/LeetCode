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

        //Duplicate Zeros
        public void DuplicateZeros(int[] arr)//[1,0,2,3,0,4,5,0]//[1,0,0,2,3,0,0,4]
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == 0)
                {
                    for (int j = n-1; j > i ; j--)
                    {
                        arr[j] = arr[j-1];
                    }
                    i++;
                }
            }
        }

        public void duplicateZeros(int[] arr)
        {
            int possibleDups = 0;
            int length_ = arr.Length - 1;

            // Find the number of zeros to be duplicated
            // Stopping when left points beyond the last element in the original array
            // which would be part of the modified array
            for (int left = 0; left <= length_ - possibleDups; left++)
            {

                // Count the zeros
                if (arr[left] == 0)
                {

                    // Edge case: This zero can't be duplicated. We have no more space,
                    // as left is pointing to the last element which could be included  
                    if (left == length_ - possibleDups)
                    {
                        // For this zero we just copy it without duplication.
                        arr[length_] = 0;
                        length_ -= 1;
                        break;
                    }
                    possibleDups++;
                }
            }

            // Start backwards from the last element which would be part of new array.
            int last = length_ - possibleDups;

            // Copy zero twice, and non zero once.
            for (int i = last; i >= 0; i--)
            {
                if (arr[i] == 0)
                {
                    arr[i + possibleDups] = 0;
                    possibleDups--;
                    arr[i + possibleDups] = 0;
                }
                else
                {
                    arr[i + possibleDups] = arr[i];
                }
            }
        }


        //Merge Sorted Array
        //nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
        //[1,2,2,3,5,6]
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int r1 = m - 1;
            int r2 = n - 1;

            for (int w = m + n - 1; w >= 0; w--)
            {
                if (r1 >= 0 && r2 >= 0)
                {
                    nums1[w] = nums1[r1] > nums2[r2] ? nums1[r1--] : nums2[r2--];
                }
                else if (r1 >= 0)
                {
                    nums1[w] = nums1[r1--];
                }
                else
                {
                    nums1[w] = nums2[r2--];
                }
            }
        }

        public void merge_Naive(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                nums1[i + m] = nums2[i];
            }
            Array.Sort(nums1);
        }
    }
}
