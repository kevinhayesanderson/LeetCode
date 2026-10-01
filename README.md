# LeetCode Practice (Go & Rust)

Collection of LeetCode algorithmic problem solutions implemented in both Go and Rust with unit test coverage.

## Project Structure

```text
leetcode/
├── schedule.json                                      # Problem roadmap and topic mapping
├── daily.mjs                                          # CLI utility for schedule tracking & scaffolding
├── leetcode/
│   ├── 00_warmup/
│   │   └── 1_two_sum/
│   │       ├── main.go
│   │       ├── main_test.go
│   │       └── solution.rs
│   ├── 01_two_pointers_and_sliding_window/
│   │   ├── 15_3sum/
│   │   └── 167_two_sum_ii_input_array_is_sorted/
│   │       ├── main.go
│   │       ├── main_test.go
│   │       └── solution.rs
│   ├── 02_monotonic_stacks_and_binary_search/
│   ├── 03_trees_and_graphs/
│   └── 04_backtracking_and_dp/
```

## Running Tests

### Go

```bash
# Run all tests across the repository
go test ./...

# Run tests for a specific problem package
go test -v ./leetcode/01_two_pointers_and_sliding_window/167_two_sum_ii_input_array_is_sorted

# Run main directly
go run ./leetcode/01_two_pointers_and_sliding_window/167_two_sum_ii_input_array_is_sorted
```

### Rust

```bash
# Run all test suites
cargo test

# Run tests for a specific problem target
cargo test --bin p167

# Run binary directly
cargo run --bin p167
```

## Daily Helper CLI

```bash
# Show current scheduled problem and official daily challenge
node daily.mjs today

# Scaffold starter files for a problem number
node daily.mjs scaffold 15

# View roadmap schedule
node daily.mjs plan
```
