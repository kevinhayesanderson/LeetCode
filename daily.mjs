#!/usr/bin/env node

import fs from 'fs';
import path from 'path';
import { fileURLToPath } from 'url';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

// Load .env if present
const envPath = path.join(__dirname, '.env');
if (fs.existsSync(envPath)) {
  try {
    process.loadEnvFile(envPath);
  } catch (e) {
    const content = fs.readFileSync(envPath, 'utf8');
    for (const line of content.split('\n')) {
      const match = line.match(/^\s*([\w.-]+)\s*=\s*(.*)?\s*$/);
      if (match) {
        process.env[match[1]] = match[2].trim();
      }
    }
  }
}

// Terminal styling
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

// LeetCode GraphQL query helper
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

// Command: Today / Point
async function showToday() {
  const todayIso = getTodayIso();
  console.log('\n' + '='.repeat(70));
  console.log(bold(cyan(`  LeetCode Daily Pointer (Go & Rust)`)));
  console.log(gray(`  Date: ${todayIso} | Local System Time`));
  console.log('='.repeat(70) + '\n');

  // Check login / cookie status
  const userStatus = await fetchUserStatus();
  if (userStatus && userStatus.isSignedIn) {
    console.log(green(`  [OK] LeetCode Account: ${bold(userStatus.username)}${userStatus.isPremium ? ' [Premium]' : ''}`));
    const stats = await fetchUserStats(userStatus.username);
    if (stats?.numAcceptedQuestions) {
      const counts = stats.numAcceptedQuestions;
      const easy = counts.find((c) => c.difficulty === 'EASY')?.count || 0;
      const med = counts.find((c) => c.difficulty === 'MEDIUM')?.count || 0;
      const hard = counts.find((c) => c.difficulty === 'HARD')?.count || 0;
      const total = easy + med + hard;
      console.log(`       Total Solved: ${bold(total)} (Easy: ${easy}, Med: ${med}, Hard: ${hard})`);
    }
    const recent = await fetchRecentAcSubmissions(userStatus.username, 3);
    if (recent.length > 0) {
      console.log(`       Recent Accepted: ${recent.map((r) => cyan(r.title)).join(', ')}`);
    }
    console.log('');
  } else {
    console.log(yellow(`  [INFO] Running in public mode.`));
    console.log(gray(`         Set LEETCODE_SESSION in .env for private account tracking.\n`));
  }

  // 1. Roadmap Target Problem
  let targetPlan = schedule.find((s) => s.isoDate === todayIso);
  let isKickoffTomorrow = false;

  if (!targetPlan) {
    const tomorrowIso = getTodayIso(1);
    targetPlan = schedule.find((s) => s.isoDate === tomorrowIso) || schedule[0];
    isKickoffTomorrow = true;
  }

  console.log(bold(magenta(`  [1] ROADMAP TARGET ${isKickoffTomorrow ? '(Kickoff Tomorrow, Oct 1)' : '(Today\'s Target)'}:`)));
  if (targetPlan) {
    console.log(`      Day #${targetPlan.dayIndex}: ${bold(targetPlan.dateLabel)}`);
    console.log(`      Phase:      ${targetPlan.phaseTitle}`);
    if (targetPlan.type === 'problem') {
      console.log(`      Problem:    #${targetPlan.number} ${targetPlan.title}`);
      console.log(`      URL:        ${cyan(targetPlan.url)}`);
      console.log(`      Directory:  leetcode/${targetPlan.folder}/${targetPlan.number}_${targetPlan.slug}/`);
    } else {
      console.log(`      Review:     ${bold(yellow(targetPlan.title))}`);
      console.log(`      Topic:      Spaced Review / Idioms`);
    }
  }

  // 2. Official LeetCode Daily Challenge
  console.log('\n' + bold(blue(`  [2] LEETCODE DAILY CHALLENGE:`)));
  const daily = await fetchDailyChallenge();
  if (daily && daily.question) {
    const q = daily.question;
    const diffColor = q.difficulty === 'Easy' ? green : q.difficulty === 'Medium' ? yellow : red;
    console.log(`      Problem:    #${q.questionFrontendId} ${q.title} [${diffColor(q.difficulty)}]`);
    console.log(`      Topics:     ${(q.topicTags || []).map((t) => t.name).join(', ')}`);
    console.log(`      URL:        ${cyan('https://leetcode.com' + daily.link)}`);
  } else {
    console.log(gray('      Unable to fetch daily challenge.'));
  }

  console.log('\n' + bold(yellow(`  TIMEBOX PROTOCOL (45 Minutes):`)));
  console.log(`      00–05 min: Logic trace, diagramming, edge cases`);
  console.log(`      05–20 min: Go implementation`);
  console.log(`      20–40 min: Rust implementation`);
  console.log(`      40–45 min: Complexity analysis & commit\n`);

  console.log(gray(`  Commands:`));
  console.log(gray(`    node daily.mjs scaffold          -> Scaffold files for today's roadmap problem`));
  console.log(gray(`    node daily.mjs scaffold daily    -> Scaffold files for official daily challenge`));
  console.log(gray(`    node daily.mjs plan              -> View the roadmap schedule`));
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
	fmt.Println("LeetCode #${probNum}: ${problem.title} (Go)")
}
`;
  fs.writeFileSync(path.join(targetDir, 'main.go'), goContent, 'utf8');
  console.log(green(`  - Generated main.go`));

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
    #[ignore = "not yet implemented"]
    fn test_example() {
        // Add test assertions
    }
}

fn main() {
    println!("LeetCode #${probNum}: ${problem.title} (Rust)");
}
`;
  fs.writeFileSync(path.join(targetDir, 'solution.rs'), rustContent, 'utf8');
  console.log(green(`  - Generated solution.rs`));

  // 3. Register in root Cargo.toml if not already present
  const cargoPath = path.join(__dirname, 'Cargo.toml');
  if (fs.existsSync(cargoPath)) {
    const cargoContent = fs.readFileSync(cargoPath, 'utf8');
    const binName = `p${probNum}`;
    if (!cargoContent.includes(`name = "${binName}"`)) {
      const relPath = path.relative(__dirname, path.join(targetDir, 'solution.rs')).replace(/\\/g, '/');
      const binEntry = `\n[[bin]]\nname = "${binName}"\npath = "${relPath}"\n`;
      fs.appendFileSync(cargoPath, binEntry, 'utf8');
      console.log(green(`  - Registered [[bin]] "${binName}" in Cargo.toml`));
    }
  }

  console.log(green(`\nScaffolding complete for #${probNum}.\n`));
}

// Command: Plan
function showPlan(phaseArg) {
  console.log('\n' + '='.repeat(70));
  console.log(bold(cyan(`  LeetCode Roadmap Schedule (Oct 1, 2026 – Jan 20, 2027)`)));
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
