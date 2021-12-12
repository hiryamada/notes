# DevOpsのCI/CDパイプラインの概念

[CI/CDパイプライン](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/key-pipelines-concepts?view=azure-devops)を使用して、CI/CDを自動化することができる。

自動化のメリット
- 品質の向上: 人手による作業を排除することで、作業のミスや漏れを防ぐ
- 俊敏性: ビルド・テスト・デプロイをより頻繁に実行できる
- 速度: 複数の作業を連続的に、高速に実行できる
- 並列化: 複数のジョブ（ビルドやリリース）を同時に実行できる。

※並列化を行わない場合は、ジョブはキューに格納され、1つずつ実行される。

CI/CDのサービス/ツールの例
- [Azure Pipelines](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/what-is-azure-pipelines?view=azure-devops)
- [Google Cloud Build](https://cloud.google.com/build?hl=ja)
- [AWS CodePipeline](https://aws.amazon.com/jp/codepipeline/)
- [TeamCity](https://www.jetbrains.com/ja-jp/teamcity/)
- [Jenkins](https://www.jenkins.io/)
- [CloudBees](https://cloudbees.techmatrix.jp/)
- [CircleCI](https://circleci.com/ja/)
- [Travis CI](https://travis-ci.org/)
