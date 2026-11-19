---
lab:
    title: 'Delegate work with Microsoft Copilot Cowork.'
    description: 'Hands-on lab guide for end-to-end testing of all eight Microsoft Copilot Cowork scenarios — from prompt to confirmed result.'
    duration: 120 minutes
    level: L300
    islab: true
    status: 'in-development' 
    targetDate: 2026-07-31 
---
<!--
Edit the metadata above to manage the list of exercises in the home page of the GitHub site that gets generated.
You can delete the module and edit index.md in the root of the repo to customize the display so that only the exercises are listed
To enable GitHub page publishing, edit the Page settings for the repo and publish from the main branch
-->

# Delegate work with Microsoft Copilot Cowork

In this exercise you will run end-to-end testing of all eight Microsoft Copilot Cowork scenarios — from prompt to confirmed result.

This exercise should take approximately **120** minutes to complete. <!-- update with estimated duration -->

## Before you start

<!--
Add steps to get the learner to the starting point" for the exercise. This might be cloning the repo and running a script or performing some manual steps.

Only include this section if its necessary to do some pre-exercise setup AND the same setup steps are required for self-paced (on Learn) and managed (in hosted ILT lab profiles) scenarios. Otherwise delete this section.
If self-paced /ILT-specific setup steps are required, include them in the Learn "Exercise" unit from where they open this exercise and in the Skillable lab profile instructions before this markdown file is imported.

Do not include requirements for getting an Azure (or other) subscription (write the exercise on the assumption the learner has a functioning lab environment - this section is only for exercise-specific steps to get to a starting point)

If there are complex setup steps that apply to ALL of the exercises in the repo (for example, installing and configuring client-side tools), create a separate 00-setup.md file with instructions.
 -->

Before you can start this exercise, you will need to...

1. Login to https://admin.microsoft.com as the MOD Admin with the credentials provided.
   > **Note**: In the pop-up window that says, "You need to set up multifactor authentication," select **Skip for now**.
1. Navigate to **Agents** > **Overview**
1. In the **Get early access to Agent 365 Frontier** banner, select **Join the Frontier program**.
1. Select **All users** > **Save**.
1. Select the **x** to close out the fly-out window.
1. Navigate to **Copilot** > **Cost management** on the left-hand side of the navigation menu.
1. Select **Get Started**.
1. In the pop-up window **Activate the default spending policy for your organization** mark the checkbox next to **Use Capacity Packs**.
1. Under **Set the monthly spending limit for this policy**, ensure **No limit** is selected.
1. Under the field **Select the monthly spending limit for users** select **Limit the monthly spending per user** put in **5,000**.
1. Select **Activate**.
1. Close out of the pop-up window. 

## Task 1:  Run a Read-Only Briefing

First, you need to ...

1. In a new InPrivate window navigate to https://copilot.cloud.microsoft.com and login as Megan Bowen with the credentials provided. 
1. In the middle of the page, on the chat box, ensure the **Cowork** tab is selected.
1. Select **+**. 
1. In the chat box, select **+** > **Add content**.
1. Select the **Files** tab. 
1. Select **Portfolio Status (current, post-decision).xlsx**.
1. In the chat box, select the **+** button > **Add content**.
1. Select the **Files** tab. 
1. Select **Summit Evidence Pack (outline).docx**.
1. In the chat box, select the **+** button > **Add content**.
1. Select the **Files** tab. 
1. Select **Beacon GA Hold - Decision Memo.docx**.
1. In the chat box, select the **+** button > **Add content**.
1. Select the **Emails** tab.
1. Select **Your weekly PIM digest for Contoso (ID: d9d00af5-1ecb-468f-b6e1-f8cc726eb19)**.
1. In the chat box, select the **+** button > **Add content**.
1. Select the **Emails** tab.
1. Select **Microsoft Entra ID Protection Weekly Digest**.
1. In the chat box, select the **+** button > **Add content**.
1. Select the **Chats** tab.
1. Select **Nestor, Patti**.
1. In the chat box, select the **+** button > **Add content**.
1. Select the **Chats** tab.
1. Select **Allan, Diego, Isaiah**.
1. In the chat box, select the **+** button > **Add content**.
1. Select the **Chats** tab.
1. Select **Alex, Allan, Diego**.
1. In the prompt field, copy and paste the following prompt:
   Give me a read-only briefing of where things stand right now. Look at my selected emails, Teams chats, and my open tasks. Don’t send or change anything — just tell me what needs my attention, what I might have missed, and what’s coming up. Group it as “Needs a decision,” “FYI,” and “Upcoming".
1.  Send the prompt by selecting the black circle with the white up-arrow in the bottom-right corner.
1. **Outcome:** Cowork should produce the following:
   
   - One chat briefing, organized into “Needs a decision,” “FYI,” and “Upcoming.”
     
    - Content is drawn from the attached emails and Teams chat, as well as your calendar, and tasks.
      
    - Nothing was sent or changed — no files produced.



## Task 2: Reconstruct Your Week

1. Still as Megan Bower, select **+ New** at the left-hand side of the navigation menu. 
1. In the prompt field, copy and paste the following prompt:
      Draft my weekly update for my manager. Reconstruct what I did this week from my sent email, completed tasks, the meetings I led, and my Teams threads. Structure it as Accomplished / Questions & where I need help / Looking ahead — and ground “Looking ahead” in my actual upcoming calendar and open tasks. Match my writing voice. Leave it as a draft for me to review — don’t send it.
1. Send the prompt by selecting the black circle with the hite up-arrow in the bottom-right corner.
1. **Outcome:** Cowork should produce the following:

    - Three sections are present and that each “Accomplished” item ties back to a real artifact, thread, or meeting.
       
### Task 2.1: Put It on a Schedule

1. In the same conversation, paste the following prompt in the chat box:
       Run this every Friday at 3 PM and drop the draft for my review — never auto-send.
1. When prompted under **Which time zone should the Friday 3PM run use?**, select **Pacific (American/Los_Angeles)** > **Submit**.
   > **Note**: Cowork may not respond with this step. If not, proceed to the next step.
1. Select **Schedule**.
1. **Outcome:** Cowork should produce a response like "Done! Every Friday at 3 PM Pacific, I'll rebuild your weekly update from that week's sent mail, meetings you led, and Teams threads — structured as Accomplished / Questions & where I need help / Looking ahead, in your voice — and leave it as a draft to Patti for your review. It will never auto-send; you always get the final say before it goes out".
   > **Note**: Cowork may respond with a different variation of the above response. This is expected.

## Task 3: Triage your Inbox

1. Still as Megan Bower, select **+ New** at the left-hand side of the navigation menu.
1. In the prompt field, copy and paste the following prompt:
      Triage my inbox. Sort everything into “Waiting on me,” “FYI,” and “Can be delegated.” For each “Waiting on me” item, draft a contextual reply but hold it for my approval — don’t send anything. Create follow-up tasks for anything that needs tracking.
1. Send the prompt by selecting the black circle with the white up-arrow in the bottom-right corner.
1. Cowork may display several message which says **Flag email?**, select **cancel** on all of them when prompted.
1. **Outcome:** Cowork should produce the following:
   
    -  A response with your inbox sorted into different buckets.
      
    -  Held reply drafts exist for “Waiting on me” items — no sends.

### Task 3.1: Run it Every Weekday

1. In the same conversation, paste the following prompt in the chat box:
      Run this every weekday at 8 AM. 
1. When prompted under **Which timezone should the 8 AM weekday triage run in??**, select **Pacific(PT) (American/Los_Angeles)** > **Submit**.
   > **Note**: Cowork may not respond with this step. If not, proceed to the next step.
1. Select **Schedule**.
1. **Outcome:** Cowork should produce a response like "Done! I'll triage your inbox every weekday (Mon–Fri) at 8 AM Pacific".
   > **Note**: Cowork may respond with a different variation of the above response. This is expected.
1. Log out of the as Megan from this browser and close out the window. 

## Task 4: Create a Meeting-to-Momentum Loop

1. In a new InPrivate window navigate to https://copilot.cloud.microsoft.com and login as **Joni Sherman** with the credentials provided.
   > **Note**: If you are still logged in as Megan Bowen, ensure you logout as Megan before opening a new InPrivate window and logging in as Joni Sherman. 
1. In the middle of the page, on the chat box, ensure the **Cowork** tab is selected.
1. In the chat box, type in the following prompt:
   For the Summit Evidence, pull the recaps and open action items from the recent instances, keep a running decision log, and draft the agenda for the next meeting from the unfinished items and prior decisions. Save the log and the agenda to my files.
1. Send the prompt by selecting the black circle with the white up-arrow in the bottom-right corner.
1. **Outcome:** Cowork should produce the following:
- A decision-log doc (or a running log) and a next-agenda doc are saved to files.
- The agenda reflects unfinished items and prior decisions.
> **Note**: You may get a response from Cowork notifying you that there is no Teams transcript or recording regarding the five Summit evidence meetings. This is expected behavior.  

## Task 5: Get updated information from within your organization

1. Still as Joni Sherman, select **+** at the left-hand side of the navigation menu.
1. In the prompt field, copy and paste the following prompt:
   I’ve been out for two weeks. Catch me up: what decisions were made, which threads moved, and what tasks came due while I was away. Build me a prioritized re-entry plan for my first day back, and draft catch-up replies for the threads that need me — hold them for my review.
1. Send the prompt by selecting the black circle with the white up-arrow in the bottom-right corner.
1. **Outcome:** Cowork should produce the following:
   
    - A recap covering decisions, moved threads, and due tasks.
      
    - A prioritized re-entry plan for the first day back.
  
    - Catch-up reply drafts held for review — no sends.
   > **Note**: You may get a response from Cowork notifying you that no information was found after as specific date, like August 4th. This is expected behavior.  

## Task 6: Create a Project Dashboard

1. Still as Joni Sherman, select **+** at the left-hand side of the navigation menu.
1. In the prompt field, copy and paste the following prompt:
  Build me a project status dashboard across my active projects. For each one, pull the status from the relevant threads, files, and task lists, and lay it out as a table: Project / Status (Red-Amber-Green) / Blockers / Next milestone / Owner. Save it to my files.
1.  Send the prompt by selecting the black circle with the white up-arrow in the bottom-right corner.
1. **Outcome:** Cowork should produce the following:
   
    - A saved five-column RAG status table across the active projects.
      
    -  Each status is backed by real threads, files, or tasks.
1. Log out as Joni and close the browser. 

 ## Task 7: Create a Project Status Update on a Specific Topic

1. In a new InPrivate window navigate to https://copilot.cloud.microsoft.com and login as **Alex Wilbur** with the credentials provided.
    > **Note**: If you are still logged in as Joni Sherman, ensure you logout as Joni before opening a new InPrivate window and logging in as Alex Wilbur. 
1. In the middle of the page, on the chat box, ensure the **Cowork** tab is selected.
1. In the prompt field, copy and paste the following prompt:
   Pull the source material for the Atlas Launch from my email, Teams, and files. Analyze the numbers in Excel, build a short PowerPoint readout of the findings, and export a one-page PDF brief. Save all three to my files.
1. Send the prompt by selecting the black circle with the white up-arrow in the bottom-right corner.
1. **Outcome:** Cowork should produce the following:
   
    - Three artifacts saved: Excel + PowerPoint + PDF.
      
    - The deck and PDF are consistent with the Excel analysis.

### Task 7.1 (Optional): Create a Monthly Read-Out

1. In the same conversation, paste the following prompt in the chat box:
      Turn this into a monthly read-out on a schedule.  
1. When prompted under **When should the monthly Atlas read-out?**, select any option such as  **1st business day, 8AM** > **Submit**.
1. When prompted under **Which time zone should the monthly 8 AM run use?**, select any option such as  **US Eastern** > **Submit**.
   > **Note**: Cowork may not respond with prompts as notes in steps 2 - 3 of this Task. If this is the case, proceed to the next step.
1. Select **Schedule**.
1. **Outcome:** Cowork should produce a response like "Done — the monthly Atlas Launch read-out is scheduled.". 
    > **Note**: Cowork may respond with a different variation of the above response. This is expected. 

## Task 8: Build-Your-Own Skill Challenges

1. Still s Alex Wilbur, select **+ New** in the top left hand navigation menu.
1. In the prompt field, copy and paste the following prompt:
  I'd like to build a skill that writes my status update regarding the Atlas Launch. 
1. Send the prompt by selecting the black circle with the white up-arrow in the bottom-right corner.
1. Work through the guided builder’s questions and save the skill to your library.
     > **Note**: Cowork may or may not ask guided questions prior to an output. If no builder questions are asked, proceed to the next task.
1. **Outcome:** Cowork should create and have the skill saved. The name of the skill may be similar to **atlas-launch-status**.

### Task 8.1: Trigger the Saved Skill

1. Select **+ New** at the top left of the navigation menu.
1. In the prompt field, copy and paste the following prompt:
   Write my Atlas status update for the weekly sync
1. Send the prompt by selecting the black circle with the white up-arrow in the bottom-right corner.
1. Cowork may respond with the following: I couldn't find any new Atlas Launch activity from Oct 26 to Nov 2. Your calendar shows only the daily Atlas Standups, with no notes or recordings. The latest Atlas emails and files are from Sept 29 to Oct 5. How should I write the update? Select **Widen to 30+ days**. Select **Submit**.
1. **Outcome:** Cowork should respond with a project status regarding the Atlas Launch. 

## Clean up

1. Sign out of all accounts and close all browsers.
1. In a new InPrivate window navigate to https://copilot.cloud.microsoft.com and login as Megan Bowen with the credentials provided. 
1. Navigate to **Recent** in the left hand navigation menu.
1. Select the first item which should be labeled something similar to **Inbox Triage with Reply Draft**.
1. Under **Scheduled task**,  next to **Weekly inbox triage** > select the **...** button > Select **Delete** > Select **Delete** again.
1. Navigate to **Recent** in the left hand navigation menu.
1. Select the second item which should be labeled something similar to **Weekly manager update Draft**.
1. Under **Scheduled task**,  next to **Weekly manager update draft** > select the **...** button > Select **Delete** > Select **Delete** again.
1. Sign out as Megan and close out all browsers.
1. In a new InPrivate window navigate to https://copilot.cloud.microsoft.com and login as Alex Wilbur with the credentials provided. 
1. Navigate to **Recent** in the left hand navigation menu.
1. Select the third item which should be labeled something similar to **Atlast Launch Source and Readout**.
1. Under **Scheduled task**,  next to **Atlas Launch monthly read-out** > select the **...** button > Select **Delete** > Select **Delete** again.
1. Now that you've finished the exercise, you should sign out of all accounts and close out of all browsers.

END OF LAB.

