# Azure SignalR Service

リアルタイムの Web 機能をアプリケーションに追加するプロセスを簡略化するサービス。

公式 https://azure.microsoft.com/ja-jp/services/signalr-service/

価格 https://azure.microsoft.com/ja-jp/pricing/details/signalr-service/

ドキュメント https://docs.microsoft.com/ja-jp/azure/azure-signalr/signalr-overview

■歴史

2018/5/7 パブリックプレビュー https://azure.microsoft.com/ja-jp/blog/azure-signalr-service-a-fully-managed-service-to-add-real-time-functionality/


2018/9/24 一般提供開始 https://azure.microsoft.com/ja-jp/blog/azure-signalr-service-now-generally-available/


■ 「SignalR」 と 「Azure SignalR Service」 の違い（「SignalR」 ではなく 「Azure SignalR Service」 を使う理由）

[なぜ SignalR を自分でデプロイしないのか](https://docs.microsoft.com/ja-jp/azure/azure-signalr/signalr-concept-scale-aspnet-core#why-not-deploy-signalr-myself)

> ASP.NET Core SignalR をバックエンド コンポーネントとしてサポートする独自の Azure Web アプリを全体的な Web アプリケーションにデプロイするアプローチは依然として有効です。

> Azure SignalR サービスを使用する主な理由の 1 つは、シンプルさです。 Azure SignalR サービスでは、パフォーマンス、スケーラビリティ、可用性などの問題を処理する必要がありません。

> 別の理由は、Web アプリケーションを実際にホストする必要がまったくない可能性があることです。

[ASP.NET Core SignalR から Azure SignalR Service への移行](https://jpdsi.github.io/blog/web-apps/MigrationAzureSignalR/)

> Azure SignalR Serviceは、ASP.NET Core SignalRフレームワーク上に構築されており、リアルタイムのWeb機能を実現するという点についてはASP.NET Core SignalRと大きな違いはございません。

> 主な特徴としてはAzure SignalR Serviceを使用する場合、クライアントはアプリケーションサーバーではなくAzure SignalR Serviceに接続することです。

[Azure SignalR Service のメリット](https://jpdsi.github.io/blog/web-apps/MigrationAzureSignalR/#Azure-SignalR-Service-%E3%81%AE%E3%83%A1%E3%83%AA%E3%83%83%E3%83%88)



■用途

[Azure SignalR サービスの用途](https://docs.microsoft.com/ja-jp/azure/azure-signalr/signalr-overview#what-is-azure-signalr-service-used-for)


■Azure Functionsとの連携

Azure Functions の Azure SignalR Service トリガー・バインド https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-signalr-service

Blog記事: [Azure Functions で SignalR Service バインドを使用したリアルタイムのサーバーレス アプリケーション](https://azure.microsoft.com/ja-jp/blog/real-time-serverless-applications-with-the-signalr-service-bindings-in-azure-functions/)

> Cosmos DB 変更フィード、Azure Functions、SignalR Service を組み合わせて使用することにより、これらの更新を受信するクライアントの登録と更新自体のプッシュを行うわずか数行のコードを記述するだけで、リアルタイムな UI の更新を自動化できます。


■Event Gridとの連携

SignalRのクライアントが接続・接続解除した際にイベントが発生する。そのイベントをEvent Gridに通知できる。

[イベントを Azure SignalR Service から Event Grid に送信する](https://docs.microsoft.com/ja-jp/azure/azure-signalr/signalr-howto-event-grid-integration)

[SignalR Service 用の Azure Event Grid イベント スキーマ](https://docs.microsoft.com/ja-jp/azure/event-grid/event-schema-azure-signalr)

[Azure SignalR Service and Event Grid Walkthrough](https://microsoft.github.io/AzureTipsAndTricks/blog/blog/tip243.html)


■シリアル化オプション

https://docs.microsoft.com/ja-jp/aspnet/core/signalr/configuration?view=aspnetcore-6.0&tabs=dotnet#jsonmessagepack-serialization-options

メッセージをエンコードするため、JSON と MessagePack がサポートされている。

■サービス モード

https://docs.microsoft.com/ja-jp/azure/azure-signalr/concept-service-mode

- 既定モード
- サーバーレス モード
- クラシック モード


■ネゴシエート要求

https://jp.infragistics.com/products/ignite-ui-angular/angular/components/general/how-to/signal-r-service-live-data

> SignalR が最新のクライアントとサーバーを処理する方法であり、利用可能な場合は内部で WebSockets を使用し、そうでない場合は他の技術とテクノロジーに適切にフォールバックします。
> それはハンドシェイクのようなもので、クライアントとサーバーは何を使用するかについて合意します。これはプロセス ネゴシエーションと呼ばれます。


https://www.souya.biz/blog/2016/07/22/asp-net-signalr-%E3%81%A8%E3%81%AF/

> トラスポートの自動ネゴシエーション

https://docs.microsoft.com/ja-jp/azure/azure-signalr/signalr-concept-internals#client-connections

- 各ハブの negotiate エンドポイントが作られる
- クライアントがnegotiate エンドポイントに「ネゴシエート要求」を送信し、「クライアントアクセスURL」（アクセストークン）を受信する。

https://jpdsi.github.io/blog/web-apps/MigrationAzureSignalR/

> クライアントはサーバーへ接続のネゴシエーション要求を送る
> サーバーはアクセストークンとURLとともにAzure SignalR Serviceにリダイレクトする
> クライアントはAzure SignalR Serviceと永続的な接続を確立する

https://docs.microsoft.com/ja-jp/aspnet/core/signalr/configuration?view=aspnetcore-6.0&tabs=dotnet#configure-additional-options

SkipNegotiation

> ネゴシエーション手順をスキップするには、これを true に設定します。 WebSocket トランスポートが唯一有効なトランスポートである場合にのみサポートされます。 この設定は、Azure SignalR サービスを使用する場合は有効にできません。

https://qiita.com/akiojin/items/ad8b61f63b129c40ed6d

> SignalR.Client では HubConnection というクラスがありますが、このクラスが SignalR に接続する際にデフォルトでは最初に negotiate 関数にアクセスを行います。
> negotiate 関数では SignalR に接続するための URL やアクセストークンなどの情報をクライアントに返す役割を持っている

