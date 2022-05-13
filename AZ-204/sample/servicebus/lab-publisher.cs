// ラボ https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_lab_10.html
// の、メッセージ送信側プログラムの改良版。

// パッケージを以下のように追加。

// dotnet add package Azure.Messaging.ServiceBus
// dotnet add package Azure.Identity

// コードを実行する開発者のID（VM等でこのプログラムを動かす場合はVM等のマネージドID）に
// 「Azure Service Bus のデータ送信者」ロールを割り当て。

using Azure.Messaging.ServiceBus;
using Azure.Identity;

const string queueName = "messagequeue";
const int numOfMessages = 3;

var endpoint = "sbnamespace9283723.servicebus.windows.net";
var credential = new DefaultAzureCredential();
await using var client = new ServiceBusClient(endpoint, credential);
await using var sender = client.CreateSender(queueName);
using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

for (int i = 1; i <= numOfMessages; i++)
{
    if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
    {
        throw new Exception($"The message {i} is too large to fit in the batch.");
    }
}

await sender.SendMessagesAsync(messageBatch);
Console.WriteLine($"A batch of {numOfMessages} messages has been published to the queue.");
