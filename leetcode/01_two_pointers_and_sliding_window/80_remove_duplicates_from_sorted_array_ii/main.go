package main

import (
	"fmt"
)

// LeetCode #80: Remove Duplicates from Sorted Array II
// Difficulty: Medium
// URL: https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
//
// Given an integer array nums sorted in non-decreasing order, remove some duplicates
// in-place such that each unique element appears at most twice.
// The relative order of the elements should be kept the same.
// Return k after placing the final result in the first k slots of nums.
// Must modify array in-place with O(1) extra memory.

func removeDuplicates(nums []int) int {
	// TODO: Implement Two Pointers in-place solution
	_ = nums
	return 0
}

func main() {
	fmt.Println("=== LeetCode #80: Remove Duplicates from Sorted Array II (Go) ===")
	nums1 := []int{1, 1, 1, 2, 2, 3}
	k1 := removeDuplicates(nums1)
	fmt.Printf("Example 1: k = %d, nums = %v\n", k1, nums1[:k1])

	nums2 := []int{0, 0, 1, 1, 1, 1, 2, 3, 3}
	k2 := removeDuplicates(nums2)
	fmt.Printf("Example 2: k = %d, nums = %v\n", k2, nums2[:k2])
}
