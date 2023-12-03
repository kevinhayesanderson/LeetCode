
using System;
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

            var res = test.RunningSum(new int[] { 1, 2, 3, 4 });//[1,3,6,10]

            Array.ForEach(res, Console.WriteLine);

            ////Console.ReadKey();
        }


    }

    
    public class Test
    {
        public int[] RunningSum(int[] nums)
        {
            int sum = 0;
            return nums.Select(n => sum += n).ToArray();
        }
    }
}
