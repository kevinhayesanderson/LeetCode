# #15. 3Sum

- **Difficulty**: Medium
- **Topics**: Array, Two Pointers, Sorting
- **LeetCode URL**: [https://leetcode.com/problems/3sum/](https://leetcode.com/problems/3sum/)

---

## 45-Minute Execution Protocol

- [ ] **00–05 min**: Whiteboard & Logic Trace (pointer diagrams, boundary conditions, edge cases).
- [ ] **05–20 min**: Go Implementation (`main.go`).
- [ ] **20–40 min**: Rust Zero-Cost Implementation (`solution.rs`).
- [ ] **40–45 min**: Complexity Analysis & Local Git Commit.

---

## Problem Statement

Given an integer array nums, return all the triplets `[nums[i], nums[j], nums[k]]` such that `i != j`, `i != k`, and `j != k`, and `nums[i] + nums[j] + nums[k] == 0`.

Notice that the solution set must not contain duplicate triplets.

 

**Example 1:**

```

**Input:** nums = [-1,0,1,2,-1,-4]
**Output:** [[-1,-1,2],[-1,0,1]]
**Explanation:** 
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
The distinct triplets are [-1,0,1] and [-1,-1,2].
Notice that the order of the output and the order of the triplets does not matter.

```

**Example 2:**

```

**Input:** nums = [0,1,1]
**Output:** []
**Explanation:** The only possible triplet does not sum up to 0.

```

**Example 3:**

```

**Input:** nums = [0,0,0]
**Output:** [[0,0,0]]
**Explanation:** The only possible triplet sums up to 0.

```

 

**Constraints:**

	• `3 5 5`

---

## Approach & Diagram

### Intuition & Whiteboard Notes
-

### Complexity
- **Time Complexity**: `O(...)`
- **Space Complexity**: `O(...)`

### Go vs. Rust Language Comparisons
- **Go**:
- **Rust**:
