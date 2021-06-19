# モジュール9 依存関係管理戦略の設計と実装

- パッケージとは。
- NuGet, NPM, Maven, PyPI とは。
- パッケージ フィードとは。
- パッケージ フィード マネージャーとは。
- Azure Artifactsとは。

重要ポイント:

- パッケージ: 
  - 別のソフトウェア ソリューションから利用できる、ソフトウェア成果物。
- パッケージ フィード（フィード）: 
  - パッケージの集中管理を行うスペース。
- パッケージ フィード マネージャー: 
  - パッケージの管理を行うしくみ/ツール/コマンド。パッケージマネージャ。npm等
- パブリック パッケージ ソース（パブリック パッケージ フィード）: 
  - パッケージを提供する場所。パッケージのリポジトリ。npmjs.com等
- プライベート フィード: 
  - 組織等でプライベートに使用されるフィード。
- セルフホステッド プライベート フィード: 
  - オンプレミスのサーバー等で運用されるプライベート フィード。Nexus等。
- SaaS プライベート フィード: 
  - サービスとして提供されるプライベート フィード。Azure Artifact等
- アップストリームソース: 
  - Azure Artifacts のフィードが参照する、外部のフィード。npmjs.com等

## 依存関係のパッケージ化

### 依存関係管理とは何ですか?

- パッケージはソフトウェアの「部品」。
  - インターネット上には、無料で利用できる、多数のパッケージが公開されている。
  - ベンダーが提供する有償のパッケージもある。
- パッケージを利用する場合は、その利用条件（ライセンス）に従う必要がある。
- 多くの場合、1つのソフトウェア（プロジェクト）では、多数のパッケージを利用する。
- プロジェクトで外部のパッケージを利用する際は、その「依存関係」を追加する。
- 依存関係（ソフトウェアがどのパッケージを使用しているか）を管理する必要がある。
  - パッケージマネージャを使用して、パッケージ（依存関係）を追加する。
- 依存関係をチェックすることで、脆弱性のあるパッケージを使っているかどうかを調査できる。

### 依存関係管理戦略の要素

- 標準化
  - パッケージを管理する標準的な方法が（言語やプラットフォームで）確立されているので、それに従う
- パッケージ形式とソース
  - パッケージの取得元をプロジェクトで指定する。
- バージョン管理
  - パッケージマネージャを使用して、プロジェクトにおいて、特定のバージョンのパッケージを取得したり、プロジェクトで使用するパッケージのバージョンを上げたりする。

### 依存関係の特定

- プロジェクトで、既に他のパッケージを導入している場合が多い
- 

### ソースとパッケージのコンポーネント化

コンポーネント（部品）化の方法・範囲。

- ソースコードレベルのコンポーネント化
  - メソッド、クラス、名前空間などを分けて部品化
  - 1つのプロジェクト内で再利用が可能
- パッケージによるコンポーネント化
  - プロジェクトをパッケージ化し、名前とバージョンを付ける
  - 他のプロジェクトで再利用が可能

以下、パッケージ化について考えていく。

### システムを分解する

大きなプログラムを複数のパッケージに分解する。

プログラムからパッケージを利用するには、以下のような技術が必要となる。
- [インターフェース](https://ufcpp.net/study/csharp/oo_interface.html)による抽象化
  - インターフェースと実装クラスを分離する
  - 利用者側はインターフェースを使ってコーディングする
- [依存関係の注入(Dependency Injection: DI)](https://docs.microsoft.com/ja-jp/dotnet/core/extensions/dependency-injection)
  - インターフェースを実装するオブジェクトを作成。
  - 利用者のインターフェースの変数にオブジェクトを「注入」する。
  - 「DIコンテナー」がその処理を担当する。
- [制御の反転(Inversion of Control: IoC)](https://docs.microsoft.com/ja-jp/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion)
  - [実質的にDIに同じ。](https://ja.wikipedia.org/wiki/%E5%88%B6%E5%BE%A1%E3%81%AE%E5%8F%8D%E8%BB%A2)
  - 上記のDI処理を、利用者側ではなく、DIコンテナーが実行するという様子を「反転」という。

### 依存関係のコードベースをスキャンする

大きなソースコードを分解してパッケージ化するための指針。

- 重複コード
  - コードが重複している部分は、分解対象となる。
- 高い[凝集度](https://ja.wikipedia.org/wiki/%E5%87%9D%E9%9B%86%E5%BA%A6)、低い[結合度](https://ja.wikipedia.org/wiki/%E7%B5%90%E5%90%88%E5%BA%A6)
  - 関連性が高く、他の部分との結び付きが弱い部分は、分解対象となる
- ライフサイクル
  - ライフサイクルが同じ部分は、分解対象となる
- 安定した部分
  - ほとんど変化しないソースコードの部分は、分解対象となる
- 独立したコードとコンポーネント
  - 機能的に独立している部分は、分解対象となる

## パッケージの管理

### パッケージ

パッケージとは。

パッケージは、別のソフトウェア ソリューションから利用できる、ソフトウェア成果物。

よく使われるパッケージの形式（または、パッケージマネージャー）として、NuGet, npm, Maven, PyPIなどがある。

#### NuGet: .NET (C#, VB.NET, F#)

- Package Manager for .NET
- [公式サイト(www.nuget.org)](https://www.nuget.org/)
- 読み方: [ニューゲット（ニュゲット）](https://www.youtube.com/watch?v=WW3bO1lNDmo)

#### npm

- a JavaScript package manager
- [公式サイト(npmjs.com)](https://www.npmjs.com/)
- 読み方: [エヌピーエム](https://www.youtube.com/watch?v=32j-b1iacys)
- [(もともと)Node Package Manager の略](https://en.wikipedia.org/wiki/Npm_(software))
- 小文字で表記される(NPMではなくnpm)
- [公式サイト(npmjs.com)](https://www.npmjs.com/)左上をクリックするとNPMのいろいろな意味が出てくる(Network Printer Managerなど) 

#### Maven

- Java用のプロジェクト管理ツール
- [公式サイト(Apache Maven)](https://maven.apache.org/)
- [MVN Repository](https://mvnrepository.com/)
- 読み方: [メイヴン / メイヴェン](https://ja.wikipedia.org/wiki/Apache_Maven)
- [Gradle](https://gradle.org/)などのビルドツールからもMavenのリポジトリを利用することができる

#### PyPI

- The Python Package Index
- [PyPI](https://pypi.org/)
- 読み方: [パイピーアイ](https://www.google.com/search?q=pypi+%E3%83%91%E3%82%A4%E3%83%94%E3%83%BC%E3%82%A2%E3%82%A4) 
  - または（[もともとcheeseshop.python.orgドメインで運用されていたことから](https://speakerdeck.com/brettcannon/how-to-pronounce-pypi?slide=9)）[チーズショップ](https://www.google.com/search?q=pypi+%E3%83%81%E3%83%BC%E3%82%BA%E3%82%B7%E3%83%A7%E3%83%83%E3%83%97)
    - [動画](https://www.google.com/search?q=The+Cheese+Shop+sketch%2C+Monty+Python&oq=The+Cheese+Shop+sketch%2C+Monty+Python&aqs=edge..69i57j0i19j0i19i30j69i61.465j0j4&sourceid=chrome&ie=UTF-8)
    - [Wikipedia](https://ja.wikipedia.org/wiki/%E3%83%81%E3%83%BC%E3%82%BA%E3%83%BB%E3%82%B7%E3%83%A7%E3%83%83%E3%83%97_(%E3%83%A2%E3%83%B3%E3%83%86%E3%82%A3%E3%83%BB%E3%83%91%E3%82%A4%E3%82%BD%E3%83%B3))



### パッケージ フィード

(Azure Artifactの)パッケージ フィードとは。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/concepts/feeds?view=azure-devops)

※「フィード(feed)」は、パッケージリポジトリのこと。

- フィードは、パッケージを格納、管理、およびグループ化し、そのパッケージを共有するユーザーを制御できるようにする、組織の構造です。
- フィードはパッケージ型に依存しません。
- Npm、NuGet、Maven、Python、ユニバーサルパッケージのすべてのパッケージの種類を1つのフィードに格納することができます。
- 外部リポジトリ（アップストリームソース）のキャッシュとしても利用することができる。

Azure Artifacts で、[フィードを作成](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/concepts/feeds?view=azure-devops#create-a-feed)することができる。


### パッケージ フィード マネージャー

パッケージを管理するしくみ（コマンド等）。

- npm - [npmコマンド](https://docs.npmjs.com/cli/v7/commands)
- Maven - [mvnコマンド](https://maven.apache.org/guides/getting-started/maven-in-five-minutes.html)
- Python - [pipコマンド](https://pip.pypa.io/en/stable/)
- NuGet - dotnetコマンド ([dotnet add package](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-add-package), [dotnet list package](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-list-package), [dotnet remove package](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-remove-package))

### 一般的なパブリック パッケージ ソース

各言語で使用することができるパッケージのソース。

- https://www.nuget.org/
- https://www.npmjs.com/
- https://search.maven.org/
- https://pypi.org/

### セルフホステッドおよび SaaS ベースの パッケージ ソース

プライベートな、エンタープライズ用のパッケージ ソースを構築する場合に使用されるソフトウェア、またはPaaS。OSS、商用サービスなど。

一般に、「アーティファクト リポジトリ マネージャ」(Artifact Repository Manager)と呼ばれる。

[プライベートなリポジトリが必要となる理由](https://docs.microsoft.com/ja-jp/nuget/hosting-packages/overview):

- パッケージをパブリックに利用できるようにする代わりに、組織やワークグループなど、制限された対象ユーザーのみにパッケージをリリースする必要がある場合
- 開発者が使用する可能性があるサードパーティ製のライブラリを制限する必要がある場合

■代表的な「アーティファクト リポジトリ マネージャ」

- [Nexus](https://www.sonatype.com/products/repository-oss): Maven, npm, NuGet等
- [Artifactory](https://jfrog.com/ja/artifactory/): Maven, PyPI, npm, NuGet等
- [Apache Archiva](https://archiva.apache.org/): Maven


### パッケージの使用

■パッケージマネージャ

開発者は、パッケージマネージャーを使用して、必要なパッケージの名前とバージョンを指定し、パッケージを入手する。

また、パッケージマネージャの設定として、フィード（パッケージのリポジトリ）を指定する。

■「パッケージグラフ」の考え方
https://docs.microsoft.com/ja-jp/azure/devops/artifacts/concepts/package-graph?view=azure-devops

※上記ドキュメントでは矢印の元がアップストリームソースで表示されているが、本資料では、矢印の先をアップストリームソースとして表現する。

Fabricam、Contoso、AdventureWorksという3つのフィードがあるとする。
FabricamのアップストリームソースはContoso,
ContsosoのアップストリームソースはAdventureWorksに設定されている。

```
AdventureWorks (Things 1.0.0, Gadgets 1.0.0/2.0.0)
↑ アップストリームソース
Contoso        (Gizmos 1.0.0/3.0.0)
↑ アップストリームソース
Fabricam       (Widgets 1.0.0/2.0.0)
```

ここで、Contosoに接続したユーザーがGadgets 2.0.0を利用した。
Contosoには、Gadget 2.0.0が、AdventureWorksへのリンクとともに保存される。

```
AdventureWorks (Things 1.0.0, Gadgets 1.0.0/2.0.0)
↑ アップストリームソース                        ↑ リンク
Contoso        (Gizmos 1.0.0/3.0.0, Gadgets 2.0.0)
↑ アップストリームソース
Fabricam       (Widgets 1.0.0/2.0.0)
```

この場合、Fabricamに接続したユーザーは:
- Widgetsのすべてのバージョンを利用できる。
- Gismosのすべてのバージョンを利用できる。
- Gadgetsは2.0.0のみ利用できる。（アップストリームのContosoに保存されているため）
- Thingsは、どのバージョンも使用できない。（アップストリームのContosoに保存されていないため）


### Azure Artifacts

- NuGet, npm, Maven, Pythonパッケージをサポート。
- 2GiBまで無料。2-10 GiB: 224円/GiB, 10-100: 112円/GiB, 100-1000GiB: 56円/GiB, 1000～GiB: 28円/GiB

### パッケージを公開する

■パッケージをフィードに公開する手順

- フィードを作成する
  - フィードはデフォルトで「非公開」である
- パッケージマネージャを使用して、開発したパッケージをフィードに「プッシュ」する
  - `nuget.exe push -Source URL -ApiKey KEY PACKAGE `
  - URL: フィードのURL
  - KEY: APIキー
  - PACKAGE: パッケージ

### 実証: パッケージ フィードの作成

※ラボで実施します。

### デモンストレーション: パッケージのプッシュ

※ラボで実施します。

## 成果物の移行と統合

### 既存の成果物リポジトリの識別

### アーティファクト リポジトリを移行し、統合する

## パッケージ セキュリティ

### パッケージ フィードへのアクセスを保護する

### ロール

### アクセス許可

### 認証

## バージョン管理戦略の実装

### バージョン管理の概要

### 成果物のバージョンを管理する

### セマンティック バージョニング

### リリース ビュー

### パッケージを昇格する

### 実証: パッケージの昇格

### バージョン管理のベスト プラクティス

### パイプラインからのデモンストレーション

## ラボ

https://docs.microsoft.com/ja-jp/azure/devops/artifacts/get-started-nuget?view=azure-devops&tabs=windows
