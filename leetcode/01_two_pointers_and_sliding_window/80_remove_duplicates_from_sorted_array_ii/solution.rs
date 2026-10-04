//! LeetCode #80: Remove Duplicates from Sorted Array II
//! Difficulty: Medium
//! URL: https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
//!
//! Given an integer array nums sorted in non-decreasing order, remove some duplicates
//! in-place such that each unique element appears at most twice.
//! The relative order of the elements should be kept the same.
//! Return k after placing the final result in the first k slots of nums.
//! Must modify array in-place with O(1) extra memory.

pub struct Solution;

impl Solution {
    pub fn remove_duplicates(nums: &mut Vec<i32>) -> i32 {
        // TODO: Implement Two Pointers in-place solution
        let _ = nums;
        0
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_example_1() {
        let mut nums = vec![1, 1, 1, 2, 2, 3];
        let expected_slice = vec![1, 1, 2, 2, 3];
        let k = Solution::remove_duplicates(&mut nums);
        assert_eq!(k as usize, expected_slice.len());
        assert_eq!(&nums[..k as usize], &expected_slice[..]);
    }

    #[test]
    fn test_example_2() {
        let mut nums = vec![0, 0, 1, 1, 1, 1, 2, 3, 3];
        let expected_slice = vec![0, 0, 1, 1, 2, 3, 3];
        let k = Solution::remove_duplicates(&mut nums);
        assert_eq!(k as usize, expected_slice.len());
        assert_eq!(&nums[..k as usize], &expected_slice[..]);
    }

    #[test]
    fn test_short_arrays() {
        let mut nums1 = vec![1, 1];
        let k1 = Solution::remove_duplicates(&mut nums1);
        assert_eq!(k1, 2);
        assert_eq!(&nums1[..k1 as usize], &[1, 1]);

        let mut nums2 = vec![1, 1, 1];
        let k2 = Solution::remove_duplicates(&mut nums2);
        assert_eq!(k2, 2);
        assert_eq!(&nums2[..k2 as usize], &[1, 1]);
    }
}

fn main() {
    println!("=== LeetCode #80: Remove Duplicates from Sorted Array II (Rust) ===");
    let mut nums1 = vec![1, 1, 1, 2, 2, 3];
    let k1 = Solution::remove_duplicates(&mut nums1);
    println!("Example 1: k = {}, nums = {:?}", k1, &nums1[..k1 as usize]);
}
