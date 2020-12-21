Azure Service Bus

[製品ページ](https://azure.microsoft.com/ja-jp/services/service-bus/)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/service-bus/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-messaging-overview)

Microsoft Learn

- [Azure Service Bus を使用し、メッセージベースの通信ワークフローを実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-message-workflows-with-service-bus/)

# Azure Queue Storage と Azure Service Busの比較

https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-azure-and-service-bus-queues-compared-contrasted


# [対応プロトコル](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-messaging-overview#compliance-with-standards-and-protocols)

AMQP 1.0, JMS 2.0(Service Bus Premium), JMS 1.0(Service Bus Standard)

[AMQP 1.0の紹介とその重要な理由](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-amqp-overview) - AMQP 1.0 は、堅牢なクロス プラットフォーム メッセージング アプリケーションを作成するために使用できる、効率的で信頼性の高い回線レベルのメッセージング プロトコルです。AMQP 1.0 は国際標準であり、ISO および IEC によって、ISO/IEC 19464:2014 として承認されています。AMQP 1.0 は、2008 年以降、20 社を超える企業 (テクノロジ サプライヤーとエンド ユーザー企業の両方) で構成される中核的なグループにより開発されています。

# Service Bus [キュー](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-messaging-overview#queues)

メッセージは キュー に送受信されます。 受信側アプリがメッセージを受信して処理できるようになるまで、キューがメッセージを格納します。

# Service Bus [トピック](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-messaging-overview#topics)

トピック を使用してメッセージを送受信することもできます。 キューはポイント間通信によく使用されますが、トピックは[パブリッシュ/サブスクライブ](https://ja.wikipedia.org/wiki/%E5%87%BA%E7%89%88-%E8%B3%BC%E8%AA%AD%E5%9E%8B%E3%83%A2%E3%83%87%E3%83%AB)のシナリオで役立ちます。

# Active なメッセージとは？

deferred stateやscheduled stateではない、受信可能なメッセージ。

https://github.com/MicrosoftDocs/azure-docs/issues/57611

https://docs.microsoft.com/en-us/azure/service-bus-messaging/message-counters#message-count-details
Messages in the queue or subscription that are in the active state and ready for delivery. The messages are available to be received.

Messages can be in deferred state (https://docs.microsoft.com/en-us/azure/service-bus-messaging/message-deferral) or scheduled state (https://docs.microsoft.com/en-us/azure/service-bus-messaging/message-sequencing#scheduled-messages) - They are not active and not ready for delivery.

