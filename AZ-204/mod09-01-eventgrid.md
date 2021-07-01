# Azure Event Grid

フル マネージドのイベント ルーティング サービスです。

Blob Storage などのさまざまなソースから Azure Functions や Webhook などのさまざまなハンドラーにイベントを配布します。

[製品ページ](https://azure.microsoft.com/ja-jp/services/event-grid/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/event-grid/overview)

[料金](https://azure.microsoft.com/ja-jp/pricing/details/event-hubs/)

Microsoft Learn

- [ご自分のサービスにゆるく接続するために Azure でメッセージング モデルを選ぶ](https://docs.microsoft.com/ja-jp/learn/modules/choose-a-messaging-model-in-azure-to-connect-your-services/)

- [Event Grid を使用して Azure サービスの状態の変更に対応する](https://docs.microsoft.com/ja-jp/learn/modules/react-to-state-changes-using-event-grid/)

# Event GridとEvent Hubsの違い

Event Grid:
- イベントソースで発生するイベント（状態変化）を、イベントハンドラーへ配信
- パブリッシュ - サブスクライブ モデル（Pub-Sub）
- ほぼリアルタイム
- Event Gridに「接続して受信する」ことはできない。Webhook経由で「送ってもらう」ことができる。
- 定期的にポーリングする必要がない
- Azure サービスと緊密に統合。サポートされているハンドラーはWebhook（Azure Automation Runbook と Logic Apps は Webhook を介してサポート）、Azure Functions、Event Hubs、[Azure Relay ハイブリッド接続](https://docs.microsoft.com/ja-jp/azure/event-grid/handler-relay-hybrid-connections)、Service Bus のキューとトピック、Storage キュー。
- データ パイプラインではない（メッセージは、イベントの発生日時やイベントソースといった情報しか持たない）
- [カスタム トピックを使用した独自のイベント](https://docs.microsoft.com/ja-jp/azure/event-grid/custom-event-quickstart-portal)もサポート
- サブスクリプションでのイベントのフィルター処理、サブスクリプションの[有効期限の指定](https://docs.microsoft.com/ja-jp/azure/event-grid/concepts#event-subscription-expiration)が可能
- 指数バックオフによる 24 時間の再試行で、確実にイベントが配信
- メッセージサイズは最大 64 KB（最大 1 MB のサイズのイベントのサポートは現在、プレビュー）
- [HTTPエンドポイントでのイベント受信](https://docs.microsoft.com/ja-jp/azure/event-grid/receive-events)、[カスタム トピックへの HTTP POST によるイベント送信](https://docs.microsoft.com/ja-jp/azure/event-grid/post-to-custom-topic)
- [すべてのイベントに存在するプロパティとスキーマ](https://docs.microsoft.com/ja-jp/azure/event-grid/event-schema)

Event Hubs:
- 1秒間に数百万件のイベントを処理。リアルタイムのビッグ データ パイプラインを構築。
- イベント インジェスト サービス。イベント ストリームの生成とそのようなイベントの消費とを分離。
- [高いスケーラビリティ](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-scalability)
- AMQP、HTTPS、Apache Kafka など広く使われているプロトコルをサポート。AMQP 1.0、Kafka プロトコル、または HTTPS 経由でイベントを発行。すべてのコンシューマーは AMQP 1.0 セッションを介して接続。
- プロデューサー - コンシューマー モデル
- 独自のアプリケーションで、イベントの[送信](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-dotnet-standard-getstarted-send#send-events)と[受信](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-dotnet-standard-getstarted-send#receive-events)を行うことができる
- 各コンシューマーは、メッセージ ストリームの特定のサブセット (パーティション) のみを読み取り
- クライアントがデータの可用性をポーリングする必要はありません。
- イベント保持: 発行されたイベントは、構成可能な時間ベースの保持ポリシーに基づいて、イベント ハブから削除されます。 既定値および指定可能な最小保持期間は 1 日 (24 時間) です。 Event Hubs Standard の場合、最大保持期間は 7 日です。 Event Hubs Dedicated の場合、最大保持期間は 90 日です。
- Event Hubs Capture では、Event Hubs のストリーミング データを自動でキャプチャし、任意の BLOB ストレージ アカウントまたは Azure Data Lake Service アカウントのいずれかに保存することができます。
- [専用クラスター](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-dedicated-cluster-create-portal)をサポート

[Azure メッセージング サービスの中から選択する - Azure Event Grid、Event Hubs、および Service Bus](https://docs.microsoft.com/ja-jp/azure/event-grid/compare-messaging-services)

# SDK(レガシー)

[Microsoft.Azure.EventHubs](https://www.nuget.org/packages/Microsoft.Azure.Management.EventHub/)

> Development of this library has shifted focus to the Azure Unified SDK. The future development will be focused on "Azure.ResourceManager.EventHubs" (Azure.ResourceManager.EventHubs).

[Azure Event Hubs の .NET プログラミング ガイド (レガシー Microsoft.Azure.EventHubs パッケージ)](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-programming-guide)

# SDK(新)

[Azure.Messaging.EventHubs](https://www.nuget.org/packages/Azure.Messaging.EventHubs/)

[Azure Event Hubs との間でイベントを送受信する](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-dotnet-standard-getstarted-send)

