# Azure Service Bus

[製品ページ](https://azure.microsoft.com/ja-jp/services/service-bus/)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/service-bus/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-messaging-overview)

Microsoft Learn

- [Azure Service Bus を使用し、メッセージベースの通信ワークフローを実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-message-workflows-with-service-bus/)

# Azure Service Bus と Azure Queue Storage の比較

https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-azure-and-service-bus-queues-compared-contrasted

Service Bus:
- [キュー](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-quickstart-portal)にて、**ブローカー メッセージング通信**モデルをサポート（[メッセージブローカーの説明](https://docs.microsoft.com/ja-jp/azure/architecture/patterns/publisher-subscriber)）
- [トピックとサブスクリプション](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-quickstart-topics-subscriptions-portal)にて、**パブリッシュ/サブスクライブ** モデルをサポート。（参考：[Fanoutパターン](http://aws.clouddesignpattern.org/index.php/CDP:Fanout%E3%83%91%E3%82%BF%E3%83%BC%E3%83%B3)）
- **メッセージの順序をFIFOで保証できる**
- **キューのサイズは1～80GBの間で指定**
- メッセージの最大サイズは1MB
- 複数の通信プロトコル、データ コントラクト、信頼ドメイン、ネットワーク環境などにまたがるアプリケーションやアプリケーション コンポーネントの統合を目的としている
- セッション、トランザクション、重複削除（自動重複検出）などの高度な機能をサポート
- 複数のプロトコル(AMQP 1.0, JMS 1.0/2.0)をサポート

Queue Storage:
- **メッセージの順序は変わることがある**
- **キューのサイズは最大500TB**
- メッセージの最大サイズは64KB
- 非同期的な処理のバックログを作成（して、Queueに格納）
- アプリケーションコンポーネントを分離してスケーラビリティや対障害性を高めたり、負荷を平準化する目的で使用される
- ストレージアカウント 汎用v1/v2で使用できる
- HTTPベースのプロトコル: [REST API](https://docs.microsoft.com/ja-jp/rest/api/storageservices/queue-service-rest-api)

# [対応プロトコル](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-messaging-overview#compliance-with-standards-and-protocols)

AMQP 1.0, JMS 2.0(Service Bus Premium), JMS 1.0(Service Bus Standard)


# AMQP

https://www.amqp.org/

[AMQP 1.0の紹介とその重要な理由](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-amqp-overview) - AMQP 1.0 は、堅牢なクロス プラットフォーム メッセージング アプリケーションを作成するために使用できる、効率的で信頼性の高い回線レベルのメッセージング プロトコルです。AMQP 1.0 は国際標準であり、ISO および IEC によって、ISO/IEC 19464:2014 として承認されています。AMQP 1.0 は、2008 年以降、20 社を超える企業 (テクノロジ サプライヤーとエンド ユーザー企業の両方) で構成される中核的なグループにより開発されています。


[【仕様を読み解く】第1回 Advanced Message Queuing Protocol (1) ~Types~](https://buildersbox.corp-sansan.com/entry/2020/11/06/110000)

[【仕様を読み解く】第2回 Advanced Message Queuing Protocol (2) ~Transport~](https://buildersbox.corp-sansan.com/entry/2020/12/11/110000)


# Service Bus [キュー](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-messaging-overview#queues)

メッセージは キュー に送受信されます。 受信側アプリがメッセージを受信して処理できるようになるまで、キューがメッセージを格納します。

[QueueClient](https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.servicebus.queueclient?view=azure-dotnet)

`SendAsync(Message)`

# [Service Bus キューの作成](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-quickstart-portal#create-a-namespace-in-the-azure-portal)

「名前空間」を作成。このとき、Basic/Standard/Premiumを指定。

Premiumの場合は、メッセージングユニットの数を指定。ゾーン冗長を指定。

# Service Bus [トピック](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-messaging-overview#topics)

トピック を使用してメッセージを送受信することもできます。 キューはポイント間通信によく使用されますが、トピックは[パブリッシュ/サブスクライブ](https://ja.wikipedia.org/wiki/%E5%87%BA%E7%89%88-%E8%B3%BC%E8%AA%AD%E5%9E%8B%E3%83%A2%E3%83%87%E3%83%AB)のシナリオで役立ちます。

[TopicClient](https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.servicebus.topicclient?view=azure-dotnet)

`SendAsync(Message)`

# Service Busトピックの作成

トピック/サブスクリプションを使用する場合は、StandardまたはPremiumを指定。（Basicは不可）

# トピックフィルター

サブスクライバーは、トピックから受信するメッセージを定義できます。 

これらのメッセージは、1 つ以上の名前付きのサブスクリプション ルールの形式で指定されます。 

各ルールは、特定のメッセージを選択する条件と、選択したメッセージを注釈するアクションで構成されます。

- ブール値フィルター (TrueFilter/FalseFilter)
- SQLフィルター (SqlFilter)
- 相関関係フィルター (CorrelationFilter)

可能な場合は、アプリケーションでは、SQLフィルターではなく、処理効率が高く、スループットに与える影響が少ない、相関関係フィルターを選択してください。

フィルターおよびアクションでは、パーティション分割とルーティングという、さらに 2 つのパターン グループが作成されます。

https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/topic-filters#examples

https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-tutorial-topics-subscriptions-portal


# Active なメッセージとは？

deferred stateやscheduled stateではない、受信可能なメッセージ。

https://github.com/MicrosoftDocs/azure-docs/issues/57611

https://docs.microsoft.com/en-us/azure/service-bus-messaging/message-counters#message-count-details
Messages in the queue or subscription that are in the active state and ready for delivery. The messages are available to be received.

Messages can be in deferred state (https://docs.microsoft.com/en-us/azure/service-bus-messaging/message-deferral) or scheduled state (https://docs.microsoft.com/en-us/azure/service-bus-messaging/message-sequencing#scheduled-messages) - They are not active and not ready for delivery.

