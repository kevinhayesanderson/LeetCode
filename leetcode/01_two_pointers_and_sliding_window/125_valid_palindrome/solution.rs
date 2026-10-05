//! LeetCode #125: Valid Palindrome
//! Difficulty: Easy
//! URL: https://leetcode.com/problems/valid-palindrome/
//!
//! A phrase is a palindrome if, after converting all uppercase letters into lowercase
//! letters and removing all non-alphanumeric characters, it reads the same forward
//! and backward. Alphanumeric characters include letters and numbers.

pub struct Solution;

impl Solution {
    pub fn is_palindrome(s: String) -> bool {
        // TODO: Implement Two Pointers solution
        let _ = s;
        false
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_example_1() {
        assert_eq!(
            Solution::is_palindrome("A man, a plan, a canal: Panama".to_string()),
            true
        );
    }

    #[test]
    fn test_example_2() {
        assert_eq!(Solution::is_palindrome("race a car".to_string()), false);
    }

    #[test]
    fn test_example_3() {
        assert_eq!(Solution::is_palindrome(" ".to_string()), true);
    }

    #[test]
    fn test_extra() {
        assert_eq!(Solution::is_palindrome("a.".to_string()), true);
        assert_eq!(Solution::is_palindrome("0P".to_string()), false);
    }
}

fn main() {
    println!("=== LeetCode #125: Valid Palindrome (Rust) ===");
    println!(
        "Example 1: {}",
        Solution::is_palindrome("A man, a plan, a canal: Panama".to_string())
    );
    println!(
        "Example 2: {}",
        Solution::is_palindrome("race a car".to_string())
    );
    println!("Example 3: {}", Solution::is_palindrome(" ".to_string()));
}
