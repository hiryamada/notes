
# Event GridとEvent Hubs

■用途

Event Grid:
- イベントソースで発生するイベント（状態変化）を、イベントハンドラーへ配信する。
- [Azure サービスと緊密に統合されている](https://docs.microsoft.com/ja-jp/azure/event-grid/overview)
- 独自のアプリケーションからカスタムのイベントを送信することもできる
- 独自のアプリケーションでイベントを受信することもできる(WebHook経由)

Event Hubs:
- ストリーミングデータ、IoTデータ等のイベント インジェスト（取り込み）サービス。
- ストリーミングデータ処理の例
  - モバイルデバイスのアプリ利用状況のトラッキング
  - アプリケーションのログ収集
  - [金融取引データにおける不正・異常の検出](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-tutorial-visualize-anomalies)
  - IoTデバイスから取り込んだデータのリアルタイム処理
  - 参考: [スシローのすしテクノロジー(Kinesushi)](https://media.amazonwebservices.com/jp/csd20140909/BZ-02.pdf): 寿司のリアルタイム需要予測システム
- リアルタイムのビッグ データ パイプライン
- 「Azure Event Hubs Capture」を使用して、取り込んだデータをBlobに格納できる

■アーキテクチャ例

Event Grid:

- 発生したイベントを1つ～複数の「サブスクライバー」に確実に配信したい
- イベント処理のコンポーネントの組み換えを柔軟にできるようにしたい
- フィルターを設定して、特定の条件を満たすイベントだけを受け取りたい

```
Blob Storage
↓イベント（数分に1回など）
Event Grid 「トピック」
↓イベント           ↓イベント（フィルターを設定）
Azure Functions      Logic Apps
```

Event Hubs:

- 大量のストリーミングデータを安定して取り込みたい
- 受信したデータを複数のコンシューマーで利用したい
- コンシューマーに障害が発生し、回復した際に、障害発生時点の続きからデータを受信して処理したい

```
モバイルデバイス（数千～数万）
↓イベント（1秒に数千件など）
Event Hubs 「イベントハブ」
↓イベント            ↓イベント
コンシューマー1      コンシューマー2
リアルタイム分析     （Event Hubs Capture）
↓                    ↓
ダッシュボード        Blob（長期保存）
（Power BI）
```

■イベントを蓄積しておけるか？

Event Grid:
- 基本的にNo
- ほぼリアルタイムで、直ちに、サブスクライバーにイベントを配信
- [再試行](https://docs.microsoft.com/ja-jp/azure/event-grid/delivery-and-retry)あり
  - 指数バックオフによる 24 時間の再試行で、確実にイベントが配信

Event Hubs:
- Yes
- 最小保持期間: 1 日 (24 時間)
- 最大保持期間:
  - Event Hubs Standard: 7 日
  - Event Hubs Dedicated: 90 日
- 保持期限が切れたイベントは自動的に削除される

■スケーラビリティ / 制約

Event Grid:
- イングレス: 5,000 イベント/秒または 5 MB/秒
- [クォータと制限](https://docs.microsoft.com/ja-jp/azure/event-grid/quotas-limits)

Event Hubs:
- 1秒間に数百万件のイベントを処理。
- [高いスケーラビリティ](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-scalability)
- 1個～32個（Standardの場合）のパーティションを使用してスケーリング
- 「専用クラスター」と「Premium レベル」では、パーティション数を増減可能
- [クォータと制限](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-quotas)

■モデル

Event Grid:
- パブリッシュ - サブスクライブ モデル（Pub-Sub）
- パブリッシャー側
  - Event Gridトピックに、イベントを送信
- サブスクライバー側
  - Event Gridトピックは、事前に登録されたサブスクライバーに、イベントを「プッシュ」で配信する
  - 「Event Gridに接続してイベントを受信する」必要がない（できない）
  - 「ポーリング」する必要がない（できない）

Event Hubs:
- プロデューサー - コンシューマー モデル
- プロデューサー側
  - イベントを[送信](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-dotnet-standard-getstarted-send#send-events)
- コンシューマー側
  - イベントを[受信](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-dotnet-standard-getstarted-send#receive-events)

■プロトコル

Event Grid:
- 独自 ([Azure Event Grid REST API](https://docs.microsoft.com/ja-jp/rest/api/eventgrid/dataplane/publish-custom-event-events/publish-custom-event-events))

Event Hubs:
- AMQP、HTTPS、Apache Kafka など広く使われているプロトコルをサポート。
- AMQP 1.0、Kafka プロトコル、または HTTPS 経由でイベントを発行。
- コンシューマーは AMQP 1.0 セッションを介して接続。

■イベントのサイズ

Event Grid:
- 最大 64 KB（[最大 1 MB のサイズのイベントのサポートは現在、プレビュー](https://azure.microsoft.com/ja-jp/updates/events-up-to-1mb-in-event-grid-public-preview/)）

Event Hubs:
- 256 KB (Basic)
- 1 MB (Standard, Premium, 専用)



# 詳細な比較

[Azure メッセージング サービスの中から選択する - Azure Event Grid、Event Hubs、および Service Bus](https://docs.microsoft.com/ja-jp/azure/event-grid/compare-messaging-services)
