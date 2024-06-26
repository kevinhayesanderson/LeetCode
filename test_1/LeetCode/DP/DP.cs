﻿using NUnit.Framework;
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
        public int Tribonacci(int n)
        {
            var map = new Dictionary<int, int>();

            int ti(int i)
            {
                if (i == 0) return 0;
                if (i == 1 || i == 2) return 1;
                if (!map.ContainsKey(i))
                {
                    map[i] = ti(i - 3) + ti(i - 2) + ti(i - 1);
                }
                return map[i];
            }

            return ti(n);
        }
        public int DeleteAndEarn(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var map  = new Dictionary<int, int>();

            int pointsi(int i)
            {
                if(!map.ContainsKey(i))
                {
                    int points = 0;
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (nums[j] == i || nums[j] != i + 1 || nums[j] != i - 1)
                        {
                            points += nums[j];
                        }
                    }
                    map[i] = points;
                }
                return map[i];
            }

            var res = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if(pointsi(nums[i]) > res)
                {
                    res = pointsi(nums[i]);
                }
            }

            return res;

        }
    }
}
