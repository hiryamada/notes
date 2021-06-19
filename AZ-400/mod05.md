# モジュール5 Azure Pipelinesの構成

- パイプラインとは何か。
  - どんなメリットがあるのか。
  - どんなことができるのか。
- Azure Pipelinesとは。
  - エージェントとは何か。
  - エージェントプールとは何か。
  - ジョブとは何か。
  - 複数のジョブを並列で実行するには。
  - 「YAML」と「クラシック」とは。

## DevOpsのパイプラインの概念

- パイプラインとは何か。
  - どんなメリットがあるのか。
  - どんなことができるのか。

[パイプライン](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/key-pipelines-concepts?view=azure-devops)を使用して、CI/CDを自動化することができる。

自動化のメリット
- 品質の向上: 人手による作業を排除することで、作業のミスや漏れを防ぐ
- 俊敏性: ビルド・テスト・デプロイをより頻繁に実行できる
- 速度: 複数の作業を連続的に、高速に実行できる
- 並列化: 複数のジョブ（ビルドやリリース）を同時に実行できる。

※並列化を行わない場合は、ジョブはキューに格納され、1つずつ実行される。

CI/CDのサービス/ツールの例
- Azure Pipelines
- [Google Cloud Build](https://cloud.google.com/build?hl=ja)
- [AWS CodePipeline](https://aws.amazon.com/jp/codepipeline/)
- [TeamCity](https://www.jetbrains.com/ja-jp/teamcity/)
- [Jenkins](https://www.jenkins.io/)
- [CloudBees](https://cloudbees.techmatrix.jp/)
- [CircleCI](https://circleci.com/ja/)
- [Travis CI](https://travis-ci.org/)

## Azure Pipelines

[Azure Pipelines](azure-pipelines.md)を参照。

## ホスト型エージェントと自己ホストエージェント

[Azure Pipelines](azure-pipelines.md)を参照。

## エージェントプール

[Azure Pipelines](azure-pipelines.md)を参照。

## パイプラインとコンカレンシー

[Azure Pipelines](azure-pipelines.md)を参照。

## Azure DevOpsとオープンソースプロジェクト

[Azure Pipelines](azure-pipelines.md)を参照。

## Azure Pipelines YAMLとVisual Designer

[Azure Pipelines](azure-pipelines.md)を参照。

## ラボ

Azure Pipeline

[Enabling Continuous Integration with Azure Pipelines](https://azuredevopslabs.com//labs/azuredevops/continuousintegration/)

短いラボなので30分ほどで完了できる。

