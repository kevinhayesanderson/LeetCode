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
        if nums.len() < 3 {
            return vec![];
        }
        let mut nums = nums;
        nums.sort_unstable();
        let mut res : Vec<Vec<i32>> = Vec::new();
        for (i, &val) in nums.iter().enumerate() {
            if val > 0 {
                break;
            }
            if i > 0 && nums[i] == nums[i - 1] {
                continue;
            }
            let mut low = i+1;
            let mut high = nums.len() - 1;
            while low < high {
                let sum = nums[i]+nums[low]+nums[high];
                match sum.cmp(&0) {
                    std::cmp::Ordering::Less => low +=1,
                    std::cmp::Ordering::Greater => high -= 1,
                    std::cmp::Ordering::Equal =>{
                        res.push(vec![nums[i], nums[low], nums[high]]);
                        low += 1;
                        high -= 1;
                        while low < high && nums[low] == nums[low - 1] {
                            low += 1;
                        }
                        while low < high && nums[high] == nums[high + 1] {
                            high -= 1;
                        }
                    } 
                }
            }
        }
        res
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
