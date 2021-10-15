# Azure Logic Apps

ビジネス プロセスの実行を自動化し、複数のシステムやアプリケーションを統合するためのサービス。

「Logic Apps デザイナー」と呼ばれるグラフィカル デザイン ツールを使ってアプリを作成。

[製品ページ](https://azure.microsoft.com/ja-jp/services/logic-apps/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-overview)

Microsoft Learn
[Azure Logic Apps の概要](https://docs.microsoft.com/ja-jp/learn/modules/intro-to-logic-apps/)

■参考: ローコード（ノーコード）

[ローコード](https://www.google.com/search?q=%E3%83%AD%E3%83%BC%E3%82%B3%E3%83%BC%E3%83%89)

- 最小限のソースコードの記述により、または、ソースコードを記述せず、アプリケーションを開発する手法・ツール
- Azure Logic Apps や Microsoft Power Appsは、ローコードのプラットフォームに分類される。事前に構築済みの「コネクター」（に含まれるトリガーやアクション）を、デザイナーの画面上でつなぎ合わせて、かんたんなアプリケーションを開発することができる。

Azureでのローコード アプリケーション開発
https://azure.microsoft.com/ja-jp/solutions/low-code-application-development/#overview

■参考: 統合のためのサービス（iPaaS、Integration Platform as a Service）

統合（インテグレーション）: クラウドやオンプレミスのシステムやアプリケーションを接続し、データを交換したり、機能を連携させたりすること。

Azure Logic Apps は、統合のためのサービスの1つ。「ワークフロー」を作成して、数百ものアプリケーションやサービスを統合することができる。

Azureの統合のためのサービス
https://azure.microsoft.com/ja-jp/product-categories/integration/

https://docs.microsoft.com/ja-jp/rest/api/logic/
> Azure Logic Appsはフル マネージドの iPaaS (Integration Platform as a Service, サービスとしての統合プラットフォーム) なので、開発者はホスティング、スケーラビリティ、可用性、管理の構築について心配する必要はありません。 Azure Logic Appsに合わせて自動的にスケールアップします。

https://atmarkit.itmedia.co.jp/ait/articles/1607/29/news085.html
> クラウド／オンプレミスのアプリケーションと各種データ、ガバナンスをクラウド上で統合する「iPaaS（Integration Platform as a Service：サービスの統合プラットフォーム）」と呼ばれるサービス群に位置付けられる。

※つまり、Logic Appは、それ自身で完全なアプリケーションを構築するためのプラットフォームというよりは、すでに開発済み・稼働している他のサービスやアプリケーションをつなぎ合わせて統合するためのサービスという位置づけであると言える。

■参考: サーバーレス

サーバーレスのサービスでは、サーバーなどのインフラを管理する必要がない。開発者は、インフラの管理ではなく、アプリケーションの開発に集中することができる。

Azure Logic AppsやAzure Functionsは、Azureのサーバーレスのサービスに分類される。
https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-serverless-overview

Azureのサーバーレス
https://azure.microsoft.com/ja-jp/solutions/serverless/

■歴史

2015/3/24 Azure App Service 発表。Web Apps、Mobile Apps、Logic Apps、API Appsをサポート。
https://weblogs.asp.net/scottgu/announcing-the-new-azure-app-service

2021/5/25 Logic Apps Standard 一般提供開始
https://azure.microsoft.com/ja-jp/blog/a-new-way-to-send-custom-metrics-to-azure-monitor/

- Azure portal上では「タイプ」を「Standard」として作成
  - （従来のLogic Appsリソースは「消費」として作成。ドキュメント状は「従量課金」）
- [シングルテナント](https://docs.microsoft.com/ja-jp/azure/logic-apps/single-tenant-overview-compare)
  - （従来のLogic Appsは「マルチテナント」と呼ばれる）
- [1つのロジックアプリ上に複数の「ワークフロー」を含めることができる](https://docs.microsoft.com/ja-jp/azure/logic-apps/single-tenant-overview-compare#stateful-and-stateless-workflows)
  - ステートフル ワークフロー に加え ステートレス ワークフロー をサポート（パフォーマンスが高速化されて応答時間が短くなり、スループットが向上し、実行コストが削減される）
- [新しいコードデザイナー](https://docs.microsoft.com/ja-jp/azure/logic-apps/create-single-tenant-workflows-azure-portal) （[Visual Studio Code上でも利用可能](https://docs.microsoft.com/ja-jp/azure/logic-apps/create-single-tenant-workflows-visual-studio-code)）
- [App Service プラン上で実行される。](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-pricing#standard-pricing)（プランの種類：「ワークフロー Standard WS1/WS2/WS3」などが利用可能）
- [受信トラフィックでプライベートエンドポイントを利用可能。送信トラフィック用に仮想ネットワーク統合を利用可能。](https://docs.microsoft.com/ja-jp/azure/logic-apps/secure-single-tenant-workflow-virtual-network-private-endpoint)

■ロジックアプリの構造

```
リソースグループ
└ロジックアプリ
 └ワークフロー
  ├トリガー
  └アクション
```

[ロジックアプリから別のロジックアプリを呼び出すこともできる。](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-http-endpoint)

■ロジックアプリの作成例

[まとめPDF](pdf/mod14/Azure%20Logic%20Apps%20作成例.pdf)


■コネクター

外部サービスへのインターフェイスを提供するコンポーネント。 

- Twitter コネクタ
  - ツイートを送信および取得
- Office 365 Outlook コネクタ
  - メール、予定表、連絡先を管理できる。 

[300種類を超えるコネクター](https://docs.microsoft.com/ja-jp/connectors/connector-reference/)が利用可能。

[カスタム コネクター](https://docs.microsoft.com/ja-jp/connectors/custom-connectors/)を開発することも可能。[カスタムコネクターからは、任意のWeb APIを呼び出すことができる。](https://docs.microsoft.com/ja-jp/learn/modules/logic-apps-and-custom-connectors/)

コネクタには、トリガーとアクションが含まれる。

■コネクターの例


|種類|コネクタの例|
|-|-|
|Azure のサービス|VM, App Service, Container Instance, Cosmos DB, DevOps, Blob, Files, Event Grid, Event Hub, Service Bus, Resource Manager, Automation, Communication Services SMS, IoT Central, Data Factory, Sentinel|
|Azureの AI系のサービス|Text Analytics, Computer Vision, Face API, LUIS, Content Moderator, QnA Maker, Bing Search, Video Indexer|
|Microsoftのサービス|Excel、Word、Outlook、OneDrive、OneNote、SharePoint、Teams、Project、Yammer、Power BI、Forms, Planner|
|ソーシャル|Twitter, Youtube, LinkedIn, Pinterest, RSS|
|業務システム|GitHub, Slack, SAP, ServiceNow, Zendesk, Adobe Creative Cloud, Amazon Web Services, SMTP|
|ファイル/データベース連携|SFTP, FTP, File System, Microsoft SQL Server、MySQL, PostgreSQL, Oracle Database, DB2|
|B2Bソリューション|AS2, Edifact, X12|

すべての利用可能なコネクタと、個々のコネクタの詳細
https://docs.microsoft.com/ja-jp/connectors/connector-reference/


■コネクターの種類とコスト

トリガーやアクションの起動回数に比例したコストがかかる。
https://azure.microsoft.com/ja-jp/pricing/details/logic-apps/


|分類|概要|コスト（従量課金の分類）|
|-|-|-|
|組み込みのトリガーとアクション|スケジュール、要求、HTTP、ワークフロー制御、変数、データ操作、日付/時刻などのコネクタ|「アクションの価格」|
|標準コネクタ|Azure Blob Storage、Office 365、Dynamics、Power BI、OneDrive、Salesforce、SharePoint Online などのサービスと連携するためのコネクタ。|「Standardコネクタの価格」|
|エンタープライズ コネクタ|SAP、IBM 3270、IBM MQ などのエンタープライズ システムにアクセスするための コネクタ。|「エンタープライズ コネクタの価格」|
|カスタム コネクタ|独自のトリガーとアクションを備えたコネクタ。REST APIのラッパー。Azure Functions, Azure App Service (Web AppsまたはAPI Apps) で実装されたAPIや、オンプレミスのプライベートAPIを呼び出すことができる。|「Standardコネクタの価格」|



■トリガー

特定の条件が成立した際に、トリガーが起動される。

例：Blobがアップロードされた、Twitterで特定のキーワードを含むツイートがあった、メールを受信した、Slackにメッセージが投稿された、など。

[定期的なスケジュールでロジックアプリを起動することもできる。](https://docs.microsoft.com/ja-jp/azure/logic-apps/tutorial-build-schedule-recurring-logic-app-workflow)

ロジックアプリのワークフローの最初にはトリガーを配置する必要がある。

■アクション

ビジネス プロセスのタスクを実行する操作。

複数のアクションを組み合わせることができる。

例：VMを起動・停止・再起動する、メールを送る、Twitterにツイートを送信する、Slackにメッセージを投稿する、テキストの感情を分析する、など。

■ ワークフローを制御するアクション

ワークフロー内で、分岐や繰り返しなどの制御構造を利用することができる。

https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-workflow-actions-triggers#control-workflow-actions)

- [ForEach](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-workflow-actions-triggers#foreach-action)
- [If (Condition)](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-workflow-actions-triggers#if-action)
- [Scope](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-control-flow-run-steps-group-scopes)
- [Switch](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-workflow-actions-triggers#switch-action)
- [Until](https://docs.microsoft.com/ja-jp/azure/logic-apps/logic-apps-workflow-actions-triggers#until-action)


■参考（開発者向け）: Logic AppsのAzure SDK, REST API

https://www.nuget.org/packages/Microsoft.Azure.Management.Logic

https://www.nuget.org/packages/Microsoft.Azure.Management.Logic.Fluent

ドキュメント
https://azuresdkdocs.blob.core.windows.net/$web/dotnet/Microsoft.Azure.Management.Logic/4.1.0/api/index.html

REST API
https://docs.microsoft.com/ja-jp/rest/api/logic/
