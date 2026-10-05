//! LeetCode #11: Container With Most Water
//! Difficulty: Medium
//! URL: https://leetcode.com/problems/container-with-most-water/
//!
//! You are given an integer array height of length n. There are n vertical lines
//! drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
//! Find two lines that together with the x-axis form a container, such that the
//! container contains the most water.
//! Return the maximum amount of water a container can store.

use std::cmp::{max, min};

pub struct Solution;

impl Solution {
    pub fn max_area(height: Vec<i32>) -> i32 {
        let mut max_area = 0;
        let mut left = 0;
        let mut right = height.len()-1;
        while left < right {
            let width = right-left;
            max_area = max(max_area, min(height[left], height[right])*width as i32);
            if height[left] <= height[right] {
                left += 1;
            }
            else {
                right -= 1;
            }
        }
        max_area
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_example_1() {
        assert_eq!(Solution::max_area(vec![1, 8, 6, 2, 5, 4, 8, 3, 7]), 49);
    }

    #[test]
    fn test_example_2() {
        assert_eq!(Solution::max_area(vec![1, 1]), 1);
    }

    #[test]
    fn test_extra() {
        assert_eq!(Solution::max_area(vec![4, 3, 2, 1, 4]), 16);
        assert_eq!(Solution::max_area(vec![1, 2, 1]), 2);
    }
}

fn main() {
    println!("=== LeetCode #11: Container With Most Water (Rust) ===");
    println!("Example 1: {}", Solution::max_area(vec![1, 8, 6, 2, 5, 4, 8, 3, 7]));
    println!("Example 2: {}", Solution::max_area(vec![1, 1]));
}
