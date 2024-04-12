using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCode.DP
{
    internal class DP
    {
        [Test]
        public void MinCostClimbingStairs_test()
        {
            var res = MinCostClimbingStairs(new int[] { 10, 15, 20 });
            Assert.Equals(15, res);
        }
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length == 0) return 0;

            var map = new Dictionary<int, int>();

            int costi(int i)
            {
                if (i == 0 || i == 1) return 0;

                if (!map.ContainsKey(i))
                {
                    map[i] = Math.Min(cost[i - 1] + costi(i - 1), cost[i - 2] + costi(i - 2));
                }

                return map[i];
            }

            return costi(cost.Length);
        }
    }
}
