package main

import (
	"fmt"
	"sort"
)

// LeetCode #15: 3Sum
// Difficulty: Medium
// URL: https://leetcode.com/problems/3sum/
//
// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]]
// such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
// Notice that the solution set must not contain duplicate triplets.

func threeSum(nums []int) [][]int {
	sort.Ints(nums) //sort is clean than map store
	res := [][]int{}
	for i := 0; i < len(nums) && nums[i] <= 0; i++ {
		if i == 0 || nums[i-1] != nums[i] {
			low := i + 1
			high := len(nums) - 1
			for low < high {
				sum := nums[i] + nums[low] + nums[high]
				if sum < 0 {
					low++
				} else if sum > 0 {
					high--
				} else {
					res = append(res, []int{nums[i], nums[low], nums[high]})
					low++
					high--

					for low < high && nums[low -1] == nums[low]{
						low++
					}

					for low < high && nums[high+1] == nums[high]{
						high--
					}
				}
			}
		}
	}

	return res
}

func main() {
	fmt.Println("=== LeetCode #15: 3Sum (Go) ===")
	fmt.Printf("Example 1: %v\n", threeSum([]int{-1, 0, 1, 2, -1, -4}))
	fmt.Printf("Example 2: %v\n", threeSum([]int{0, 1, 1}))
	fmt.Printf("Example 3: %v\n", threeSum([]int{0, 0, 0}))
}
