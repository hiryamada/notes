# 知識チェック

■知識チェックの重要ポイント

トランザクション処理: 「詳細を1つのトランザクションにグループ化」 → [トランザクション](https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-transactions)などの高度な機能を利用できる「Azure Service Busキュー」

更新管理: 「定義されたメンテナンス期間内にインストール」→ [Runbook（PowerShell）のスケジュール実行](https://docs.microsoft.com/ja-jp/azure/automation/shared-resources/schedules)を利用できる「Azure Automation」

イベント処理: 「1秒あたり数百万のイベントを処理」、「イベントをBLOBに保存」 → Event Hubs

GitHubコードの更新: 「イベント発生時に、関数をトリガー」→ [GitHubのWebhookとAzure Function](https://docs.microsoft.com/ja-jp/learn/modules/monitor-github-events-with-a-function-triggered-by-a-webhook/) ※Azure Webhookというサービスはない。Webhookの呼び出し先として、Azure Functionの「HTTPトリガーを使用した関数」を指定することは可能。

■知識チェック

https://docs.microsoft.com/ja-jp/learn/modules/design-application-architecture/10-knowledge-check
