using System;

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
        public static int Digits_Log10(int n) =>
            n == 0 ? 1 : (n > 0 ? 1 : 2) + (int)Math.Log10(Math.Abs((double)n));

        // WHILE LOOP:
        public static int Digits_While(int n)
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
                    squares[n - 1] = nums[right] * nums[right];
                    right--;
                }
                else
                {
                    squares[n - 1] = nums[left] * nums[left];
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
                    for (int j = n - 1; j > i; j--)
                    {
                        arr[j] = arr[j - 1];
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

        /// <summary>
        /// Input: nums = [0,1,2,2,3,0,4,2], val = 2
        /// Output: 5, nums = [0,1,4,0,3, _, _, _]
        /// Explanation: Your function should return k = 5, with the first five elements of nums containing 0, 0, 1, 3, and 4.
        /// Note that the five elements can be returned in any order.
        /// It does not matter what you leave beyond the returned k (hence they are underscores).
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns>k</returns>
        public int RemoveElement_TwoPointer(int[] nums, int val)
        {
            int i = 0;
            int n = nums.Length;
            while (i < n)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[n - 1];
                    // reduce array size by one
                    n--;
                }
                else
                {
                    i++;
                }
            }
            return n;
        }

        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }

        /// <summary>
        /// Input: nums = [0,0,1,1,1,2,2,3,3,4]
        /// Output: 5, nums = [0,1,2,3,4, _, _, _, _, _]
        /// Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        /// It does not matter what you leave beyond the returned k(hence they are underscores).
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates_Naive(int[] nums)
        {
            int k = 1;
            int w = 0;
            int r = 0;
            while (r < nums.Length)
            {
                if (nums[r] != nums[w])
                {
                    w++;
                    nums[w] = nums[r];
                    k++;
                }
                r++;
            }

            return k;
        }

        public int RemoveDuplicates_TwoIndex(int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return 0;
            }

            int insertIndex = 1;
            for (int i = 1; i < n; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[insertIndex] = nums[i];
                    insertIndex++;
                }
            }

            return insertIndex;
        }

        public int RemoveDuplicates_Naive1(int[] nums)
        {
            int r = 0, w = 0;
            while (r < nums.Length)
            {
                if (nums[r] != nums[w])
                {
                    w++;
                    nums[w] = nums[r];
                }
                r++;
            }

            return w + 1;
        }

        /// <summary>
        /// Given an array arr of integers, check if there exist two indices i and j such that :
        /// i != j
        /// 0 <= i, j<arr.length
        /// arr[i] == 2 * arr[j]
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CheckIfExist(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i != j && arr[i] == 2 * arr[j])
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// https://leetcode.com/problems/valid-mountain-array/description/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool ValidMountainArray_Naive(int[] arr)
        {
            if (arr.Length < 3) return false;
            for (int i = 1; i < arr.Length -1; i++)
            {
                if (arr[i - 1] >= arr[i]) return false;
                if (arr[i] == arr[i + 1]) return false;
                if (arr[i] > arr[i + 1])
                {
                    for (int j = i; j < arr.Length -1; j++)
                    {
                        if (arr[j +1] >= arr[j]) return false;
                        if (j + 1 == arr.Length - 1) return true;
                    }
                }
            }

            return false;
        }

        public bool ValidMountainArray_OnePass(int[] arr)
        {
            int N = arr.Length;
            int i = 0;

            // walk up
            while (i + 1 < N && arr[i] < arr[i + 1])
                i++;

            // peak can't be first or last
            if (i == 0 || i == N - 1)
                return false;

            // walk down
            while (i + 1 < N && arr[i] > arr[i + 1])
                i++;

            //If we reach the end, the array is valid, otherwise its not.
            return i == N - 1;
        }

        #region In-Place Array Operations

        /// <summary>
        /// replace every element in that array with the greatest element among the elements to its right, and replace the last element with -1.
        /// Input: arr = [17,18,5,4,6,1]
        /// Output: [18,6,6,6,1,-1]
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] ReplaceElements_Naive(int[] arr)
        {
            if(arr.Length == 1)
            {
                arr[0] = -1;
                return arr;
            }
            for (int i = 1; i < arr.Length; i++)
            {
                int max = arr[i];
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] > max)
                    {
                        max = arr[j];
                    }
                }

                arr[i-1] = max;
            }
            arr[^1] = -1;
            return arr;
        }

        public int[] ReplaceElements_Backwards(int[] arr)
        {
            for (int i = arr.Length - 1, max = -1; i >= 0; --i)
            {
                (arr[i], max) = (max, Math.Max(max, arr[i])); //tuple assignment
            }
            return arr;
        }

        public int RemoveDuplicates_StraightForward(int[] nums)
        {
            // The initial length is simply the capacity.
            int length = nums.Length;

            // Assume the last element is always unique.
            // Then for each element, delete it if it is
            // the same as the one after it. Use our deletion
            // algorithm for deleting from any index.
            for (int i = length - 2; i >= 0; i--)
            {
                if (nums[i] == nums[i + 1])
                {
                    // Delete the element at index i, using our standard
                    // deletion algorithm we learned.
                    for (int j = i + 1; j < length; j++)
                    {
                        nums[j - 1] = nums[j];
                    }
                    // Reduce the length by 1.
                    length--;
                }
            }
            // Return the new length.
            return length;
        }

        public int RemoveDuplicates_TwoPointer(int[] nums)
        {
            int w = 0;
            for (int r = 0; r < nums.Length; ++r)
            {
                if (nums[r] != nums[w])
                {
                    w++;
                    nums[w] = nums[r];
                }
            }
            return w + 1;
        }
        #endregion
    }
}
