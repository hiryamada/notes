
# Microsoft Copilot Demo for Finance: Exercise 1

## Demo Overview

In this scenario, a finance or accounting professional reviews departmental budgets and actuals, identifies items with large variances, and prepares for a stakeholder review.

Use Microsoft Copilot to review financial data, analyze variances, summarize key points, and communicate with stakeholders.

1. Review budgets and actuals
2. Analyze items with large variances
3. Summarize key points for the financial review
4. Draft a meeting message for stakeholders

> **Demo flow: Review → Analyze → Explain → Align**

The total demo duration is 50 minutes.

---

## Demo Structure

| Exercise | Presentation Time | End-User Situation | App or Agent | Prompt to Enter | Expected Outcome |
|---|---:|---|---|---|---|
| **Exercise 1-1: Review budgets and actuals** | 14 min | A finance professional wants to review departmental budgets and actuals for the monthly review and identify items with large variances. | [Excel](https://excel.cloud.microsoft/) | #Prompt for Exercise 1-1 | Budget variances and variance percentages calculated by department and expense category, with items requiring review identified. |
| **Exercise 1-2: Analyze potential causes of variances** | 14 min | Having identified large variances, the professional wants to organize discussion points and potential causes for the financial review. | [Analyst](https://copilot.cloud.microsoft/agents/analyst) | #Prompt for Exercise 1-2 | An overview of material variances, facts confirmed by the data, hypotheses about causes, and additional items to verify. |
| **Exercise 1-3: Summarize key points for the financial review** | 10 min | The professional wants to summarize the analysis so managers and department heads can understand it quickly. | [Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home) | #Prompt for Exercise 1-3 | A concise summary of major variances, business issues, items to confirm, and recommended next actions. |
| **Exercise 1-4: Draft a review meeting invitation** | 10 min | The professional wants to draft an invitation to a monthly financial review meeting to discuss the variances with stakeholders. | [Teams](https://teams.cloud.microsoft/) | #Prompt for Exercise 1-4 | A Teams message covering review objectives, items to confirm, preparation, and decisions to make during the meeting. |
| **Exercise 1 Summary** | 2 min | Review the process from checking financial data to preparing for a stakeholder review. | - | - | Understand the Copilot-assisted financial review workflow: **Review → Analyze → Explain → Align**. |
| **Total** | **50 min** |  |  |  |  |

---

# Exercise 1-1: Review Budgets and Actuals

## App

[Open Excel](https://excel.cloud.microsoft/)

## Situation

Review budgets and actuals for multiple departments in preparation for a monthly financial review.

Use a demo sample Excel file, not actual company data.

## Sample Data

Prepare the following columns in the sample Excel file.

- Month
- Department
- Expense Category
- Budget
- Actual
- Variance
- Variance Percentage
- Comment

`Variance` and `Variance Percentage` may be left blank. You can add them using Copilot.

## Prompt

```text
Perform the following tasks to analyze this budget-versus-actual data.

1. Add a "Variance" column calculated as actual minus budget
2. Add a variance percentage column relative to the budget
3. Identify items with large budget overruns
4. Identify items that are under budget
5. Summarize major trends by department and expense category
6. Highlight items that should receive priority in the financial review

If the causes of variances cannot be determined from the data alone, do not state them as facts; indicate that further verification is needed.
```

## Expected Outcome

Excel performs analyses such as:

- Calculating variances
- Calculating variance percentages
- Identifying over-budget items
- Identifying under-budget items
- Departmental trends
- Expense category trends
- Extracting items for review

> A large variance does not necessarily mean there is a problem. After Copilot organizes the numbers, people verify the background and business reasons.

## Follow-Up Prompt: Create a Chart

```text
Create a chart comparing budgets and actuals by department.

Choose a chart that clearly shows the differences between budgets and actuals.
```

## Follow-Up Prompt: Narrow Down the Priorities

```text
Considering both variance percentages and amounts, select five items to prioritize in the financial review.
```

---

# Exercise 1-2: Analyze Potential Causes of Variances

## Tool

[Open Analyst](https://copilot.cloud.microsoft/agents/analyst)

## Situation

Reviewing budget-versus-actual variances in Excel has revealed large variances across multiple departments and expense categories.

Next, organize the discussion points for the financial review.

In this exercise, add the sample Excel file used in Exercise 1-1 to Analyst.

## Prompt

```text
Analyze this budget-versus-actual data.

Focus on the following.

1. Items with large variances in monetary terms
2. Items with large variance percentages
3. Characteristics by department
4. Characteristics by expense category
5. Trends shared across multiple departments
6. Additional information needed to determine whether variances are temporary or ongoing trends
7. Questions to ask stakeholders during the financial review

Organize the analysis by distinguishing the following three categories.

- Facts confirmed by the data
- Hypotheses about possible causes
- Additional information to verify

Do not make definitive claims about causes that cannot be confirmed from the data alone.
```

## Expected Outcome

Analyst organizes information such as:

- Material budget variances
- Patterns by department and expense category
- Potential outliers
- Facts confirmed by the data
- Hypotheses about causes
- Additional information needed
- Questions for stakeholders

This exercise emphasizes **keeping facts separate from hypotheses**.

## Follow-Up Prompt

```text
Select three items from this analysis that may have a significant business impact.

For each, organize the following.

- Confirmed facts
- Potential impact
- Questions to verify the cause
- Recommended next actions
```

---

# Exercise 1-3: Summarize Key Points for the Financial Review

## App

[Open Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home)

## Situation

The budget-versus-actual analysis is complete.

Next, organize key points for the monthly review with managers and department heads.

Without using existing emails or meeting data, start a new chat to create a general financial review structure.

## Prompt

```text
Organize the key points for a monthly budget-versus-actual review.

Assume the analysis has identified material variances across multiple departments and expense categories.

Use the following structure.

1. Overall status
2. Variances to prioritize for review
3. Facts confirmed by the data
4. Items whose causes need verification
5. Questions for stakeholders
6. Recommended next actions
7. Items to verify before the next review

Do more than list numbers; help managers and department heads understand the issues quickly.

Avoid definitive statements about variances whose causes have not been confirmed.
```

## Expected Outcome

Key points for the financial review are organized.

For example:

- Overall status
- Material variances
- Confirmed facts
- Open questions
- Potential impact
- Recommended actions
- Follow-up items

## Follow-Up Prompt: Adapt for Executives

```text
Narrow the content down to no more than five key points that executives can review in about one minute.
```

## Follow-Up Prompt: Create a Question List

```text
Create seven questions for the financial review with department heads, ordered from highest to lowest priority.
```

---

# Exercise 1-4: Draft a Review Meeting Invitation

## App

[Open Teams](https://teams.cloud.microsoft/)

## Situation

The variance analysis and financial review discussion points have been organized.

Next, draft a Teams message communicating the purpose of the monthly financial review meeting and the required preparation.

Draft a new message without using existing Teams chats or meetings.

## Prompt

```text
Draft an invitation message to department heads for a monthly budget-versus-actual review meeting.

Include the following.

1. The purpose of the meeting
2. That we will review budget-versus-actual variances
3. The main issues we particularly want to discuss
4. What participants should review in advance
5. What we want to decide during the meeting
6. A request to prepare additional information as needed

Do not assume that a variance is a problem. Use a collaborative, concise tone focused on reviewing the background and next steps together.
```

## Expected Outcome

A draft message suitable for Teams is created.

The message includes:

- Meeting purpose
- Main review items
- Preparation
- Decisions to make during the meeting
- A request for cooperation

## Follow-Up Prompt: Make It Shorter

```text
Shorten the message for easy reading in Teams chat while preserving the important content.
```

## Follow-Up Prompt: Add an Agenda

```text
Add a concise agenda with time allocations for a 30-minute meeting.
```

---

# Exercise 1 Summary

This demo explored how a finance professional reviews budgets and actuals, organizes variance discussion points, and prepares for a stakeholder review.

| Stage | Finance Activity | Tool |
|---|---|---|
| **Review** | Review budgets and actuals | [Excel](https://excel.cloud.microsoft/) |
| **Analyze** | Analyze material variances and items to confirm | [Analyst](https://copilot.cloud.microsoft/agents/analyst) |
| **Explain** | Summarize key points for the financial review | [Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home) |
| **Align** | Communicate the purpose of the review meeting to stakeholders | [Teams](https://teams.cloud.microsoft/) |

> The key point of this exercise is not to delegate financial judgment to Copilot, but to verify numbers accurately, distinguish facts from hypotheses, and organize information so stakeholders can make their next decisions.

---

# Demo Delivery Tips

This exercise does not use actual financial data or existing internal communications.

- Actual budget-versus-actual data: Not used
- Existing financial materials: Not used
- Existing Outlook emails: Not used
- Existing Teams chats: Not used
- Existing meeting data: Not used
- Contracts or contract analysis: Not used

Exercises 1-1 and 1-2 use the same demo sample Excel file.

The two main preparation items are:

1. A sample budget-versus-actual Excel file
2. Backup results from Analyst

## Notes on Preparing Sample Data

Intentionally include characteristics such as the following to make the demo easier to explain.

- Items with large monetary amounts but small variance percentages
- Items with small monetary amounts but large variance percentages
- Increases in expense categories shared across multiple departments
- Under-budget items
- Items that appear to have temporary variances
- Items whose causes cannot be determined from the data alone

This enables a demo that considers amounts, variance percentages, trends, and business impact together, rather than looking only at the largest value.

---

# App Links

- [Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home)
- [Researcher](https://copilot.cloud.microsoft/agents/researcher)
- [Analyst](https://copilot.cloud.microsoft/agents/analyst)
- [Word](https://word.cloud.microsoft/)
- [Excel](https://excel.cloud.microsoft/)
- [PowerPoint](https://powerpoint.cloud.microsoft/)
- [Outlook Mail](https://outlook.cloud.microsoft/mail/)
- [Outlook Calendar](https://outlook.cloud.microsoft/calendar/)
- [Teams](https://teams.cloud.microsoft/)
- [Whiteboard](https://whiteboard.cloud.microsoft/)
