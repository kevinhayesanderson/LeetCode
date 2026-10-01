package main

import (
	"fmt"
)

// LeetCode #167: Two Sum II - Input Array Is Sorted
// Difficulty: Medium
// URL: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

func twoSumNaive(numbers []int, target int) []int {
	if len(numbers) == 2 {
		return []int{0, 1}
	} else {
		for i1, v1 := range numbers {
			if v1 < target {
				for i2, v2 := range numbers[i1+1:] {
					if v2 < target && v1+v2 == target {
						return []int{i1, i1 + i2 + 1}
					}
				}
			}
		}
	}
	return []int{}
}

func twoSumTwoPassHashTable(numbers []int, target int) []int {
	if len(numbers) == 2 {
		return []int{0, 1}
	} else {
		m := make(map[int]int)
		for i, n := range numbers {
			m[n] = i
		}
		for i, v := range numbers {
			compliment := target - v
			if j, exists := m[compliment]; exists && j != i {
				return []int{i, j}
			}
		}
	}
	return []int{}
}

func twoSumOnePass(numbers []int, target int) []int {
	if len(numbers) == 2 {
		return []int{0, 1}
	} else {
		m := make(map[int]int)
		for i, n := range numbers {
			compliment := target - n
			if j, exists := m[compliment]; exists && i != j {
				return []int{j, i}
			}
			m[n] = i
		}
	}
	return []int{}
}

func main() {
	fmt.Println("--- LeetCode #167: Two Sum II - Input Array Is Sorted (Go) ---")
	// TODO: Add test execution cases
	fmt.Println(twoSumNaive([]int{3, 2, 4}, 6))
	fmt.Println(twoSumTwoPassHashTable([]int{3, 2, 4}, 6))
	fmt.Println(twoSumOnePass([]int{3, 2, 4}, 6))
}
