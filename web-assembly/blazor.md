# ASP.NET Core Blazor

https://docs.microsoft.com/ja-jp/aspnet/core/blazor/

- Blazor を使って対話型のクライアント側 Web UI を構築するためのフレームワーク
- JavaScript の代わりに C# を使って、対話型 UI を作成
- 「Blazor アプリ」

https://www.publickey1.jp/blog/18/blazorwebassemblynetwebcnet.html

> (2018/6)マイクロソフトの実験的プロダクト「Blazor」、WebAssemblyで.NETランタイムを実装。WebブラウザでC#など.NETアセンブリをそのまま実行可能に

https://www.publickey1.jp/blog/18/blazorwebassemblynetwebcnet.html

> Bの次がRでなくLなのはその方が発音しやすいためだそうです

# ホスティングモデル

- Blazor Server
  - WebAssembly は使用されない
  - サーバー側の.NETランタイム上でRazorコンポーネントを動作させる
  - サーバーとWebブラウザーが [SignalR](https://docs.microsoft.com/ja-jp/aspnet/core/signalr/introduction?view=aspnetcore-6.0) を使用して通信する
- Blazor WebAssembly
  - .NETランタイムをWebAssembly内で動かし、その上でRazorコンポーネントを動作させる
  - Content Delivery Network (CDN) からアプリを提供するなどのサーバーレス展開シナリオが可能
- Blazor Hybrid
  - WebAssembly は使用されない
  - ネイティブ アプリ内で他の .NET コードと共に直接実行される
  - HTML と CSS に基づく Web UI を、埋め込み Web View コントロールにレンダリング

# Razorコンポーネント（Blazorコンポーネント）

- ページ、ダイアログ、データ エントリ フォームなどの UI の要素
- 通常、コンポーネント クラスは、.razor ファイル拡張子を持つ Razor マークアップ ページの形式で記述される
- **公式には "Razor コンポーネント"と呼ばれる**
- **非公式には "Blazor コンポーネント" と呼ばれる**
- **Razor Pages と MVC でも Razor が使用される**
  - → [Razor Pages](https://docs.microsoft.com/ja-jp/aspnet/core/razor-pages)

# Razorの構文

https://docs.microsoft.com/ja-jp/aspnet/core/mvc/views/razor

- 通常、Razor を含むファイルには、ファイル拡張子 .cshtml が付いています。
- Razor は、Razorコンポーネント ファイル (.razor) にも含まれています。

Razor コンポーネントでのみ使用できる 「ディレクティブ」がある。
