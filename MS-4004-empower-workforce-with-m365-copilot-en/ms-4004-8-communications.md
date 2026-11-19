
# Microsoft Copilot Demo for Communications: Exercise 1

## Demo Overview

In this scenario, an internal communications professional informs employees about a new internal initiative.

Use Microsoft Copilot to gather information about the topic, draft an announcement, organize audience data, and create presentation materials.

1. Research information about an internal initiative
2. Draft an internal announcement
3. Organize audience data
4. Create a presentation for an information session

> **Demo flow: Research → Write → Organize → Present**

The total demo duration is 50 minutes.

---

## Demo Structure

| Exercise | Presentation Time | End-User Situation | App or Agent | Prompt to Enter | Expected Outcome |
|---|---:|---|---|---|---|
| **Exercise 1-1: Research information about the initiative** | 13 min | A new hybrid work initiative will be announced internally. To plan employee communications, the professional wants to research work trends and common challenges. | [Researcher](https://copilot.cloud.microsoft/agents/researcher) | #Prompt for Exercise 1-1 | Hybrid work trends, employee and organizational challenges, and communication considerations organized with sources. |
| **Exercise 1-2: Draft an internal announcement** | 13 min | Using the research as a reference, the professional wants to draft an internal announcement that clearly explains the new initiative to employees. | [Word](https://word.cloud.microsoft/) | #Prompt for Exercise 1-2 | An announcement covering the purpose, changes, employee impact, required actions, and contact information. |
| **Exercise 1-3: Organize communication audiences** | 10 min | Rather than only sending the same information to all employees, the professional wants to organize guidance according to location, work style, and other factors. | [Excel](https://excel.cloud.microsoft/) | #Prompt for Exercise 1-3 | Required communications and guidance organized by audience group. |
| **Exercise 1-4: Create information session materials** | 12 min | The professional wants to create a concise presentation for an employee information session about the new initiative. | [PowerPoint](https://powerpoint.cloud.microsoft/) | #Prompt for Exercise 1-4 | Presentation materials covering background, changes, employee impact, required actions, and FAQs. |
| **Exercise 1 Summary** | 2 min | Review the process from gathering information to communicating with employees. | - | - | Understand the Copilot-assisted communications workflow: **Research → Write → Organize → Present**. |
| **Total** | **50 min** |  |  |  |  |

---

# Exercise 1-1: Research Information About the Initiative

## Tool

[Open Researcher](https://copilot.cloud.microsoft/agents/researcher)

## Situation

Your organization is introducing a new hybrid work initiative.

Before planning employee communications, research recent hybrid work trends and key considerations when explaining the initiative to employees.

## Prompt

```text
Research recent trends in hybrid work.

Focus on the following areas.

1. Recent major hybrid work trends
2. Common challenges for employees
3. Common challenges for organizations
4. Information to communicate clearly to employees when introducing new ways of working
5. Considerations for internal communications
6. Common questions employees may ask

Base your answer on publicly available information and cite your sources.

Because policies and circumstances vary by company, distinguish general trends from individual company rules.
```

## Expected Outcome

Researcher creates a report covering topics such as:

- Hybrid work trends
- Employee challenges
- Organizational challenges
- Key points to communicate
- Anticipated questions
- Sources

## Demo Delivery Tips

Researcher may take time to generate a response.

You can prerecord a successful run and prepare a backup video with the waiting time removed.

---

# Exercise 1-2: Draft an Internal Announcement

## App

[Open Word](https://word.cloud.microsoft/)

## Situation

The research has clarified key considerations for employee communications.

Next, draft a document announcing the new hybrid work initiative to employees.

Start with a new Word document without using existing internal documents.

## Prompt

```text
Draft an internal announcement informing employees about a new hybrid work initiative.

Use the following structure.

1. Purpose of this announcement
2. Background to introducing new ways of working
3. What is changing
4. Main impact on employees
5. Actions employees are asked to take
6. Timeline leading up to the policy launch
7. Frequently asked questions
8. Contact information

Do not make definitive statements about specific company policies or dates, as these have not been confirmed.
Mark the relevant sections as "To be confirmed."

Use clear, approachable language so employees can understand the content quickly.
```

## Expected Outcome

Word creates a draft internal announcement covering topics such as:

- Purpose
- Background
- What is changing
- Employee impact
- Required actions
- Timeline
- FAQ
- Contact information

## Follow-Up Prompt: Make It Shorter

```text
Shorten the text while preserving the important content so employees can read it in about two minutes.
```

## Follow-Up Prompt: Improve the Opening

```text
Add a summary at the beginning of the document that makes the following clear at a glance.

"What is changing"
"When it is changing"
"What I need to do"
```

---

# Exercise 1-3: Organize Communication Audiences

## App

[Open Excel](https://excel.cloud.microsoft/)

## Situation

A basic announcement for all employees is ready.

However, the guidance needed may vary by work style, location, and other factors.

Use fictional demo audience data to organize communication audiences.

## Sample Data

For example, prepare an Excel file with the following columns.

- Employee ID
- Location
- Work Style
- Department
- Communication Status

Actual employee names and email addresses are not needed.

## Prompt

```text
Organize this employee communication audience data.

Assume we are announcing a new hybrid work initiative.

Organize the following.

1. Number of employees by location
2. Number of employees by work style
3. Number of employees by department
4. Employees who have not yet been notified
5. Items that may require additional explanation for different audience groups

Do not infer individuals' abilities, work attitudes, opinions, or similar characteristics.

Limit the analysis to the attributes and communication status recorded in the data.
```

## Expected Outcome

Information such as the following is organized:

- Number of employees by location
- Number of employees by work style
- Number of employees by department
- Communication Completed
- Communication Pending
- Information to confirm for each audience

## Follow-Up Prompt

```text
Make communication status easy to review by clearly organizing the following.

- Notified
- Not yet notified
```

## Follow-Up Prompt: Organize by Group

```text
For each work style, organize the following.

1. Information to communicate to everyone
2. Additional information that may need to be communicated to that group

Mark anything that cannot be determined from the source data alone as "To be confirmed."
```

---

# Exercise 1-4: Create Information Session Materials

## App

[Open PowerPoint](https://powerpoint.cloud.microsoft/)

## Situation

The employee announcement content and communication audiences have been organized.

Next, create a presentation explaining the new way of working to employees.

## Prompt

```text
Create an employee presentation explaining a new hybrid work initiative.

Include the following.

1. Why the change is happening
2. What is changing
3. What is not changing
4. Employee impact
5. Actions employees are asked to take
6. Timeline leading up to implementation
7. Frequently asked questions
8. Contact information

Use a concise, easy-to-understand structure suitable for an information session of about 15 minutes.

Mark any unconfirmed company-specific rules or dates as "To be confirmed."

Rather than focusing only on detailed policy explanations, prioritize helping employees understand:

"What is changing"
"How it affects me"
"What I need to do"
```

## Expected Outcome

PowerPoint creates a presentation with a structure such as:

1. New ways of working
2. Background to the changes
3. What is changing
4. What is not changing
5. Employee impact
6. Required actions
7. Timeline
8. FAQ
9. Contact information

## Follow-Up Prompt: Emphasize the Key Messages

```text
Structure the opening slides so the following three points are immediately clear.

"What is changing"
"When it is changing"
"What employees need to do"
```

---

# Exercise 1 Summary

This demo explored how an internal communications professional moves from gathering information to delivering clear messages to employees.

| Stage | Communications Activity | Tool |
|---|---|---|
| **Research** | Research information about the topic | [Researcher](https://copilot.cloud.microsoft/agents/researcher) |
| **Write** | Draft an internal announcement | [Word](https://word.cloud.microsoft/) |
| **Organize** | Organize communication audiences | [Excel](https://excel.cloud.microsoft/) |
| **Present** | Create employee presentation materials | [PowerPoint](https://powerpoint.cloud.microsoft/) |

> The key point of this exercise is not to let Copilot decide internal policy itself, but to gather the necessary information, organize audiences and messages, and turn them into communications that are easy for the audience to understand.

---

# Demo Delivery Tips

This exercise is designed not to depend on actual internal communications data.

- Actual employee data: Not used
- Existing emails: Not used
- Existing Teams chats: Not used
- Existing internal documents: Not used
- Viva Engage: Not used
- Idea Coach: Not used
- Agent Builder: Not used

Only Exercise 1-3 uses a sample Excel file containing about 15-20 fictional records.

The two main preparation items are:

1. A sample Excel file of communication audiences
2. Backup results from Researcher

## Tips for Preparing the Sample Excel File

Personal names and email addresses are not needed.

Data such as the following is sufficient.

| Employee ID | Location | Work Style | Department | Communication Status |
|---|---|---|---|---|
| E001 | Tokyo | Hybrid | Sales | Completed |
| E002 | Osaka | Office | Finance | Pending |
| E003 | Tokyo | Remote | Marketing | Pending |
| E004 | Nagoya | Hybrid | IT | Completed |

This allows you to demonstrate the communications task of:

**"Organizing who needs to receive which information"**

without handling actual employee information.

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
