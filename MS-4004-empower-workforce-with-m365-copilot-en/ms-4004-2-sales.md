# Microsoft Copilot Demo for Sales: Exercise 1

## Demo Overview

In this scenario, a sales representative uses Microsoft Copilot to prepare a proposal for a new customer through the following activities.

1. Research the market and competitors
2. Discuss the direction of the sales proposal
3. Create a customer proposal
4. Draft an email to the customer

> **Demo flow: Research → Think → Create → Communicate**

The total demo duration is 50 minutes.

---

## Demo Structure

| Exercise | Presentation Time | End-User Situation | App or Agent | Prompt to Enter | Expected Outcome |
|---|---:|---|---|---|---|
| **Exercise 1-1: Research the market and competitors** | 13 min | A sales representative is preparing a proposal for a new healthcare organization and wants to quickly understand Japan's healthcare digital transformation (DX) market, customer challenges, and developments at leading companies. | [Researcher](https://copilot.cloud.microsoft/agents/researcher) | #Prompt for Exercise 1-1 | A research report with sources covering market trends, challenges facing healthcare organizations, and the characteristics of leading companies. |
| **Exercise 1-2: Discuss the direction of the sales proposal** | 10 min | After researching the market, the sales representative wants to consult Copilot about what to propose and organize potential approaches. | [Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home) | #Prompt for Exercise 1-2 | An organized overview of customer challenges, key selling points, and questions to ask the customer. |
| **Exercise 1-3: Create a customer proposal** | 15 min | With the proposal direction established, the representative wants to draft a proposal for an initial discussion with the healthcare organization. | [Word](https://word.cloud.microsoft/) | #Prompt for Exercise 1-3 | An initial proposal draft covering background, customer challenges, potential solutions, expected benefits, and next steps. |
| **Exercise 1-4: Draft an email to the customer** | 10 min | With the proposal ready, the representative wants to contact the prospective customer and request a 30-minute meeting to introduce it. | [Outlook Mail](https://outlook.cloud.microsoft/mail/) | #Prompt for Exercise 1-4 | A polite, concise new email draft with proposal highlights and a meeting request. |
| **Exercise 1 Summary** | 2 min | Review the sales activities and how to connect multiple Copilot features into a business process. | - | - | Understand the Research, Think, Create, Communicate sales workflow. |
| **Total** | **50 min** |  |  |  |  |

---

## Prompt for Exercise 1-1

### Tool

[Open Researcher](https://copilot.cloud.microsoft/agents/researcher)

### Situation

Research Japan's healthcare DX market, challenges facing healthcare organizations, and developments at leading companies in preparation for a proposal to a new healthcare organization.

### Prompt

```text
Research the healthcare digital transformation (DX) market in Japan.

Focus on the following areas.

1. Key market trends in electronic medical records, healthcare information systems, and operational efficiency for clinics
2. Major challenges facing healthcare organizations
3. Leading companies involved in healthcare DX and their characteristics based on publicly available information
4. Solutions likely to see growing demand among healthcare organizations
5. Points a sales representative should focus on when considering a customer proposal

Base your answer on publicly available information and cite your sources.
Distinguish facts from assumptions, and do not make definitive statements about information that cannot be verified.
```

### Expected Outcome

Researcher generates a research report covering topics such as:

- Healthcare DX market trends in Japan
- Common challenges facing healthcare organizations
- Characteristics of leading companies and solutions
- Future market opportunities
- Points to consider in a sales proposal
- Referenced sources

### Demo Delivery Tips

Researcher may take time to generate a report.

For the demo, you can prerecord the following sequence and use a video with the waiting time removed.

1. Enter the prompt
2. Start the research
3. Show the processing screen for a few seconds
4. Cut the waiting time
5. Display the completed report
6. Review the report structure and sources

---

## Prompt for Exercise 1-2

### App

[Open Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home)

### Situation

After researching the market, consult Copilot about what to propose to the customer as a sales representative.

In this demo, start a new chat about a general sales scenario without using past emails, Teams chats, or customer files.

### Prompt

```text
As a sales representative proposing healthcare DX solutions to healthcare organizations, organize the key points to focus on in an initial proposal.

Divide your response into the following three sections.

1. Common challenges healthcare organizations may face
2. Key selling points for the proposal
3. Questions to ask to understand the customer's situation

Because circumstances vary by customer, do not make definitive statements about customer-specific challenges.
Keep the content practical and concise so it can be used for initial customer discovery and proposal preparation.
```

### Expected Outcome

A new chat with Copilot organizes the following:

- Potential customer challenges
- Selling points for the sales proposal
- Questions to ask during the initial discovery meeting
- Items to adjust based on the customer's situation

### Follow-Up Prompt

If the response is long, use the following prompt to make it more concise.

```text
Organize this content into a one-page checklist that a sales representative can review before an initial customer visit.
```

---

## Prompt for Exercise 1-3

### App

[Open Word](https://word.cloud.microsoft/)

### Situation

Based on the proposal direction for the healthcare organization, create a new proposal draft for an initial discussion.

Start with a blank Word document without using existing customer files.

### Prompt

```text
Create a draft healthcare DX proposal for a healthcare organization.

Use the following structure.

1. Background
2. Common challenges facing healthcare organizations
3. Potential solutions
4. Expected benefits
5. Items to confirm when considering implementation
6. Next steps

Use a concise, clear, professional style suitable for an initial customer discussion.

Do not make definitive statements about the customer's specific circumstances. Mark items that require individual confirmation as "To be confirmed."
Avoid excessive use of specific product or service names, and focus on customer challenges and expected outcomes.
```

### Expected Outcome

Word generates an initial proposal draft covering:

- Why healthcare DX is needed
- Common challenges facing healthcare organizations
- Potential approaches to addressing them
- Expected operational benefits
- Items to confirm with the customer
- Steps toward the next meeting

### Follow-Up Prompt: Shorten the Text

```text
Shorten the opening section to about half its length so it can be used as an executive summary.
```

### Follow-Up Prompt: Adapt for Executives

```text
Rewrite the content with fewer technical terms and a stronger focus on operational benefits so that healthcare executives can understand it quickly.
```

---

## Prompt for Exercise 1-4

### App

[Open Outlook Mail](https://outlook.cloud.microsoft/mail/)

### Situation

With the proposal ready, create a new email to the prospective customer requesting a 30-minute meeting to introduce it.

Start a new email without using an existing email thread.

### Prompt

```text
Draft an email to a healthcare customer requesting a 30-minute meeting to introduce a healthcare DX proposal.

Include the following.

1. The purpose of reaching out
2. The key points of the proposal you would like to introduce
3. A request for a 30-minute meeting
4. A question about their availability

Present the proposal highlights concisely in no more than three points.
Use polite, natural English that does not sound overly sales-oriented.
Because the customer's current challenges have not been confirmed, do not make definitive statements about their specific circumstances.
```

### Expected Outcome

Outlook creates a new email draft covering:

- The purpose of reaching out
- An overview of the healthcare DX proposal
- Expected value for the customer
- A request for a 30-minute meeting
- A question about possible meeting times

### Follow-Up Prompt: Make It Shorter

```text
Make the overall email a little shorter so it is easy to read as an initial outreach message.
```

### Follow-Up Prompt: Adjust the Tone

```text
Make the message less sales-oriented and use a softer tone that suggests an exchange of information.
```

---

## Exercise 1 Summary

This demo explores a sales representative's workflow in four stages.

| Stage | Sales Activity | Tool |
|---|---|---|
| **Research** | Research the market, customer challenges, and leading companies | [Researcher](https://copilot.cloud.microsoft/agents/researcher) |
| **Think** | Organize the customer proposal and discovery questions | [Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home) |
| **Create** | Draft a customer proposal | [Word](https://word.cloud.microsoft/) |
| **Communicate** | Draft an email requesting a customer appointment | [Outlook Mail](https://outlook.cloud.microsoft/mail/) |

> The key point of this exercise is to connect research, consideration, deliverable creation, and customer communication into a single workflow, rather than using individual Copilot features in isolation.

---

## App Links

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
