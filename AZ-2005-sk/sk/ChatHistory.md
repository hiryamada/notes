
# `ChatHistory`

## `ChatHistory`

https://learn.microsoft.com/en-US/semantic-kernel/concepts/ai-services/chat-completion/chat-history?pivots=programming-language-csharp

`ChatHistory`オブジェクトは、チャット セッション内のメッセージのレコードを保持するために使用されます。 

ユーザー、アシスタント、ツール、システムなど、さまざまな作成者からのメッセージを格納するために使用されます。 

メッセージを送受信するための主要なメカニズムとして、`ChatHistory`オブジェクトは、会話のコンテキストと継続性を維持するために不可欠です。

## 使用例1

https://learn.microsoft.com/ja-JP/semantic-kernel/concepts/ai-services/chat-completion/chat-history?pivots=programming-language-csharp#creating-a-chat-history-object

```c#
using Microsoft.SemanticKernel.ChatCompletion;

// Create a chat history object
ChatHistory chatHistory = [];

chatHistory.AddSystemMessage("You are a helpful assistant.");
chatHistory.AddUserMessage("What's available to order?");
chatHistory.AddAssistantMessage("We have pizza, pasta, and salad available to order. What would you like to order?");
chatHistory.AddUserMessage("I'd like to have the first option, please.");
```

## 使用例2

https://learn.microsoft.com/en-us/semantic-kernel/concepts/agents?pivots=programming-language-csharp#personas-giving-your-agent-a-job-description

```c#
// Create chat history
ChatHistory chatMessages = new ChatHistory("""
    You are a friendly assistant who likes to follow the rules. You will complete required steps
    and request approval before taking any consequential actions. If the user doesn't provide
    enough information for you to complete a task, you will keep asking questions until you have
    enough information to complete the task.
    """);
chatMessages.AddUserMessage("Can you help me write an email for my boss?");

// Get the response from the AI
var result = await chatCompletionService.GetChatMessageContentAsync(
    history,
    executionSettings: openAIPromptExecutionSettings,
    kernel: kernel
);
```

## 「自動関数呼び出し」との関連

https://learn.microsoft.com/ja-JP/semantic-kernel/concepts/ai-services/chat-completion/chat-history?pivots=programming-language-csharp#creating-a-chat-history-object

自動関数呼び出しが有効になっているチャット完了サービスにチャット履歴オブジェクトを渡すたびに、関数呼び出しと結果が含まれるようにチャット履歴オブジェクトが操作されます。

これにより、これらのメッセージをチャット履歴オブジェクトに手動で追加する必要がなくなります。また、チャット履歴オブジェクトを調べて関数の呼び出しと結果を確認することもできます。

ただし、チャット履歴オブジェクトに最後のメッセージを追加する必要があります。

```c#
using Microsoft.SemanticKernel.ChatCompletion;

ChatHistory chatHistory = [
    new() {
        Role = AuthorRole.User,
        Content = "Please order me a pizza"
    }
];

// Get the current length of the chat history object
int currentChatHistoryLength = chatHistory.Count;

// Get the chat message content
ChatMessageContent results = await chatCompletionService.GetChatMessageContentAsync(
    chatHistory,
    kernel: kernel
);

// Get the new messages added to the chat history object
for (int i = currentChatHistoryLength; i < chatHistory.Count; i++)
{
    Console.WriteLine(chatHistory[i]);
}

// Print the final message
Console.WriteLine(results);

// Add the final message to the chat history object
chatHistory.Add(results);
```
