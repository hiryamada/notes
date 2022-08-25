# GUI・プレゼンテーション技術周辺 まとめ

（時系列順＋ひとことメモ）

- OLE: 1991～ ([wikipedia](https://en.wikipedia.org/wiki/Object_Linking_and_Embedding))
- Microsoft Foundation Class Library(MFC): 1992～ ([wikipedia](https://ja.wikipedia.org/wiki/Microsoft_Foundation_Class))
- ActiveX: 1996～ ([wikipedia](https://en.wikipedia.org/wiki/ActiveX))
- Active Template Library(ATL): 1996～ ([wikipedia](https://ja.wikipedia.org/wiki/Active_Template_Library))
- COMコンポーネント: 1997～
- MSI (Windows Installer): 1999～
- .NET Framework: 2000～
- Windows Forms: 2002～ ([wikipedia](https://en.wikipedia.org/wiki/Windows_Forms))
- Mono: 2004～
- Avalon: 2004～
  - Windows Longhornに搭載予定だったグラフィックエンジン
  - CTP(Community Technology Preview)
- WPF: 2006～ ([wikipedia](https://en.wikipedia.org/wiki/Windows_Presentation_Foundation))
  - .NET Framework 3.0以降に含まれるUIサブシステム
  - Direct3Dを使用した描画
- Microsoft Silverlight: 2007～ ([wikipedia](https://en.wikipedia.org/wiki/Microsoft_Silverlight))
  - Web およびデスクトップ上でビデオやアニメーションを作成、表示、操作
  - WPF のサブセット
  - Adobe Flashの競合技術
  - HTML5への移行により2021/10/12 でサポート終了
- XAML: 2008～
  - Extensible Avalon Markup Language → Extensible Application Markup Language
  - WPF/SilverlightにおいてUI要素やデータバインディング、イベント処理などを定義
- Xamarin: 2011～ ([wikipedia](https://en.wikipedia.org/wiki/Xamarin))
  - Mono、MonoTouch、Mono for Androidの開発者により設立された企業
  - Xamarin.Forms: 2014～
    - クロスプラットフォームUIフレームワーク
    - 後に .NET MAUIに進化
  - Xamarin.OS
  - Xamarin.Android
- WinUI: 2011～
  - Windows UI Library
  - UWPのバックボーンを形成するWindowsランタイムプログラミングモデルの一部
- Universal Windows Platform (UWP): 2012～
- .NET Core: 2016～
- MSIX: 2018～
  - Win32からWPF、Windows Forms、UWPまで、あらゆる形式のアプリを包含する統合型パッケージング形式
- XAML Islands: 2018
  - Windows Forms、WPF、ネイティブWin32など、使用しているUIスタックにかかわらず、XAMLにアクセスできる
- Uno Platform: 2018～
  - オープンソース、クロスプラットフォームGUI
  - WinUI/UWPベースのコードをiOS、macOS、Linux、macOS、Android、WebAssemblyで実行
- WinUI 2: 2018～
- Project Reunion: 2020～
  - → Windows App SDK
- WinUI 3: 2020～
  - Windows デスクトップ アプリに対応した最新かつ推奨されるUIフレームワーク
  - Windows App SDK(旧称：Project Reunion)の一部
- .NET MAUI (Multi-platform App UI): 2022～
  - 単一の .NET コード ベースから各プラットフォームのネイティブ UI とサービスを活用する、Android、iOS、macOS、Windows アプリケーションを構築するための、オープンソースのクロスプラットフォーム フレームワーク
  - .NET MAUI を使用してビルドされた Windows アプリでは、WinUI 3を使用して、Windows デスクトップを対象とするネイティブ アプリを作成
  - XAMLによるMVVMをサポート
  - C#でUIを構築するためのMVUのサポート ([Comet](https://github.com/dotnet/Comet))
  - Blazorをサポート

■参考

- [WinUI 3.0とProject Reunion【C#】](https://biotech-lab.org/articles/3457)
- [マイクロソフト、Win32とUWPのAPIへのアクセス統合目指す「Project Reunion」発表](https://japan.zdnet.com/article/35154066/)
- [Introducing WinUI 3 Preview 1](https://blogs.windows.com/windowsdeveloper/2020/05/19/introducing-winui-3-preview-1/)
- [7 つの Blazor のプロジェクトの作り方](https://rksoftware.hatenablog.com/entry/2022/05/08/163539)