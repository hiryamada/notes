
# Microsoft Copilot Demo for Customer Service: Exercise 2

## Demo Overview

In this scenario, a customer service representative receives a customer inquiry about a product or service.

Use Microsoft Copilot to organize the inquiry, troubleshoot the issue, draft a response, and turn the support interaction into reusable knowledge.

1. Organize the customer's inquiry
2. Troubleshoot the issue
3. Draft a customer response
4. Organize the support interaction as reusable knowledge

> **Demo flow: Understand → Troubleshoot → Respond → Learn**

The total demo duration is 50 minutes.

---

## Demo Structure

| Exercise | Presentation Time | End-User Situation | App or Agent | Prompt to Enter | Expected Outcome |
|---|---:|---|---|---|---|
| **Exercise 2-1: Organize the inquiry** | 10 min | A customer reports being unable to sign in to a cloud service. The representative first wants to organize what to check to narrow down the issue. | [Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home) | #Prompt for Exercise 2-1 | Initial information to confirm, such as the problem details, scope of impact, conditions, and errors. |
| **Exercise 2-2: Troubleshoot the issue** | 15 min | Having gathered basic information from the customer, the representative wants to organize possible causes and verification steps. | [Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home) | #Prompt for Exercise 2-2 | Possible causes organized, with troubleshooting steps starting from low-impact checks. |
| **Exercise 2-3: Draft a customer response** | 12 min | With verification steps organized, the representative wants to create a response that a customer without technical expertise can understand. | [Outlook Mail](https://outlook.cloud.microsoft/mail/) | #Prompt for Exercise 2-3 | A polite, clear email draft covering items to verify and steps toward resolution. |
| **Exercise 2-4: Turn the support interaction into knowledge** | 11 min | The representative wants to document the approach so other representatives can handle similar inquiries in the future. | [Word](https://word.cloud.microsoft/) | #Prompt for Exercise 2-4 | A draft knowledge article covering symptoms, checks, possible causes, resolution steps, and escalation criteria. |
| **Exercise 2 Summary** | 2 min | Review the flow from receiving an inquiry to creating reusable knowledge. | - | - | Understand the Copilot-assisted customer service workflow: **Understand → Troubleshoot → Respond → Learn**. |
| **Total** | **50 min** |  |  |  |  |

---

# Exercise 2-1: Organize the Inquiry

## App

[Open Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home)

## Situation

Assume a customer sends the following inquiry.

> I can no longer sign in to the cloud service.
> It was working fine until yesterday.
> An error appears when I try to sign in.
> I use it for work, so I would like to resolve this as soon as possible.

Because information is still limited, work with Copilot to organize the questions needed to narrow down the issue rather than jumping to conclusions about the cause.

## Prompt

```text
A customer has sent the following inquiry.

"I can no longer sign in to the cloud service.
It was working fine until yesterday.
An error appears when I try to sign in.
I use it for work, so I would like to resolve this as soon as possible."

As a customer service representative, organize the questions to ask the customer to narrow down the issue.

Include the following areas.

1. When the problem started
2. Scope of affected users
3. Devices and apps being used
4. The error message displayed
5. Recent changes
6. Checks or troubleshooting already performed
7. Business impact

Do not draw conclusions about the cause at this stage. Prioritize the additional questions to ask.
```

## Expected Outcome

Questions for narrowing down the issue are organized.

For example:

- Is one user affected or are multiple users affected?
- Does it also happen in the web version?
- Can it be reproduced on another device?
- What is the exact error message?
- Have the password or account settings recently changed?
- Does it still happen on a different network?
- Is work completely blocked?

> The important point at this stage is not to have Copilot immediately provide an answer, but to organize the information needed to resolve the issue.

---

# Exercise 2-2: Troubleshoot the Issue

## App

[Open Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home)

## Situation

Assume additional checks have established the following.

- Only one user is affected
- The service worked until yesterday
- The user cannot sign in through a web browser either
- Another user can use the same service normally
- The network connection itself is working
- The user recently changed their password
- An error message appears

Use this information to organize possible causes and safe verification steps.

## Prompt

```text
Additional checks have established the following.

- Only one user is affected
- The service worked until yesterday
- The user cannot sign in through a web browser either
- Another user can use the same service normally
- The network connection itself is working
- The user recently changed their password
- An error message appears during sign-in

Based on this information, organize possible causes and troubleshooting steps to verify them.

Use the following format.

1. Possible cause
2. Reason for suspecting this cause
3. How to verify it
4. What to check next if the issue is not resolved

Order the steps so safe, low-impact checks come first.

If information is insufficient, do not draw definitive conclusions about the cause; indicate what else needs to be verified.
```

## Expected Outcome

Possible causes and a step-by-step approach to narrowing down the issue are organized.

The goal is not simply to obtain an answer stating "This is the cause," but to support the troubleshooting approach:

**Hypothesis → Verification → Result → Next hypothesis**

## Follow-Up Prompt

```text
To minimize customer impact, narrow the initial checks down to three.

Explain what each check helps distinguish or rule out.
```

---

# Exercise 2-3: Draft a Customer Response

## App

[Open Outlook Mail](https://outlook.cloud.microsoft/mail/)

## Situation

The items to verify and the troubleshooting direction have been organized.

Next, draft a new email describing the checks you would like the customer to perform.

Do not use an existing email thread.

## Prompt

```text
Draft a reply to a customer who reported being unable to sign in to a cloud service.

The following is currently known.

- Only one user is affected
- The service worked until yesterday
- The user cannot sign in through a web browser either
- Another user can use the service normally
- The affected user recently changed their password

Include the following in the email.

1. Thanks for contacting us
2. The currently confirmed situation
3. Additional items we would like the customer to check
4. A request to reply with the results
5. Reassurance that we will continue assisting if the issue persists

Avoid definitive statements because the cause has not been confirmed.

Use polite, concise English that a customer without IT expertise can understand.
```

## Expected Outcome

Outlook creates an email draft that can be reviewed before sending it to the customer.

Demonstrate the transformation from:

**Troubleshooting information for technical staff**

to:

**Communication the customer can understand and act on**

## Follow-Up Prompt: Make It Shorter

```text
Make the email a little shorter while preserving the content.
```

## Follow-Up Prompt: Make It Clearer

```text
Reduce technical language and present the actions for the customer as numbered steps.
```

---

# Exercise 2-4: Turn the Support Interaction into Knowledge

## App

[Open Word](https://word.cloud.microsoft/)

## Situation

Assume the support interaction is now complete.

Organize the troubleshooting information into a knowledge article so another representative can handle similar inquiries.

Start with a new Word document without using existing files.

## Prompt

```text
Create a knowledge article for customer service representatives about the inquiry "Unable to sign in to a cloud service."

Use the following structure.

1. Symptoms
2. Initial checks
3. Main possible causes
4. Troubleshooting steps
5. Checks to ask the customer to perform
6. Additional checks if the issue remains unresolved
7. Criteria for escalating to a specialist
8. Support considerations

Do not assume a single cause. Make the content suitable for narrowing down the issue while verifying the situation.

Keep the document concise and practical so a customer service representative new to the role can use it.
```

## Expected Outcome

Word generates a reusable draft knowledge article.

It organizes topics such as:

- Symptoms
- Initial checks
- Possible causes
- Diagnostic steps
- Checks to request from the customer
- Escalation criteria
- Considerations

## Follow-Up Prompt

```text
Add a "First five things to check" checklist at the beginning so representatives can review it quickly while handling an inquiry.
```

---

# Exercise 2 Summary

This demo explored how a customer service representative moves from receiving an inquiry to turning the support approach into reusable knowledge.

| Stage | Customer Service Activity | Tool |
|---|---|---|
| **Understand** | Organize the inquiry and identify missing information | [Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home) |
| **Troubleshoot** | Organize possible causes and verification steps | [Microsoft 365 Copilot Chat](https://copilot.cloud.microsoft/home) |
| **Respond** | Create a response the customer can understand | [Outlook Mail](https://outlook.cloud.microsoft/mail/) |
| **Learn** | Turn the support approach into reusable knowledge | [Word](https://word.cloud.microsoft/) |

> The key point of this exercise is not to leave problem resolution itself to Copilot, but to organize the situation, develop hypotheses, verify them safely, and clearly communicate the results to customers and other representatives.

---

# Demo Delivery Tips

This exercise does not use actual customer information or inquiry history.

- Actual customer data: Not used
- Existing Outlook emails: Not used
- Existing Teams chats: Not used
- Actual support tickets: Not used
- Existing knowledge articles: Not used

Including the exercise's inquiry details directly in the prompts minimizes advance data preparation.

When troubleshooting actual systems, do not make changes based solely on Copilot's responses. Consult official product documentation and your organization's support procedures before taking action.

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
