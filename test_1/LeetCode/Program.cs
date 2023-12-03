
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    internal class Program
    {
        protected Program()
        {

        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var test = new Test();

            //var res = test.RunningSum(new int[] { 1, 2, 3, 4 });//[1,3,6,10]

            //Array.ForEach(res, Console.WriteLine);


            //var res1 = test.MaximumWealth(new int[][] { new int[] { 2, 8, 7 }, new int[] { 7, 1, 3 }, new int[] { 1, 9, 5 } });

            //Console.WriteLine(res1);


            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, null))))));

            var res2 = test.MiddleNode_TwoPointer(head);

            Console.WriteLine(res2.val);
            ////Console.ReadKey();
            ///

            var res3 = test.CanConstruct("aa", "aab");
            Console.WriteLine(res3);
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
                if(num % 2 == 0)
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
                    num  >>= 1;
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

            for (int i = 0;i < ransomNote.Length; i++)
            {
                if(map.GetValueOrDefault(ransomNote[i]) == 0)
                {
                    return false;
                }

                map[ransomNote[i]] -= 1;
            }
            return true;
        }
    }
}
