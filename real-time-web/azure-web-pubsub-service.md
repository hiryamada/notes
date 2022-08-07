# Azure Web PubSub Service

「WebSocket」 と「パブリッシュ-サブスクライブ パターン」を使用して、リアルタイム メッセージング Web アプリケーションを作成するためのサービス。

サーバーと接続クライアント (シングル ページ Web アプリケーション、モバイル アプリケーションなど) との間でコンテンツの更新をパブリッシュできる。

公式 https://azure.microsoft.com/ja-jp/services/web-pubsub/

価格 https://azure.microsoft.com/ja-jp/pricing/details/web-pubsub/

ドキュメント https://docs.microsoft.com/ja-jp/azure/azure-web-pubsub/

YouTube [Build WebSocket-based web apps with the Azure Web PubSub Service](https://www.youtube.com/watch?v=0Oa-PApgNnw)


■歴史

2021/4/29 プレビュー https://azure.microsoft.com/en-us/blog/easily-build-realtime-apps-with-websockets-and-azure-web-pubsub-now-in-preview/

2021/11/16 一般提供開始 https://azure.microsoft.com/ja-jp/blog/build-realtime-web-apps-with-azure-web-pubsub-now-generally-available/

■用途

https://docs.microsoft.com/ja-jp/azure/azure-web-pubsub/overview#what-is-azure-web-pubsub-service-used-for

- ダッシュボード
- IoT監視
- チャット
- ゲーム
- 投票
- オークション
- リアルタイムプッシュ広告
- ホワイトボードアプリ
- ニュースやイベントのブロードキャスト


■ 「Azure SignalR Service」 と 「Azure Web PubSub Service」 の違い

- [Azure SignalR Service](azure-signalr-service.md): 2018～
- [Azure Web PubSub Service](azure-web-pubsub-service.md): 2021～

|サービス|登場時期|特徴|
|-|-|-|
|Azure SignalR Service|2018年～|リアルタイムの Web 機能を HTTP 経由でアプリケーションに追加するプロセスを簡略化。サービスが、接続されているクライアントにシングル ページ Web やモバイル アプリケーションなどのコンテンツの更新をプッシュできる。サーバーからクライアントにリアルタイムでデータをプッシュする必要があるすべてのシナリオで使用できる。|
|Azure Web PubSub Service|2021年～|WebSocket とパブリッシュ-サブスクライブ パターンを使用して、リアルタイム メッセージング Web アプリケーションを作成。サーバーと接続クライアント (シングル ページ Web アプリケーション、モバイル アプリケーションなど) との間でコンテンツの更新をパブリッシュ。|

Azure SignalR ServiceはWebSocket「も」使える（その他のプロトコルを使う場合もある - ネゴシエーションによる）。Azure Web PubSub ServiceはWebSocket「のみ」使う。

https://twitter.com/davidfowl/status/1387885010665967617

> How is it different from SignalR you ask? Well internally it's built on the same underlying tech but the big difference is that there's no client requirement or protocol requirement, BYOWL (bring your own websocket library).

Azure SignalR Service では、SignalRクライアントライブラリを使う。Azure Web PubSub Service では 任意のWebSocketクライアントライブラリを使える。

[Azure SignalR Service と Azure Web PubSub サービスのどちらかを選択するにはどうすればよいですか?](https://docs.microsoft.com/ja-jp/azure/azure-web-pubsub/resource-faq#how-do-i-choose-between-azure-signalr-service-and-azure-web-pubsub-service)

一般に、既に SignalR ライブラリを使用してリアルタイム アプリケーションを構築している場合は、Azure SignalR Service を選択。

WebSocket とパブリッシュ/サブスクライブ パターンに基づいてリアルタイム アプリケーションを構築する汎用ソリューションを探している場合は、Azure Web PubSub サービスを選択。

■Azure portalからの作成

「Web PubSub Service」

Pricing tierがFree、Standard、Premiumとある。同時接続数、一日に送信できるメッセージ数、SLA、可用性ゾーン対応、カスタムドメインの利用可否などが異なる。Premiumの場合、1ユニットあたり6832円、ユニットあたり100万メッセージを超えると追加料金。

ユニットは1～100。

パブリックエンドポイントまたはプライベートエンドポイント利用可能。

■Azure Functionsとの連携が可能

[トリガーとバインド](https://docs.microsoft.com/ja-JP/azure/azure-web-pubsub/reference-functions-bindings)が利用できる。

[チュートリアル: Azure Functions と Azure Web PubSub サービスを使用してサーバーレスのリアルタイム チャット アプリを作成する](https://docs.microsoft.com/ja-jp/azure/azure-web-pubsub/quickstart-serverless?tabs=javascript)


■アクセスキー（接続文字列）とアクセストークン（クライアントアクセスURL）

- アクセスキー
  - 接続文字列には「アクセスキー」が含まれる。
  - アクセス キーを他のユーザーに配布したり、ハードコーディングしたりしてはいけない。
- アクセストークン
  - クライアントがサーバーの「ネゴシエートエンドポイント」に接続して払い出される
  - JWT形式
  - クライアントアクセスURLの末尾に付与される
  - wss://インスタンス名.webpubsub.azure.com/client/hubs/ハブ名?access_token=アクセストークン

■クイックスタート

[クイックスタート: ブラウザーから Azure Web PubSub インスタンスに接続する](https://docs.microsoft.com/ja-jp/azure/azure-web-pubsub/quickstart-live-demo)

オンラインですぐに試せるデモ。作成済みのAzure Web PubSubにWebブラウザーから接続してチャット。

■チュートリアル - コンソールアプリ

[チュートリアル: WebSocket API と Azure Web PubSub サービス SDK を使用してメッセージの発行とサブスクライブを行う](https://docs.microsoft.com/ja-jp/azure/azure-web-pubsub/tutorial-pub-sub-messages?tabs=csharp)

ざっくりとした流れ

- Azure上に Web PubSub Service のリソースを作る
  - Keys から、接続文字列をコピー
- Publisher（サーバー側）のプロジェクトを作る
  - [Azure.Messaging.WebPubSub パッケージ](https://www.nuget.org/packages/Azure.Messaging.WebPubSub) (クライアントライブラリ)を追加する
  - エンドポイント、ハブ名、キーを使用して接続する
  - メッセージを送信する
- Receiver（クライアント側）のプロジェクトを作る
  - [Websocket.Client パッケージ](https://www.nuget.org/packages/Websocket.Client/)を追加する
  - サーバーと同様の方法で自前でURLを取得する
    - 本来は、クライアント側には接続文字列を持たせず、サーバー側から、Web PubSub Service に接続するためのアクセストークン(ClientAccessUri)を発行してもらう。
  - WebSocketで Web PubSub Service に接続し、サブスクライブする
  - メッセージを受信する

Websocket.Client ではなく System.Net.WebSocket を直接使おうとするとつらいらしい https://zenn.dev/drumath2237/scraps/b3b4fe1f0a97db

■チュートリアル - Webアプリ

[チュートリアル: Azure Web PubSub サービスを使用してチャット アプリを作成する](https://docs.microsoft.com/ja-jp/azure/azure-web-pubsub/tutorial-build-chat?tabs=csharp)

ざっくりとした流れ

- Azure上に Web PubSub Service のリソースを作る（azコマンドを使用）
- 接続文字列を取得
- ASP.NET Coreのプロジェクトを作成 dotnet new web
- [Microsoft.Azure.WebPubSub.AspNetCore パッケージ](https://www.nuget.org/packages/Microsoft.Azure.WebPubSub.AspNetCore/)を追加
- `wwwroot/index.html`を作成
- `Program.cs`に`using Microsoft.Azure.WebPubSub.Common;`を追加
- DIコンテナーに Web PubSub のサービスクライアントを追加する。ここで接続文字列と、イベントを処理するクラス`Sample_ChatApp`を指定。
- ```c#
  builder.Services.AddWebPubSub(
    o => o.ServiceEndpoint = new ServiceEndpoint("<connection_string>"))
    .AddWebPubSubServiceClient<Sample_ChatApp>();
  ```
- ```c#
  sealed class Sample_ChatApp : WebPubSubHub
  {
      private readonly WebPubSubServiceClient<Sample_ChatApp> _serviceClient;
      // コンストラクターで WebPubSubServiceClient を受け取る
      public Sample_ChatApp(WebPubSubServiceClient<Sample_ChatApp> serviceClient)
      {
          _serviceClient = serviceClient;
      }
      // connectedイベントがトリガーされた場合の処理
      public override async Task OnConnectedAsync(ConnectedEventRequest request)
      {
          // すべてのクライアントにブロードキャスト
          await _serviceClient.SendToAllAsync($"[SYSTEM] {request.ConnectionContext.UserId} joined.");
      }
      // message イベントがトリガーされた場合の処理
      public override async ValueTask<UserEventResponse> OnMessageReceivedAsync(UserEventRequest request, CancellationToken cancellationToken)
      {
          // すべてのクライアントにブロードキャスト
          await _serviceClient.SendToAllAsync($"[{request.ConnectionContext.UserId}] {request.Data}");

          return request.CreateResponse($"[SYSTEM] ack.");
      }
  }
  ```
- ネゴシエートエンドポイントを追加。`/negotiate?id=taro` のような形で呼び出され、「クライアントアクセスURL」を生成する。
- ```c#
  app.UseEndpoints(endpoints =>
  {
    endpoints.MapGet("/negotiate", async  (WebPubSubServiceClient<Sample_ChatApp> serviceClient, HttpContext context) =>
    {
        var id = context.Request.Query["id"];
        if (id.Count != 1)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("missing user id");
            return;
        }
        await context.Response.WriteAsync(serviceClient.GetClientAccessUri(userId: id).AbsoluteUri);
    });
    // イベントハンドラー
    endpoints.MapWebPubSubHub<Sample_ChatApp>("/eventhandler/{*path}");
  });
  ```
- `wwwroot/index.html`の中身を作成。アクセス時、ダイアログで名前を入力。ネゴシエートエンドポイントにアクセスして「クライアントアクセスURL」を受け取り、WebSocket通信を開始する。
- ```html
  <html>

  <body>
    <h1>Azure Web PubSub Chat</h1>
    <input id="message" placeholder="Type to chat...">
    <div id="messages"></div>
    <script>
      (async function () {
        let id = prompt('Please input your user name');
        let res = await fetch(`/negotiate?id=${id}`);
        let url = await res.text();
        let ws = new WebSocket(url);
        ws.onopen = () => console.log('connected');

        let messages = document.querySelector('#messages');
        ws.onmessage = event => {
          let m = document.createElement('p');
          m.innerText = event.data;
          messages.appendChild(m);
        };

        let message = document.querySelector('#message');
        message.addEventListener('keypress', e => {
          if (e.charCode !== 13) return;
          ws.send(message.value);
          message.value = '';
        });
      })();
    </script>
  </body>

  </html>
  ```
- [ngrok](https://ngrok.com/) または [loophole](https://loophole.cloud/) を起動する。
  - ログインしないとうまく動かなかった
  - [このIssue](https://github.com/MicrosoftDocs/azure-docs/issues/86799)と同様の現象。AbuseProtectionResponseMissingAllowedOrigin
  - Web PubSubの「監視＞Live trace settings」から「Open Live Trace Tool」で詳細なライブトレースをキャプチャできる。
- インターネット上にURLが生成され、そのアドレスでlocalhostにアクセスできるようになる。
- コマンド実行時に表示されたURLをコピー。
- ```sh
  # ngrokの場合
  (ngrokのアカウントでログインが必要)
  ngrok config add-authtoken ...
  ngrok http 8080
  # loopholeの場合
  loophole account login
  loophole http 8080
  ```
- Web PubSub上に「ハブ」を作る（サービス イベント ハンドラーを設定）。
  - portalの 設定＞Settings からもハブを追加できる。
  - ハブの中に「Url template」「ハンドルするイベント」（システムイベントとユーザーイベントを選択）が設定される。
  ```
  az webpubsub hub create -n "<your-unique-resource-name>" -g "myResourceGroup" --hub-name "Sample_ChatApp" --event-handler url-template="https://<domain-name>.ngrok.io/eventHandler" user-event-pattern="*" system-event="connected"
  ```
- `dotnet run --urls http://localhost:8080` で、ローカルでプロジェクトを起動する
- Webブラウザーで http://localhost:8080/index.html にアクセスする
- 名前を入力し、メッセージを送信する（チャットとして動作）

■チュートリアル - Azure Functions

[チュートリアル: Azure Functions と Azure Web PubSub サービスを使用してサーバーレス通知アプリを作成する](https://docs.microsoft.com/ja-jp/azure/azure-web-pubsub/tutorial-serverless-notification?tabs=javascript)


ざっくりとした流れ

- 関数アプリのプロジェクトを作成
- index.htmlを作成
  - negotiate関数を使用してクライアントアクセスURLを取得しWebSocket接続
  - 温度データ（ランダム）が「通知」されたら画面を更新
- index関数を作成
  - HTTPトリガー
  - index.htmlを返す
  - 認証なし
- negotiate関数を作成
  - HTTPトリガー
  - クライアントアクセスURLを返す
  - index.htmlの中のJavaScriptから呼ばれる
  - 認証なし
- notification関数を作成
  - タイマートリガー,10秒ごとに起動
  - サービスクライアントを使用して、温度データ（ランダム）を「通知」

