# モジュール9 依存関係管理戦略の設計と実装

- パッケージとは。
- NuGet, NPM, Maven, PyPI とは。
- パッケージ フィードとは。
- パッケージ フィード マネージャーとは。
- Azure Artifactsとは。
- アップストリームソースとは
- パッケージグラフとは。
- ユニバーサルパッケージとは。

[Azure Artifactの位置づけについて、まずはこちらのPDFをご覧ください](pdf/Azure%20DevOps機能の連携.pdf)

用語集:

- パッケージ
  - (1)別のソフトウェア ソリューションから利用できる、再利用が可能な、ソフトウェアコンポーネント。ライブラリ。
  - (2)何らかのシステム・アプリケーションとして運用が可能な、デプロイ可能なソフトウェア。パッケージソフト。
- アーティファクト（成果物）
  - (1)「パッケージ」と同じ意味。npmのパッケージ等。
  - (2) [広い意味での成果物・副産物](https://blog.jfrog.co.jp/entry/what-is-an-artifact)。パッケージに加え、ドキュメント、ログファイル、エビデンスなども含まれる。参考: [Azure Pipelinesでサポートされている成果物](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/artifacts/artifacts-overview?view=azure-devops&tabs=nuget)
- パッケージ フィード（フィード）
  - パッケージの保管と配信を行うサーバー/サービス。
  - Azure Artifactでは「フィード」と呼ばれるパッケージの管理領域を作成する。
    - パブリックなフィードとプライベートなフィードを作ることができる
  - `nuget push`や`npm publish`を使って、フィードにパッケージを「発行」することができる。
  - 一般的には「リポジトリ」とも。ただしソースコードを格納する「Gitリポジトリ」ではない。
  - 「RSSフィード」とは関係はない。
- パッケージ フィード マネージャー
  - パッケージの管理を行うしくみ/ツール/コマンド。パッケージマネージャ。npm等
- パブリック パッケージ ソース（パブリック パッケージ フィード）
  - パッケージを提供する場所。パッケージのリポジトリ。nuget.org, npmjs.com等
- プライベート フィード（プライベート リポジトリ）
  - 組織等でプライベートに使用されるフィード。
  - 「セルフホステッド」または「SaaS」のどちらかで、プライベート フィードを運用できる。
- セルフホステッド プライベート フィード
  - オンプレミスのサーバー等で運用されるプライベート フィード。
  - 「アーティファクト リポジトリ マネージャ」を使用して作成できる。
- アーティファクト リポジトリ マネージャ
  - プライベート フィード（プライベート リポジトリ）を作るためのソフトウェア。
  - Nexus, Artifactory, Apache Archivaなどが有名。
  - NuGetの場合は「[NuGet.Server](https://www.nuget.org/packages/NuGet.Server/)」を使用。
- SaaS プライベート フィード
  - サービスとして提供されるプライベート フィード。Azure Artifactや、商用のものがある。
- ソース: 
  - (1)Azure Artifactsに接続したCIシステム等（アーティファクトが生成される場所）。Azure PipelinesのYAMLパイプライン等。
  - (2)「アップストリームソース」（Azure Artifacts のフィードが接続する、別のフィード）
    - パブリック パッケージ フィード（npmjs.com等）
    - 他のAzure Artifactsフィード
  - (3)（パッケージの利用者から見た）フィード。例「フィードはパッケージの信頼できるソースです」
  - (4)プログラムのソースコード。Azure Artifactはアーティファクトを格納・配信するものであり、ソースコードは扱わないため、Azure Artifactのドキュメント中ではほぼこの意味では使われない。
- アップストリームソース
  - Azure Artifacts のフィードが参照する、外部のフィード。npmjs.com等。「パブリック パッケージ ソース」は「プライベート フィード」の「アップストリーム ソース」として設定できる。
- 消費者（コンシューマー）
  - パッケージの利用者。フィードからパッケージを取り出して別の開発で利用する開発者やプロジェクトなど。
- 依存関係（Dependency）
  - ソフトウェアプロジェクトで、別のパッケージを使用すること。
  - そのソフトウェアは、そのパッケージに「依存する」。
    - 開発時の依存性、テスト時の依存性、実行時の依存性などがある。
- 依存関係管理（Dependency Management）
  - プロジェクトで使用するパッケージを設定ファイルなどで記録すること。
  - Python: 
    - [requirements.txt](https://www.google.com/search?q=python+requirements.tx)
  - Java: 
    - [pom.xml](https://www.google.com/search?q=java+pom.xml&oq=java+pom.xml)
    - [build.gradle](https://www.google.com/search?q=gradle+build.gradle)


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

つまり、FabricamからContosoにクエリを実行したとき、ContosoからAdventureWorksへの「推移的なクエリ」は実行されない。これは、循環するアップストリームソースが設定されて、[無限ループが形成されるのを防ぐ](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/concepts/package-graph?view=azure-devops#how-upstream-sources-construct-the-set-of-available-packages)ための仕様となっている。

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


ユニバーサルパッケージとは。

ユニバーサル パッケージを使用すると、ユーザーは NuGet、npm、Maven、Python パッケージなど、広く使用されているパッケージ**以外**のさまざまな種類のパッケージを格納できます。

アップロードされたパッケージのサイズは異なります (最大 4 TB までテスト済み) が、常に名前とバージョン番号を持つ必要があります。 

### 既存の成果物リポジトリの識別

※ここは「リリースパイプライン」についての説明だが、これは、Azure Pipelineの「クラシック」パイプラインについての話題なので、スキップする。

参考
[1](https://blog.beachside.dev/entry/2019/08/26/203000),
[2](https://blog.shibayan.jp/entry/20190719/1563525611)

対応部分の[Azure Pipelineのドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/release/artifacts?view=azure-devops)

### アーティファクト リポジトリを移行し、統合する

既存のアーティファクトリポジトリ（オンプレミス サーバー上で運用されていたプライベートなリポジトリ等）を、Azure Artifactに移行することができる。

- [NuGet](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/get-started-nuget?view=azure-devops&tabs=windows&viewFallbackFrom=vsts)
- [npm](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/get-started-npm?view=azure-devops&tabs=new-nav,windows&viewFallbackFrom=vsts)
- [Maven](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/get-started-maven?view=azure-devops&tabs=new-nav&viewFallbackFrom=vsts)
- [Python](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/quickstarts/python-packages?view=azure-devops&tabs=new-nav&viewFallbackFrom=vsts)
- [ユニバーサル パッケージ](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/quickstarts/universal-packages?view=azure-devops&tabs=azuredevops&viewFallbackFrom=vsts)
  - 上記以外の成果物をAzure Artifactで扱う場合に利用。
    - 例
      - C++の成果物
      - テストデータ
      - その他、Gitで管理するのに不向きなもの。
  - 各パッケージは4TBまで。名前とバージョンを指定。
  - [参考](https://qiita.com/nkshigeru/items/4eb022f396935429a7a0)

## パッケージ セキュリティ

### パッケージ フィードへのアクセスを保護する

■フィードは「信頼できるソース」でなければならない

パッケージフィードに悪意のあるパッケージが紛れ込むと、パッケージの利用者（＝開発者、エンドユーザー）に影響が及んでしまう。

パッケージフィードは、パッケージの利用者にとって「信頼できるソース」でなければならない。

※ここでの「ソース」は「パッケージの取得元」という意味。ソースコードや、パッケージを生成するCIのことではない。

■アクセスのセキュリティ保護 （書き込みの制限、スキャン）

悪意のあるパッケージが紛れ込まないよう、正規のユーザー（アクセスを承認されたアカウント）のみ、パッケージをフィードにプッシュできるようにする必要がある。

また、セキュリティスキャンツール、脆弱性スキャンツールを使用して、フィード内のパッケージをスキャンし、危険なパッケージを発見できるようにしなければならない。

■可用性 （アクセス許可）

※ここでの「可用性」は、「システムが稼働していること」ではなく、適切なユーザーだけがフィードを利用できる、という意味。

プライベートなフィードは、非公開の成果物（パッケージ）を取り扱う場合が多い。

したがって、適切な権限があるユーザーだけが、フィードにアクセスできるようにしなければならない。

### ロール

Azure Artifactsの「ロール」

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/feeds/feed-permissions?view=azure-devops)

※RBACロールやAzure ADロールとは別のしくみである。

- Raeder (リーダー、閲覧者)
  - パッケージの一覧表示、インストール、および復元が可能
- Collaborator （コラボレーター）
  - Raederの権限に加え、アップストリームソースからのパッケージを保存が可能
- Contributor（コントリビューター、共同作成者）
  - Collaboratorの権限に加え、パッケージのプッシュ、削除などが可能
- Owner（オーナー、所有者）
  - すべての操作が可能

### アクセス許可

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/feeds/feed-permissions?view=azure-devops)


個々の「ビュー」にもアクセス許可がある。


### 認証

ユーザーの追加（招待）については[モジュール1](mod01.md)で説明済み。

ユーザーは、Azure AD、Microsoftアカウント、GitHubアカウントを使って認証する。

認証が済むと、Azure DevOps（Boards、Repos、Pipelines、Artifacts）にアクセスすることができる。

## バージョン管理戦略の実装

### バージョン管理の概要

- パッケージは、バグの修正や機能の追加で変化し続ける。
- 使用するパッケージを特定するため、バージョン番号を指定する。
- パッケージのコンシューマー（利用者）は、プロジェクトで使用するパッケージのバージョン番号を指定する（依存関係管理）。

■パッケージの不変性とは。

- 一度、パッケージにバージョン番号を付けて公開したら、そのバージョンは変更しない。
- パッケージに修正や機能追加を行ったら、新しいバージョン番号を付けて公開する。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/artifacts-key-concepts?view=azure-devops#immutability)

### 成果物のバージョンを管理する

[セマンティックバージョニング](https://www.google.com/search?q=%E3%82%BB%E3%83%9E%E3%83%B3%E3%83%86%E3%82%A3%E3%83%83%E3%82%AF%E3%83%90%E3%83%BC%E3%82%B8%E3%83%A7%E3%83%8B%E3%83%B3%E3%82%B0)に従ってバージョン番号を付ける。


### セマンティック バージョニング

「1.2.3」のように3つの数字を「.」で区切って表される。3つの数字は順に、以下のように呼ばれる。

- メジャーバージョン
- マイナーバージョン
- パッチバージョン

- **APIの変更に互換性のない場合**は、メジャーバージョンを上げる。
- 後方互換性があり、**機能を追加した場合**はマイナーバージョン上げる。
- 後方互換性を伴う、**バグ修正をした場合**はパッチバージョンを上げる。

さらに、プレリリース バージョンの場合は、後ろに「-rc1」（Release Candidate 1）のような「ラベル」を付与する。アーリー アダプターは、プロジェクトで、プレリリース バージョンを使用できる。

### リリース ビュー

■ビュー（フィードビュー）とは

[ドキュメント](https://docs.microsoft.com/en-us/azure/devops/artifacts/concepts/views?view=azure-devops)


パッケージのバージョンのサブセットを、コンシューマー（パッケージ利用者）に共有することができるしくみ。

つまり、フィードに含まれるパッケージのすべてのバージョンを公開するのではなく、一部の選択されたバージョンのみを、コンシューマーに使用させることができる。

- フィードには、@local, @prerelease, @releaseの3つの「フィードビュー」がある。
- ビューは追加・削除できる。@prerelease, @release は不要であれば削除してもよい。
- フィードはデフォルトのビューを1つ持たなければならない。
- フィードを作成した直後のデフォルトのビューは @local である。
- @local ビューには以下のものが含まれる。
  - フィードに直接発行されたパッケージ
  - フィードのアップストリームソースから保存されたパッケージ
- @local は、他のフィードが、このフィードをアップストリームソースとして指定した場合に使用される。（「パッケージグラフ」で解説済み）


### パッケージを昇格する

■リリース ビュー（パッケージの昇格）とは

- リリース ビューは @prereleaseや @releaseである。
- パッケージが特定の品質基準を満たした際に、パッケージを@prereleaseや @releaseに「昇格（promote）」することができる。
- コンシューマーは、リリースビューを使って、特定の品質基準が満たされたパッケージだけを使用することができる。

### 実証: パッケージの昇格

ラボで実施

### バージョン管理のベスト プラクティス

プロジェクトまたは組織で、以下のようなルールに従うとよい。

- バージョン管理方法をドキュメント化する。
- セマンティックバージョニングを使用する。
- プロジェクトで1つのフィードのみを参照する。（後述：フィードと決定性）
- （Azure Pipelines等で）パッケージの作成する時に、パッケージをフィードに自動的に公開する。

■決定的と非決定的

パッケージマネージャの世界では「決定的」「非決定的」という言葉が登場する場合がある。

- 決定的（deterministic）
  - 依存関係を解決した結果の構成が常に同じとなる
- 非決定的（non-deterministic）
  - 依存関係を解決した結果の構成が常に同じとは限らない

たとえば、[パッケージマネージャnpmでは非決定的な動作をする場合がある](https://www.zilverline.com/blog/unraveling-npm-deterministic-dependencies-with-yarn)。

たとえば、あるプロジェクトがパッケージAとパッケージBへの依存関係がある場合、Aからインストールした場合とBからインストールした場合で、プロジェクトに実際に追加される最終的なパッケージの構成が変わってしまう場合がある。

（かなり乱暴なたとえになるが、料理をする場合に、鍋に材料をいれる順番が変われば、完成した料理の味が変わる、ということに少し似ているかもしれない）

npmの後に開発されたパッケージマネージャYarnの場合は、決定的な動作をするための仕組みを持っている。そのため、依存関係の問題は起こらないようになっている。

■フィードと決定性

パッケージマネージャが使用するフィードが1つだけの場合と、複数ある場合で、動作が決定的あるいは非決定的となる場合がある。

たとえば、NuGet では、複数のフィードが指定されている場合、すべてのフィードに対してパッケージを並列で要求し、最初に応答したフィードからパッケージを受信する。したがって、実行するタイミングによって、異なるフィードから受信したパッケージが使用されるため、最終的なパッケージの構成が変わってしまう場合がある。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/concepts/upstream-sources?view=azure-devops#determining-the-package-to-use-search-order)では、「you should ensure that your client's configuration file only references your product feed, and not any other feeds like the public package managers.」（構成ファイルにて「プロダクト用」のフィードだけを参照し、パブリックのパッケージマネージャなどを参照しないようにするべき）とアドバイスがある。

### パイプラインからのデモンストレーション

ラボで実施

## ラボ

https://docs.microsoft.com/ja-jp/azure/devops/artifacts/get-started-nuget?view=azure-devops&tabs=windows
