# モジュール11 Azure Pipelineを使った継続的デプロイの実装


## リリース パイプラインの作成

### Azure DevOps リリース パイプライン

YAMLパイプラインと、クラシックパイプラインの比較。[モジュール10](mod10.md)で解説済み。

ここでは特に、YAMLパイプラインで「No」と表示されている機能に注意。
- [ゲート](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/release/deploy-using-approvals?view=azure-devops#set-up-gates)
  - YAMLの場合は[ステージの条件](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/conditions?view=azure-devops&tabs=yaml)を使用して制御。
- [デプロイジョブグループ（配置グループジョブ）](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/deployment-group-phases?view=azure-devops&tabs=yaml)
- [タスクグループ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/library/task-groups?view=azure-devops)
  - 代わりにYAMLテンプレートを使用できる。YAMLテンプレートについては[モジュール6](mod06.md)で説明済み。

### ビルドとリリースのタスク

**「クラシック」のパイプラインの説明のため、本節は省略**

### リリース ジョブ

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml)


- パイプラインは、少なくとも1つのジョブで構成される。
- ジョブは、1 つの単位として順番に実行されるステップの集まりである。
- ジョブは、実行をスケジュールできる最小の作業単位

■複数のジョブによるデプロイの例

プロジェクトに以下のものが含まれていると考えてみる。

- .NETのバックエンド - Windowsエージェントでビルド
- Angular のフロント エンド - Linuxエージェントでビルド
- およびネイティブ IOS モバイル アプリ - Macエージェントでビルド

3 つの成果物のデプロイすべてを 1 つのパイプラインの一部にする場合は、異なるエージェント、サーバー、またはデプロイ グループを対象とする複数のリリース ジョブを定義することができる。

### マルチ構成およびマルチエージェント

■マルチ構成ビルド/デプロイ/テスト

複数の構成を並列でビルド/デプロイ/テストすることができます。

たとえば、あるアプリの x86版 と x64版 を並列でビルドすることができます。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#multi-job-configuration)

### ディスカッション: リリース ジョブの使用方法

（省略）

## 環境のプロビジョニングと構成

### ターゲット環境のプロビジョニングと構成

パイプラインを使用して、さまざまな環境のプロビジョニングを行うこともできる。

- オンプレミスのサーバーを構成する
  - IISのセットアップ等
- IaaS（Azure仮想マシン等）をデプロイする
  - ARMテンプレート
  - Terraform
- Kubernetesクラスターをデプロイする

### 実証: サービス接続のセットアップ

（省略）


## タスクとテンプレートの管理とモジュール化

**「クラシック」のパイプラインの説明のため、本節は省略**

## 自動統合と機能テスト自動化の構成

### 自動統合と機能テスト自動化の構成

テストをいくつかの観点で分類することができる。

- 比較的容易に自動化できるテスト
  - 単体テスト等
  - アプリケーションと同じ言語でテストコードを記述
  - 追加のインフラを必要としない場合が多い
  - できるだけこのレベルでテストを行うべき
- 特殊な機能を使用する必要があるテスト
  - Seleniumなどを使ったエンド・トゥ・エンドのテスト
  - テスト用の環境をパイプラインの中で構築する必要がある場合が多い
- 外部のテストツールを使ったテスト
  - 負荷テスト等
  - 外部のテストサービスなどの契約、呼び出しが必要となる

### テスト インフラストラクチャのセットアップ

.NETアプリケーションのテストの実行例。

[DotNetCoreCLI@2](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/build/dotnet-core-cli?view=azure-devops)の `command: test` を使用して、テストを実行することができる。

要するに `dotnet test` と同じ結果となる。

### 可用性テストの設定と実行

Webアプリのテストの自動化の[事例](https://azure.microsoft.com/nl-nl/blog/creating-a-web-test-alert-programmatically-with-application-insights/)の紹介。

この事例では、Application Insightsを使用してWebテストを行っている。

- まずは手動でAzure portalからApplication Insightsを構成する
- Application Insightsを、ARMテンプレートにエクスポートする
- テンプレートから必要部分（Webテストと、アラートルール）を抽出し、新しいARMテンプレートを作る

ゼロからARMテンプレートでテストをJSONに書き起こすのではなく、Azure portalからリソースをエクスポートする形で、テンプレートを新しく作る作業を省力化することができる。


## 健康検査の自動化

### 正常性検査の自動化


- ゲート
  - [YAMLパイプラインで対応していない](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#feature-availability)ため、割愛。


### イベント、サブスクリプション、および通知

- 作業項目、プルリクエスト、コードレビュー、ソース、ビルドなどにイベントが発生した（変更があった）場合に通知を送る。
  - 電子メールを送信
  - [Microsoft TeamsやSlackなどに送信](https://docs.microsoft.com/ja-jp/azure/devops/notifications/integrate-third-party-services?view=azure-devops)
- 人に向かって情報を送る仕組み。
- 送信量が多くなりすぎないように注意。
- [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/notifications/about-notifications?view=azure-devops)

### サービス フック

- サービスフックを使用すると、Azure DevOps プロジェクトでイベントが発生した場合に、他のサービスに対してタスクを実行することができる。
- こちらは（人への通知も含む）さまざまな外部サービスに対する連携の方法。
- [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/service-hooks/overview?view=azure-devops)

### 実証: パイプラインを監視するサービス フックの設定

