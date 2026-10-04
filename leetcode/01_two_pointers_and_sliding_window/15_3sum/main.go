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
	// TODO: Implement Two Pointers solution
	_ = sort.Ints
	return [][]int{}
}

func main() {
	fmt.Println("=== LeetCode #15: 3Sum (Go) ===")
	fmt.Printf("Example 1: %v\n", threeSum([]int{-1, 0, 1, 2, -1, -4}))
	fmt.Printf("Example 2: %v\n", threeSum([]int{0, 1, 1}))
	fmt.Printf("Example 3: %v\n", threeSum([]int{0, 0, 0}))
}
