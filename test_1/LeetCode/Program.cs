using LeetCode.ArrayTopics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    internal class Program
    {
        private static readonly Class1 array = new();
        protected Program()
        {

        }

        private static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //var test = new Test();

            //var res = test.RunningSum(new int[] { 1, 2, 3, 4 });//[1,3,6,10]
            //Console.WriteLine(res);

            //var res1 = test.MaximumWealth(new int[][] { new int[] { 2, 8, 7 }, new int[] { 7, 1, 3 }, new int[] { 1, 9, 5 } });
            //Console.WriteLine(res1);

            //var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, null))))));
            //var res2 = test.MiddleNode_TwoPointer(head);
            //Console.WriteLine(res2.val);


            //var res3 = test.CanConstruct_Naive("aa", "aab");
            //Console.WriteLine(res3);

            //var res4 = array.FindMaxConsecutiveOnes(new int[] { 0, 1, 0, 1, 1, 1, 0 });//3
            //Console.WriteLine(res4);
            //res4 = array.FindMaxConsecutiveOnes(new int[] { 0, 1, 0, 1, 1, 1, 0, 1, 1 });//3
            //Console.WriteLine(res4);
            //res4 = array.FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 1, 1, 0 });//3
            //Console.WriteLine(res4);
            //res4 = array.FindMaxConsecutiveOnes(new int[] { 1, 1, 0, 1, 1, 1, 0, 1, 1 });//3
            //Console.WriteLine(res4);
            //res4 = array.FindMaxConsecutiveOnes(new int[] { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 0 });//4
            //Console.WriteLine(res4);

            //var res5 = array.SortedSquares_TwoPointer_While(new int[] { -4, -1, 0, 3, 10 });//[0,1,9,16,100]
            //Array.ForEach(res5, x => Console.WriteLine(x));

            //array.DuplicateZeros(new int[] { 1, 0, 2, 3, 0, 4, 5, 0 });

            //array.duplicateZeros(new int[] { 1, 0, 2, 3, 0, 4, 5, 0 });

            //array.Merge(nums1: new int[] { 1, 2, 3, 0, 0, 0 }, m: 3, nums2: new int[] { 2, 5, 6 }, n: 3);

            //array.Merge(nums1: new int[] { 0 }, m: 0, nums2: new int[] { 1 }, n: 1);

            //var res6 = array.RemoveElement_TwoPointer(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2);
            //Console.WriteLine(res6);

            //var res7 = array.RemoveDuplicates_Naive1(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });
            //Console.WriteLine(res7);

            //var res8 = array.CheckIfExist(new int[] { 10, 2, 5, 3 });
            //Console.WriteLine(res8);

            //var res9 = array.ValidMountainArray_OnePass(new int[] { 0, 3, 2, 1 });
            //Console.WriteLine(res9);

            //var res10 = array.RemoveDuplicates_TwoPointer(new int[] { 1,1,2 });
            //Console.WriteLine(res10);

            var arr=  new int[] { 0, 1, 0, 3, 12 };
            array.MoveZeroes_Efficient(ref arr);
            Array.ForEach(arr, Console.WriteLine);
        }


    }



    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    public class Test
    {
        public int[] RunningSum(int[] nums)
        {
            int sum = 0;
            return nums.Select(n => sum += n).ToArray();
        }

        public int MaximumWealth(int[][] accounts)
        {
            int res = 0;
            foreach (var account in accounts)
            {
                res = Math.Max(res, account.Sum());
            }
            return res;
        }

        public int NumberOfSteps_Naive(int num)
        {
            int steps = 0;
            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num--;
                }
                steps++;
            }
            return steps;
        }

        public int NumberOfSteps_Bitwise(int num)
        {
            int steps = 0;
            while (num > 0)
            {
                if ((num & 1) == 0)
                {
                    num >>= 1;
                }
                else
                {
                    num--;
                }
                steps++;
            }
            return steps;
        }

        public ListNode MiddleNode_Naive(ListNode head)
        {
            List<ListNode> array = new List<ListNode>();
            int length = 0;

            while (head != null)
            {
                array.Add(head);
                head = head.next;
                length++;
            }

            return array[length / 2];
        }

        public ListNode MiddleNode_TwoPointer(ListNode head)//[1,2,3,4,5,6]
        {
            ListNode middle = head;
            ListNode end = head;

            while (end != null && end.next != null)
            {
                middle = middle.next;
                end = end.next.next;
            }

            return middle;
        }

        public bool CanConstruct_Naive(string ransomNote, string magazine)
        {
            var map = new Dictionary<char, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                map[magazine[i]] = map.TryGetValue(magazine[i], out int value) ? value + 1 : 1;
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (map.GetValueOrDefault(ransomNote[i]) == 0)
                {
                    return false;
                }

                map[ransomNote[i]] -= 1;
            }
            return true;
        }
    }
}
