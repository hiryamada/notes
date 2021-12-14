
## Azure Pipelinesとの統合

YAMLパイプラインの定義方法。

ここではAzure PipelinesのYAMLパイプラインについて解説します。

詳細についてはドキュメントを参照してください。

### パイプラインの構造

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml)

[リファレンス](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema)

#### name


パイプラインの実行の番号付け方法をカスタマイズできます。
パイプラインのルート レベルで指定します。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/run-number?view=azure-devops&tabs=yaml)

```
name: $(TeamProject)_$(Build.DefinitionName)_$(SourceBranchName)_$(Date:yyyyMMdd)$(Rev:.r)

steps:
  - script: echo '$(Build.BuildNumber)' # outputs customized build number like project_def_master_20200828.1
```

#### trigger

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#triggers)

トリガーにはいくつかの種類がありますが、ここではプッシュトリガーについて説明します。

プッシュトリガー: 継続的インテグレーション ビルドを実行するブランチを指定します。
```
trigger:
- main
```

#### variables

変数を初期化します。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=example%2Cparameter-schema#variables)

```
variables:
  VAR1: 'value1'
  VAR2: 'value2'
```

#### pool

ジョブで使用するプールを指定します。

パイプライン、ステージ、またはジョブ レベルでプールを指定できます。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=example%2Cparameter-schema#pool)


プールを使用するには、プールの名前を指定します。

```
pool: MyPool
```
Microsoft がホストするプールを使用するには、名前を省略し、[使用可能なホストされている イメージ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/hosted?view=azure-devops&tabs=yaml#use-a-microsoft-hosted-agent)の1つを指定します。

```
pool:
  vmImage: ubuntu-16.04
```

#### steps

各ステップは、[スクリプト](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#script)や[タスク](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/?view=azure-devops)です。

以下は、スクリプトの利用例です。

```
steps:
- script: echo hello
- script: echo world
```

以下は、[「.NET Core CLI」タスク](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/dotnet-core-cli?view=azure-devops)の利用例です。`dotnet build`を実行します。

```
steps:
- task: DotNetCoreCLI@2
  inputs:
    command: 'build'
```

#### jobs と job

ジョブ（エージェントで実行するステップの集まり）を指定します。

複数のステップを、ジョブにまとめて実行します。

ジョブの実行条件を指定したり、複数のジョブの依存関係を指定したりすることができます。（ジョブAとジョブBがどちらも終わったらジョブCを実行、など）

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=example%2Cparameter-schema#job)


`job:` の後ろに、ジョブの名前を指定します。

`steps:` で、ジョブのステップを指定します。

```
jobs:
- job: Job1
  steps:
  - script: echo Job1
- job: Job2
  steps:
  - script: echo Job2
```

#### stages と stage

ステージ（ジョブのあつまり）を指定します。

[承認](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/approvals?view=azure-devops&tabs=check-pass)を使用して、ステージを実行するかどうかを人が制御できます。

Microsoft Teamsで、承認の通知を送ることができます。[事例](https://qiita.com/okazuki/items/4e303ecdc099925084a1)

承認は、YAMLには記入せず、Azure Pipelinesの画面から設定します。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#stage)


以下の例では、BuildとDeployという2つのステージを指定しています。Deployに対して承認を設定することで、担当者によって承認されたらデプロイを行うようにすることができます。

```
stages:
- stage: Build
  jobs:
    steps:
    - script: echo build
- stage: Deploy
  jobs:
    steps:
    - script: echo deploy
```


### Pipeline Structure

（パイプライン、ステージ、ジョブ、ステップ、タスクについてのサンプル。上記で説明済み）

### テンプレート

1 つのファイルに一連のステージを定義し、それを他のファイルで複数回使用することができます。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/templates?view=azure-devops)

例：build1.ymlでステージを定義し、azure-pipelines.ymlでステージを利用。

build1.yml
```
stages:
  stage: Build
  jobs:
    steps:
    - script echo build
```

azure-pipelines.yml
```
stages:
- template: build1.yml
```

### YAML リソース

環境とは。リソースとは。

「環境」とは、パイプラインからのデプロイの対象となる、Kubernetes クラスターや virtual machines などの「リソース」の集まり。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/environments-virtual-machines?view=azure-devops)

使用例:

- デプロイ先となるVMを作成する。
- Azure Pipelinesの「Environments」メニューから、新しい「Environment」（環境）を作る。環境の名前を指定し、種類として「Kubernetes」や「Virtual machines」を選択する。
- 続いて表示されるPowerShellスクリプト（Windows VMの場合）をコピーし、VM内で実行する。環境にそのVMがリソースとして登録される。
- YAMLパイプラインの中に、デプロイを行うステージを定義する。ステージの中で「deployment」ジョブを使用して、そこで、上記で作成した「環境」を指定する。
    ```
    jobs:
    - deployment: 
        environment: 
        name: WebServers
        resourceType: VirtualMachine
    ```

### パイプラインで複数のリポジトリを使用

複数のリポジトリからソースコードを取り出してビルドするには。

自分自身のリポジトリ（azure-pipelines.ymlが置かれているリポジトリ）以外のリポジトリを利用することができる。

[ドキュメント1](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/repos/multi-repo-checkout?view=azure-devops),
[ドキュメント2](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#repository-resource)

以下の例では、「repo1」として、このプロジェクトの中の「repo1」というAzure Reposリポジトリを参照し、「repo2」として、GitHubの「githubuser」ユーザーの「repo2」リポジトリを参照している。
```
resources:
  repositories:
  - repository: repo1
    type: git
    name: repo1
  - repository: repo2
    type: github
    name: githubuser/repo2    
```

そして、ステップの中で以下のようにして、自分自身のリポジトリ（self）と、repo1, repo2をチェックアウトしている。

```
steps:
- checkout: self
- checkout: repo1
- checkout: repo2
```
