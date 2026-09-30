#!/usr/bin/env node

import fs from 'fs';
import path from 'path';
import { fileURLToPath } from 'url';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

// Load .env if present
try {
  process.loadEnvFile(path.join(__dirname, '.env'));
} catch (e) {
  // ignore
}

// Colors for terminal output
const bold = (s) => `\x1b[1m${s}\x1b[0m`;
const green = (s) => `\x1b[32m${s}\x1b[0m`;
const cyan = (s) => `\x1b[36m${s}\x1b[0m`;
const yellow = (s) => `\x1b[33m${s}\x1b[0m`;
const magenta = (s) => `\x1b[35m${s}\x1b[0m`;
const blue = (s) => `\x1b[34m${s}\x1b[0m`;
const red = (s) => `\x1b[31m${s}\x1b[0m`;
const gray = (s) => `\x1b[90m${s}\x1b[0m`;

// Load Schedule
const schedulePath = path.join(__dirname, 'schedule.json');
let schedule = [];
if (fs.existsSync(schedulePath)) {
  schedule = JSON.parse(fs.readFileSync(schedulePath, 'utf8'));
}

// Helper to query LeetCode GraphQL
async function queryLeetCode(query, variables = {}) {
  const cookie = process.env.LEETCODE_SESSION || '';
  const headers = {
    'Content-Type': 'application/json',
    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36'
  };
  if (cookie) {
    headers['Cookie'] = `LEETCODE_SESSION=${cookie}`;
  }

  try {
    const res = await fetch('https://leetcode.com/graphql', {
      method: 'POST',
      headers,
      body: JSON.stringify({ query, variables })
    });
    if (!res.ok) throw new Error(`HTTP ${res.status}`);
    return await res.json();
  } catch (err) {
    return null;
  }
}

// Fetch official daily challenge
async function fetchDailyChallenge() {
  const query = `query questionOfToday {
    activeDailyCodingChallengeQuestion {
      date
      link
      question {
        questionFrontendId
        title
        titleSlug
        difficulty
        topicTags { name }
        content
      }
    }
  }`;
  const data = await queryLeetCode(query);
  return data?.data?.activeDailyCodingChallengeQuestion || null;
}

// Fetch problem details by titleSlug
async function fetchProblemDetails(titleSlug) {
  const query = `query questionData($titleSlug: String!) {
    question(titleSlug: $titleSlug) {
      questionFrontendId
      title
      titleSlug
      difficulty
      content
      topicTags { name }
      codeSnippets {
        lang
        langSlug
        code
      }
    }
  }`;
  const data = await queryLeetCode(query, { titleSlug });
  return data?.data?.question || null;
}

// Get user profile/status
async function fetchUserStatus() {
  const query = `query globalData {
    userStatus {
      userId
      username
      isSignedIn
      isPremium
    }
  }`;
  const data = await queryLeetCode(query);
  return data?.data?.userStatus || null;
}

// Get user profile submission stats
async function fetchUserStats(username) {
  const query = `query userProfileUserQuestionProgressV2($userSlug: String!) {
    userProfileUserQuestionProgressV2(userSlug: $userSlug) {
      numAcceptedQuestions {
        difficulty
        count
      }
      numFailedQuestions {
        difficulty
        count
      }
      numUntouchedQuestions {
        difficulty
        count
      }
    }
  }`;
  const data = await queryLeetCode(query, { userSlug: username });
  return data?.data?.userProfileUserQuestionProgressV2 || null;
}

// Get recent AC submissions
async function fetchRecentAcSubmissions(username, limit = 5) {
  const query = `query recentAcSubmissions($username: String!, $limit: Int!) {
    recentAcSubmissionList(username: $username, limit: $limit) {
      id
      title
      titleSlug
      timestamp
    }
  }`;
  const data = await queryLeetCode(query, { username, limit });
  return data?.data?.recentAcSubmissionList || [];
}

// Get today's ISO date string (YYYY-MM-DD)
function getTodayIso(offsetDays = 0) {
  const now = new Date();
  if (offsetDays !== 0) {
    now.setDate(now.getDate() + offsetDays);
  }
  const yr = now.getFullYear();
  const mo = String(now.getMonth() + 1).padStart(2, '0');
  const da = String(now.getDate()).padStart(2, '0');
  return `${yr}-${mo}-${da}`;
}

// Clean HTML tags for markdown/terminal
function htmlToPlainText(html) {
  if (!html) return '';
  return html
    .replace(/<pre>([\s\S]*?)<\/pre>/gi, '\n```\n$1\n```\n')
    .replace(/<code>(.*?)<\/code>/gi, '`$1`')
    .replace(/<strong[^>]*>(.*?)<\/strong>/gi, '**$1**')
    .replace(/<em[^>]*>(.*?)<\/em>/gi, '*$1*')
    .replace(/<li[^>]*>(.*?)<\/li>/gi, '• $1\n')
    .replace(/<p[^>]*>/gi, '\n')
    .replace(/<\/p>/gi, '\n')
    .replace(/&le;/g, '≤')
    .replace(/&ge;/g, '≥')
    .replace(/&lt;/g, '<')
    .replace(/&gt;/g, '>')
    .replace(/&nbsp;/g, ' ')
    .replace(/&amp;/g, '&')
    .replace(/&quot;/g, '"')
    .replace(/&#39;/g, "'")
    .replace(/<[^>]+>/g, '')
    .replace(/\n{3,}/g, '\n\n')
    .trim();
}

// Command: Today / Point
async function showToday() {
  const todayIso = getTodayIso();
  console.log('\n' + '='.repeat(70));
  console.log(bold(cyan(`  🚀 DAILY LEETCODE POINTER (Go + Rust Dual Track)`)));
  console.log(gray(`  Current Date: ${todayIso} | Local System Time`));
  console.log('='.repeat(70) + '\n');

  // Check login / cookie status
  const userStatus = await fetchUserStatus();
  if (userStatus && userStatus.isSignedIn) {
    console.log(green(`  ✓ LeetCode Logged In as: ${bold(userStatus.username)}${userStatus.isPremium ? ' [Premium]' : ''}`));
    const stats = await fetchUserStats(userStatus.username);
    if (stats?.numAcceptedQuestions) {
      const counts = stats.numAcceptedQuestions;
      const easy = counts.find((c) => c.difficulty === 'EASY')?.count || 0;
      const med = counts.find((c) => c.difficulty === 'MEDIUM')?.count || 0;
      const hard = counts.find((c) => c.difficulty === 'HARD')?.count || 0;
      const total = easy + med + hard;
      console.log(`    Total Solved: ${bold(total)} (${green('Easy: ' + easy)}, ${yellow('Med: ' + med)}, ${red('Hard: ' + hard)})`);
    }
    const recent = await fetchRecentAcSubmissions(userStatus.username, 3);
    if (recent.length > 0) {
      console.log(`    Recent Accepted: ${recent.map((r) => cyan(r.title)).join(', ')}`);
    }
    console.log('');
  } else {
    console.log(yellow(`  ℹ LeetCode Session: Using public API mode.`));
    console.log(gray(`    Tip: LEETCODE_SESSION is configured in .env and mcp_config.json.\n`));
  }

  // 1. Roadmap Target Problem
  let targetPlan = schedule.find((s) => s.isoDate === todayIso);
  let isKickoffTomorrow = false;

  if (!targetPlan) {
    const tomorrowIso = getTodayIso(1);
    targetPlan = schedule.find((s) => s.isoDate === tomorrowIso) || schedule[0];
    isKickoffTomorrow = true;
  }

  console.log(bold(magenta(`  [1] ROADMAP TARGET PROBLEM ${isKickoffTomorrow ? '(Kickoff Tomorrow, Oct 1)' : '(Today\'s Scheduled Target)'}:`)));
  if (targetPlan) {
    console.log(`      Day #${targetPlan.dayIndex}: ${bold(targetPlan.dateLabel)}`);
    console.log(`      ${cyan(targetPlan.phaseTitle)}`);
    if (targetPlan.type === 'problem') {
      console.log(`      Problem:    ${bold(yellow(`#${targetPlan.number} ${targetPlan.title}`))}`);
      console.log(`      URL:        ${cyan(targetPlan.url)}`);
      console.log(`      Local Dir:  leetcode/${targetPlan.folder}/${targetPlan.number}_${targetPlan.slug}/`);
    } else {
      console.log(`      Review:     ${bold(yellow(targetPlan.title))}`);
      console.log(`      Topic:      Spaced Review / Idiomatic Comparisons`);
    }
  }

  // 2. Official LeetCode Daily Challenge
  console.log('\n' + bold(blue(`  [2] OFFICIAL LEETCODE DAILY CHALLENGE (Live from LeetCode):`)));
  const daily = await fetchDailyChallenge();
  if (daily && daily.question) {
    const q = daily.question;
    const diffColor = q.difficulty === 'Easy' ? green : q.difficulty === 'Medium' ? yellow : red;
    console.log(`      Problem:    ${bold(`#${q.questionFrontendId} ${q.title}`)} [${diffColor(q.difficulty)}]`);
    console.log(`      Topics:     ${(q.topicTags || []).map((t) => t.name).join(', ')}`);
    console.log(`      URL:        ${cyan('https://leetcode.com' + daily.link)}`);
  } else {
    console.log(gray('      Unable to fetch official daily challenge (check network connection).'));
  }

  // Execution Protocol Guide
  console.log('\n' + bold(yellow(`  ⏱ STRICT 45-MINUTE EXECUTION PROTOCOL (04:00 - 05:00 AM):`)));
  console.log(`      ${bold('00–05 min')}: Whiteboard trace, pointer diagramming, edge cases`);
  console.log(`      ${bold('05–20 min')}: ${green('Go implementation')} (explicit loops, slice ranges, stdlib primitives)`);
  console.log(`      ${bold('20–40 min')}: ${magenta('Rust rewrite')} (ownership, iterators, Option/Result, zero unneeded .clone())`);
  console.log(`      ${bold('40–45 min')}: Git commit with complexity and memory model comparisons\n`);

  console.log(gray(`  Commands:`));
  console.log(gray(`    node daily.mjs scaffold          -> Scaffold folder and boilerplate for today's roadmap problem`));
  console.log(gray(`    node daily.mjs scaffold daily    -> Scaffold folder and boilerplate for official daily challenge`));
  console.log(gray(`    node daily.mjs plan              -> View the upcoming schedule roadmap`));
  console.log('='.repeat(70) + '\n');
}

// Command: Scaffold problem folder and starter files
async function scaffoldProblem(arg) {
  let targetSlug = null;
  let folderName = '01_two_pointers_and_sliding_window';

  const todayIso = getTodayIso();
  let targetPlan = schedule.find((s) => s.isoDate === todayIso);
  if (!targetPlan) {
    targetPlan = schedule.find((s) => s.isoDate === getTodayIso(1)) || schedule[0];
  }

  if (arg === 'daily') {
    const daily = await fetchDailyChallenge();
    if (!daily || !daily.question) {
      console.error(red('Failed to fetch official daily challenge.'));
      return;
    }
    targetSlug = daily.question.titleSlug;
    folderName = 'daily_challenges';
  } else if (arg && isNaN(Number(arg))) {
    targetSlug = arg;
  } else if (arg && !isNaN(Number(arg))) {
    const num = Number(arg);
    const found = schedule.find((s) => s.number === num);
    if (found) {
      targetSlug = found.slug;
      folderName = found.folder;
    } else {
      console.error(red(`Problem #${num} not found in roadmap schedule.`));
      return;
    }
  } else {
    // Default to target plan
    if (targetPlan && targetPlan.type === 'problem') {
      targetSlug = targetPlan.slug;
      folderName = targetPlan.folder;
    }
  }

  if (!targetSlug) {
    console.error(red('No valid problem slug determined to scaffold.'));
    return;
  }

  console.log(cyan(`\nFetching problem details for "${targetSlug}" from LeetCode...`));
  const problem = await fetchProblemDetails(targetSlug);
  if (!problem) {
    console.error(red(`Could not fetch details for "${targetSlug}".`));
    return;
  }

  const probNum = problem.questionFrontendId;
  const dirName = `${probNum}_${targetSlug.replace(/-/g, '_')}`;
  const targetDir = path.join(__dirname, 'leetcode', folderName, dirName);

  fs.mkdirSync(targetDir, { recursive: true });
  console.log(green(`Created directory: ${path.relative(__dirname, targetDir)}`));

  // Extract Go and Rust snippets
  let goCode = (problem.codeSnippets || []).find((s) => s.lang === 'Go')?.code || `// func solution(...) {\n// }\n`;
  if (goCode && !goCode.includes('panic("not implemented")')) {
    goCode = goCode.replace(/\{\s*\}/g, '{\n\tpanic("not implemented")\n}');
  }
  let rustCode = (problem.codeSnippets || []).find((s) => s.lang === 'Rust')?.code || `pub struct Solution;\nimpl Solution {\n}\n`;
  if (rustCode && !rustCode.includes('todo!')) {
    rustCode = rustCode.replace(/\{\s*\}/g, '{\n        todo!()\n    }');
  }

  // 1. Generate main.go
  const goContent = `package main

import (
	"fmt"
)

// LeetCode #${probNum}: ${problem.title}
// Difficulty: ${problem.difficulty}
// URL: https://leetcode.com/problems/${targetSlug}/

${goCode}

func main() {
	fmt.Println("--- LeetCode #${probNum}: ${problem.title} (Go) ---")
	// TODO: Add test execution cases
}
`;
  fs.writeFileSync(path.join(targetDir, 'main.go'), goContent, 'utf8');
  console.log(green(`  ✓ Generated main.go`));

  // 2. Generate solution.rs
  const rustContent = `//! LeetCode #${probNum}: ${problem.title}
//! Difficulty: ${problem.difficulty}
//! URL: https://leetcode.com/problems/${targetSlug}/

pub struct Solution;

${rustCode}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_example() {
        // TODO: Add test assertions
    }
}

fn main() {
    println!("--- LeetCode #${probNum}: ${problem.title} (Rust) ---");
}
`;
  fs.writeFileSync(path.join(targetDir, 'solution.rs'), rustContent, 'utf8');
  console.log(green(`  ✓ Generated solution.rs`));

  // Register in root Cargo.toml if not already present
  const cargoPath = path.join(__dirname, 'Cargo.toml');
  if (fs.existsSync(cargoPath)) {
    const cargoContent = fs.readFileSync(cargoPath, 'utf8');
    const binName = `p${probNum}`;
    if (!cargoContent.includes(`name = "${binName}"`)) {
      const relPath = path.relative(__dirname, path.join(targetDir, 'solution.rs')).replace(/\\/g, '/');
      const binEntry = `\n[[bin]]\nname = "${binName}"\npath = "${relPath}"\n`;
      fs.appendFileSync(cargoPath, binEntry, 'utf8');
      console.log(green(`  ✓ Registered [[bin]] "${binName}" in Cargo.toml`));
    }
  }

  // 3. Generate README.md
  const plainText = htmlToPlainText(problem.content);
  const readmeContent = `# #${probNum}. ${problem.title}

- **Difficulty**: ${problem.difficulty}
- **Topics**: ${(problem.topicTags || []).map((t) => t.name).join(', ')}
- **LeetCode URL**: [https://leetcode.com/problems/${targetSlug}/](https://leetcode.com/problems/${targetSlug}/)

---

## 45-Minute Execution Protocol

- [ ] **00–05 min**: Whiteboard & Logic Trace (pointer diagrams, boundary conditions, edge cases).
- [ ] **05–20 min**: Go Implementation (\`main.go\`).
- [ ] **20–40 min**: Rust Zero-Cost Implementation (\`solution.rs\`).
- [ ] **40–45 min**: Complexity Analysis & Local Git Commit.

---

## Problem Statement

${plainText}

---

## Approach & Diagram

### Intuition & Whiteboard Notes
-

### Complexity
- **Time Complexity**: \`O(...)\`
- **Space Complexity**: \`O(...)\`

### Go vs. Rust Language Comparisons
- **Go**:
- **Rust**:
`;
  fs.writeFileSync(path.join(targetDir, 'README.md'), readmeContent, 'utf8');
  console.log(green(`  ✓ Generated README.md`));

  console.log(bold(green(`\nScaffolding complete! Ready to start the 45-minute sprint.\n`)));
}

// Command: Plan
function showPlan(phaseArg) {
  console.log('\n' + '='.repeat(70));
  console.log(bold(cyan(`  📅 LEETCODE ROADMAP SCHEDULE (Oct 1, 2026 – Jan 20, 2027)`)));
  console.log('='.repeat(70) + '\n');

  let filtered = schedule;
  if (phaseArg) {
    const num = parseInt(phaseArg, 10);
    if (!isNaN(num)) {
      filtered = schedule.filter((s) => s.phaseNumber === num);
    }
  }

  let lastPhase = '';
  for (const item of filtered) {
    if (item.phaseTitle !== lastPhase) {
      console.log('\n' + bold(magenta(`--- ${item.phaseTitle} ---`)));
      lastPhase = item.phaseTitle;
    }
    const dayStr = item.dateLabel.padEnd(14, ' ');
    if (item.type === 'problem') {
      console.log(`  Day ${String(item.dayIndex).padStart(3, ' ')} | ${dayStr} | ${cyan(`#${String(item.number).padEnd(4, ' ')}`)} ${item.title}`);
    } else {
      console.log(`  Day ${String(item.dayIndex).padStart(3, ' ')} | ${dayStr} | ${yellow('[Review]')} ${item.title}`);
    }
  }
  console.log('\n' + '='.repeat(70) + '\n');
}

// CLI Routing
const args = process.argv.slice(2);
const cmd = args[0] || 'today';

if (cmd === 'today' || cmd === 'point') {
  await showToday();
} else if (cmd === 'scaffold') {
  await scaffoldProblem(args[1]);
} else if (cmd === 'plan') {
  showPlan(args[1]);
} else if (cmd === 'status') {
  await showToday();
} else {
  console.log(`Usage: node daily.mjs [today|scaffold|plan|status]`);
}
