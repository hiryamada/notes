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

■Azureのサービスとの統合

さまざまなAzureサービスと統合されている。
イベントによる起動、データの送受信などを簡単に実現できる。

すべての一覧（サポートされているバインディング）:
https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-triggers-bindings?tabs=csharp#supported-bindings

Twilio（トゥイリオ）: これは、サードパーティ製のサービス。APIを使用して、テキストメッセージ（SMS）を送信したりすることができる。

解説動画: https://www.youtube.com/watch?v=1QfaGZ2Gm9g

Functionsのドキュメント: https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-twilio

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

■ストレージアカウント

Azure Functions では、Function App インスタンスを作成するときに Azure ストレージ アカウントが必要になります。

アカウントが削除されると、関数アプリは実行されません。

最適なパフォーマンスを得るには、関数アプリで同じリージョンのストレージ アカウントを使用する必要があります。

複数の関数アプリで1つのストレージアカウントを共有してもよい。

ただし、パフォーマンスを最大化するには、関数アプリごとに個別のストレージ アカウントを使用する。

https://docs.microsoft.com/ja-jp/azure/azure-functions/storage-considerations

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

■各言語でのトリガー・バインドの指定方法:

- C#: 属性で指定。
- Java: アノテーションで指定。
- C#スクリプト(～.csx), JavaScript等: function.json ファイルに指定

■Durable Functions

Durable: 永続性のある、恒久的な

[参考資料](../AZ-204/pdf/mod02/durable-function.pdf)

■学習に役立つリソース

Microsoft Learn: サーバーレス アプリケーションの作成
https://docs.microsoft.com/ja-jp/learn/paths/create-serverless-applications/

サーバーレスコミュニティライブラリ: 多数のサンプルコード
https://serverlesslibrary.net/
