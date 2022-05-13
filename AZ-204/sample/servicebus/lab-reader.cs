// ラボ https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_lab_10.html
// の、メッセージ受信側プログラムの改良版。

// パッケージを以下のように追加。

// dotnet add package Azure.Messaging.ServiceBus
// dotnet add package Azure.Identity

// コードを実行する開発者のID（VM等でこのプログラムを動かす場合はVM等のマネージドID）に
// 「Azure Service Bus のデータ受信者」ロールを割り当て。

using Azure.Messaging.ServiceBus;
using Azure.Identity;

const string queueName = "messagequeue";

async Task MessageHandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine($"Received: {body}");
    await args.CompleteMessageAsync(args.Message);
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}

var endpoint = "sbnamespace9283723.servicebus.windows.net";
var credential = new DefaultAzureCredential();
await using var client = new ServiceBusClient(endpoint, credential);
await using var processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

await processor.StartProcessingAsync();
Console.WriteLine("Wait for a minute and then press any key to end the processing");
Console.ReadKey();

Console.WriteLine("\nStopping the receiver...");
await processor.StopProcessingAsync();
Console.WriteLine("Stopped receiving messages");
