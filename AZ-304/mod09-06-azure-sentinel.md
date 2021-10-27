# Azure Sentinel

https://docs.microsoft.com/ja-jp/azure/sentinel/overview

- セキュリティ情報イベント管理(SIEM) および
- セキュリティオーケストレーション自動応答(SOAR) ソリューション

※SIEM: Security Information and Event Management [読み方: シーム](https://www.google.com/search?q=siem++%E3%82%B7%E3%83%BC%E3%83%A0+security), セキュリティ情報とイベントの管理

※SOAR: Security Orchestration, Automation and Response [読み方: ソアー](https://www.google.com/search?q=soar+%E3%82%BD%E3%82%A2%E3%83%BC+security), セキュリティ情報の自動収集・自動対応

2019/9/26 Azure Sentinel 一般提供開始
https://azure.microsoft.com/ja-jp/blog/azure-sentinel-general-availability-a-modern-siem-reimagined-in-the-cloud/

[PDFまとめ](../AZ-500/pdf/mod4/Azure%20Sentinel%20まとめ.pdf)

■ハンズオン: Azure Sentinel

- Azure portal画面上部の検索で「Azure sentinel」を検索
- 「＋作成」
- 「＋新しいワークスペースの作成」
- リソースグループ、名前、地域（リージョン）を指定して、Log Analyticsワークスペースを作成
- 「最新の情報に更新」をクリックして、作成したLog Analyticsワークスペースを選択し、「追加」
- Azure Sentinelの画面が表示される
- 画面左「ニュースとガイド」、画面上部「始める」に、Sentinelの使用ステップが表示される。
  - 1. データの収集
  - 2. セキュリティアラートの作成
  - 3. 自動化と調整