# Azure Monitor


■Azure Monitor（＋Application Insights）が収集することができるデータ

- アプリケーション監視データ
  - Application Insightsによる
- ゲストOS監視データ
  - Azure VM、オンプレミスのサーバー、Azure外のクラウドの仮想マシンに、エージェントを組み込む
  - Azure VMの場合は「VM拡張機能」での組み込みが可能
  - OSレベルの詳細な監視が可能となる（メモリやプロセスの情報、Windowsイベントログ、LinuxのSyslogなど）
  - エージェントはWindowsとLinuxに対応
    - Log Analyticsエージェント
    - Azure Monitorエージェント（プレビュー）：Log Analyticsエージェントと共存も可能
- Azure リソース監視データ
  - プラットフォーム メトリック データ（VMのCPU利用率など）
  - 各リソースの「リソース ログ」
    - 「診断設定」によりLog Analyticsワークスペースなどに送信する設定を行う
- Azure サブスクリプション監視データ
  - サブスクリプションのアクティビティログ
  - リソースの変更、仮想マシンの起動などの情報が含まれる
- Azuer テナントの監視データ
  - Azure ADのアクティビティログ
  - Azure AD サインイン ログ
    - サインインの成功・失敗など
    - プレミアム ライセンスが必要

Azure Monitorが収集するデータ
https://docs.microsoft.com/ja-jp/azure/azure-monitor/overview#what-data-does-azure-monitor-collect

Azure ADの監視
https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/overview-monitoring


■メトリック

- 数値の時系列データ
- メトリックエクスプローラでグラフ化できる

■ログ

- Log Analytics ワークスペース、Event Hubs、Azure Storageへ送信できる
- KQL（Kusto Query Language）でクエリができる

■アラート

- メトリックや、ログの集計結果、リソースの正常性などに対して、アラートを設定できる
- アラートが発生したら、通知をしたり、アクションを実行したりすることができる

通知

- SMS
- メール
- 電話

アクション
- Azure Functionの起動
- Logic Appの起動

通知とアクションは「アクショングループ」にまとめて定義される。

■ダッシュボード

# Log Analytics

■Log Analyticsとは

- ログの分析機能。
- Azure Monitorの「ログ」、

https://docs.microsoft.com/ja-jp/azure/azure-monitor/logs/log-analytics-overview


■「診断設定」とは

- Log Analyticsワークスペース
- ストレージアカウント
- Event Hub


Azure ADの診断設定の構成
https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/overview-monitoring#diagnostic-settings-configuration

# Application Insights

■Application Insightsとは。

アプリケーションの（パフォーマンスの）監視のサービス。

APM（Application Performance Monitoring）と呼ばれるジャンルの製品。
https://www.google.com/search?q=apm

アプリケーションに、Application Insightsを組み込む必要がある（後述）。

稼働中のアプリケーションから、さまざまな情報が集まってきて、Application Insights側で一元監視を行うことができる。

■Azure Monitorとは何が違うのか？

- Azure Monitor
  - VMのCPU使用率、ネットワーク、ディスク利用状況など、インフラレベルの情報を収集
  - インフラ管理者向け
  - メトリックとログ
  - 解像度: 分単位
- Application Insights
  - 要求・応答・エラー率・例外・ページビュー・パフォーマンスなど、アプリレベルの情報を収集
  - アプリケーション開発者向け
  - テレメトリ
  - 解像度: 秒単位（ライブメトリクス）

■どんな監視ができるか？

[参考資料](pdf/mod12/Application%20Insightsの主な機能.pdf)

■オーバーヘッド

（一般的に）追加の処理・負荷のこと。アプリケーションへの影響。

Application Insightsをアプリケーションに組み込むことによるオーバーヘッドはわずか。

- テレメトリの収集は、メインの処理をブロッキングしない
- テレメトリの送信は、別スレッドで実行される

■テレメトリ

Application Insightsが、アプリケーションから収集するデータ。

アプリ側から、カスタムのテレメトリを収集して、Application Insightsに送信することもできる。

■Application Insightsを利用できるアプリケーションの種類

- Webアプリ、SPA
- コンソールアプリ
- バックグラウンドアプリ（デーモン、サービス）
- モバイルアプリ

■Application Insightsを利用できる環境

- Azure App Service のWebアプリ
- Azure Function 関数アプリ
- Azure Kubernetes Service（AKS）
- オンプレミス、（Azure以外の）パブリッククラウド等

■Application Insightsを利用できる言語

- .NET (C#等)
- Java
- Python
- JavaScript
- Node.js

■インストルメンテーション

アプリケーションに、Application Insightsを組み込む作業のこと。

大きく分けて「コードベース監視」と「コードなしの監視」の2種類のやりかたがある。
- コードベース監視: アプリ内に、Application Insightsを使用するコードを書き込む。
- コードなしの監視: エージェントベースとも。アプリのコードを変更する必要がない。

インストルメンテーションによってアプリが監視され、インストルメンテーション キーと呼ばれる一意の GUID を使用して、テレメトリ データが Azure Application Insights リソースに転送されます。

■インストルメンテーションキー

アプリケーションが、Application Insightsのリソースに接続するために必要となるキー。

■インストルメンテーションキーの設定方法

- コード内に直接書き込む
- 環境変数に設定する
- appsetting.json （アプリケーションのルートフォルダー内）に設定する。（ASP.NET Core）
- ApplicationInsights.config 内に設定する （ASP.NET）
- ApplicationInsights.xml 内に設定する (Java)
- App Configurationから設定する（[関連GitHub Issue](https://github.com/Azure/AppConfiguration/issues/162)）

くわしくは[ドキュメント](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/app-insights-overview)の「コードベースの監視」「コード不要の監視」以下をご確認ください

■インストルメンテーションキーの設定方法（JavaScript、Webページの場合）

Webページ内にApplication InsightsのJavaScriptとインストルメンテーションキーを組み込むことで、Webページレベルの詳細な監視が可能となる。
https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/javascript

この場合、インストルメンテーションキーはページの中に直接記述される。

この方法は、モニタリングソリューションにおいては一般的な方法である。キーが露出することによって、データが盗まれるようなことはない。第三者がキーを盗み、ApplicationInsightsに偽のデータを送信する可能性はあるが、今の所そのような攻撃はMicrosoftの顧客からは報告されていない。キーを露出させないようにするには、プロキシーを立てて、プロキシー側にキーを置くという手法が利用できる。
https://docs.microsoft.com/ja-jp/azure/azure-monitor/faq#my-instrumentation-key-is-visible-in-my-web-page-source-

■接続文字列

現在は、インストルメンテーションキーではなく、（それを含む）接続文字列を使用することが推奨されている。新しいリージョンでは、接続文字列の利用が必須となっている。
https://docs.microsoft.com/ja-jp/azure/azure-monitor/faq#should-i-use-connection-strings-or-instrumentation-keys-

# 一時的なエラーへの対処


https://docs.microsoft.com/ja-jp/azure/architecture/best-practices/retry-service-specific

https://docs.microsoft.com/ja-jp/azure/architecture/best-practices/transient-faults

# ラボ11


- ソースコードをまだダウンロードしていない場合は[こちらからダウンロード](https://github.com/MicrosoftLearning/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/archive/refs/heads/master.zip)します。
- まず[参考資料](lab/lab11.md)を見て、概要を把握します
- [手順書](https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_11_lab_ak.html)を見ながら演習を行います。
