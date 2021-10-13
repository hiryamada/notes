# Azure Functions

サーバーレスアプリケーションの実行を行うサービス。
コードを実行するためのインフラの管理が不要。必要なリソースはオンデマンドで提供される（「従量課金プラン」の場合）。
「関数アプリ」リソース内に複数の「関数」を作成。
「関数アプリ」作成時に、そのアプリが使用する「価格プラン」を選択する。

製品ページ
https://azure.microsoft.com/ja-jp/services/functions/

価格プラン
https://azure.microsoft.com/ja-jp/services/functions/#pricing

価格の詳細
https://azure.microsoft.com/ja-jp/pricing/details/functions/

※Azureのサーバーレスのサービス
https://azure.microsoft.com/ja-jp/solutions/serverless/

■歴史

2014/1/23 Functionsの前身となる「Windows Azure WebJobs」が利用可能に。App Service上で、「トリガー」により、小さな「ジョブ」を実行。
https://www.hanselman.com/blog/introducing-windows-azure-webjobs

※[WebJobsとFunctionsの比較](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-compare-logic-apps-ms-flow-webjobs#compare-functions-and-webjobs)

2016/11/15 Azure Functions 一般提供開始 Consumptionプラン（消費量または従量課金とも）/App Service(専用)プラン。ローカルで開発・デバッグを行うための「Azure Functions CLI」のBeta版も提供。
https://azure.microsoft.com/ja-jp/blog/announcing-general-availability-of-azure-functions/

2017/3/18頃 「Azure Functions CLI」 が 「Azure Function Core Tools」に改名された
https://github.com/Azure/azure-functions-core-tools/issues/92

2017/7/6 Durable Functions アルファプレビュー
https://azure.github.io/AppService/2017/07/06/Alpha-Preview-for-Durable-Functions.html

2018/5/8 Durable Functions GA Release
https://github.com/Azure/azure-functions-durable-extension/releases/tag/v1.4.0

2019/11/4 Premiumプランの一般提供開始。コールドスタートの回避、仮想ネットワーク接続（VNet統合）への対応、高速スケールなど、エンタープライズアプリケーション向けの強化。
https://azure.microsoft.com/ja-jp/updates/azure-functions-premium-plan-is-now-generally-available/

2021/10/8 Dynamic concurrency モデルをサポート（プレビュー）従来の「Static concurrencyモデル」よりも、構成が簡素化され、時間の経過とともに変動する負荷に対応しやすくなった
https://azure.microsoft.com/ja-jp/updates/public-preview-dynamic-concurrency-in-azure-functions/

■Azure Functionsでできることの例

- イベント処理
- APIの実装
- マイクロサービスの実装
- システムの統合
- IoTデバイスからデータを収集して処理する
- スケジュールに従ったタスク実行
- Cosmos DBの変更に対応する
- キューのメッセージを処理する

https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-overview#scenarios

■Azure Functionsで利用できるランタイムのバージョン

https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-versions

ランタイムバージョン: 1.x, 2.x, 3.x, 4.xがある。

※実際には[「3.3.1」](https://github.com/Azure/app-service-announcements/issues/345)のようなバージョン番号が使われる。

Function上で動かしたいプログラミング言語のバージョンに対応するランタイムを選択する。

例: .NET, C#

- .NET Core 3.1, .NET 5.0 → Azure Functions ランタイムバージョン 3.x:
- .NET 6.0 → Azure Functions ランタイムバージョン 4.x

ランタイムバージョンの確認/設定方法: Azure CLI等を使用。
https://docs.microsoft.com/ja-jp/azure/azure-functions/set-runtime-version

ランタイムバージョンの更新についてはGitHub の Azure/app-service-announcements リポジトリでIssueとして確認できる。
https://github.com/Azure/app-service-announcements/issues


■テンプレート

あらかじめ用意されたテンプレートを選択して、コードの開発を開始することができる。

- QueueTrigger
- HttpTrigger
- BlobTrigger
- TimerTrigger
- DurableFunctionsOrchestration
- SendGrid
- EventHubTrigger
- ServiceBusQueueTrigger
- ServiceBusTopicTrigger
- EventGridTrigger
- CosmosDBTrigger
- IotHubTrigger

Azure Functions Core Toolsで `func init` でプロジェクトを作り、次にそのプロジェクト内で `func new` で「関数」を作る。関数を作るときに、テンプレートを選択する。

■タイマートリガー

https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-timer

（1時間、1週間、1ヶ月、などの）一定間隔ごとに関数を実行したい場合は「タイマートリガー」を使用。

「[NCRONTAB式](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-timer?tabs=csharp#ncrontab-expressions)」でスケジュールを指定。[CRONTAB](https://ja.wikipedia.org/wiki/Crontab)に似ている。

`{second} {minute} {hour} {day} {month} {day-of-week}`

例: 
- `0 30 9 * * 1-5`
- 平日の毎日午前 9 時 30 分

参考: [Cron Expression Descriptor](https://bradymholt.github.io/cron-expression-descriptor/?locale=ja): 
(N)CRONTAB式を、人間にわかる言葉（日本語・英語等）に変換

参考: [NCrontab Expression Tester](https://ncrontab.swimburger.net/): NCRONTAB式を、実際のスケジュールされる日時に展開

■Azureのサービスとの統合

さまざまなAzureサービスと統合されている。
イベントによる起動、データの送受信などを簡単に実現できる。

すべての一覧（サポートされているバインディング）:
https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-triggers-bindings?tabs=csharp#supported-bindings

■参考: Azure からのSMS送信

[Twilio](https://www.twilio.com/ja/)（トゥイリオ）: サードパーティ製のサービス。APIを使用して、テキストメッセージ（SMS）を送信したりすることができる。Azureでは、[Azure Communication Servicesを使用してSMSを送信することができる](https://docs.microsoft.com/ja-jp/azure/communication-services/concepts/telephony-sms/concepts) が、まだAzure Functionsとは統合されていないので、Twilioバインディングを使う必要がある。

Functionsのドキュメント: https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-twilio

解説動画: https://www.youtube.com/watch?v=1QfaGZ2Gm9g


■ホスティングプラン

関数アプリは以下のいずれかのプラン上で動かすことができる。

- 従量課金プラン(消費, Consumption)
- Premium プラン
- 専用プラン(App Serviceプラン)

概要: https://docs.microsoft.com/ja-jp/azure/azure-functions/pricing

詳しい比較: https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale

主な違い:
- タイムアウト: 従量課金プランは最大10分、Premium プランと専用プランは無制限に設定可能
- 最大インスタンス数: 従量課金プランは200、Premiumプランは100、専用プランは10-20。
- 自動スケール: 従量課金プランとPremiumプランは自動スケール。専用プランは設定による。
- ネットワーク機能: 従量課金プランは「受信IP制限」のみ利用可能。Premiumプランと専用プランは「受信IP制限」に加えて「仮想ネットワーク統合」などが利用できる。

選択の目安:
- すでにApp Serviceプランがあり、その上でAzure Functionsも実行したい場合: 専用プラン
- Azure Functionsを継続的に、高頻度で実行する場合: Premiumプラン
- その他の場合(高度なネットワーク機能が不要): 従量課金プラン

■スケーリング

https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#scale

https://docs.microsoft.com/ja-jp/azure/azure-functions/event-driven-scaling#runtime-scaling

関数アプリは、Azureの内部の「Functions host instance」（関数ホストのインスタンス）で実行される。

インスタンスの増減（スケールアウト・スケールイン）は、自動的に実行される。（専用プランでは手動スケーリングも利用できる）

各プランでのスケーリング, 最大インスタンス数

- 従量課金プラン: 自動, 200
- Premiumプラン: 自動, 100
- 専用プラン: 自動/手動, 10-20

[専用プランの自動スケーリングは、Premiumプランのスケーリングよりも低速。](https://docs.microsoft.com/ja-jp/azure/azure-functions/dedicated-plan#scaling)

■コールドスタート

https://docs.microsoft.com/ja-jp/azure/azure-functions/event-driven-scaling#cold-start

関数アプリがアイドル（呼び出しがない時間が続いた）になると、「Functions host instance」（関数ホストのインスタンス）が 0 にスケールインされる。

0にスケールインした場合、次の関数アプリの要求の処理の際に、0から1へスケールアウトする時間がかかる。（コールドスタート）

コールドスタートを避けるには:
- [専用プラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/dedicated-plan) を使用し、[「常時接続」（「常にオン」、「Always On」とも）設定を有効にする](https://docs.microsoft.com/ja-jp/azure/azure-functions/dedicated-plan#always-on)
- [Premiumプラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-premium-plan?tabs=portal) を使用する。インスタンスを常にウォーム状態に維持することでコールド スタートを回避できる。

■ストレージアカウント

https://docs.microsoft.com/ja-jp/azure/azure-functions/storage-considerations

Azure Functions では、Function App インスタンスを作成するときに Azure ストレージ アカウントが必要になる。

Azure portalを使用して関数アプリを作成すると、一緒にストレージアカウントが作成される。

ストレージアカウントが削除されると、関数アプリは実行されなくなるので、削除しないように注意。

最適なパフォーマンスを得るには、関数アプリで同じリージョンのストレージ アカウントを使用する。

複数の関数アプリで1つのストレージアカウントを共有してもよい。ただし、パフォーマンスを最大化するには、関数アプリごとに個別のストレージ アカウントを使用する。

■トリガーとバインド

関数では、トリガーとバインドを利用できる。

- トリガーは、関数が実行される原因。
- バインドは、関数に別のリソースを宣言的に接続する方法。

参考資料: [トリガーとバインド](../AZ-204/pdf/mod02/トリガー、バインド.pdf)

トリガーとバインドにより、他のサービスへのアクセスのハードコーディングを避けることができる。

（トリガーやバインドを使用できる場合は、他のサービスへの明示的な接続、読み書きをコーディングする必要がない）

https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-triggers-bindings

SDKを使用した、Azureのサービスへの明示的なアクセスの例: https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-quickstart-blobs-dotnet#download-blobs

■トリガー

関数を起動するきっかけとなるもの。
関数には、ただ1つのトリガーを含める必要がある。

- 「BlobTrigger」では、Blobがアップロードされたら関数が起動する。
- 「TimerTrigger」では、特定の時間間隔で関数が起動する。

トリガーにはデータが関連付けられる。
「BlobTrigger」では、Blobがアップロードされたら、Blobの入力ストリームにアクセスできる。

トリガーは特殊な入力バインドである。

■バインド

関数は、複数の入力バインドと出力バインドを利用できる。
バインドの利用はオプション（必須ではない）。

一部のバインドは「inout」をサポート。

■サポートされている言語

C#（「クラスライブラリ」と「C#スクリプト」）, F#, JavaScript, Java, PowerShell, Python, TypeScript

https://docs.microsoft.com/ja-jp/azure/azure-functions/supported-languages

■参考: C#スクリプト

C#スクリプトの解説
https://docs.microsoft.com/ja-jp/archive/msdn-magazine/2016/january/essential-net-csharp-scripting

C#スクリプトの解説
https://ufcpp.net/study/csharp/cheatsheet/apscripting/

Azure FunctionsでのC#スクリプトの利用
https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-reference-csharp

Azure Functionsでは、C#クラスライブラリ（ふつうのC#）に加え、C#スクリプトも利用できる。Azure portal上の開発環境では、C#スクリプトの開発・テストができる。

■各言語でのトリガー・バインドの指定方法:

- C#（クラスライブラリ）: 属性で指定。
  - https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-dotnet-class-library?tabs=v2%2Ccmd#methods-recognized-as-functions
- Java: アノテーションで指定。
  - https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-reference-java?tabs=bash%2Cconsumption#triggers-and-annotations
- C#スクリプト(～.csx), JavaScript等: function.json ファイルに指定
  - https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-reference-csharp#binding-to-arguments
  - https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-reference-node?tabs=v2#bindings

C#（クラスライブラリ）/Java では、トリガーやバインドはコード中の属性やアノテーションで指定される。functions.json は自動で生成される。

■Durable Functions

Durable: 永続性のある、恒久的な

[参考資料](../AZ-204/pdf/mod02/durable-function.pdf)

■学習に役立つリソース

Microsoft Learn: サーバーレス アプリケーションの作成
https://docs.microsoft.com/ja-jp/learn/paths/create-serverless-applications/

サーバーレスコミュニティライブラリ: 多数のサンプルコード
https://serverlesslibrary.net/
