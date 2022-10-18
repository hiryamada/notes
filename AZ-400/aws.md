# AWSの開発者向けサービス

■AWS CodeCommit

https://aws.amazon.com/jp/codecommit/

プライベート Git リポジトリをホストする、安全で高度にスケーラブルなマネージド型のソース管理サービス。

対応するAzureサービス/機能: Azure DevOps に含まれる Azure Repos

■AWS CodeBuild

https://aws.amazon.com/jp/codebuild/

ソースコードをコンパイルし、テストを実行し、デプロイ可能なソフトウェアパッケージを作成できる完全マネージド型のビルドサービス。CodeBuild により、ビルドサーバーのプロビジョニング、管理、スケーリングが不要になる。

対応するAzureサービス/機能:

- Azure DevOps に含まれる Azure Pipelines の「エージェント」（ビルドなどのタスクを実行するコンピュータ。マイクロソフトが管理する「Microsoft ホステッド エージェント」または「セルフ ホステッド エージェント」を使用）
- Azure Container Registry（プライベートなコンテナーレジストリ。コンテナーのビルド機能を内蔵している）

■AWS CodePipeline

https://aws.amazon.com/jp/codepipeline/

完全マネージド型の継続的デリバリーサービス。アプリケーションとインフラストラクチャのアップデートのための、パイプラインのリリースを自動化。

対応するAzureサービス/機能: Azure DevOps に含まれる Azure Pipelines

■AWS CodeDeploy

https://aws.amazon.com/jp/codedeploy/

Amazon EC2、AWS Fargate、AWS Lambda、オンプレミスで実行されるサーバーなどへのソフトウェアのデプロイを自動化する、フルマネージド型のサービス。

対応するAzureサービス: Azure DevOps に含まれる Azure Pipelines（デプロイを行うタスク）

デプロイタスクの例:
- [Azure App Service](https://learn.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/azure-rm-web-app-deployment?view=azure-devops)
- [Azure Functions](https://learn.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/azure-function-app?view=azure-devops)
- AWS Tools for Azure DevOps ([製品ページ](https://aws.amazon.com/jp/vsts/), [Azure Marketplaceのページ](https://marketplace.visualstudio.com/items?itemName=AmazonWebServices.aws-vsts-tools)) - 以前 Visual Studio Team Services (VSTS) と呼ばれていたもの。Azure DevOpsの拡張機能。
  - S3へのファイルコピー
  - Elastic Beanstalkへのデプロイ
  - AWS Lambdaへのデプロイ
  - など

■AWS CodeStar

https://aws.amazon.com/jp/codestar/

アプリケーションコードのコーディング、ビルド、テスト、デプロイに使用する開発および継続的な配信ツールチェーン全体を簡単に設定。

- CodeCommit / GitHubのリポジトリの作成
- CodePipelineのパイプライン設定
- など

対応するAzureサービス/機能:
- [Azure DevOps Starter](https://learn.microsoft.com/ja-jp/azure/devops-project/overview)
  - ※[2023/3/31に廃止予定](https://learn.microsoft.com/ja-jp/azure/devops-project/retirement-and-migration)。
  - 後続: [Azure Developer CLI](https://learn.microsoft.com/ja-jp/azure/developer/azure-developer-cli/get-started?tabs=baremetal&pivots=programming-language-nodejs)

