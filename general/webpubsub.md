# Azure Web PubSub

- WebSocket とパブリッシュ-サブスクライブ パターンを使用して、リアルタイム メッセージング Web アプリケーションを作成。
- 数百万のクライアント接続に対応。
- Web ブラウザー、モバイル ブラウザー、デスクトップ アプリ、モバイル アプリ、サーバー プロセス、IoT デバイス、ゲーム コンソールなど、多様なクライアントに対応。
- [Azure Functionsとネイティブに統合(トリガー、バインド)](https://docs.microsoft.com/ja-jp/azure/azure-web-pubsub/reference-functions-bindings?tabs=csharp)
- 応用例: ゲーム、投票、ポーリング、オークション、チャット、ダッシュボードなど。


製品ページ
https://azure.microsoft.com/ja-jp/services/web-pubsub/

ドキュメント
https://docs.microsoft.com/ja-jp/azure/azure-web-pubsub/overview

価格
https://azure.microsoft.com/ja-jp/pricing/details/web-pubsub/

Azureサポートチームによる解説
https://jpdsi.github.io/blog/azure-web-pubsub/AzureWebPubSub-for-beginner/

ブログ/報道等
- https://uncaughtexception.hatenablog.com/entry/2021/04/30/072300
- https://ascii.jp/elem/000/004/055/4055215/
- https://tech-blog.cloud-config.jp/2021-05-11-azure-web-pubsub-azure/

■歴史

2021/4/29 プレビュー
https://azure.microsoft.com/en-us/blog/easily-build-realtime-apps-with-websockets-and-azure-web-pubsub-now-in-preview/

2021/11/16 一般提供開始
https://azure.microsoft.com/ja-jp/blog/build-realtime-web-apps-with-azure-web-pubsub-now-generally-available/

■WebSocket

- https://ja.wikipedia.org/wiki/WebSocket
  - > WebSocket（ウェブソケット）は、単一のTCPコネクション上に双方向通信のチャンネルを提供する、コンピュータの通信プロトコルの1つである。
  - > WebSocketプロトコルは、2011年にRFC 6455としてIETFにより標準化された。
  - > HTTPプロトコルと互換性がある。
- https://developer.mozilla.org/ja/docs/Web/API/WebSockets_API
  - > WebSocket API は、ユーザーのブラウザーとサーバー間で対話的な通信セッションを開くことができる先進技術です。
  - > この API によって、サーバーにメッセージを送信したり、応答をサーバーにポーリングすることなく、イベント駆動型のレスポンスを受信したりすることができます。
- https://www.html5rocks.com/ja/tutorials/websockets/basics/
  - > WebSocket 仕様は、ウェブ ブラウザとサーバー間に「ソケット」接続を確立する API を定義しています。
  - > 簡単に言うと、クライアントとサーバーの間に持続的接続があり、どちらの側からでも、いつでもデータの送信を開始できます。
  - > ws: に注目してください。これは WebSocket 接続用の新しい URL スキーマです。
  - > セキュリティで保護された WebSocket 接続用の wss: もあります。
- https://techinfoofmicrosofttech.osscons.jp/index.php?WebSocket
  - 

Azureでの対応

- 2013/11/14 Azure Web SitesでのWebSocket対応 https://azure.microsoft.com/ja-jp/blog/introduction-to-websockets-on-windows-azure-web-sites/
- Application GatewayでのWebSocket対応 https://docs.microsoft.com/ja-jp/azure/application-gateway/application-gateway-websocket
- 2018/9/7 Azure AD Application Proxyで、WebSocketに対応 https://techcommunity.microsoft.com/t5/azure-active-directory-identity/new-azure-ad-application-proxy-updates/ba-p/245375
- Azure AD Connect内での使用 https://o365blog.com/post/pta-deepdive/
- Azure Service Bus内での使用 https://docs.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-faq
- 
■パブリッシュ-サブスクライブ パターン

■Azure SignalR

- 2018/5/7 パブリックプレビュー https://azure.microsoft.com/en-us/blog/azure-signalr-service-a-fully-managed-service-to-add-real-time-functionality/
- 2018/9/24 一般提供開始 https://azure.microsoft.com/ja-jp/blog/azure-signalr-service-now-generally-available/
- 双方向通信が可能という点では近いサービス
- SignalRは、ロングポーリングやサーバ送信イベントのフォールバックや、自動再接続をサポート。
  - これらはPubSubにはない。
- 現在SignalRを使っている場合、PubSubに乗り換える必要はない。
  