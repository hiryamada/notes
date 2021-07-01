Azure Queue Storage

[製品ページ](https://azure.microsoft.com/ja-jp/services/storage/queues/)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/storage/queues/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/storage/queues/)

[Microsoft Learn](https://docs.microsoft.com/ja-jp/learn/modules/communicate-between-apps-with-azure-queue-storage/)

# Azure Service Bus と Azure Queue Storage の比較

→[こちら](mod10-01-servicebus.md)


# Blob トリガーの問題をQueueで解決

https://tech-lab.sios.jp/archives/7505

# プログラミング例(.NET)

https://docs.microsoft.com/ja-jp/azure/storage/queues/storage-dotnet-how-to-use-queues


デキュー（メッセージの取り出し）にはGetMessage(s) / ReceiveMessage(s)を使用する。

# Azure SDK for .NET v11

GetMessage / GetMessages

https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.storage.queue.cloudqueue?view=azure-dotnet-legacy

```
GetMessages(int messageCount, TimesSpan? visibilityTimeout)
```
count: 最大32
timeout: デフォルト30秒

# Azure SDK for .NET v12

※[ラボ11ではこちらを使用しています](https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_11_lab_ak.html)

ReceiveMessage / ReceiveMessages

https://docs.microsoft.com/ja-jp/dotnet/api/azure.storage.queues.queueclient?view=azure-dotnet

```
ReceiveMessages(int? count, TimeSpan? visibilityTimeout)
```