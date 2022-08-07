
■ 非同期 / 双方向 / プッシュ の技術いろいろ

[リアルタイム通信で利用されるプロトコルと手法](https://tech.guitarrapc.com/entry/2015/08/17/044937)

- [Push技術（サーバープッシュ）](https://ja.wikipedia.org/wiki/Push%E6%8A%80%E8%A1%93)
  - [ロングポーリング](https://ja.wikipedia.org/wiki/Push%E6%8A%80%E8%A1%93#Long_polling)
  - [HTTP server push](https://ja.wikipedia.org/wiki/Push%E6%8A%80%E8%A1%93#HTTP_server_push)
- [XHR (XMLHttpRequest)](https://ja.wikipedia.org/wiki/XMLHttpRequest)
  - もともと[Outlook Web Access](https://ja.wikipedia.org/wiki/Outlook_Web_Access)のために実装された技術
- [Ajax](https://ja.wikipedia.org/wiki/Ajax)
- [Comet](https://ja.wikipedia.org/wiki/Comet)
  - 既存の技術を利用してサーバーからの通信を実現する技術

■ロングポーリング いろいろ

Service Bus + Event Grid により、サブスクライバがService Busへのポーリング（Long polling）をする必要がなくなる。 https://logico-jp.io/2020/02/28/integrate-azure-service-bus-with-azure-event-grid/

[SQS ロングポーリング](https://docs.aws.amazon.com/ja_jp/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-short-and-long-polling.html)

https://docs.microsoft.com/ja-jp/azure/azure-signalr/signalr-concept-performance

> WebSocket は、単一の TCP 接続における双方向かつ全二重の通信プロトコルです。 Server-Sent-Event は、サーバーからクライアントにメッセージをプッシュする一方向のプロトコルです。 Long-Polling では、クライアントが HTTP 要求を通じてサーバーから情報を定期的にポーリングする必要があります。 同じ条件下の同じ API では、WebSocket のパフォーマンスが最も高く、Server-Sent-Event がそれより遅く、Long-Polling が最も低速です。 Azure SignalR Service では、既定で WebSocket が推奨されます。

■ クラサバ型か P2P型 か

基本的に

- WebSocket = クラサバ
- WebRTC = P2P

[WebSocketを使ってWebブラウザ間P2P通信をしてみた](https://yogit.hatenadiary.org/entry/20111105/1320492134)
