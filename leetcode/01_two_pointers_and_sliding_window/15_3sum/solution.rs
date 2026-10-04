//! LeetCode #15: 3Sum
//! Difficulty: Medium
//! URL: https://leetcode.com/problems/3sum/
//!
//! Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]]
//! such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
//! Notice that the solution set must not contain duplicate triplets.

pub struct Solution;

impl Solution {
    pub fn three_sum(nums: Vec<i32>) -> Vec<Vec<i32>> {
        // TODO: Implement Two Pointers solution
        let _ = nums;
        vec![]
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    fn normalize(mut triplets: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        for t in triplets.iter_mut() {
            t.sort_unstable();
        }
        triplets.sort_unstable();
        triplets
    }

    #[test]
    fn test_example_1() {
        let nums = vec![-1, 0, 1, 2, -1, -4];
        let expected = vec![vec![-1, -1, 2], vec![-1, 0, 1]];
        assert_eq!(normalize(Solution::three_sum(nums)), normalize(expected));
    }

    #[test]
    fn test_example_2() {
        let nums = vec![0, 1, 1];
        let expected: Vec<Vec<i32>> = vec![];
        assert_eq!(normalize(Solution::three_sum(nums)), normalize(expected));
    }

    #[test]
    fn test_example_3() {
        let nums = vec![0, 0, 0];
        let expected = vec![vec![0, 0, 0]];
        assert_eq!(normalize(Solution::three_sum(nums)), normalize(expected));
    }

    #[test]
    fn test_all_zeroes() {
        let nums = vec![0, 0, 0, 0];
        let expected = vec![vec![0, 0, 0]];
        assert_eq!(normalize(Solution::three_sum(nums)), normalize(expected));
    }

    #[test]
    fn test_multiple_duplicates() {
        let nums = vec![-2, 0, 1, 1, 2];
        let expected = vec![vec![-2, 0, 2], vec![-2, 1, 1]];
        assert_eq!(normalize(Solution::three_sum(nums)), normalize(expected));
    }
}

fn main() {
    println!("=== LeetCode #15: 3Sum (Rust) ===");
    println!("Example 1: {:?}", Solution::three_sum(vec![-1, 0, 1, 2, -1, -4]));
    println!("Example 2: {:?}", Solution::three_sum(vec![0, 1, 1]));
    println!("Example 3: {:?}", Solution::three_sum(vec![0, 0, 0]));
}
