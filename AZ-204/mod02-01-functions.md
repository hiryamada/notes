Azure Functions

Azure Functions はサーバーレス アプリケーション プラットフォームです。

これにより、開発者はインフラストラクチャをプロビジョニングすることなく実行できるビジネス ロジックをホストできます。 

Functions では、組み込みのスケーラビリティが提供され、使用されているリソースに対してのみ料金が請求されます。 

C#、F#、JavaScript、Python、PowerShell Core など、好みの言語で関数コードを記述することができます。

NuGet や NPM などのパッケージ マネージャーのサポートも含まれているので、ビジネス ロジック内で一般的なライブラリを使用することができます。

[製品ページ](https://azure.microsoft.com/ja-jp/services/functions/)

[概要](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-overview)

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


# リソースの作り方

- 検索＞「関数アプリ」
- 検索＞「Func」
- すべてのリソース＞「関数アプリ」

「関数アプリ」の中に、複数の「関数」を作成できます。

# ストレージ アカウント


Azure Functions では、関数アプリを作成するときに [Azure ストレージ アカウントが必要](https://docs.microsoft.com/ja-jp/azure/azure-functions/storage-considerations)になります。

トリガーの管理や関数実行のログ記録などの操作に Azure Storage を使用しているためです。

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

# トリガー

トリガーは、関数が実行される原因です。 トリガーで関数の呼び出し方法が定義されます。

1 つの関数には正確に 1 つのトリガーを含める必要があります。

Azure portalでは、新しい関数を追加する際に、「テンプレート」から選択することで、「HTTP trigger」「Timer trigger」「Blob Storage trigger」

※[トリガーは、実行を開始する機能を別途備えた特殊な入力バインドです](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-add-output-binding-storage-queue-vs-code?pivots=programming-language-csharp)。

# バインド（バインディング）

関数へのバインドは、関数に別のリソースを宣言的に接続する方法です。

バインドを使用することで、データに接続するためのコードの記述が不要となります。たとえば、Blob Storageのバインドを使用することで、Blobに接続する入出力の準備を行うコードを関数内に記述する必要がなくなります。

バインドは入力バインド または出力バインド、あるいは両方として接続される場合があります。 

バインドからのデータは、パラメーターとして関数に提供されます。

バインドは省略可能であり、関数には 1 つまたは複数の入力または出力バインドがある場合があります。

Azure portalでは、関数を作成したあとで、「統合」で、「入力」と「出力」の部分で、バインドを設定できます。

# モニター

関数の成功数・エラー数を確認したり、ログに対してクエリを実行したりすることができます。

# 関数キー

関数を作成したときにキーが1つ生成されます。Anonymous以外に設定した場合は、キーがないとアクセスできなくなります。

# host.json

関数アプリのトップに配置します。

Application Insightの設定など、複数の関数に共通する設定をここで記述します。

# function.json

関数アプリ以下の、各関数のディレクトリ以下似配置します。

トリガーとバインドの設定をこのファイルに記述します。

directionがinのものが入力バインド、outのものが出力バインドとなります。
