
# .NET 5 リリース

https://github.com/dotnet/core/blob/master/release-notes/5.0/README.md

https://devblogs.microsoft.com/dotnet/announcing-net-5-0/

# .NET 5

https://docs.microsoft.com/ja-jp/dotnet/core/dotnet-five

[.NET Core 3](https://docs.microsoft.com/ja-jp/dotnet/core/whats-new/dotnet-core-3-1) の後継は [.NET 5.0](https://docs.microsoft.com/ja-jp/dotnet/core/dotnet-five) となる。

.NET Core 4.0 はない。.NET Framework 4.x との混同を避けるため。

[ASP.NET Core 5.0](https://docs.microsoft.com/ja-jp/aspnet/core/migration/31-to-50?view=aspnetcore-5.0&tabs=visual-studio) は、.NET 5.0 ベースだが、Core という名前を残す。ASP.NET MVC 5 との混同を避けるため。

[Entity Framework Core 5.0](https://docs.microsoft.com/ja-jp/ef/core/what-is-new/ef-core-5.0/whatsnew) も同様。Entity Framework 5 や 6 との混同を避けるため。

[Web Forms](https://docs.microsoft.com/ja-jp/aspnet/web-forms/what-is-web-forms) の推奨される代替は ASP.NET Core Blazor や Razor Pages である。

[Windows Workflow (WF)](https://docs.microsoft.com/ja-jp/dotnet/framework/windows-workflow-foundation/) の推奨される代替はオープンソースの [CoreWF](https://github.com/UiPath/corewf) または [Elsa-Workflow](https://elsa-workflows.github.io/elsa-core/) である。

# .NET Standard

https://docs.microsoft.com/ja-jp/dotnet/core/dotnet-five#net-50-doesnt-replace-net-standard

> .NET 5.0 doesn't replace .NET Standard

.NET 5.0は、.NET Standard を置き換えない。

https://docs.microsoft.com/ja-jp/dotnet/standard/net-standard

> .NET Standard は、複数の .NET 実装で使用できる .NET API の正式な仕様です。 .NET Standard の背後にある意図は、.NET エコシステムの高度な統一性を確立することでした。 しかし、.NET 5 には統一性を確立するための別のアプローチが採用されており、この新しいアプローチによって、多くのシナリオで .NET Standard が不要になります。

# .NET Framework 4.x

https://docs.microsoft.com/ja-jp/dotnet/core/dotnet-five#net-50-doesnt-replace-net-framework

> .NET 5.0 doesn't replace .NET Framework

.NET 5.0は、.NET Framework を置き換えない。

https://www.atmarkit.co.jp/ait/articles/2011/09/news005.html

> .NET Frameworkについては4.8が最後のメジャーバージョンになり、今後は新機能を追加しません。

# TFM (ターゲット フレームワーク モニカー)

https://docs.microsoft.com/ja-jp/dotnet/standard/frameworks

.NET 5 (5.0) の TFM は `net5.0`

.NET Core (3.1) の TFM は `netcoreapp3.1`

https://ufcpp.net/blog/2020/3/net5optionalworkload/

> .NET Core に対して netcoreapp、 .NET Standard に対して netstandard みたいな記号的な名前を振っていたわけですが、これが Moniker です。


# .NET 5.0のダウンロード

https://dotnet.microsoft.com/download/dotnet/5.0




# Azureにおける .NET 5 の対応状況

App Service

https://azure.microsoft.com/ja-jp/updates/net-5-now-available-in-app-service/

> .NET 5 now available in App Service

Azure Functions

https://techcommunity.microsoft.com/t5/apps-on-azure/net-5-support-on-azure-functions/ba-p/1973055

> The .NET 5 worker will be generally available in early 2021.


# C# と .NET 5

https://docs.microsoft.com/ja-jp/dotnet/csharp/whats-new/csharp-9

> C# 9.0 は .NET 5 でサポートされています。


# .NET 5 のサポート期間

https://forest.watch.impress.co.jp/docs/news/1288541.html

> サポート期間は、次の「.NET 6.0」がリリースされて3カ月後、つまり2022年2月中旬までとなる。「.NET」は毎年11月ごろにリリースされ、偶数バージョンが3年間サポートされる長期サポート（LTS）版となる。「.NET 6.0」の初期ビルドはすでに存在し、Appleの新しいCPU“M1”にも対応するという。
