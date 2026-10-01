package main

import (
	"fmt"
)

// LeetCode #167: Two Sum II - Input Array Is Sorted
// Difficulty: Medium
// URL: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
//
// Constraints & Guarantees:
// - The array is already sorted in non-decreasing order.
// - Must use O(1) constant extra space.
// - Returns 1-based indices: [index1, index2] where 1 <= index1 < index2 <= len(numbers).

// TwoSum is the optimal Two-Pointer approach: O(n) time, O(1) space.
func twoSum(numbers []int, target int) []int {
	left, right := 0, len(numbers)-1

	for left < right {
		sum := numbers[left] + numbers[right]
		if sum == target {
			return []int{left + 1, right + 1}
		} else if sum < target {
			left++
		} else {
			right--
		}
	}

	return []int{}
}

// TwoSumHashMap is the alternative O(n) space HashMap approach, adapted for 1-based indexing.
func TwoSumHashMap(numbers []int, target int) []int {
	seen := make(map[int]int)

	for i, val := range numbers {
		complement := target - val
		if prevIdx, exists := seen[complement]; exists {
			return []int{prevIdx + 1, i + 1}
		}
		seen[val] = i
	}

	return []int{}
}

func main() {
	fmt.Println("=== LeetCode #167: Two Sum II - Input Array Is Sorted (Go) ===")

	// Test Case 1: [2, 7, 11, 15], target = 9 -> [1, 2]
	fmt.Printf("Example 1 [2,7,11,15], target=9:  %v\n", twoSum([]int{2, 7, 11, 15}, 9))

	// Test Case 2: [2, 3, 4], target = 6 -> [1, 3]
	fmt.Printf("Example 2 [2,3,4], target=6:       %v\n", twoSum([]int{2, 3, 4}, 6))

	// Test Case 3: [-1, 0], target = -1 -> [1, 2]
	fmt.Printf("Example 3 [-1,0], target=-1:      %v\n", twoSum([]int{-1, 0}, -1))
}
