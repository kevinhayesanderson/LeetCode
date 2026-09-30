# LeetCode Systems Engineering Practice (Go + Rust Dual Track)

Personal daily LeetCode practice repository for Kevin, structured around the **112-Day Systems Engineering Roadmap** (October 1, 2026 – January 20, 2027) with dual implementations in **Go** and **Rust**.

---

## 📅 Daily Execution Routine (04:00 – 05:00 AM)

| Day Type | Time Slot | Focus Area |
| :--- | :--- | :--- |
| **Mon – Sat** | **04:00 – 05:00 AM** | **1 Problem: Dual-Language (Go + Rust)** |
| **Sunday** | **04:00 – 05:00 AM** | **Spaced Review & Language Idiom Comparisons** |

### Strict 45-Minute Sprint Protocol

- **00–05 min**: **Whiteboard & Logic Trace** (pointer diagramming, invariants, edge cases).
- **05–20 min**: **Go Implementation** (`main.go`): explicit loops, slice ranges, standard library primitives.
- **20–40 min**: **Rust Rewrite** (`solution.rs`): ownership, iterator chaining, `Option`/`Result`, references, zero unneeded `.clone()`.
- **40–45 min**: **Review & Local Git Commit**: complexity and memory model comparisons.

---

## 📁 Repository Structure

```text
leetcode/
├── schedule.json                                      # Complete 112-day parsed roadmap
├── daily.mjs                                          # CLI pointer & scaffolding tool
├── leetcode/
│   ├── 01_two_pointers_and_sliding_window/            # Phase 1: Oct 1 – Oct 28
│   │   └── 167_two_sum_ii_input_array_is_sorted/
│   │       ├── README.md                              # Problem statement, approach & analysis
│   │       ├── main.go                                # Idiomatic Go solution & test runner
│   │       └── solution.rs                            # Memory-safe Rust solution & test suite
│   ├── 02_monotonic_stacks_and_binary_search/         # Phase 2: Oct 29 – Nov 25
│   ├── 03_trees_and_graphs/                           # Phase 3: Nov 26 – Dec 23
│   └── 04_backtracking_and_dp/                        # Phase 4: Dec 24 – Jan 20
```

---

## 🛠️ CLI Commands

Run directly inside `C:\Users\kevin\source\repos\leetcode`:

```bash
# 1. Point to today's roadmap problem & official daily challenge
node daily.mjs today
# or:
npm run today

# 2. Automatically scaffold folder & starter files for today's roadmap problem
node daily.mjs scaffold
# or for a specific problem number:
node daily.mjs scaffold 15

# 3. Scaffold the official LeetCode Daily Challenge
node daily.mjs scaffold daily

# 4. View the full roadmap schedule or filter by phase (1 to 4)
node daily.mjs plan
node daily.mjs plan 1
```

---

## 🔌 LeetCode MCP Server Integration

The LeetCode MCP server (`@jinzcdev/leetcode-mcp-server`) is installed globally and configured in Antigravity:
`C:\Users\kevin\.gemini\config\mcp_config.json`

### To Connect Your Logged-In Chrome Session (Optional)
If you want to track private submissions, solve status, and sync notes:
1. Open Google Chrome where you are logged into LeetCode.
2. Press `F12` (Developer Tools) -> select the **Application** tab.
3. In the left sidebar, expand **Cookies** -> select `https://leetcode.com`.
4. Copy the value of the `LEETCODE_SESSION` cookie.
5. Set `LEETCODE_SESSION` in your system environment variables or add it to `mcp_config.json`:
   ```json
   {
     "mcpServers": {
       "leetcode": {
         "command": "node",
         "args": [
           "C:\\Users\\kevin\\AppData\\Roaming\\npm\\node_modules\\@jinzcdev\\leetcode-mcp-server\\build\\index.js",
           "--site", "global"
         ],
         "env": {
           "LEETCODE_SITE": "global",
           "LEETCODE_SESSION": "<PASTE_YOUR_COOKIE_HERE>"
         }
       }
     }
   }
   ```
