# ASP.NET SignalR / ASP.NET Core SignalR

リアルタイム Web 機能をアプリに簡単に追加できるオープンソース ライブラリ。 リアルタイム Web 機能を使用すると、サーバー側のコードでコンテンツをクライアントに即座にプッシュできる。


■公式 (ASP.NET Core SignalR): 新しい方

[ASP.NET Core SignalRの概要](https://docs.microsoft.com/ja-jp/aspnet/core/signalr/introduction)

[リアルタイム ASP.NET と SignalR](https://dotnet.microsoft.com/ja-jp/apps/aspnet/signalr)

[ASP.NET Core SignalR](https://github.com/dotnet/aspnetcore/tree/main/src/SignalR)

■公式 (ASP.NET SignalR): 古い方

[SignalR](https://docs.microsoft.com/ja-jp/aspnet/signalr/)

[SignalR 入門](https://docs.microsoft.com/ja-jp/aspnet/signalr/overview/getting-started/introduction-to-signalr)

■利用例

[Blazor Serverでは、WebブラウザーとWebサーバーはSignalRを使用して通信する。](https://docs.microsoft.com/ja-jp/aspnet/core/blazor/hosting-models?view=aspnetcore-6.0#blazor-server)

[Azure Event Grid Viewer](azure-event-grid-viewer.md)

■Wikipedia

[Microsoft ASP.NET SignalR](https://ja.wikipedia.org/wiki/Microsoft_ASP.NET_SignalR)

■「ASP.NET SignalR」と「ASP.NET Core SignalR」の違い

- 2012/9 ASP.NET 4.5にて、「ASP.NET SignalR」が、ASP.NETファミリーの一員となった
- 2018/2/27 [ASP.NET Core SignalRが利用可能になった](https://blogs.msdn.microsoft.com/webdev/2018/02/27/asp-net-core-2-1-0-preview1-getting-started-with-signalr/)

[ASP.NET SignalR と ASP.NET Core SignalR の違い](https://docs.microsoft.com/ja-jp/aspnet/core/signalr/version-differences?view=aspnetcore-6.0)


[SignalR のアプリの開発](https://docs.microsoft.com/ja-jp/azure/azure-signalr/signalr-concept-scale-aspnet-core#developing-signalr-apps)

> 現時点では、Web アプリケーションで使用できる SignalR には 2 つのバージョンがあります。SignalR for ASP.NET と、最新バージョンの ASP.NET Core SignalR です。 Azure SignalR サービスは、ASP.NET Core SignalR 上に構築された Azure のマネージド サービスです。

> ASP.NET Core SignalR は、以前のバージョンのリライトです。 そのため、ASP.NET Core SignalR は、以前のバージョンの SignalR と下位互換性がありません。

■芝村達郎 さんの記事

わかりやすい

[ASP.NET SignalRを知る：特集：ASP.NET SignalR入門（前編）（1/5 ページ） - ＠IT](https://atmarkit.itmedia.co.jp/ait/articles/1303/19/news099.html)

- もともと、ASP.NET開発チームのDavid Fowler氏とDamian Edwards氏の両名によって開発されたコンポーネント
- (2012年9月, ASP.NET 4.5～)正式にASP.NETファミリーの一員となった
- SignalR自体は新しい技術だが、内部で使われているのはすでに一般的になっている技術が多い
- サーバの要件とブラウザ側の対応状況に基づいて、最適な通信方式をSignalRが選択するようになっている
- SignalRではクライアントとの接続時に一意となる値を、「コネクションID」という名前で発行する。サーバではコネクションIDを基にクライアントを管理する
- サーバとクライアントの間ではメソッド呼び出しとその戻り値の返送という形で通信を行える
- SignalRにはPersistentConnectionとHubという2つのAPIが存在する。
- PersistentConnectionは名前のとおり、サーバとクライアントの間での「持続的な接続」を提供するとともに、クライアントを管理するための機能も用意されている。
- HubはPersistentConnectionの上に実装されている高レベルAPIで、クライアント／サーバ間のメソッド呼び出しという基本的な機能を提供している

[リアルタイムWebを極める 記事一覧](https://gihyo.jp/list/group/%E3%83%AA%E3%82%A2%E3%83%AB%E3%82%BF%E3%82%A4%E3%83%A0Web%E3%82%92%E6%A5%B5%E3%82%81%E3%82%8B#rt:/dev/serial/01/realtimeweb/0001)

■「マイクロソフト系技術情報 Wiki」によるまとめ

https://techinfoofmicrosofttech.osscons.jp/index.php?ASP.NET%20SignalR

■クライアント

https://docs.microsoft.com/ja-jp/aspnet/core/signalr/client-features

.NET/Java/JavaScript用のクライアントが提供されている。

その他
- client library for iOS and Mac OS X https://github.com/DyKnow/SignalR-ObjC
- Swift https://github.com/moozzyk/SignalR-Client-Swift
- Blazor Extensions https://github.com/BlazorExtensions/SignalR
- [Flutter](https://ja.wikipedia.org/wiki/Flutter) クライアント https://github.com/soernt/signalr_client
- [Dart](https://ja.wikipedia.org/wiki/Dart) クライアント https://github.com/jamiewest/signalr_core

■Unity で ASP.NET Core SignalR を利用する

- 実は ASP.NET Core SignalR は .NET Core 依存ではない
- Plugins フォルダに対象となる dll を入れるだけで利用できる

https://blog.xin9le.net/entry/2019/05/03/231001


