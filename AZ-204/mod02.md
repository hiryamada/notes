# Azure Functions

- サーバーレスアプリケーションの実行を行うサービス。
- コードを実行するためのインフラの管理が不要。必要なリソースはオンデマンドで提供される（「従量課金プラン」の場合）。
- 「関数アプリ」リソース内に複数の「関数」を作成。

※Azureのサーバーレスのサービス
https://azure.microsoft.com/ja-jp/solutions/serverless/

<!--
製品ページ
https://azure.microsoft.com/ja-jp/services/functions/

価格プラン
https://azure.microsoft.com/ja-jp/services/functions/#pricing
-->


■Azure Functionsの利用例

PDF資料: [Azure Functionsによるサムネイル作成](pdf/mod02/トリガー、バインド.pdf)

■Azure Functionsでできることの例

https://learn.microsoft.com/ja-jp/azure/azure-functions/functions-overview?pivots=programming-language-csharp#scenarios

- ストレージアカウントにファイル（Blob）がアップロードされたら、そのファイルを読み取って処理する
  - [Blobトリガー](https://learn.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-storage-blob)
    - 応用例: 画像ファイルがアップロードされたらその画像のサムネイルを生成して別のコンテナーへ記録する
    - 応用例: CSVファイルがアップロードされたらその内容をSQL DatabaseへINSERTする
    - 応用例: JSONファイルがアップロードされたらその内容をCosmos DBへ登録する
- 定期的な処理（タイマー）
  - [タイマートリガー](https://learn.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-timer)
  - スケジュールは[NCrontab](https://github.com/atifaziz/NCrontab)を使用して設定。
  - 設定例: `0 */5 * * * *` ... 5分に1回
- Web APIの実装
  - [HTTPトリガー](https://learn.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-http-webhook)
- IoTデバイスからのデータ収集・処理
  - [IoT Hubトリガー](https://learn.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-event-iot)
  - IoTデバイス → (HTTPS/MQTT) → IoT Hub → Azure Functions
- Cosmos DBのデータの変更時に自動的に処理を行う
  - [Cosmos DBトリガー](https://learn.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-cosmosdb-v2-trigger)
  -  (RDBでいう「[トリガー](https://techblog.recruit.co.jp/article-590/)」のようなことが実現できる)
- キューに到着したメッセージを処理する
  - [Azure Queue Storageのトリガー](https://learn.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-storage-queue-trigger)
  - [Service Busトリガー](https://learn.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-service-bus-trigger)
- **Azure Monitor**との連動
  - [アクショングループでの設定](https://learn.microsoft.com/ja-jp/azure/azure-monitor/alerts/action-groups#manage-action-groups)
  - Azure Monitorアラートがトリガーされた際に、Azure FunctionsのHTTPトリガーに関連付けられた関数で、対応する処理を実行する

<!--

■Azure Functionsでできない/苦手なこと

できないこと:
- 実行環境へのドライバー、ウィルス対策ソフトなどの組み込み
- エンドユーザー向けのアプリケーションのインストール
- 古いバージョンの言語ランタイムをずっとサポートする

バージョンについて
https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-versions

https://docs.microsoft.com/ja-jp/azure/azure-functions/set-runtime-version

バージョンの更改のお知らせ
https://github.com/Azure/app-service-announcements/issues

工夫すればできること:
（バッチ処理のような）長時間にわたる実行 → 基本的に、Azure Functionは10分以内といった短時間での処理を想定。ただし、Durable Functionsを使用すると、複数の「関数の実行」をつなげることで、長期間に渡るワークフローの実行などを実現することは可能。ただしこの場合でも、Durable Functionsに含まれる個々の処理（「アクティビティ関数」の実行）の1回あたりの実行時間の上限は伸びない。

（セッションなどの）状態を持たせる → 基本的にAzure Functionsのようなサーバーレスのアーキテクチャはステートレスが前提。ただし、外部のストレージを利用するなどして、状態を持たせる（複数の実行の間でデータを受け渡す）ことは不可能ではない。

-->

■料金

https://azure.microsoft.com/ja-jp/pricing/details/functions/

「関数アプリ」作成時に、そのアプリで使用する「価格プラン」を選択する。

- [消費（使用量、従量課金とも）](https://docs.microsoft.com/ja-jp/azure/azure-functions/consumption-plan)
  - 1 秒あたりのリソースの使用量と実行回数に基づいて課金
  - リソース使用量
    - GB秒あたり $0.000016
    - 400,000 GB/秒 は毎月無料
  - 実行回数
    - 100万回あたり $0.2
- [Premium プラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-premium-plan?tabs=portal)
  - 少なくとも1つのインスタンス（サーバー）をプロビジョニング（事前準備）しておく方法
  - インスタンス全体にわたって割り当てられたコア秒数とメモリに基づく料金
- [専用プラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/dedicated-plan)
  - 「App Service プラン」上でAzure Functionsを実行
  - App Service プランの料金

■Functions Premiumプランで利用できる機能

- より強化されたパフォーマンス
- コールド スタートなし
- VNet統合
  - 関数アプリから、VNet内のリソースにアクセス
  - VNetを経由して別のリソースにアクセス

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

■タイマートリガー

https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-timer

「NCRONTAB式」でスケジュールを指定。[CRONTAB](https://ja.wikipedia.org/wiki/Crontab)に似ている。

参考: NCRONTABの式（ `*/30 * * * * *` 等）を入れると、人間の言葉（日本語・英語等）でその意味を説明してくれるサイト https://bradymholt.github.io/cron-expression-descriptor/?locale=ja

■Azureのサービスとの統合

さまざまなAzureサービスと統合されている。
イベントによる起動、データの送受信などを簡単に実現できる。

すべての一覧（サポートされているバインディング）:
https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-triggers-bindings?tabs=csharp#supported-bindings

Twilio（トゥイリオ）: サードパーティ製のサービス。APIを使用して、テキストメッセージ（SMS）を送信したりすることができる。

解説動画: https://www.youtube.com/watch?v=1QfaGZ2Gm9g

Functionsのドキュメント: https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-twilio

<!--

■スケーリング

https://docs.microsoft.com/ja-jp/azure/azure-functions/event-driven-scaling#runtime-scaling

拡大縮小はキューの長さや最も古いキュー メッセージの経過時間に基づいて実施されます。


■ホスティングプラン

関数アプリは以下のいずれかのプラン上で動かすことができる。

- 従量課金プラン(消費, Consumption): 実行数、実行時間、およびメモリの使用量に基づいて課金
- Premium プラン: 従量課金プランと比較して、予測可能な料金。
- App Service プラン: App Service のプラン上で関数を実行。

概要: https://docs.microsoft.com/ja-jp/azure/azure-functions/pricing

詳しい比較: https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale

主な違い:
- タイムアウト: 従量課金プランは最大10分、Premium プランとApp Serviceプランは無制限に設定可能
- 最大インスタンス数: 従量課金プランは200、Premiumプランは100、App Serviceプランは10-20。
- 自動スケール: 従量課金プランとPremiumプランは自動スケール。App Serviceプランは設定による。
- ネットワーク機能: 従量課金プランは「受信IP制限」のみ利用可能。PremiumプランとApp Serviceプランは「受信IP制限」に加えて「仮想ネットワーク統合」などが利用できる。

かんたんな選択例:
- すでにApp Serviceプランがあり、その上でAzure Functionsも実行したい場合: App Serviceプラン
- Azure Functionsを継続的に、高頻度で実行する場合: Premiumプラン
- その他の場合(高度なネットワーク機能が不要な場合): 従量課金プラン

■常にオン(Always On, 「常時接続」とも)

App Service プランを実行する場合、関数アプリが正常に実行されるように、「常時接続」を「有効」に設定する必要がある。
この設定は、App Service プランでのみ指定できる。

https://docs.microsoft.com/ja-jp/azure/azure-functions/dedicated-plan#always-on

-->

■ストレージアカウント （ホストストレージ）

Azure Functions 関数アプリのリソースを作成する際、Azure ストレージ アカウントも必要。

このストレージアカウントが削除されると、関数アプリは実行されない。

最適なパフォーマンスを得るには、関数アプリで同じリージョンのストレージ アカウントを使用する必要がある。

複数の関数アプリで1つのストレージアカウントを共有してもよい。

ただし、パフォーマンスを最大化するには、関数アプリごとに個別のストレージ アカウントを使用する。

https://docs.microsoft.com/ja-jp/azure/azure-functions/storage-considerations

■トリガーとバインド

関数では、トリガーとバインドを利用できる。

- トリガーは、関数が実行される原因。
- バインドは、関数に別のリソースを宣言的に接続する方法。

参考資料: [トリガーとバインド](pdf/mod02/トリガー、バインド.pdf)

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

C#（「クラスライブラリ」と「C#スクリプト」）, Java, JavaScript, TypeScript,  Python, PowerShellなど。

https://learn.microsoft.com/ja-jp/azure/azure-functions/supported-languages?tabs=isolated-process%2Cv4&pivots=programming-language-csharp#language-support-details

■各言語でのトリガー・バインドの指定方法:

- C#: 属性で指定。
- Java: アノテーションで指定。
- C#スクリプト(～.csx), JavaScript等: function.json ファイルに指定

■開発する場所について

Azure portal上で関数を作成・コーディング・テスト実行できる。
本格的な開発の場合は、ローカル環境で関数を開発・テストし、Azure Functionsにデプロイすることができる。
ローカル環境での開発には、「Azure Functions Core Tools」を利用する。

■開発の概要

プロジェクトのフォルダ構成: 言語により若干異なる。

以下はC#の例。

```
プロジェクトのフォルダ
├関数1のコード(～.cs)
├関数2のコード(～.cs)
├ host.json
├ local.settings.json
└ func.csproj
```

以下はJavaScriptの例。

```
プロジェクトのフォルダ
├関数1のフォルダ
│ ├index.js
│ └function.json
├関数2のフォルダ
│ ├index.js
│ └function.json
├ host.json
├ local.settings.json
└ package.json
```

function.json: それぞれの関数のトリガー、バインド、その他の構成設定を定義します。
https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-reference

host.json: 関数アプリのすべての関数に影響するグローバル構成を定義します。
https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-host-json

local.settings.json: ローカル設定

■Azure Functions Core Toolsとは？

https://learn.microsoft.com/ja-jp/azure/azure-functions/functions-run-local

Azure Functions Core Tools を使用すると、ローカル コンピューター上のコマンド プロンプトまたはターミナルから関数を開発およびテストできる。

■Azure Functions Core Toolsのインストール

- Windows/Mac/Linuxでインストール方法が異なる。
- Windowsの場合はMSIでインストール。
- [最新版の配布場所(GitHubリリース)](https://github.com/Azure/azure-functions-core-tools/releases)

■Azure Functions Core Tools（funcコマンド）によるローカルでの関数開発

```
mkdir func1
cd func1

func new
	worker runtime: dotnet
	template: HTTP trigger
	Function name: testfunc1
func start
	http://localhost:7071/api/testfunc1
```
※再度、func new を実行すると、関数を追加できる。

<!--

■Visual Studio Codeによるコードの編集

```
code .
```

■httpreplとは？
Web APIのテストを行うためのコマンドラインツール。
.NET Core がサポートされているすべての場所で動作する。
※REPL: Read-Evaluate-Print Loop

■httpreplのインストール

```
dotnet tool install -g Microsoft.dotnet-httprepl
```

■httpreplでGETを行う例

```
httprepl http://localhost:7071/api/testfunc1?name=taro
get
exit
```

■httpreplでPOSTを行う例

```
httprepl http://localhost:7071/api/testfunc1
post -c {"name":"taro"}
exit
```


■Visual Studio CodeのAzure Account拡張機能

Azure Account - a single Azure sign-in and subscription filtering experience for all other Azure extensions
https://marketplace.visualstudio.com/items?itemName=ms-vscode.azure-account

F1 または Ctrl-Shift-P でコマンドパレットを起動
```
F1, Azure: Sign In
```
■Visual Studio CodeのAzure Account拡張機能

Azure Functions - quickly create, debug, manage, and deploy serverless apps directly from VS Code.
https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions
```
F1, Azure Functions: Deploy to Function App...
```
-->

<!--
■ラボ2 

ラボの手順書
https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_lab_02.html

- ※冒頭の「仮想マシンへのログイン」はスキップします。
- ※Microsoft Edge（ブラウザ）は、お好きなWebブラウザで代用できます。
- ※Windows terminalは、コマンドプロンプト、Windows PowerShell、MacのTerminal等で代用できます。

ラボのコードのダウンロード（緑色の「Code」ボタンをクリック、Download Zip）
https://github.com/MicrosoftLearning/AZ-204JA-DevelopingSolutionsforMicrosoftAzure
ZIPを展開すると、AllFiles/Labs以下にファイルがあります。

Azure Function Core Tools
https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-run-local#install-the-azure-functions-core-tools

.NET Core SDK 3.1
https://dotnet.microsoft.com/download
画面中央「.NET Core 3.1」の「SDK」をダウンロード、インストール。

Visual Studio Code
https://code.visualstudio.com/download

httprepl
https://docs.microsoft.com/ja-jp/aspnet/core/web-api/http-repl/#installation


■学習に役立つリソース

Microsoft Learn: サーバーレス アプリケーションの作成
https://docs.microsoft.com/ja-jp/learn/paths/create-serverless-applications/

サーバーレスコミュニティライブラリ: 多数のサンプルコード
https://serverlesslibrary.net/
-->
