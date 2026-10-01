//! LeetCode #1: Two Sum
//! Difficulty: Easy
//! URL: https://leetcode.com/problems/two-sum/
//!
//! Key Differences from #167:
//! - Array is UNSORTED (Two Pointers cannot be used directly).
//! - Returns 0-based indices: [0, 1].
//! - Optimal approach: One-Pass Hash Map (O(n) time, O(n) space).

pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        use std::collections::HashMap;

        let mut seen = HashMap::new();
        for (i, &val) in nums.iter().enumerate() {
            let complement = target - val;
            if let Some(&prev_idx) = seen.get(&complement) {
                return vec![prev_idx, i as i32];
            }
            seen.insert(val, i as i32);
        }

        vec![]
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_examples() {
        assert_eq!(Solution::two_sum(vec![2, 7, 11, 15], 9), vec![0, 1]);
        assert_eq!(Solution::two_sum(vec![3, 2, 4], 6), vec![1, 2]);
        assert_eq!(Solution::two_sum(vec![3, 3], 6), vec![0, 1]);
    }
}

fn main() {
    println!("=== LeetCode #1: Two Sum (0-Indexed Rust) ===");
    println!("Example 1: {:?}", Solution::two_sum(vec![2, 7, 11, 15], 9));
    println!("Example 2: {:?}", Solution::two_sum(vec![3, 2, 4], 6));
    println!("Example 3: {:?}", Solution::two_sum(vec![3, 3], 6));
}
