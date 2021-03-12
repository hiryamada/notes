/*
dotnet new console -n ServiceBusReceiver
cd ServiceBusReceiver
dotnet add package Azure.Messaging.ServiceBus --version 7.1.1
*/

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

void Print(object value)
{
    Console.WriteLine(value);
}

string Read(string prompt)
{
    Print(prompt);
    return Console.ReadLine();
}

// メッセージハンドラー
async Task MessageHandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Print($"Received: {body}");

    // complete the message. messages is deleted from the queue. 
    await args.CompleteMessageAsync(args.Message);
}

// エラーハンドラー
Task ErrorHandler(ProcessErrorEventArgs args)
{
    Print(args.Exception.ToString());
    return Task.CompletedTask;
}

var connectionString = Read("Service Bus名前空間の共有アクセスポリシーの接続文字列を入力: ");
var queueName = Read("Service Busキューの名前を入力: ");

var client = new ServiceBusClient(connectionString);
var processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

// メッセージハンドラーとエラーハンドラーを追加
processor.ProcessMessageAsync += MessageHandler;
processor.ProcessErrorAsync += ErrorHandler;

// start processing 
await processor.StartProcessingAsync();

Print("メッセージを受信中です。メッセージがキューに到着すれば表示されます。なにかキーを押すとメッセージの受信処理を停止してプログラムを終了します");
Console.ReadKey();

Print("\nメッセージの受信を停止しています。しばらくお待ち下さい（30秒ほどかかります）...");
await processor.StopProcessingAsync();
Print("停止しました");
