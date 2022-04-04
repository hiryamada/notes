# 5日目

- ラーニングパス 10 メッセージング（キュー）
- ラーニングパス 11 ログ記録（Application Insights）
- ラーニングパス 12 キャッシュ（Azure CDN、Azure Cache for Redis）

# ラーニングパス: AZ-204: メッセージ ベースのソリューションを開発する[🐾](https://docs.microsoft.com/ja-jp/learn/paths/az-204-develop-message-based-solutions/)

## モジュール: Azure メッセージ キューを検出する[🐾](https://docs.microsoft.com/ja-jp/learn/modules/discover-azure-message-queue/)

- 「キュー」「メッセージ」とはなにか？ なぜ使うのか？
  - 「キュー」: 「メッセージ」をためておく場所
  - 基本的に、メッセージはキューに到着順にたまり、先に到着したものから取り出される ※FIFO
  - メッセージを送受信するアプリ・システム等を「コンポーネント」と呼ぶ
    - 送信側は「プロデューサー」とも
    - 受信側は「コンシューマー」とも
  - コンポーネント間を「キュー」でつなぐ
  - 負荷分散
  - 負荷平準化
  - 送信側・受信側は、相手の状態を気にしなくてよい（メンテナンス、障害対応等で有利）
  - 送信側・受信側は、相手のアドレスを知らなくてよい（構成の変更に強い）
  - タイトカップリング（tight coupling、密結合）→ルーズカップリング（loose coupling、疎結合）
- Azure Service Bus - 高度な機能
  - 「FIFO」をサポートしている
  - 「At-Most-Once」の配信保証
  - ノンブロッキング受信・ブロッキング受信をサポート
  - 最大キューサイズ 80 GB
  - 最大メッセージサイズ 100 MB ※Premiumの場合
- Azure Queue Storage - シンプル
  - 「FIFO」をサポートしていない
  - 「At-Least-Once」の配信
  - ノンブロッキング受信のみ
  - 最大キューサイズ 500 TB
  - 最大メッセージサイズ 64 KB
- 知識チェック https://docs.microsoft.com/ja-jp/learn/modules/discover-azure-message-queue/9-knowledge-check
  - Azure Service Bus
    - 先入れ先出し (FIFO) を提供する機能
      - **メッセージ セッション** https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/message-sessions
    - [負荷平準化](https://docs.microsoft.com/ja-JP/azure/architecture/patterns/queue-based-load-leveling)の利点
      - コンシューマー側アプリケーションは、**平均時の負荷** を処理すればよい
- [ラボ10](https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_lab_10.html) Service Bus

# ラーニングパス: AZ-204: 監視とログ記録をサポートするソリューションをインストルメントする (Instrument solutions to support monitoring and logging)[🐾](https://docs.microsoft.com/ja-jp/learn/paths/az-204-instrument-solutions-support-monitoring-logging/)

## モジュール: アプリのパフォーマンスを監視する

- [Application insightsまとめ資料](pdf/mod12/Application%20Insightsの主な機能.pdf)
- Application insights [🐾](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/app-insights-overview)
- ★メトリックの種類 [🐾](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/pre-aggregated-metrics-log-metrics)
  - ログベースのメトリック [🐾](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/pre-aggregated-metrics-log-metrics#log-based-metrics)
    - 大量のテレメトリを生成するアプリケーションには不向き
  - ★事前に集計されたメトリック [🐾](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/pre-aggregated-metrics-log-metrics#pre-aggregated-metrics)
    - データをクエリに適した形で事前に集計して格納する方式
    - ほぼリアルタイムのクエリとアラートを利用できる
- インストルメンテーション
  - アプリを監視し、テレメトリ データをApplication Insightsに送信すること。
  - 一意の 「インストルメンテーション キー」が使用される
  - 方法
    - アプリケーションにSDKを組み込む[🐾](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/asp-net-core)
    - または
    - Application Insightsエージェントを使用する（アプリの変更が不要）
      - 例: VMやVMSS上で実行されている.NETやJavaアプリに対する監視が可能 [🐾](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/azure-vm-vmss-apps)
- ★可用性テスト
  - 世界各地の複数のポイントから定期的にアプリケーションに Web 要求を送信
  - アプリケーションが応答していない場合、または応答が遅すぎる場合、アラートが生成される
  - ★可用性テストの種類 [🐾](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/availability-overview#types-of-tests)
    - 複数ステップWebテスト（非推奨）
    - ★カスタム TrackAvailability テスト: 認証テスト向けに推奨
- 知識チェック[🐾](https://docs.microsoft.com/ja-jp/learn/modules/monitor-app-performance/8-knowledge-check)
  - 認証テストに推奨される可用性テスト
  - ほぼリアルタイムのクエリとアラートを提供するメトリックの種類
- [ラボ11](https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_lab_11.html) Application Insights

# ラーニングパス: AZ-204: キャッシュとコンテンツ配信をソリューション内に統合する[🐾](https://docs.microsoft.com/ja-jp/learn/paths/az-204-integrate-caching-content-delivery-within-solutions/)

## モジュール: Azure Cache for Redis の開発

- [Azure Cacheまとめ資料](pdf/mod13/Azure%20Cacheまとめ.pdf)
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-azure-cache-for-redis/6-knowledge-check)
  - 運用シナリオで使用するために推奨される最低のレベル（サービス階層）
    - Standard以上では[SLA](https://azure.microsoft.com/ja-jp/support/legal/sla/cache/v1_1/)が提供されるため運用シナリオに向く。[🐾](https://docs.microsoft.com/ja-jp/azure/azure-cache-for-redis/cache-overview#service-tiers)
  - 期限切れ時刻の精度を表す値
    - 有効期限は、秒(EX) または ミリ秒(PX) の精度で設定することができる。[🐾](https://redis.io/commands/set)
    - 有効期限切れの時刻の精度は、常に 1 ミリ秒 [🐾](https://redis.io/commands/expire#expires-and-persistence)

## モジュール: CDN でのストレージの開発

- [Azure CDNまとめ資料](pdf/mod13/Azure%20CDN%E3%81%BE%E3%81%A8%E3%82%81.pdf)
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-storage-cdns/5-knowledge-check)
  - サブスクリプションの制限
    - [CDNプロファイルはサブスクリプションあたり25個までに制限される](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits#content-delivery-network-limits)
    - 参考: 
      - [ストレージアカウント: 250](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits#storage-limits)
      - リソースグループ: 800（？） [参考1](https://build5nines.com/azure-subscription-resource-limits-and-quotas/) [参考2](https://muratsenelblog.wordpress.com/2016/02/09/azure-subscription-limitations-and-others/)
  - ファイルにTTL(Time to live, 有効期限)を指定しない場合のデフォルト値
    - [大きなファイルの最適化: 1日](https://docs.microsoft.com/ja-jp/azure/cdn/cdn-manage-expiration-of-cloud-service-content)
- [ラボ12](https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_lab_12.html) Azure CDN


# ラーニングパス 11: [AZ-204: 監視とログ記録をサポートするソリューションをインストルメントする](https://docs.microsoft.com/ja-jp/learn/paths/az-204-instrument-solutions-support-monitoring-logging/)
## モジュール 1: [アプリのパフォーマンスを監視する](https://docs.microsoft.com/ja-jp/learn/modules/monitor-app-performance/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/monitor-app-performance/1-introduction)
- ユニット 2: [Azure Monitor の調査](https://docs.microsoft.com/ja-jp/learn/modules/monitor-app-performance/2-azure-monitor-overview)
- ユニット 3: [Application Insights について](https://docs.microsoft.com/ja-jp/learn/modules/monitor-app-performance/3-application-insights-overview)
- ユニット 4: [ログベースのメトリックを検出する](https://docs.microsoft.com/ja-jp/learn/modules/monitor-app-performance/4-logs-based-metrics)
- ユニット 5: [監視用アプリをインストルメント化する](https://docs.microsoft.com/ja-jp/learn/modules/monitor-app-performance/5-app-instrumentation)
- ユニット 6: [可用性テストを選択する](https://docs.microsoft.com/ja-jp/learn/modules/monitor-app-performance/6-availability-tests)
- ユニット 7: [アプリケーション マップを使用してアプリのパフォーマンスのトラブルシューティングを行う](https://docs.microsoft.com/ja-jp/learn/modules/monitor-app-performance/7-application-map)
- ユニット 8: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/monitor-app-performance/8-knowledge-check)
- ユニット 9: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/monitor-app-performance/9-summary)
# ラーニングパス 12: [AZ-204: キャッシュとコンテンツ配信をソリューション内に統合する](https://docs.microsoft.com/ja-jp/learn/paths/az-204-integrate-caching-content-delivery-within-solutions/)
## モジュール 1: [Azure Cache for Redis の開発](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-azure-cache-for-redis/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-azure-cache-for-redis/1-introduction)
- ユニット 2: [Azure Cache for Redis を探索する](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-azure-cache-for-redis/2-azure-cache-redis-overview)
- ユニット 3: [Azure Cache for Redis を構成する](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-azure-cache-for-redis/3-configure-azure-cache-redis)
- ユニット 4: [.NET を使用して、Azure Cache for Redis と対話する](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-azure-cache-for-redis/4-interact-redis-api)
- ユニット 5: [演習: .NET Core を使用してアプリを Azure Cache for Redis に接続する](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-azure-cache-for-redis/5-console-app-azure-cache-redis)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-azure-cache-for-redis/6-knowledge-check)
- ユニット 7: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-azure-cache-for-redis/7-summary)
## モジュール 2: [CDN 上のストレージ用の開発](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-storage-cdns/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-storage-cdns/1-introduction)
- ユニット 2: [Azure Content Delivery Network を探索する](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-storage-cdns/2-azure-content-delivery-network-overview)
- ユニット 3: [Azure Content Delivery Network でキャッシュ動作を制御する](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-storage-cdns/3-control-cache-behavior)
- ユニット 4: [.NET を使用して Azure Content Delivery Networks と対話する](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-storage-cdns/4-azure-cdn-libraries-dotnet)
- ユニット 5: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-storage-cdns/5-knowledge-check)
- ユニット 6: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/develop-for-storage-cdns/6-summary)
