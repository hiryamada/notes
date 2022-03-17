# ラーニングパスとモジュールの概要

- 4日目
  - ラーニングパス7: パッケージ管理(Azure Artifacts)
  - ラーニングパス8: コンテナー型仮想化

# 講義とハンズオン

- 講義: [依存関係の管理戦略/パッケージ管理](mod09.md)
- 講義: [Docker](mod15.md)
- ハンズオン(前編): [Docker](mod15-handson-docker.md)
  - ※ハンズオン(前編)は(後編)に続きます
- 講義: [Kubernetes](mod16.md)
- ハンズオン(後編): [Kubernetes](mod16-handson-kubernetes.md)

# [ラーニング パス7: 依存関係の管理戦略の設計と実装](https://docs.microsoft.com/ja-jp/learn/paths/az-400-design-implement-dependency-management-strategy/)

## [モジュール1: パッケージの依存関係を探索する](https://docs.microsoft.com/ja-jp/learn/modules/explore-package-dependencies/)

- コンポーネント(component)
  - オープンソースのコンポーネントや、商用のコンポーネントがある
  - ソフトウェアの「部品」
    - ※.NETでは「パッケージ」と呼ぶ
    - 例: [「Json.NET」（newtonsoft.json）](https://www.newtonsoft.com/json): .NETプロジェクトで広く使用されているJSONシリアライザ・デシリアライザ
- コンポーネント化(componentization)
  - ソフトウェアの「部品」（コンポーネント）を切り出して、名前とバージョンを付けること。
  - 再利用がしやすくなる
  - 保守がしやすくなる
- ★コンポーネント化の方法
  - ★「ソース」によるコンポーネント化
    - プロジェクトのソースコードを「コンポーネント」に分解する
      - 例: [ある機能をクラスを切り出す](https://docs.microsoft.com/ja-jp/dotnet/csharp/fundamentals/tutorials/classes)
    - コンポーネントはそのプロジェクトの中だけで使う
    - 別のプロジェクトでその「コンポーネント」を使用したい場合は、ソースコードをコピーする必要がある
  - ★「パッケージ」によるコンポーネント化
    - 「コンポーネント」をパッケージ化する
      - 例: [.NETの「Nugetパッケージ」を作る](https://docs.microsoft.com/ja-jp/nuget/what-is-nuget)
    - 「NuGet.org」や「Azure Artifacts フィード」にパッケージを格納して、関係者と共有する
- 依存関係(dependency)
  - あるプロジェクトで、「別のプロジェクト」や「コンポーネント」（パッケージ）を使用すること
    - このとき、プロジェクトから、「別のプロジェクト」や「コンポーネント」への「依存関係」が生じる
      - つまり、プロジェクトは、「依存関係」にある「別のプロジェクト」や「コンポーネント」がないと、動かすことができなくなる。
    - 「依存関係」を「宣言」（追加）する
      - プロジェクトで「パッケージX」の「バージョン1.2以上が必要」といった指定を行うこと
      - 例: [dotnet add package](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-add-package)
        - 依存関係が ～.csproj ファイルに記録される
    - 「依存関係」を「解決」する
      - プロジェクトの依存関係の宣言を元に、「パッケージX」の「バージョン1.2.3」を使う、といったように、実際にプロジェクトで使用するバージョンを決めること
      - 例: NuGet
        - [依存関係の解決](https://docs.microsoft.com/ja-jp/nuget/concepts/dependency-resolution)
        - [依存関係の解決ルール](https://docs.microsoft.com/ja-jp/nuget/concepts/dependency-resolution#dependency-resolution-rules)
- [依存関係管理(dependency management)](https://docs.microsoft.com/ja-jp/learn/modules/explore-package-dependencies/2-what-dependency-management)
  - [プロジェクトの依存関係を追加・削除・記録すること。](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dependencies)
    - [dotnet add package](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-add-package)
    - [dotnet remove package](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-remove-package)
    - 依存関係は[プロジェクトの「～.csproj」ファイル](https://docs.microsoft.com/ja-jp/dotnet/core/project-sdk/overview#project-files)に記録される
- ★[依存関係管理の戦略(dependency management strategy)](https://docs.microsoft.com/ja-jp/learn/modules/explore-package-dependencies/3-describe-elements-of-dependency-management-strategy)
  - 「戦略」（依存関係の管理の方法）は言語によってさまざま。
  - ★標準化された方法
    - 言語ごとに、パッケージの作成、発行、入手などについて、「標準化された方法」があり、それらの作業を「自動化する方法」も提供される
    - dotnet add/remove package
    - npm
    - pip
    - Maven / Gradle
  - ★パッケージの形式
    - [NuGetパッケージ](https://docs.microsoft.com/ja-jp/nuget/what-is-nuget)
    - [npmパッケージ](https://ja.wikipedia.org/wiki/Npm_(%E3%83%91%E3%83%83%E3%82%B1%E3%83%BC%E3%82%B8%E7%AE%A1%E7%90%86%E3%83%84%E3%83%BC%E3%83%AB))
    - [Pythonパッケージ(Distribution Package?)](https://packaging.python.org/en/latest/glossary/#term-Distribution-Package)
    - [JARファイル](https://docs.oracle.com/javase/jp/7/technotes/guides/jar/jarGuide.html)
  - ★ソース（パッケージの一元管理と配布）
    - [NuGet.org](https://www.nuget.org/)
    - [npm](https://www.npmjs.com/)
    - [The Python Package Index](https://pypi.org/)
    - [Maven repository](https://mvnrepository.com/)
  - ★バージョン管理
    - 多くの場合 [セマンティックバージョニング](https://semver.org/lang/ja/) が利用される
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/explore-package-dependencies/8-knowledge-check)

## [モジュール2: パッケージ管理について理解する](https://docs.microsoft.com/ja-jp/learn/modules/understand-package-management/)

- 「フィード」
  - パッケージを記録・配信するしくみ
  - Azure Artifactは「フィード」を提供するサービス
- ★「プライベートフィード」
  - 関係者（自分と、招待した人）だけがアクセスできる「フィード」
- ★「プライベートフィード」の運用方法
  - ★SaaSのサービス
    - SaaS型で提供されている「フィード」を使用する方法。
    - Azure Artifacts
    - GitHub Packages
  - ★セルフホスティング
    - 「Azure Artifacts」と同様の仕組みを自分でサーバーを立てて運用する方法。
    - [NuGet.Server](https://docs.microsoft.com/ja-jp/nuget/hosting-packages/nuget-server)
    - [Nexus](https://www.sonatype.com/products/repository-pro) 
      - リポジトリマネージャ
      - Maven/Java, npm, NuGet, Helm, Docker, P2, OBR, APT, GO, R, Conan
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/understand-package-management/12-knowledge-check)

## [モジュール3: 成果物の移行、統合、およびセキュリティ保護](https://docs.microsoft.com/ja-jp/learn/modules/migrate-consolidating-secure-artifacts/)

- [ユニバーサルパッケージ](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/quickstarts/universal-packages?view=azure-devops)
  - Azure Artifactsフィード内の場所
  - （NuGet形式等以外の）任意のバイナリを格納できる
  - [Azure Pipelinesからは「UniversalPackages@0」タスクを使用して発行できる](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/artifacts/universal-packages?view=azure-devops&tabs=yaml#publish-a-universal-package)
- [Azure Artifactsの「権限」](https://docs.microsoft.com/ja-jp/azure/devops/artifacts/feeds/feed-permissions?view=azure-devops#permissions-table)
  - 閲覧者
    - フィードのパッケージの一覧表示、復元（[dotnet restore](https://docs.microsoft.com/ja-jp/dotnet/core/tools/dotnet-restore)）、インストール）
  - コラボレーター
  - Contributor（共同作成者）
  - 所有者
  - 管理者
- [Azure DevOpsのサービスアカウント](https://docs.microsoft.com/ja-jp/azure/devops/organizations/security/permissions?view=azure-devops&tabs=preview-page#service-accounts)
  - Organization Settings＞Security＞Permissions＞Usersで確認できる
  - プロジェクト コレクション ビルド サービス
    - 「共同作成者」ロールを持つ
    - [Azure Pipelinesのパイプラインから Azure Artifacts フィードにパッケージを発行するには、Project Collection Build Service ID をフィードの共同作成者に設定する必要がある](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/artifacts/nuget?view=azure-devops&tabs=yaml#publish-a-package)
    - ※「[プロジェクト コレクション](https://docs.microsoft.com/ja-jp/azure/devops/server/admin/manage-project-collections?view=azure-devops-2020)」: Azure DevOps Serverの機能。複数のプロジェクトをグループ化し、グループで使用するリソースを管理する機能
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/migrate-consolidating-secure-artifacts/8-knowledge-check)

## [モジュール4: バージョン管理戦略を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-versioning-strategy/)

- パッケージのバージョン管理
  - 一度発行したバージョンは上書きしない
  - たとえばあるパッケージのバージョン「1.2」にバグがあった場合は、そのバージョンを上書きするのではなく、新しいバージョン「1.3」として登録する
- [パッケージの「リリースビュー」](https://docs.microsoft.com/ja-jp/learn/modules/implement-versioning-strategy/4-examine-release-views)
  - パッケージの品質を表す
  - ローカル `@Local`
  - プレリリース `@Prerelease`
  - リリース `@Release`
- 昇格
  - パッケージは常にローカルビューに表示される
  - 「昇格」すると
    - プレリリースまたはリリースのビューに表示されるようになる
    - 削除はできなくなる
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-versioning-strategy/9-knowledge-check)


# [ラーニング パス8: Docker と Kubernetes を使用したコンテナーの作成と管理](https://docs.microsoft.com/ja-jp/learn/paths/az-400-create-manage-containers-using-docker-kubernetes/)

## [モジュール1: コンテナーのビルド戦略を考える](https://docs.microsoft.com/ja-jp/learn/modules/design-container-build-strategy/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/design-container-build-strategy/11-knowledge-check)

## [モジュール2: Docker マルチステージ ビルドを実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-docker-multi-stage-builds/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-docker-multi-stage-builds/8-knowledge-check)

## [モジュール3: Azure Kubernetes Service (AKS) を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-kubernetes-service/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-kubernetes-service/11-knowledge-check)

## [モジュール4: Kubernetes ツールを探索する](https://docs.microsoft.com/ja-jp/learn/modules/explore-kubernetes-tooling/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/explore-kubernetes-tooling/5-knowledge-check)

## [モジュール5: AKS をパイプラインに統合する](https://docs.microsoft.com/ja-jp/learn/modules/integrate-aks-pipelines/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/integrate-aks-pipelines/5-knowledge-check)