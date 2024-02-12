using LeetCode.ArraysStrings;
using LeetCode.ArrayTopics;
using LeetCode.LinkedList;
using System;

namespace LeetCode
{
    internal class Program
    {
        private static readonly ArrayTopicsTestClass array = new();
        private static readonly LinkedListTestClass linkedList = new();
        private static readonly ArraysStringsTestClass arraysStrings = new();
        protected Program()
        {

        }

        private static void Main(string[] args)
        {
            #region Array

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

            //var arr=  new int[] { 0, 1, 0, 3, 12 };
            //array.MoveZeroes_Efficient(ref arr);
            //Array.ForEach(arr, Console.WriteLine);

            //arr = new int[] { 0, 1, 1, 0, 12 };
            //var res11 = array.RemoveElement_TwoPointer_InPlace1(arr, 0);
            //Console.WriteLine(res11);

            //var res12 = array.HeightChecker(new int[] { 1, 1, 4, 2, 1, 3 });
            //Console.WriteLine(res12);

            //var res13 = array.FindMaxConsecutiveOnes_Flip_Naive(new int[] { 1, 0, 1, 1, 0 });
            //Console.WriteLine(res13);

            //var res14 = array.FindMaxConsecutiveOnes_Flip_SlidingWindow(new int[] { 1,0,0,1,1,0,1 });
            //Console.WriteLine(res14);

            //var res15 = array.ThirdMax_Sorting(new int[] { 1, 0, 2, 3, 4, 5, 6, 7, 8, 9,9,10,10, 10, 11,11,11,11, });
            //Console.WriteLine(res15);


            //var res16 = array.FindDisappearedNumbers(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
            //Console.WriteLine(res16);

            #endregion Array
            #region Linked List

            #endregion Linked List
            #region Arrays & Strings
            var res = arraysStrings.PlusOne(new int[] { 1, 2, 3 });
            Array.ForEach(res, Console.WriteLine);
            #endregion Arrays & Strings
        }
    }
}
