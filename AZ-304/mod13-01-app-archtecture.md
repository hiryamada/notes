# イベントベースのクラウド オートメーション

https://docs.microsoft.com/ja-jp/azure/architecture/reference-architectures/serverless/cloud-automation#patterns-in-event-based-automation

■関数アプリ

- Azure Functions
- Durable Functions

■ロジックアプリ

- Azure Logic Apps

■APIの管理・APIゲートウェイ・API利用者向けポータルの運用

- API Management
  - APIの管理
    - APIの定義
    - バックエンドのエンドポイントとの結びつけ
  - APIゲートウェイ
    - キャッシュ
    - 認証
    - データ変換
    - 測定
  - API利用者向けポータルの作成と運用
    - 「開発者ポータル」

■イベント

- [Event Grid](https://docs.microsoft.com/ja-jp/azure/event-grid/overview)
  - [Event Grid でできること](https://docs.microsoft.com/ja-jp/azure/event-grid/overview#what-can-i-do-with-event-grid)
  - [システムトピック](https://docs.microsoft.com/ja-jp/azure/event-grid/system-topics)
    - Azureサービスによって発行されるイベントをハンドリング
  - [カスタムトピック](https://docs.microsoft.com/ja-jp/azure/event-grid/custom-topics)
    - アプリケーション独自のイベントをハンドリング
- [Event Hubs](https://docs.microsoft.com/ja-jp/azure/event-hubs/event-hubs-about)
  - ビッグデータのストリーミング、インジェスト（取り込み）

■キュー

- ストレージアカウントのキュー（Azure Queue Storage）
- Service Bus

■データの保存・検索

- Azure Cosmos DB

■監視

- Azure Monitor アラート
- Application Insights
  - アプリケーションのパフォーマンス監視(APM)

■ボット

- Azure Bot Framework
