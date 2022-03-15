# DevOpsのCI/CDパイプラインの概念

[CI/CDパイプライン](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/key-pipelines-concepts?view=azure-devops)を使用して、CI/CDを自動化することができる。

CI/CDのイメージ:
https://www.kagoya.jp/howto/it-glossary/develop/cicd/

- CI: Continuous Integration
  - ビルド、テスト
- CD: Continuous Delivery
  - ビルド、テスト、開発環境へのデプロイ
- CD: Continuous Deploy
  - ビルド、テスト、開発環境へのデプロイ、本番環境へのデプロイ

パイプラインのイメージ:
https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/key-pipelines-concepts

- パイプライン
  - CI/CDを定義・実行するしくみ
  - 例
    - Azure Pipelines
    - [AWS CodePipeline](https://aws.amazon.com/jp/codepipeline/)
    - Jenkinsの[Pipeline](https://www.jenkins.io/doc/book/pipeline/)
  - 何らかの作業（ビルド、テスト、デプロイなど）を自動的に、定義された順番に実行する
  - シェルスクリプトの集まりのようなもの
  - パイプラインの種類
    - ビルドパイプライン: ビルド、テスト
    - リリースパイプライン: 開発環境・本番環境へのデプロイ
      - 「リリースする」ことを、「リリースを作る」とも言う
      - 過去のリリースの記録が残る（日時、成功・失敗など）
    - 手動で起動
    - Gitリポジトリと連動させ、ソースコードがプッシュされたら起動
      - 特定のブランチの変更にだけ反応するように設定することもできる
    - YAMLで定義される
  - トリガー
    - パイプラインは何かしらの「トリガー」によって起動される
    - ビルドパイプラインを起動する「ビルドトリガー」
    - リリースパイプラインを起動する「リリーストリガー」
  - ステップ
    - 定義済みのスクリプト（タスク）の実行
      - 環境構築、ビルド、テスト、ファイルのコピー等
    - カスタムのスクリプトの実行
      - 任意のLinuxコマンド/PowerShellコマンドの実行など
    - 複数のステップは、順に、1つのコンピュータ（エージェント）の中で実行される
  - ジョブ
    - ステップのあつまり
    - ジョブは（基本的に）エージェントで実行される
      - 「Azure Functionを呼び出す」「指定された時間待機する」といった、エージェントで実行されないタスクもある（エージェントレスタスク）
  - ステージ
    - ジョブのあつまり
    - ステージ間に「依存関係」を設定
      - あるステージの実行が完了（成功）したら、別のステージを実行する
      - あるステージの実行の完了後、ユーザーの承認を得てから、次のステージを実行する
    - ステージをスケジュールで実行する
  - エージェント
    - ジョブを実行するコンピューターのこと
    - エージェントが1つしかない場合は、複数のジョブはそのエージェントで順に実行される
    - エージェント増やせば増やすほど大量のジョブを並列で実行できるが、追加料金がかかる
    - Windows/Linux
    - （普通の）エージェント
      - クラウドプロバイダ等が用意・提供する標準的なコンピューター / ソフトウェア環境
    - セルフホステッドエージェント
      - ユーザーが自分で用意するコンピューター
      - オンプレミス環境でビルド・テスト・成果物をオンプレミスにデプロイする場合など
      - 特殊なハードウェア、ソフトウェアを使ったジョブの実行など
  - ジョブアクセストークン
    - ジョブごとに自動的に生成されるセキュリティ トークン
    - ジョブ（を実行するエージェント）が、Azure Pipeline等にアクセスするために必要

自動化のメリット
- 品質の向上: 人手による作業を排除することで、作業のミスや漏れを防ぐ
- 俊敏性: ビルド・テスト・デプロイをより頻繁に実行できる
- 速度: 複数の作業を連続的に、高速に実行できる
- 並列化: 複数のジョブ（ビルドやリリース）を同時に実行できる。

※Azure DevOpsで、並列化を行わない場合（「ホステッド ジョブ」を1個しか使っていない場合）、ジョブはキューに格納され、1つずつ実行される。

CI/CDのサービス/ツールの例
- [Azure Pipelines](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/what-is-azure-pipelines?view=azure-devops)
- [Google Cloud Build](https://cloud.google.com/build?hl=ja)
- [AWS CodePipeline](https://aws.amazon.com/jp/codepipeline/)
- [TeamCity](https://www.jetbrains.com/ja-jp/teamcity/)
- [Jenkins](https://www.jenkins.io/)
- [CloudBees](https://cloudbees.techmatrix.jp/)
- [CircleCI](https://circleci.com/ja/)
- [Travis CI](https://travis-ci.org/)
