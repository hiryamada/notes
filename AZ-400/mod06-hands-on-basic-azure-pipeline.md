
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
    - Azure DevOpsの組織で使用されるエージェントプールはOrganization Settings＞Pipelines＞Agent poolsで確認できる。
    - デフォルトでは「Azure Pipelines」と「Default」の2つのエージェントプールが定義されている。
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
