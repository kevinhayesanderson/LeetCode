//! LeetCode #167: Two Sum II - Input Array Is Sorted
//! Difficulty: Medium
//! URL: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
//!
//! Constraints:
//! - Array is already sorted in non-decreasing order.
//! - Constant O(1) extra space required.
//! - 1-based indexing output: [index1, index2] where 1 <= index1 < index2 <= numbers.len().

pub struct Solution;

impl Solution {
    /// Optimal Two-Pointer approach for sorted array:
    /// - Time Complexity: O(n) single pass
    /// - Space Complexity: O(1) constant extra memory (zero heap allocations)
    /// - Returns 1-based indices as required by LeetCode #167.
    pub fn two_sum(numbers: Vec<i32>, target: i32) -> Vec<i32> {
        let mut left: usize = 0;
        let mut right: usize = numbers.len() - 1;

        while left < right {
            let sum = numbers[left] + numbers[right];
            match sum.cmp(&target) {
                // Return 1-based indices: left + 1, right + 1
                std::cmp::Ordering::Equal => return vec![(left + 1) as i32, (right + 1) as i32],
                std::cmp::Ordering::Less => left += 1,
                std::cmp::Ordering::Greater => right -= 1,
            }
        }

        vec![]
    }

    /// Alternative HashMap approach (1-based indices):
    /// - Time Complexity: O(n)
    /// - Space Complexity: O(n) auxiliary heap space
    pub fn two_sum_hash_map(numbers: Vec<i32>, target: i32) -> Vec<i32> {
        use std::collections::HashMap;

        let mut seen = HashMap::new();
        for (i, &val) in numbers.iter().enumerate() {
            let complement = target - val;
            if let Some(&prev_idx) = seen.get(&complement) {
                return vec![prev_idx + 1, (i + 1) as i32];
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
    fn test_two_pointers() {
        // Example 1: [2, 7, 11, 15], target = 9 -> [1, 2]
        assert_eq!(Solution::two_sum(vec![2, 7, 11, 15], 9), vec![1, 2]);

        // Example 2: [2, 3, 4], target = 6 -> [1, 3]
        assert_eq!(Solution::two_sum(vec![2, 3, 4], 6), vec![1, 3]);

        // Example 3: [-1, 0], target = -1 -> [1, 2]
        assert_eq!(Solution::two_sum(vec![-1, 0], -1), vec![1, 2]);
    }

    #[test]
    fn test_hash_map() {
        assert_eq!(Solution::two_sum_hash_map(vec![2, 7, 11, 15], 9), vec![1, 2]);
        assert_eq!(Solution::two_sum_hash_map(vec![2, 3, 4], 6), vec![1, 3]);
        assert_eq!(Solution::two_sum_hash_map(vec![-1, 0], -1), vec![1, 2]);
    }
}

fn main() {
    println!("=== LeetCode #167: Two Sum II - Input Array Is Sorted (Rust) ===");
    println!("Example 1: {:?}", Solution::two_sum(vec![2, 7, 11, 15], 9));
    println!("Example 2: {:?}", Solution::two_sum(vec![2, 3, 4], 6));
    println!("Example 3: {:?}", Solution::two_sum(vec![-1, 0], -1));
}
