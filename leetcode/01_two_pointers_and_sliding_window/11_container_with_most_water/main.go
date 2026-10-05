package main

import "fmt"

// LeetCode #11: Container With Most Water
// Difficulty: Medium
// URL: https://leetcode.com/problems/container-with-most-water/
//
// You are given an integer array height of length n. There are n vertical lines
// drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
// Find two lines that together with the x-axis form a container, such that the
// container contains the most water.
// Return the maximum amount of water a container can store.

func maxArea(height []int) int {
	left := 0
	right := len(height)-1
	maxArea := 0
	for left < right {
		width := right - left
		maxArea = max(maxArea, min(height[left], height[right])*width)
		if height[left] <= height[right]{
			left ++
		} else{
			right --
		}
	}

	return maxArea
}

func main() {
	fmt.Println("=== LeetCode #11: Container With Most Water (Go) ===")
	fmt.Printf("Example 1: %d\n", maxArea([]int{1, 8, 6, 2, 5, 4, 8, 3, 7}))
	fmt.Printf("Example 2: %d\n", maxArea([]int{1, 1}))
}
