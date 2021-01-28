# Azure Event Grid

フル マネージドのイベント ルーティング サービスです。

Blob Storage などのさまざまなソースから Azure Functions や Webhook などのさまざまなハンドラーにイベントを配布します。


[製品ページ](https://azure.microsoft.com/ja-jp/services/event-grid/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/event-grid/overview)

[料金](https://azure.microsoft.com/ja-jp/pricing/details/event-hubs/)

Microsoft Learn

- [ご自分のサービスにゆるく接続するために Azure でメッセージング モデルを選ぶ](https://docs.microsoft.com/ja-jp/learn/modules/choose-a-messaging-model-in-azure-to-connect-your-services/)

- [Event Grid を使用して Azure サービスの状態の変更に対応する](https://docs.microsoft.com/ja-jp/learn/modules/react-to-state-changes-using-event-grid/)

# SDK(レガシー)

[Microsoft.Azure.EventHubs](https://www.nuget.org/packages/Microsoft.Azure.Management.EventHub/)

> Development of this library has shifted focus to the Azure Unified SDK. The future development will be focused on "Azure.ResourceManager.EventHubs" (Azure.ResourceManager.EventHubs).

[Azure Event Hubs の .NET プログラミング ガイド (レガシー Microsoft.Azure.EventHubs パッケージ)](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-programming-guide)

※注意：[ラボ10ではこちらを使用しています](https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_10_lab_ak.html)

# SDK(新)

[Azure.Messaging.EventHubs](https://www.nuget.org/packages/Azure.Messaging.EventHubs/)

[Azure Event Hubs との間でイベントを送受信する](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-dotnet-standard-getstarted-send)

