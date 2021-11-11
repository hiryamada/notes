# .NET

https://docs.microsoft.com/ja-jp/dotnet/

https://dotnet.microsoft.com/download

https://dotnetfoundation.org/

https://www.atmarkit.co.jp/ait/subtop/dotnet/

https://github.com/dotnet

https://twitter.com/dotnet

https://themesof.net/

■Dotnetのロードマップ

https://github.com/dotnet/core/blob/main/roadmap.md

- .NET 6.0 
  - 2021/11/9 正式リリース。
  - LTS(long time support)
- .NET 7.0 
  - 2022/11 リリース予定
  - non-LTS
- .NET 8.0 
  - 2023/11 リリース予定
  - LTS

※LTSとは

https://docs.microsoft.com/ja-jp/dotnet/core/releases-and-support#release-tracks

少なくとも 3 年間、あるいは 次の LTS リリースが出荷されてから 1 年間はサポートされる。

# .NET 5

→ [.NET 5](dotnet5.md)

# .NET 6

→ [.NET 6](dotnet6.md)


# Visual Studio (Code)

→ [Visual Studio](vs.md)

https://visualstudio.microsoft.com/ja/vs/features/net-development/

https://code.visualstudio.com/docs/languages/dotnet



# .NET SDK

https://docs.microsoft.com/ja-jp/dotnet/fundamentals/tools-and-productivity

> .Net SDK には、.NET ランタイムと .NET CLI の両方が含まれています。 

> Windows、Linux、macOS、または Docker 用の .NET SDK をダウンロードできます。

https://docs.microsoft.com/ja-jp/dotnet/core/versions/

> .NET ランタイムと .NET SDK では、新しい機能が追加される頻度が異なります。
> 
> 一般には、ランタイムよりも SDK の方がより頻繁に更新されます。

> .NET ランタイムでは、セマンティック バージョニングに従い、メジャー、マイナーおよびパッチを使用してバージョン管理を行っています。
> 
> .NET SDK は、セマンティックバージョニングには従っていません。

# 共通言語ランタイム (CLR)

https://docs.microsoft.com/ja-jp/dotnet/standard/clr

> .NET には、共通言語ランタイムと呼ばれるランタイム環境が用意されています。

# マネージド データ

> 共通言語ランタイムはオブジェクトのレイアウトを自動的に処理し、それらのオブジェクトへの参照を管理し、不要になったオブジェクトを解放します。
> 
> このような方法で有効期間を管理されるオブジェクトをマネージド データと呼びます。 
> 
> ガベージ コレクションによって、一般的なプログラミング エラーだけでなくメモリ リークもなくなります。 
> 
> コードがマネージドである場合、作成する .NET アプリケーションではマネージド データもしくはアンマネージド データ、またはマネージドおよびアンマネージドの両方のデータを使用できます。 
> 
> プリミティブ型などのデータ型は言語コンパイラが独自に提供しているため、データがマネージド データかどうかが不明な (または把握する必要がない) 場合もあります。

# アセンブリ

> アセンブリは、.NET ベースのアプリケーションの配置、バージョン管理、再利用、アクティベーション スコープ、およびセキュリティ権限の基本単位です。 
> 
> アセンブリは、相互に連携して 1 つの論理的な機能単位を形成するように構築された型やリソースの集合です。 
> 
> アセンブリは、実行可能 ( .exe) ファイルまたはダイナミック リンク ライブラリ ( .dll) ファイルの形を取る、.NET アプリケーションの構成要素です。 
> 
> それらは、型の実装に関して必要な情報を共通言語ランタイムに提供します。

# 参照

> アプリケーションでアセンブリを使用するには、アセンブリへの参照を追加する必要があります。
> 
> アセンブリが参照された後は、その名前空間のアクセス可能なすべての型、プロパティ、メソッド、およびその他のメンバーを、そのコードがご自分のソース ファイルの一部であるかのようにアプリケーションで使用することができます。


# デプロイ モデル

解説:
https://andrewlock.net/should-i-use-self-contained-or-framework-dependent-publishing-in-docker-images/


https://docs.microsoft.com/ja-jp/dotnet/core/deploying/

> .NET Core を使用して作成したアプリケーションは、2 つの異なるモードで発行できます。
> 
> モードは、お客様のアプリをユーザーが実行する方法に影響します。

self-contained

> ご自分のアプリを "自己完結型" として発行すると、.NET Core ランタイムとライブラリ、さらにご自分のアプリケーションとその依存関係を含むアプリケーションが生成されます。
> 
> そのアプリケーションのユーザーは、.NET Core ランタイムがインストールされていないコンピューター上でそれを実行することができます。

framework-dependent

> ご自分のアプリを "フレームワーク依存" として発行すると、ご自分のアプリケーション自体とその依存関係のみを含むアプリケーションが生成されます。
> 
> そのアプリケーションのユーザーは、.NET Core ランタイムを個別にインストールする必要があります。



# 実行可能ファイル

https://docs.microsoft.com/ja-jp/dotnet/core/deploying/#produce-an-executable

> 実行可能ファイルはクロスプラットフォームではありません。 これは、オペレーティング システムおよび CPU アーキテクチャに固有のものです。
> 
> ご自分のアプリを発行して実行可能ファイルを作成するとき、アプリを自己完結型またはフレームワーク依存として発行することができます。 

# クロスプラットフォーム バイナリ

https://docs.microsoft.com/ja-jp/dotnet/core/deploying/#produce-a-cross-platform-binary

> ご自分のアプリを dll ファイルの形式で フレームワーク依存として発行すると、クロスプラットフォーム バイナリが作成されます。

> この方法で発行されたアプリは、dotnet <filename.dll> コマンドを使用して実行され、任意のプラットフォームで実行できます。


# Docker

https://docs.microsoft.com/ja-jp/dotnet/core/docker/introduction

> .NET Core は Docker コンテナー内で簡単に実行できます。

レジストリ

> Docker には、自分が使用できる Docker Hub でホストされているパブリック レジストリが含まれます。 .NET Core 関連イメージは Docker Hub に一覧表示されます。
> 
> Microsoft Container Registry (MCR) は、Microsoft が提供するコンテナー イメージの公式ソースです。 MCR は Azure CDN に基づいて構築され、グローバルにレプリケートされたイメージを備えています。 ただし、MCR には一般公開された Web サイトがありません。
> 
> Microsoft が提供するコンテナー イメージについて学習する主な方法は、Microsoft Docker Hub のページを使うことです。


https://github.com/dotnet/dotnet-docker/blob/master/samples/README.md

Dockerfileのサンプル

```docker
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# copy and publish app and libraries
COPY . .
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["./dotnetapp"]
```