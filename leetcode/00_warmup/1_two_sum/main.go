package main

import "fmt"

// LeetCode #1: Two Sum
// Difficulty: Easy
// URL: https://leetcode.com/problems/two-sum/
//
// Key Differences from #167:
// - Array is UNSORTED (Two Pointers cannot be used directly).
// - Returns 0-based indices: [0, 1].
// - Optimal approach: One-Pass Hash Map (O(n) time, O(n) space).

func twoSum(nums []int, target int) []int {
	seen := make(map[int]int)

	for i, val := range nums {
		complement := target - val
		if prevIdx, exists := seen[complement]; exists {
			return []int{prevIdx, i}
		}
		seen[val] = i
	}

	return []int{}
}

func main() {
	fmt.Println("=== LeetCode #1: Two Sum (0-Indexed Go) ===")
	fmt.Printf("Example 1 [2,7,11,15], target=9: %v\n", twoSum([]int{2, 7, 11, 15}, 9))
	fmt.Printf("Example 2 [3,2,4], target=6:      %v\n", twoSum([]int{3, 2, 4}, 6))
	fmt.Printf("Example 3 [3,3], target=6:        %v\n", twoSum([]int{3, 3}, 6))
}
