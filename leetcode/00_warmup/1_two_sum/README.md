# #1. Two Sum

- **Difficulty**: Easy
- **Topics**: Array, Hash Table
- **LeetCode URL**: [https://leetcode.com/problems/two-sum/](https://leetcode.com/problems/two-sum/)

---

## Contrast: LeetCode #1 vs. LeetCode #167

| Feature | LeetCode #1 (Two Sum) | LeetCode #167 (Two Sum II) |
| :--- | :--- | :--- |
| **Array Property** | Unsorted | Sorted in non-decreasing order |
| **Indexing** | **0-indexed** (`[0, 1]`) | **1-indexed** (`[1, 2]`) |
| **Optimal Pattern** | Hash Map (`O(n)` space) | Two Pointers (`O(1)` space) |
| **Input Variable** | `nums` | `numbers` |

---

## Problem Statement

Given an array of integers `nums` and an integer `target`, return *indices of the two numbers such that they add up to `target`*.

You may assume that each input would have ***exactly one solution***, and you may not use the same element twice.

You can return the answer in any order.

### Example 1:
```text
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
```

### Example 2:
```text
Input: nums = [3,2,4], target = 6
Output: [1,2]
```

### Example 3:
```text
Input: nums = [3,3], target = 6
Output: [0,1]
```

---

## Complexity
- **Time Complexity**: `O(n)`
- **Space Complexity**: `O(n)` (Hash Map)
