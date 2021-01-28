# Azure Functions

Azure Functions はサーバーレス アプリケーション プラットフォームです。

これにより、開発者はインフラストラクチャをプロビジョニングすることなく実行できるビジネス ロジックをホストできます。 

Functions では、組み込みのスケーラビリティが提供され、使用されているリソースに対してのみ料金が請求されます。 

C#、F#、JavaScript、Python、PowerShell Core など、好みの言語で関数コードを記述することができます。

NuGet や NPM などのパッケージ マネージャーのサポートも含まれているので、ビジネス ロジック内で一般的なライブラリを使用することができます。

[製品ページ](https://azure.microsoft.com/ja-jp/services/functions/)

[概要](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-overview)

[登場時のブログ](https://azure.microsoft.com/en-us/blog/introducing-azure-functions/)

[Product teamのTwitterもあるよ！](https://twitter.com/AzureFunctions)

Microsoft Learn

- [サーバーレス アプリケーションの作成](https://docs.microsoft.com/ja-jp/learn/paths/create-serverless-applications/)
  - 最適な Azure サービスを選択してビジネス プロセスを自動化する
    - [ビジネス ロジックを実行するために Azure Functions を選択するのが適している状況](https://docs.microsoft.com/ja-jp/learn/modules/choose-azure-service-to-integrate-and-automate-business-processes/5-web-jobs-and-functions)
  - [Azure Functions を使用したサーバーレス ロジックの作成](https://docs.microsoft.com/ja-jp/learn/modules/create-serverless-logic-with-azure-functions/)
  - [トリガーを使用して Azure 関数を実行する](https://docs.microsoft.com/ja-jp/learn/modules/execute-azure-function-with-triggers/)
  - [入力バインディングと出力バインディングを使用して Azure Functions を連結する](https://docs.microsoft.com/ja-jp/learn/modules/chain-azure-functions-data-using-bindings/)
  - [Durable Functions を使って実行時間の長いサーバーレス ワークフローを作成する](https://docs.microsoft.com/ja-jp/learn/modules/create-long-running-serverless-workflow-with-durable-functions/)
  - [Azure Functions Core Tools を使用した Azure Functions の開発、テスト、および発行](https://docs.microsoft.com/ja-jp/learn/modules/develop-test-deploy-azure-functions-with-core-tools/)
  - [Visual Studio で Azure 関数を開発、テスト、デプロイする](https://docs.microsoft.com/ja-jp/learn/modules/develop-test-deploy-azure-functions-with-visual-studio/)
  - [Azure Functions で Webhook を使用して GitHub イベントを監視する](https://docs.microsoft.com/ja-jp/learn/modules/monitor-github-events-with-a-function-triggered-by-a-webhook/)
  - [Azure Functions と SignalR Service を使って、Web アプリケーションの自動更新を有効にする](https://docs.microsoft.com/ja-jp/learn/modules/automatic-update-of-a-webapp-using-azure-functions-and-signalr/)
  - [Azure API Management を使用して、複数の Azure Functions アプリを一貫した API として公開する](https://docs.microsoft.com/ja-jp/learn/modules/build-serverless-api-with-functions-api-management/)

[SlideShare](https://www2.slideshare.net/search/slideshow?searchfrom=header&q=azure+functions)


- [[HAKODATE Developer Conference 2018] 「Azure Functions」で始めるサーバーレス アプリケーション開発](https://www2.slideshare.net/satonaoki/20180929hakodateserverlessfunctions)
- [はじめよう Azure Functions](https://www.slideshare.net/okazuki0130/azure-functions-171815345)
- [ワタシハ Azure Functions チョットデキル](https://www.slideshare.net/TsuyoshiUshio/azure-functions-98577634)
- [今日から始める Azure Functions 2.0](https://www.slideshare.net/ssusercd7b97/azure-functions-20)
- [Azure Functions あれこれ](https://www.slideshare.net/yasuakimatsuda75/azure-functions-86808540)
- [Azure Functionsでサーバーレスアプリケーション構築](https://www.slideshare.net/r_matsumura/azure-functions-87655373)
- [Azure Functions 入門](https://www.slideshare.net/jz5/azure-functions-70025759)

その他

- [DE:CODE 2019 AWS 技術者向け Azure サーバーレス](https://eventmarketing.blob.core.windows.net/decode2019-after/decode19_PDF_CD07.pdf) AWS Lambdaとの比較でわかりやすい！

# リソースの作り方

- 検索＞「関数アプリ」
- 検索＞「Func」
- すべてのリソース＞「関数アプリ」

「関数アプリ」の中に、複数の「関数」を作成できます。

「関数アプリ」作成時に、「関数アプリ名」を指定する。アプリ名はグローバルで一意でなければならない。例：myfunc1234.azurewebsites.net （「myfunc1234」を指定）

公開（Publish）：「コード」と「Docker Container」

「コード」を選択した場合は、ランタイムスタックとバージョンを選択する。

OSをLinuxかWindowsから選ぶ。

プランを選ぶ。「消費量（サーバーレス）」「Premium」「App Serviceプラン」

監視：Application Insightsを有効にするか選択する。



# ストレージ アカウント

Azure Functions では、関数アプリを作成するときに [Azure ストレージ アカウントが必要](https://docs.microsoft.com/ja-jp/azure/azure-functions/storage-considerations)になります。

トリガーの管理や関数実行のログ記録などの操作に Azure Storage を使用しているためです。

そのアカウントが削除されると、**関数アプリは実行されません。**

[アプリケーション設定の「AzureWebJobsStorage」に、ストレージへの接続文字列（ストレージアカウントのキーを含む）が記録されている！](https://docs.microsoft.com/ja-jp/azure/azure-functions/storage-considerations#storage-account-connection-setting)

ストレージ キーを再生成する場合は、ストレージ アカウント接続文字列を更新する必要があります。


# [使用できる言語](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-versions#languages)

C#, JavaScript, F#, Java, PowerShell, Python, TypeScriptの7つ。

3つの「ランタイム バージョン」がある。1.x, 2,x, 3.x

ランタイム バージョンによって使えるバージョンが異なる。例:

- 2.x - .NET Core 2.2
- 3.x - .NET Core 3.1

関数アプリを作る際には、ランタイムバージョンを選択するのではなく、言語と言語のバージョンを選択する。それによってランタイムが決まる。

[それ以外の言語については、カスタム ハンドラーを使用します (実質上、言語の制限はありません)。](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-overview#scenarios)

# OS/ランタイム

https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#operating-systemruntime

プランにより、言語サポート状況が異なる。

# ハンドラー

すべての関数アプリは、言語固有のハンドラーによって実行されます。

Azure Functions では多くの言語ハンドラーが既定でサポートされています。

# [カスタム ハンドラー](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-custom-handlers) - 2020/5 パブリックプレビュー

カスタム ハンドラーは、Functions ホストからイベントを受信する軽量の Web サーバーです。HTTP プリミティブをサポートするすべての言語で、カスタム ハンドラーを実装できます。

カスタム ハンドラーは、次のような場合に最適です。
- [Go](https://golang.org/) や [Rust](https://www.rust-lang.org/ja) など、現在サポートされていない言語で関数アプリを実装する。
- [Deno](https://deno.land/) (A secure runtime for JavaScript and TypeScript) など、現在サポートされていないランタイムで関数アプリを実装する。

[Azure Functions for Rustの公式解説](https://docs.rs/azure-functions/0.2.6/azure_functions/)

[Azure Functions for Goの歴史](https://qiita.com/qt-luigi/items/ecb1045d3a7699ac5df6)

[Azure Functions で Go 言語を使おう](https://qiita.com/okazuki/items/e0f24afb00a01eff541d)

[PHP](https://acloudguru.com/blog/engineering/how-to-run-serverless-php-on-azure)

[Bellerina](https://ballerina.io/learn/deployment/azure-functions/)


# カスタム コンテナー

https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-create-function-linux-custom-image?pivots=programming-language-csharp&tabs=bash%2Cportal


# 開発に使用できるツール

Visual Studio
Visual Studio Code

# [Azure Functions 拡張機能 for Visual Studio Code](https://docs.microsoft.com/ja-jp/azure/azure-functions/create-first-function-vs-code-csharp)

# [Azure Functions Core Tools](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-run-local?tabs=windows%2Ccsharp%2Cbash)

Azure Functions Core Tools を使用すると、ローカル コンピューター上のコマンド プロンプトまたはターミナルから関数を開発およびテストできます。

https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-run-local?tabs=windows%2Ccsharp%2Cbash#v2

funcコマンド

# あらゆるところで動くAzure Functions

https://eventmarketing.blob.core.windows.net/decode2019-after/decode19_PDF_CD07.pdf

25ページ

- [ローカル開発環境](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-develop-local)
- Azure Functions
  - [Consumption Plan](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#consumption-plan)
  - [App Service Plan](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#dedicated-app-service-plan)
  - [Premium Plan](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#premium-plan)
- [Azure IoT Edge](https://azure.microsoft.com/ja-jp/updates/azure-functions-2-0-available-in-iot-edge/)
- [AKS](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-kubernetes-keda)
- [Service Fabric Mesh](https://docs.microsoft.com/ja-jp/azure/service-fabric-mesh/service-fabric-mesh-overview)
- K8S
- VM
- [App Service on Azure Stack](https://docs.microsoft.com/ja-jp/azure-stack/operator/azure-stack-app-service-deploy?view=azs-2008&pivots=state-disconnected)

コードを直接サービスの上で動かす方法と、Dockerコンテナ上で動かす方法がある。

[ご利用のアプリのニーズに変化が生じた場合は、そのプロジェクトを取得し、それを非サーバーレス環境にデプロイすることができます。](https://docs.microsoft.com/ja-jp/learn/modules/create-serverless-logic-with-azure-functions/2-decide-if-serverless-computing-is-right-for-your-business-need)


# [ngrok](https://ngrok.com/)

エングロック

ngrok allows you to expose a web server running on your local machine to the internet. Just tell ngrok what port your web server is listening on.

ローカルで稼働させたFunctionにインターネットからアクセスできる。
`http://abcd1234.ngrok.io -> localhost:8080` という感じ。


https://blog.okazuki.jp/entry/2018/03/28/202248

https://hackernoon.com/using-ngrok-with-azure-functions-7e209e96538c




# Microsoft Graph

[Microsoft Graph API を使用してユーザーの予定表情報を取得する Azure 関数を構築するチュートリアル](https://docs.microsoft.com/ja-jp/graph/tutorials/azure-functions)

このチュートリアルでは、Microsoft Graph を呼び出す HTTP トリガ関数を実装する簡単な Azure 関数を作成します。 




# 課金

従量課金プラン: 
- **実行数、実行時間、およびメモリの使用量**に基づいて行われ、 使用量は、関数アプリ内のすべての関数にわたって集計されます。
- 同じリージョンの関数アプリを同じ従量課金プランに割り当てることができます。同じ従量課金制プランで複数のアプリケーションを実行しても、マイナス面や影響はありません。 同じ従量課金プランに複数のアプリを割り当てても、各アプリの回復性、スケーラビリティ、または信頼性には影響しません。

Premium プラン:
- 実行や消費されたメモリごとの課金ではなく、**インスタンス全体に割り当てられているコア秒数とメモリに基づいています**。

App Serviceプラン:
- App Service プランの関数アプリに対する支払いは、Web アプリなどの他の App Service リソースの場合と同じです。
- App Service Environment (ASE) で実行すると、関数を完全に分離し、App Service Plan より多い数のインスタンスを活用できます。

# 常時接続

**App Service プランを実行する場合、関数アプリが正常に実行されるように、常時接続 設定を有効にする必要があります。**

App Service プランでは、関数のランタイムは非アクティブな状態が数分続くとアイドル状態となるため、関数を "起こす" ことができるのは HTTP トリガーのみとなります。 常時接続は App Service プランでのみ使用可能です。

# コールドスタート

関数アプリが数分の間アイドル状態になると、プラットフォームによって、アプリが実行されるインスタンスの数が 0 にスケール ダウンされる可能性があります。 コールド スタートが関数に影響を与えている場合は、Always On が有効になっている Premium プランまたは専用プランで実行することを検討してください。

# [スケーラビリティ](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale)

従量課金プランと Premium プランのいずれも、コードの実行時に自動的にコンピューティング能力が追加されます。 アプリは、負荷を処理する必要があるときはスケールアウトされ、コードの実行が停止するとスケールインされます。

App Service プランでは、お客様が管理している専用のインフラストラクチャを利用できます。 関数アプリを使用しても、イベントに基づくスケーリングは行われません。つまり、ゼロにスケールインされることはありません。 ([常時接続] を有効にする必要があります)。

従量課金プランのアプリに対し、「スケールアウト制限」を適用することができる。適用時1～200（インスタンス）から指定。

[hosts.json](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-http-webhook-output#hostjson-settings)に、並列で実行される HTTP 関数の最大数 maxConcurrentRequests	（デフォルト：100）というプロパティがある。

host.json ファイルの設定は、アプリ内のすべての関数 (関数の "1 つのインスタンス") に適用されます。

# 性能

[Premiumプラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-premium-plan)では Premium コンピューティング インスタンスが利用できる。

# [パフォーマンスと信頼性の最適化（ベスプラ）](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-best-practices)

一般

- 実行時間の長い関数を使用しない - 小さい関数に分割
- 関数間の通信 - Durable Functions, Logic Apps, キュー、Event Hubsを使用
- ステートレスな関数を記述する - なるべくステートレスかつべき等に。
- 防御的な関数を記述する - 関数が途中で止まる場合を考慮

スケーラビリティ

- 接続の共有と管理 - 接続を可能な限り再利用
- ストレージ アカウントの共有を回避する - 関数アプリごとに別のストレージアカウントを使う
- 同じ関数アプリにテスト コードと運用環境のコードを混在させない - テスト関連コードは分ける
- 非同期コードを使用し、呼び出しのブロックは避ける - TaskのResultプロパティ参照やwaitメソッド呼び出しを避ける
- 複数のワーカー プロセスを使用する - Pythonなどのシングルスレッドランタイムの場合に、ワーカースレッドを増やす
- 可能な限りメッセージをバッチで受信する - 1回の呼び出しで複数個のメッセージを受信する
- コンカレンシーを適切に処理するようにホストの動作を構成する - host.jsonで今カレンシーを設定することで多数の同時要求に対応

# [監視・モニタリング・ログ](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-monitoring)

Azure Functions には、関数を監視するための Azure Application Insights とのビルトイン統合機能が用意されています。

Application Insights を使用すると、ログ、パフォーマンス、およびエラー データを収集できます。 パフォーマンスの異常が自動的に検出されるほか、強力な分析ツールが特徴となっていて、より簡単に、問題を診断したり、関数がどのように使用されているかを理解したりすることができます。 


Application Insights インストルメンテーションは Azure Functions に組み込まれているため、関数アプリを Application Insights リソースに接続するためには、有効なインストルメンテーション キーが必要です。 インストルメンテーション キーは、Azure 内に関数アプリのリソースを作成するときに、アプリケーション設定に追加されます。 関数アプリにまだこのキーがない場合は、手動で設定できます。

# Event hubsとの統合

# [API Managementとの統合](https://docs.microsoft.com/ja-jp/azure/api-management/import-function-app-as-api)

# VNetから呼び出す/VNetにアクセスする

# サービスとの統合

Azure Functionsは、Azureの様々なサービスや、サードパーティのサービスと[組み合わせて使用](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-triggers-bindings?tabs=csharp#supported-bindings)することができます。

たとえば、Blob Storageに新しいBlobがアップロードされたときに、[関数を実行する](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-storage-blob-trigger?tabs=csharp)ことができます。


※[Twilio](https://www.twilio.com/ja/)社は、音声、SMS、チャットなどの機能をすばやくアプリケーションに組み込むサービスを提供しています。[Azure FunctionsのTwilioバインド](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-twilio?tabs=csharp)を使用すると、Twilioを経由して、指定された電話番号宛てにテキスト メッセージ（SMS）を送信することができます。[Microsoft Learnの解説](https://docs.microsoft.com/ja-jp/learn/modules/send-location-over-sms-using-azure-functions-twilio/)もあります。

# ホスティング方法

Azure で関数アプリを作成するときは、アプリのホスティング プランを選択する必要があります。

選択したホスティング プランによって、次の動作が決まります。
- 関数アプリをスケールする方法。
- 各関数アプリ インスタンスに利用できるリソース。
- Azure Virtual Network 接続などの高度な機能のサポート。

「関数アプリ」を作成する際に、「ホスティング」タブで指定します。

- [消費量（サーバーレス）](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#consumption-plan) - 従量課金プラン、Consumptionとも呼ばれます。関数の実行中にのみコンピューティング リソースに対して料金が発生します。
- [Premium](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#premium-plan) - 常にウォーム状態をキープ、VNet接続をサポート
- [App Serviceプラン](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#dedicated-app-service-plan) - 「専用プラン」とも呼ばれます。すでに存在するApp Service上で関数を稼働させます。

# タイムアウト期間

プランによって、関数アプリの[タイムアウト期間](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#function-app-timeout-duration)が決まります。

従量課金: デフォルトは5分、最大は10分に設定できます。

Premium、App Serviceプランでは、最大値を無制限に設定できます。

[HTTP トリガー関数の場合は最大230秒](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#function-app-timeout-duration)。※トリガーにもいろいろな種類があり（ストレージのトリガーやCosmos DBトリガーなど）、そのうちの1つがHTTPトリガー（HttpTrigger）である。

[Azure Durable Functions](mod02-02-durable-functions.md) ... ステートフル、タイムアウトなし。

# イベント ドリブン

Functions は "イベント ドリブン" です。 つまり、HTTP 要求やキューに追加されているメッセージの受信などのイベント ("トリガー" と呼ばれる) への応答でのみ実行されます。 

キュー、BLOB、ハブなどを監視するコードを記述する必要はありません。純粋にビジネス ロジックに専念できます。

# トリガーとバインド

関数の「統合」ブレードに「トリガー」「入力」「関数」「出力」がある。

入力、出力で、新しいバインドを追加できる。たとえば「入力」バインドで「Azure Blob Storage」を選び、パラメータとして接続文字列、パス、パラメータ名などを指定する。

# トリガー

トリガーは、関数が実行される原因です。 トリガーで関数の呼び出し方法が定義されます。

**1 つの関数には正確に 1 つのトリガーを含める必要があります。**

Azure portalでは、新しい関数を追加する際に、「テンプレート」から選択することで、「HTTP trigger」「Timer trigger」「Blob Storage trigger」

※[トリガーは、実行を開始する機能を別途備えた特殊な入力バインドです](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-add-output-binding-storage-queue-vs-code?pivots=programming-language-csharp)。

# Blob トリガーの問題をQueueで解決

https://tech-lab.sios.jp/archives/7505


# バインド（バインディング）

関数へのバインドは、関数に別のリソースを宣言的に接続する方法です。

バインドを使用することで、データに接続するためのコードの記述が不要となります。たとえば、Blob Storageのバインドを使用することで、Blobに接続する入出力の準備を行うコードを関数内に記述する必要がなくなります。

バインドは入力バインド または出力バインド、あるいは両方として接続される場合があります。 

バインドからのデータは、パラメーターとして関数に提供されます。

バインドは省略可能であり、関数には 1 つまたは複数の入力または出力バインドがある場合があります。

Azure portalでは、関数を作成したあとで、「統合」で、「入力」と「出力」の部分で、バインドを設定できます。

# [カスタムバインディング](https://github.com/Azure/azure-webjobs-sdk/wiki/Creating-custom-input-and-output-bindings)

例: [Slackに出力するoutput binding](https://github.com/lindydonna/SlackOutputBinding) - allows you to write a Slack message by just adding an output binding!


# functions.json

トリガー、バインドが定義されます。

以下のサンプルは次のものを定義しています。

- Queueの入力トリガー
- Tableの出力バインド

```
{
  "bindings": [
    {
      "name": "order",
      "type": "queueTrigger",
      "direction": "in",
      "queueName": "myqueue-items",
      "connection": "MY_STORAGE_ACCT_APP_SETTING"
    },
    {
      "name": "$return",
      "type": "table",
      "direction": "out",
      "tableName": "outTable",
      "connection": "MY_TABLE_STORAGE_ACCT_APP_SETTING"
    }
  ]
}
```

※[Queue](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-storage-queue)にはトリガーと出力バインドがある。入力バインドは定義されていない。つまり、キューのイベントから関数を起動することができ、またバインドを使ってキューにメッセージを書き込める。

※[Table](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-storage-table) には入力バインドと出力バインドがあるが、 [トリガーはない。](https://stackoverflow.com/questions/59311828/triggering-an-event-when-an-azure-storage-account-table-is-updated) つまり、他のイベントで起動した関数において、バインドを使用して、テーブルから読み込んだり、テーブルに書き込んだりできる。テーブルに書き込まれたときに関数を起動したい場合は、キューのトリガーと併用するなどして対処できる。

# Azure portalでの開発

Azure portal上でコードを編集したり、テスト実行したりすることができる。

「監視ダッシュボード」で、実行履歴を確認できる。履歴では、成否、結果コード、時間、操作IDなどが確認できる。

関数内でログを出力することができる。「ログウィンドウ」に表示される。

# 関数キー

関数を作成したときにキーが1つ生成されます。Anonymous以外に設定した場合は、キーがないとアクセスできなくなります。

# host.json

関数アプリのトップに配置します。

Application Insightの設定など、複数の関数に共通する設定をここで記述します。

# function.json

関数アプリ以下の、各関数のディレクトリ以下に配置します。

トリガーとバインドの設定をこのファイルに記述します。

directionがinのものが入力バインド、outのものが出力バインドとなります。

# ローカルでの開発


# 関数アプリの「ホームページ」を無効にする

関数アプリのURLにアクセスすると
"Your Functions 3.0 app is up and running"
のようなメッセージと青い画面が表示される。
これを無効にするには、
アプリケーション設定で `AzureWebJobsDisableHomepage` を作り、その値を `true` にする。

# 「アプリケーション設定」と「接続文字列」の違い

https://tech-blog.cloud-config.jp/2020-03-25-why-application-setting-and-connection-string-exists-in-web-app/

# 設定ファイル

[hosts.json](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-host-json)

host.json メタデータ ファイルには、関数アプリのすべての関数に影響するグローバル構成オプションが含まれています。

[function.json](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-reference)

function.json ファイルには、関数のトリガー、バインド、その他の構成設定を定義します。 

[local.settings.json](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-run-local?tabs=windows%2Ccsharp%2Cbash#local-settings-file)

local.settings.json ファイルには、アプリの設定、接続文字列、およびローカルの開発ツールによって使用される設定が格納されます。 local.settings.json ファイル内の設定は、プロジェクトをローカルで実行している場合にのみ使用されます。