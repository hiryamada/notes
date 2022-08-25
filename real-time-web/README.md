# リアルタイムWeb周辺の技術とサービス

（時系列順＋ひとことメモ、リンク先に詳細）

- Comet: 1996～ ([wikipedia](https://en.wikipedia.org/wiki/Comet_(programming)))
  - サーバーからクライアントへのリアルタイム通信技法
- XML: 1998～ ([wikipedia](https://en.wikipedia.org/wiki/XML))
  - データフォーマット
- Ajax: 1999～ ([wikipedia](https://en.wikipedia.org/wiki/Ajax_(programming)))
  - JavaScriptとXMLを使用した非同期通信
- JSON: 2000～ ([wikipedia](https://en.wikipedia.org/wiki/JSON))
  - データフォーマット
- Server-sent events(SSE) ([wikipedia](https://en.wikipedia.org/wiki/Server-sent_events))
  - サーバープッシュ技術
- [MessagePack](messagepack.md): 2008頃～
  - データフォーマット
- [WebRTC](webrtc.md): 2010頃～
  - P2Pリアルタイム通信
- [WebSocket](websocket.md): 2011～
  - TCP双方向通信プロトコル
- [ASP.NET SignalR / ASP.NET Core SignalR](signalr.md): 2012～
  - リアルタイム Web 機能をアプリに追加するライブラリ
- [gRPC](grpc.md): 2016/8～
  - 言語に依存しない、RPCフレームワーク
- [MagicOnion](magic-onion.md): 2016～
  - gRPCとHTTP/2を使用したC#用双方向リアルタイム通信ライブラリ
- [Azure SignalR Service](azure-signalr-service.md): 2018～
  - 数百万の同時接続をサポートするSignalRフルマネージドサービス
  - 既存のSignalRアプリのわずかな変更でこのサービスを利用できる
- [Fluid Framework](fluid-framework): 2019～
  - 複数のクライアントでデータを共有・編集するためのフレームワーク
- [Azure Web PubSub Service](azure-web-pubsub-service.md): 2021～
  - WebSocketによる双方向通信のためのサービス
- Azure Communication Services (WebRTC対応？): 2021/3～
- [WebTransport](webtransport.md): 策定中
- [Azure Fluid Relay](azure-fluid-relay.md): 2022～
  - Fluid Frameworkアプリのわずかな変更でこのサービスを利用できる

[その他メモ](memo.md)

■参考

- [UnityのXRで使いたいリアルタイム技術・サービスの整理](https://zenn.dev/toutou/articles/fd52ceff690c1a)
- [gRPCを使ったWebアプリケーション開発](https://zenn.dev/dictav/articles/grpc-web-app)
