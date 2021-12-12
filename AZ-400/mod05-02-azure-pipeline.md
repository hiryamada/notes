# Azure Pipelines

[製品ページ](https://azure.microsoft.com/ja-jp/services/devops/pipelines/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/?view=azure-devops)

[料金（Azure DevOps）](https://azure.microsoft.com/ja-jp/pricing/details/devops/azure-devops-services/)

- Microsoft ホステッド ジョブ
  - 最初の1ジョブ 無料 (1800分/月)
  - 追加1ジョブごとに $40/月 （時間制限なし）
- セルフ ホステッド ジョブ
  - 追加1ジョブごとに $15/月（時間制限なし）

## Azure Pipelineとは

- [継続的インテグレーション (CI)](https://docs.microsoft.com/ja-jp/devops/develop/what-is-continuous-integration)/[継続的デリバリー (CD)](https://docs.microsoft.com/ja-jp/devops/deliver/what-is-continuous-delivery) のサービス
- コードを自動的にビルド・テスト・デプロイ。その他、多数の[タスク](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/?view=azure-devops)も組み込み可能
  - ビルド
    - iOS: [Xcode](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/xcode?view=azure-devops)
    - [Android](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/android-build?view=azure-devops)
    - Xamarin: [Android](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/xamarin-android?view=azure-devops), [iOS](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/xamarin-ios?view=azure-devops)
    - [.NET](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/dotnet-core-cli?view=azure-devops)
    - Java: [Maven](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/maven?view=azure-devops), [Gradle](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/gradle?view=azure-devops), [Ant](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/ant?view=azure-devops)
    - JavaScript: [Grunt](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/grunt?view=azure-devops), [gulp](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/gulp?view=azure-devops)
    - [Go](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/go?view=azure-devops)
    - [Docker](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/docker?view=azure-devops)
  - テスト
    - [WebアプリのUIテスト（Selenium等）](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/test/ui-testing-considerations?view=azure-devops&tabs=mstest)
    - [テスト結果の発行](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/test/publish-test-results?view=azure-devops&tabs=trx%2Cyaml)
      - [.Net Core](https://docs.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops&tabs=dotnetfive#run-your-tests), JUnit, NUnit, Ant, Maven, Gulp, Grunt, Xcodeなど
      - タスク内で実行されたテスト結果をパイプラインに発行して利用。[事例](https://aonasuzutsuki.hatenablog.jp/entry/2020/12/03/140531#NUnit%E3%81%AB%E3%82%88%E3%82%8B%E8%87%AA%E5%8B%95%E3%83%86%E3%82%B9%E3%83%88)
    - [Visual Studio テストランナー](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/test/vstest?view=azure-devops)
    - 負荷テスト: [Apache JMeter](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/test/run-jmeter-load-test?view=azure-devops)
    - モバイルアプリのテスト: [App Center](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/test/app-center-test?view=azure-devops)
  - デプロイ
    - Azureのサービス系
      - [Azure App Service](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/azure-rm-web-app-deployment?view=azure-devops)
      - [Azure Function](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/azure-function-app?view=azure-devops)
      - VM上の[IIS](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/iis-web-app-deployment-on-machine-group?view=azure-devops)
      - Blob Storageに[AzCopy](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/azure-file-copy?view=azure-devops)を使って静的サイト等をデプロイ
    - パッケージ系
      - [Azure Artifacts / pypi(パイピーアイ)](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/artifacts/pypi?view=azure-devops&tabs=yaml)
      - [Azure Artifacts / npm(registry.npmjs.org)](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/artifacts/npm?view=azure-devops&tabs=yaml)
      - [Azure Artifacts / Nuget](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/artifacts/nuget?view=azure-devops&tabs=yaml)
    - ストア系
      - [Windows Store](https://marketplace.visualstudio.com/items?itemName=MS-RDX-MRO.windows-store-publish)
      - [Google Play](https://marketplace.visualstudio.com/items?itemName=ms-vsclient.google-play)
      - [App storeへのリリース](https://marketplace.visualstudio.com/items?itemName=ms-vsclient.app-store)
    - その他
      - [GCP](https://marketplace.visualstudio.com/items?itemName=nexso.azure-devops-google-cloud-tools)
      - [AWS](https://marketplace.visualstudio.com/items?itemName=AmazonWebServices.aws-vsts-tools): S3, Beanstalk, Lambda, ECRなどと連携
- 様々なプログラミング言語
  - Java、JavaScript、Node.js、Python、.NET、C++、Go、PHP、XCode など
- 様々なアプリケーションプロジェクトで利用できる
  - .Net、Java、Node、Android、Xcode

## Azure Pipelines の主な用語

■パイプライン(pipeline)

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/key-pipelines-concepts?view=azure-devops#pipeline

- ビルド・テスト・デプロイ（リリース）の手順を定義したもの。
- YAMLファイルで定義される。
- トリガーによって起動される
- ステージ、ジョブ、ステップによって構成される

```
パイプライン: トリガーによって実行
└ステージ（オプション）: ジョブを整理。「QA（品質管理）」「運用」など。
 └ジョブ: 1つのエージェントで実行される、ステップの集まり。
  └ステップ: パイプラインの最小の構成単位。タスクまたはスクリプト。
```

※タスク: 事前に構成されたスクリプト

※スクリプト: コマンドライン、PowerShell, Bashなど。

※パイプラインの定義（YAML）については[モジュール6](mod06.md)で詳しく説明する。

■ステージ(stage)

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/key-pipelines-concepts?view=azure-devops#stage

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/stages?view=azure-devops&tabs=yaml

- ジョブの集まり
- 例
  - アプリをビルドする
  - テストを実行する
  - 本番環境にデプロイする
- オプションなので、不要であれば使用しなくてもよい。
- 依存関係(dependsOn)を設定することができる

複数のステージがある場合、デフォルトでは、定義された順に実行されていく
```
stages:
- stage: A
  jobs:
  - job: A1
  - job: A2
- stage: B
  jobs:
  - job: B1
  - job: B2
```
ステージを順に実行（明示的に指定）
```
stages:
- stage: A
  jobs:
  - job: A1
  - job: A2
- stage: B
  dependsOn: A
  jobs:
  - job: B1
  - job: B2
```

ステージを並列で実行
```
stages:
- stage: A
  jobs:
  - job: A1
  - job: A2
- stage: B
  dependsOn: []
  jobs:
  - job: B1
  - job: B2
```

ファンアウト・ファンイン
```
# ステージBとCは、Aが完了したら実行される（ファンアウト）
# ステージDは、BとCが完了したら実行される（ファンイン）
stages:
- stage: A
  jobs:
  - job: A1
  - job: A2
- stage: B
  dependsOn: A
  jobs:
  - job: B1
  - job: B2
- stage: C
  dependsOn: A
  jobs:
  - job: C1
  - job: C2
- stage: D
  dependsOn: [B,C]
  jobs:
  - job: D1
  - job: D2
```

■ジョブ(job)

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/key-pipelines-concepts?view=azure-devops#job

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml

- ジョブは一連のステップで構成される
- 各ジョブは（基本的には）エージェントで実行される
  - 例: ジョブ1はエージェント1、ジョブ2がエージェント2で実行される
  - エージェントは「Microsoftホステッドエージェント」または「セルフホステッドエージェント」
  - 各エージェントは1度に1つのジョブを実行する。
    - 複数のジョブを並列で実行するには複数のエージェントが必要。
  - [エージェントを使用しない「エージェントレスジョブ」もある。](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#agentless-tasks)
    - エージェントレスジョブでは以下のようなタスクを実行できる
      - ディレイタスク（遅延タスク）: 指定した分だけパイプラインの実行を停止する
      - Azure Functionsを呼び出すタスク
- あるジョブに含まれるステップは、同じエージェントで実行される
  - 例: ジョブ1に含まれるステップ1,2,3はすべてエージェント1で実行される
- 連続するステップを異なる環境などで実行したい場合などにジョブを利用する
  - 例: Python 3.5, 3.6, 3.7の各バージョンでジョブを実行する、など。
- デプロイジョブ: デプロイを行う特別なジョブ。job の代わりにdeployment キーワードを使用する。

依存関係のない2つのジョブの例
```
jobs:
- job: A
  steps:
  - bash: echo "A"
- job: B
  steps:
  - bash: echo "B"
```

依存関係がある2つのジョブの例
```
jobs:
- job: A
  steps:
  - bash: echo "A"
- job: B
  dependsOn: A
  steps:
  - bash: echo "B"
```

並列で実行されるジョブの例
```
jobs:
- job: Windows
  pool:
    vmImage: 'windows-latest'
  steps:
  - script: echo hello from Windows
- job: macOS
  pool:
    vmImage: 'macOS-latest'
  steps:
  - script: echo hello from macOS
- job: Linux
  pool:
    vmImage: 'ubuntu-latest'
  steps:
  - script: echo hello from Linux
```

マトリックスの利用例 - https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=example%2Cparameter-schema#matrix

以下の例は `Build Python35`, `Build Python36`, `Build Python37` という3つのジョブ（ジョブのコピー）を生成する。

各ジョブでは `PYTHON_VERSION` という変数を使用して、Pythonのバージョンの値(3.5, 3.6, 3.7)を利用できる。

オプションのmaxParallelで、ジョブの最大の同時実行数を指定できる。

```
jobs:
- job: Build
  strategy:
    matrix:
      Python35:
        PYTHON_VERSION: '3.5'
      Python36:
        PYTHON_VERSION: '3.6'
      Python37:
        PYTHON_VERSION: '3.7'
    maxParallel: 2
```

■ステップ(step)

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/key-pipelines-concepts?view=azure-devops#step

- パイプラインの最小の構成ブロック
- ステップには、スクリプトまたはタスクを指定できる
  - タスク: 事前に作成されたスクリプト
  - スクリプト: コマンドライン、PowerShell, Bashなど。
- ステップの例:
  - ビルド ステップ
  - テスト ステップ

スクリプトの例:
```
steps:
- script: echo Hhello world
```
タスク:
https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/?view=azure-devops

タスクの例(dotnet build)
```
- task: DotNetCoreCLI@2
  inputs:
    command: 'build'
```

タスクの例(dotnet publish)
```
- task: DotNetCoreCLI@2
  inputs:
    command: 'publish'
    publishWebProjects: false
    projects: '**/*.csproj'
    arguments: '-o $(Build.ArtifactStagingDirectory)/Output'
    zipAfterPublish: true
    modifyOutputPath: true
```

タスクの例(dockerでbuildとpush)
```
steps:
- task: Docker@2
  displayName: Login to Docker Hub
  inputs:
    command: login
    containerRegistry: dockerRegistryServiceConnection2
- task: Docker@2
  displayName: Build and Push
  inputs:
    command: buildAndPush
    repository: contosoRepository
```

タスクでは @1, @2 などを使用してタスクのメジャーバージョンを指定する。

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/tasks?view=azure-devops&tabs=yaml#task-versions

