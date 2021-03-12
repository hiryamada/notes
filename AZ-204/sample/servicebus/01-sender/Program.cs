/*
dotnet new console -n ServiceBusSender
cd ServiceBusSender
dotnet add package Azure.Messaging.ServiceBus --version 7.1.1
*/

using System;
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

var connectionString = Read("Service Bus名前空間の共有アクセスポリシーの接続文字列を入力: ");
var queueName = Read("Service Busキューの名前を入力: ");

var client = new ServiceBusClient(connectionString);
var sender = client.CreateSender(queueName);

do {
    var text = Read("メッセージの本文を入力: ");
    var message = new ServiceBusMessage(text);

    await sender.SendMessageAsync(message);

    Print("送信しました");

} while ("y".Equals(Read("さらにメッセージを送信しますか？(y/n): ")));
