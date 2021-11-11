# 正式リリース

2021/11/9 正式リリース。

https://www.publickey1.jp/blog/21/net_6netlts.html

```
$ dotnet version

.NET 6.0 へようこそ!
---------------------
SDK バージョン: 6.0.100
```

# ダウンロード

https://dotnet.microsoft.com/download/dotnet/6.0


# Microsoft Docs

.NET 6 の詳細 (新着情報と今後の予定)
https://docs.microsoft.com/ja-jp/events/build-may-2021/azure/breakouts/od485/

# 報道等

https://www.atmarkit.co.jp/ait/articles/2106/09/news046.html

> .NET 6はクロスプラットフォーム対応の強化、クラウド対応の強化、実行速度のさらなる向上が予定されています

> 「アプリコードはよりシンプルに」という点も強化されています。

> .NET 6はLTS（Long Term Support）リリースなので、約3年間のサポートが約束されています。現在のLTSリリース「.NET Core 3.1」のサポート終了は2022年12月3日なので、残りのサポート期間が短くなっています。.NET 6がローンチされる2021年11月以降にリリースを予定しているシステムなら、.NET 6の情報はとても興味深いものとなるでしょう。

> .NET 5でリリースされるはずだった「.NETとXamarinの統合」が完了します

> ターゲットフレームワークモニカー（TFM）は、「net6.0-ios」「net6.0-android」「net6.0-macos」のような名称になります。

> .NET 6ではC# 10が利用できます。

> .NET 6では「.NET Multi-platform App UI」（.NET MAUI）や「Blazor desktop apps」がサポートされ、クロスプラットフォームのアプリ開発環境がさらに強化されると同時に他のワークロードへのアプローチが容易になりました。

# .NET 6 での破壊的変更

（.NET 6だけに破壊的変更があるわけではない）
https://docs.microsoft.com/ja-jp/dotnet/core/compatibility/6.0

破壊的変更の詳細
https://docs.microsoft.com/ja-jp/dotnet/core/compatibility/


# 生成されるC#テンプレートの変更

.NET 6 Preview 7 SDKより、Program.csが[トップレベルステートメント](https://ufcpp.net/study/csharp/cheatsheet/ap_ver9/)の形式で生成される。

# Minimal ASP.NET Core 6.0

https://dotnetthoughts.net/minimal-api-in-aspnet-core-mvc6/

起動のコードが簡素化された。

# Azure のロードマップ

■Functions

- https://azure.microsoft.com/en-us/updates/general-availability-azure-functions-supports-net-5-in-production/
- .NET on Azure Functions https://techcommunity.microsoft.com/t5/apps-on-azure/net-on-azure-functions-roadmap/ba-p/2197916
- https://docs.microsoft.com/ja-jp/azure/azure-functions/dotnet-isolated-process-guide
- https://github.com/Azure/Azure-Functions/wiki/V4-early-preview
- https://techcommunity.microsoft.com/t5/apps-on-azure/what-s-new-with-net-on-azure-functions-june-2021/ba-p/2428669
- https://github.com/Azure/Azure-Functions/wiki/V4-early-preview

- 2021/3, Azure Functionsが.NET 5のアプリ実行をサポート。
  - 新しい「isolated process model」により、ホストランタイムの外側の「separate worker process」内でアプリを実行
  - 「isolated process functions」とも

ランタイム

Functions 3.x
Functions 4.x

■App Service

- Running .NET 6 (Preview) on App Service https://azure.github.io/AppService/2021/04/15/Running-dotnet-6-Preview-on-App-Service.html

# マイグレーション

.NET 3.1 -> .NET 5
https://azure.github.io/AppService/2021/04/14/Migrating-your-dotnet-31-applications-to-dotnet-5.html

# InfoQ記事

- LINQの改良 https://www.infoq.com/jp/news/2021/06/Net6-Linq/
- コレクションの改良 https://www.infoq.com/jp/news/2021/07/Net6-Collections/
- 非同期の改善 https://www.infoq.com/jp/news/2021/05/Net6-Async/
- 日付と時刻の改善 https://www.infoq.com/jp/news/2021/05/Net6-Date-Time/
- PythonとNodeに挑戦するASP.NET Core 6 https://www.infoq.com/jp/news/2021/07/ASP-Net-Core-6-Boilerplate/
- EF CoreとASP.NET Core 6で非同期ストリーミング https://www.infoq.com/jp/news/2021/07/ASP-Net-Core-6-IAsyncEnumerable/
- .NET MAUI Preview 4 https://www.infoq.com/jp/news/2021/07/dotnet-maui-preview-4/
- WPFとWinFormsでのBlazor WebViewコントロールの利用 https://www.infoq.com/jp/news/2021/06/dotnet-6-webview-winforms-wpf/

