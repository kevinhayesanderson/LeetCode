//! LeetCode #167: Two Sum II - Input Array Is Sorted
//! Difficulty: Medium
//! URL: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

pub struct Solution;

impl Solution {
    pub fn two_sum(numbers: Vec<i32>, target: i32) -> Vec<i32> {
        Self::two_sum_idiomatic_two_pointer(numbers, target)
    }

    pub fn two_sum_hash_map(numbers: Vec<i32>, target: i32) -> Vec<i32> {
        use std::collections::HashMap;

        let mut m: HashMap<i32, i32> = HashMap::new();
        for (i, v) in numbers.iter().enumerate() {
            let compliment: i32 = target - *v;
            match m.get(&compliment) {
                Some(&i2) => return vec![i2 + 1, (i + 1) as i32],
                None => m.insert(*v, i as i32),
            };
        }
        vec![]
    }

    pub fn two_sum_idiomatic_two_pointer(numbers: Vec<i32>, target: i32) -> Vec<i32> {
        let mut left: usize = 0;
        let mut right: usize = numbers.len() - 1;
        while left < right {
            let sum = numbers[left] + numbers[right];
            match sum.cmp(&target) {
                std::cmp::Ordering::Equal => return vec![(left + 1) as i32, (right + 1) as i32],
                std::cmp::Ordering::Less => left += 1,
                std::cmp::Ordering::Greater => right -= 1,
            }
        }

        vec![]
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_example() {
        assert_eq!(Solution::two_sum_idiomatic_two_pointer(vec![2, 7, 11, 15], 9), vec![1, 2]);
        assert_eq!(Solution::two_sum_idiomatic_two_pointer(vec![2, 3, 4], 6), vec![1, 3]);
        assert_eq!(Solution::two_sum_idiomatic_two_pointer(vec![-1, 0], -1), vec![1, 2]);
    }
}

fn main() {
    println!("--- LeetCode #167: Two Sum II - Input Array Is Sorted (Rust) ---");
}
