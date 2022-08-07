# MessagePack

https://msgpack.org/ja.html

MessagePackは、効率の良いバイナリ形式のオブジェクト･シリアライズ フォーマットです。

開発者 古橋貞之 氏のBlog記事

https://frsyuki.hatenablog.com/entry/20080816/p1

> JSONのように汎用的なシリアライズ形式でありつつ、バイナリベースで高速なシリアライズ形式MessagePackを開発しています。

# SignalRでの利用

https://docs.microsoft.com/en-us/aspnet/core/signalr/messagepackhubprotocol?view=aspnetcore-6.0#what-is-messagepack

> MessagePack is a fast and compact binary serialization format. It's useful when performance and bandwidth are a concern because it creates smaller messages than JSON. The binary messages are unreadable when looking at network traces and logs unless the bytes are passed through a MessagePack parser. SignalR has built-in support for the MessagePack format and provides APIs for the client and server to use.

# MessagePack for C#

https://github.com/neuecc/MessagePack-CSharp

The extremely fast MessagePack serializer for C#. It is 10x faster than MsgPack-Cli and outperforms other C# serializers.

MagickOnionでの利用

> MagicOnionでは私の開発したC#最速のバイナリシリアライザであるMessagePack for C#によってシリアライズするため、シリアライズ処理はボトルネックになりえません。また、MessagePack for C#でシリアライズできるなら、どんな型でも送ることができるというデータに対する柔軟性も、性能と同時に獲得しています。

https://github.com/neuecc/MessagePack-CSharp/

