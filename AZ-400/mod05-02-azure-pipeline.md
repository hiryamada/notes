# Azure Pipelines

[製品ページ](https://azure.microsoft.com/ja-jp/services/devops/pipelines/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/?view=azure-devops)

[料金（Azure DevOps）](https://azure.microsoft.com/ja-jp/pricing/details/devops/azure-devops-services/)

- Microsoft ホステッド ジョブ
  - 最初の1ジョブ 無料 (1800分/月)
  - 追加1ジョブごとに $40/月 （時間制限なし）
- セルフ ホステッド ジョブ
  - 追加1ジョブごとに $15/月（時間制限なし）

使用例

- 無料の範囲で、まずAzure Pipelinesで1つのジョブを実行する形で使い始める。
- 月1800分（＝月30時間）まで無料で使うことができる
- 無料の範囲を超えて使いたい場合は、追加の1ジョブを購入する（$40/月）。すると時間制限なしでジョブを実行できるようになる。
- ジョブをたくさん実行すると、ジョブはいったんキューに格納され、1個ずつ実行される。
- たくさんのジョブを並列で実行したい場合は、必要な分だけのジョブを購入する。
- 自分が管理するコンピューター上でジョブを実行したい場合は「セルフホステッドジョブ」を購入する。

## ジョブとエージェント

■ジョブとエージェント

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser

- ジョブ
  - ビルドなどの作業
  - 1つ～複数の「ステップ」で構成される
    - 各ステップはコマンドを実行する等の作業を行う
  - エージェントのホストコンピューターで実行される
- エージェント
  - 一度に1つのジョブを実行するコンピューティングインフラストラクチャ
  - エージェントのソフトウェアがインストールされる
  - VMSSやコンテナーを利用することもできる。

```
エージェント（VM等のコンピュータ）
└エージェント・ソフトウェア ... コマンド実行などの「ジョブ」を実行
```

■Microsoft ホステッド ジョブ / Microsoft ホステッド エージェント

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/licensing/concurrent-jobs?view=azure-devops&tabs=ms-hosted#microsoft-hosted-vs-self-hosted-parallel-jobs

- Microsoft が管理するコンピューターでジョブを実行する場合は、 Microsoft がホストする並列ジョブを使用します。
- ジョブは、 Microsoft がホストするエージェントで実行されます。
- パイプラインを実行するたびに、パイプライン内の各ジョブに対して新しい仮想マシンが作成される
- 仮想マシンは、1つのジョブの実行が終わったら破棄される

```
Microsoft ホステッド エージェント（Microsoftが管理する仮想マシン）
└エージェント・ソフトウェア ... 「Microsoft ホステッド ジョブ」を実行
```

■セルフ ホステッド ジョブ / セルフ ホステッド エージェント

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/licensing/concurrent-jobs?view=azure-devops&tabs=ms-hosted#microsoft-hosted-vs-self-hosted-parallel-jobs

- お客様が管理するコンピューターでジョブを実行したい場合に使用。
- コンピューターにカスタムのアプリケーション等を導入し、ジョブからそのアプリケーションを呼び出すことができる
- コンピューターの性能を好きなようにカスタマイズできる
- Microsoft ホステッド エージェントのように環境を毎回破棄することがないので高速に動作
- 参考: [DevOps の Self-hosted エージェントを構築して使ってみよう！](https://jpdscore.github.io/blog/azuredevops/try-self-hosted-agent/)

```
セルフ ホステッド エージェント（オンプレミス等のコンピューター。macOS, Linux, Windows）
└エージェント・ソフトウェア ... 「セルフ ホステッド ジョブ」を実行
```

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
- 様々なプログラミング言語に対応
  - Java、JavaScript、Node.js、Python、.NET、C++、Go、PHP、XCode など
- 様々なアプリケーションプロジェクトで利用できる
  - .Net、Java、Node、Android、Xcode

## Azure Pipelines の主な用語

■パイプライン(pipeline)

https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/key-pipelines-concepts?view=azure-devops#pipeline

- ビルド・テスト・デプロイ（リリース）の手順を定義したもの。
- YAMLファイルで定義される。
- トリガーによって起動される
  - イベントベースのトリガー
    - [CIトリガー](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/repos/azure-repos-git?view=azure-devops&tabs=yaml#ci-triggers)
      - 特定のブランチへのコミット/プッシュ等
    - [PR（プルリクエスト）トリガー](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/repos/azure-repos-git?view=azure-devops&tabs=yaml#pr-triggers)
    - [別のパイプラインの完了後](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/pipeline-triggers?view=azure-devops)
    - など
  - [スケジュールされたトリガー](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/scheduled-triggers?view=azure-devops&tabs=yaml)
  - 手動で起動することもできる
- ステージ、ジョブ、ステップによって構成される

```
パイプライン: トリガーによって実行
└ステージ: ジョブを整理。「QA（品質管理）」「運用」など。
 └ジョブ: 1つのエージェントで実行される、ステップの集まり。
  └ステップ: パイプラインの最小の構成単位。タスクまたはスクリプト。
```

※ステージとジョブは不要であれば省略できる

※タスク: 事前に構成されたスクリプト

※スクリプト: コマンドライン、PowerShell, Bashなど。

※パイプラインの定義（YAML）については[モジュール6](mod06.md)で詳しく説明する。

■ハンズオン: パイプラインを作って動かしてみよう

パイプラインの作成と実行:

- Azure DevOpsで新しいプロジェクトを作る
- プロジェクト＞Repos
  - 画面下部の「Add a README」にチェックが付いた状態で「Initialize」をクリック
- プロジェクト＞Pipelines
- Create Pipeline
- Azure Repos Git
- プロジェクト名と同名のリポジトリ名をクリック
- Starter pipeline
- Save and run
- （再度）Save and run
- Errorsに、赤のバツ印「No hosted parallelism has been purchased or granted...」と表示されてしまう場合
  - 画面左上「Azure DevOps」＞Organization Settings
  - Pipelines＞Parallel Jobs
  - Microsoft-hosted＞Change
  - Set up billing
  - 「Azure Pass - スポンサー プラン」が選択された状態で「Save」
  - MS Hosted CI/CD の行の「Paid parallel jobs」に「1」と入力、画面左下「Save」
- プロジェクト＞Pipelines
- 「Recently run pipelines」の、エラーになっているパイプライン（プロジェクト名と同名）をクリック
- 画面右上「Run pipeline」をクリック
- 「Run」をクリック
- 2～3分待つ
- 「Jobs」の「Job」行が緑のチェック印付きで表示され、StatusはSuccessとなる。
- 「Job」をクリックすると、各ステップの実行結果などの詳細が確認できる。

パイプラインの定義の確認:

- プロジェクト＞Pipelines
- プロジェクト名と同名のパイプラインをクリック
- 画面右上「...」の「Edit」

次のようなパイプライン（azure-pipelines.yml）が定義されていることがわかる。これは「YAMLパイプライン」である。

```
# Starter pipeline
# Start with a minimal pipeline that you can customize to build and deploy your code.
# Add steps that build, run tests, deploy, and more:
# https://aka.ms/yaml

trigger:
- main

pool:
  vmImage: ubuntu-latest

steps:
- script: echo Hello, world!
  displayName: 'Run a one-line script'

- script: |
    echo Add other tasks to build, test, and deploy your project.
    echo See https://aka.ms/yaml
  displayName: 'Run a multi-line script'
```

- ポイント: 
  - `#` で始まる行はコメント。
  - `trigger`
    - トリガーの定義 
    - main ブランチに変更が行われたら、このパイプラインを起動する
  - `pool` の `vmImage`
    - [エージェントプール](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/pools-queues?view=azure-devops&tabs=yaml%2Cbrowser)の指定
    - Azure DevOpsの組織で使用されるエージェントプールはOrganization Settings＞Pipelines＞Agent poolsで確認できる。デフォルトでは「Azure Pipelines」と「Default」の2つのエージェントプールが定義されている。
      - [「Azure Pipelines」プールには、さまざまな仮想マシンイメージが用意されている。その中に「ubuntu-latest」が含まれている。](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/hosted?view=azure-devops&tabs=yaml#software)
    - 「Default」には、必要に応じてセルフホステッドエージェントを追加できる。
  - `steps`
    - パイプラインのステップの定義
    - `-` で始まる部分が1つのステップ。
    - このパイプラインには2つのステップがある。
    - 1つ目のステップ:
      - `script` で、任意のコマンド（Ubuntuのbashで実行できるもの）を指定できる。
      - `displayName` で、このステップに対してわかりやすい名前を指定できる。
    - 2つ目のステップ:
      - `|` 記号は、複数行のコマンドを書く際などに用いられる。[解説](https://qiita.com/jerrywdlee/items/d5d31c10617ec7342d56#%E3%81%BE%E3%81%9A%E3%81%AF%E5%9F%BA%E6%9C%AC%E5%BD%A2%E3%81%AEfoo-)
      - 2つのechoコマンドが1つのステップとして実行される。
  - このパイプラインでは、ジョブとステージは指定されていない。
    - この場合、1つのステージ、1つのジョブの中で、これらのステップが実行される。
    - ジョブが1つであるため、エージェント（Microsoftホステッドエージェント）が1つだけ使用される。



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
- script: echo Hello world
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
