# MagicOnion


https://github.com/cysharp/MagicOnion


> modern RPC framework for .NET platform that provides bi-directional real-time communications such as SignalR and Socket.io and RPC mechanisms such as WCF and web-based APIs.

> This framework is based on gRPC, which is a fast and compact binary network transport for HTTP/2. However, unlike plain gRPC, it treats C# interfaces as a protocol schema, enabling seamless code sharing between C# projects without .proto (Protocol Buffers IDL).

https://tech.cygames.co.jp/archives/3181/


> 基本的な機能は サーバークライアント間のストリーミングRPCを提供します。サーバー側をC#、クライアント側もC#で実装し、メッセージのフォーマットはLZ4圧縮されたMessagePack、通信はgRPCによるHTTP/2を用いています

> MagicOnionでは私の開発したC#最速のバイナリシリアライザであるMessagePack for C#によってシリアライズするため、シリアライズ処理はボトルネックになりえません。また、MessagePack for C#でシリアライズできるなら、どんな型でも送ることができるというデータに対する柔軟性も、性能と同時に獲得しています。

https://github.com/neuecc/MessagePack-CSharp/
