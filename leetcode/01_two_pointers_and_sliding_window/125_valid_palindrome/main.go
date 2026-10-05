package main

import (
	"fmt"
)

// LeetCode #125: Valid Palindrome
// Difficulty: Easy
// URL: https://leetcode.com/problems/valid-palindrome/
//
// A phrase is a palindrome if, after converting all uppercase letters into lowercase
// letters and removing all non-alphanumeric characters, it reads the same forward
// and backward. Alphanumeric characters include letters and numbers.

func isPalindrome(s string) bool {
	// TODO: Implement Two Pointers solution
	_ = s
	return false
}

func main() {
	fmt.Println("=== LeetCode #125: Valid Palindrome (Go) ===")
	fmt.Printf("Example 1: %v\n", isPalindrome("A man, a plan, a canal: Panama"))
	fmt.Printf("Example 2: %v\n", isPalindrome("race a car"))
	fmt.Printf("Example 3: %v\n", isPalindrome(" "))
}
