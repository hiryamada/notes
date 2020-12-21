Azure Event Hubs

Event Hubs は、発行/サブスクライブ通信パターンの仲介役です。 

Event Grid とは異なり、非常に高いスループット、多数の発行元、セキュリティ、および回復性に対して最適化されています。

1 秒間に何百万ものイベントを受信して処理することができます。

イベント ハブに送信されたデータは、任意のリアルタイム分析プロバイダーやバッチ処理/ストレージ アダプターを使用して、変換および保存できます。


[製品ページ](https://azure.microsoft.com/ja-jp/services/event-hubs/)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/event-hubs/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-about)



# [Event Hubs Kafkaエンドポイント](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-for-kafka-ecosystem-overview)

Event Hubs によって、Apache Kafka のプロデューサーおよびコンシューマー API クライアントのバージョン 1.0 以降がサポートされています。

※[Apache Kafka](https://kafka.apache.org/): an open-source **distributed event streaming platform** used by thousands of companies for high-performance data pipelines, streaming analytics, data integration, and mission-critical applications. [Kafka was originally developed by LinkedIn, and was subsequently open sourced in early 2011.](https://en.wikipedia.org/wiki/Apache_Kafka) 

# パブリッシャー

イベント パブリッシャーは、HTTPS、AMQP 1.0、または Kafka 1.0 以降を使用してイベントを発行できます。 

# コンシューマー

Event Hubs のすべてのコンシューマーは AMQP 1.0 セッションを介して接続します。

# イベント

イベントを個別に発行することも、複数のイベントを一括して発行すること (バッチ) もできます。 


単一イベントまたはバッチのどちらであるかには関係なく、単一パブリケーション (イベント データ インスタンス) には 1 MB の制限があります。 このしきい値より大きいイベントを発行すると、エラーが発生します。


# パーティション

パーティションの数は作成時に 1 - 32 の間で指定する必要があります。

**パーティションの数は変更できない**ため、設定については長期的な規模で検討する必要があります。 

作成時点では、選択可能な最大値 (32) に設定しておくとよいでしょう。 Event Hubs チームに連絡すれば、パーティションの数を 32 より大きくすることができます。

複数のパーティションがある場合、イベントは、その順序を維持せずに、複数のパーティションに送信されることに注意してください。

Event Hubs 内にあるパーティションの数に対して料金はかかりません。

# パーティションキー

[Event Hubs によって、1 つのパーティション キー値を共有するすべてのイベントが、正しい順序で同じパーティションに確実に配信されます。](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-features)

# [名前空間](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-get-connection-string)

Event Hubs を使用するには、Event Hubs の名前空間を作成する必要があります。 名前空間は、複数のイベント ハブまたは Kafka トピック用のスコープ コンテナーです。 この名前空間より、一意の FQDN が提供されます。 名前空間を作成した後は、Event Hubs との通信に必要な接続文字列を取得できます。

`Endpoint=sb://dummynamespace.servicebus.windows.net/;SharedAccessKeyName=DummyAccessKeyName;SharedAccessKey=5dOntTRytoC24opYThisAsit3is2B+OGY1US/fuL3ly=`

https://docs.microsoft.com/ja-jp/azure/databricks/spark/latest/structured-streaming/streaming-event-hubs

```C#
// Without an entity path
val without = "Endpoint=<endpoint>;SharedAccessKeyName=<key-name>;SharedAccessKey=<key>"

// With an entity path
val with = "Endpoint=sb://<sample>;SharedAccessKeyName=<key-name>;SharedAccessKey=<key>;EntityPath=<eventhub-name>"
```

```C#
private const string connectionString = "<EVENT HUBS NAMESPACE - CONNECTION STRING>";
private const string eventHubName = "<EVENT HUB NAME>";

var producerClient = new EventHubProducerClient(connectionString, eventHubName)
```


# イベントの削除

[イベントを明示的に削除することはできません。](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-features#partitions)

# イベントインジェスター

Event Hubs represents the "front door" for an event pipeline, often called an event ingestor in solution architectures. 

Event Hubs はイベント パイプラインの "玄関口" を表し、ソリューション アーキテクチャでは "イベント インジェスター" と呼ばれることがよくあります。 

An event ingestor is a component or service that sits between event publishers and event consumers to decouple the production of an event stream from the consumption of those events. 

イベント インジェスターとは、イベント ストリームの生成とそのようなイベントの消費とを分離するために、イベント パブリッシャーとイベント コンシューマーとの間に置かれるコンポーネントやサービスです。 

([injest](https://ejje.weblio.jp/content/ingest): 摂取する、取り込む、受け入れる)

Event Hubs provides a unified streaming platform with time retention buffer, decoupling event producers from event consumers.

Event Hubs は、時間保持バッファーを備えた統合ストリーミング プラットフォームを提供し、イベント プロデューサーをイベント コンシューマーから切り離します。


# 診断設定

[診断設定をLog Analyticsワークスペース、Event Hubs、Azure Storageアカウントへ送信することができます。](https://docs.microsoft.com/ja-jp/azure/azure-monitor/platform/diagnostic-settings#destinations)

# [スループットユニット](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-scalability#throughput-units)

Event Hubs のスループット容量は、"スループット ユニット" によって制御されます。 スループット ユニットとは、購入済みの容量ユニットのことです。 1 つのスループットでは次が可能です。

- イングレス: 1 秒あたり最大で 1 MB または 1,000 イベント (どちらか先に到達した方)
- エグレス: 1 秒あたり最大で 2 MB または 4,096 イベント

購入済みのスループット ユニットの容量を超えると、イングレスが調整され、ServerBusyException が返されます。 エグレスではスロットル例外は発生しませんが、購入済みのスループット ユニットの容量に制限されます。

# .NET SDK

[イベント送受信の例（.NET）](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-dotnet-standard-getstarted-send#send-events)


送信
```
var producerClient = new EventHubProducerClient(connectionString, eventHubName)

using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First event")));

await producerClient.SendAsync(eventBatch);

```

受信

```


```


[4.1.0以前と5.0.0以降](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-availability-and-consistency?tabs=latest)

[EventHubClient](https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.eventhubs.eventhubclient?view=azure-dotnet) - [SendAsync(EventData)](https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.eventhubs.eventhubclient.sendasync?view=azure-dotnet#Microsoft_Azure_EventHubs_EventHubClient_SendAsync_Microsoft_Azure_EventHubs_EventData_)

[EventHubProducerClient](https://docs.microsoft.com/ja-jp/dotnet/api/azure.messaging.eventhubs.producer.eventhubproducerclient?view=azure-dotnet)

[EventHubConsumerClient](https://docs.microsoft.com/en-us/dotnet/api/azure.messaging.eventhubs.consumer.eventhubconsumerclient?view=azure-dotnet)


# [Event Hub Capture](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-capture-overview)


Azure Event Hubs を利用すると、Event Hubs のストリーミング データをご自分で選択した**Azure Blob Storage アカウント**または **Azure Data Lake Storage Gen 1 / Gen 2 アカウント** (Azure Blob storage or Azure Data Lake Storage Gen 1 or Gen 2 account of your choice) に自動的に配信できます。

その際、時間やサイズの間隔を柔軟に指定できます。

Capture の設定は手軽で、実行に伴う管理コストは生じません。また、Event Hubs のスループット単位に応じて自動的にスケールします。

Event Hubs Capture はストリーミング データを Azure に読み込む最も簡単な方法であり、これを利用すれば、データのキャプチャではなくデータの処理に注力できるようになります。