# GitHubアクションとの継続的インテグレーションを実装する

- GitHub Actionsとは。
- GitHub ActionsとAzure DevOpsとの関係、違いは。
- ワークフローとは。
- ランナーとは。
- ビルドマトリックスとは。
- アーティファクトとは。アップロード/ダウンロードとは。
- ステータスバッジとは。
- アクションを公開する際のベストプラクティスとは。

## GitHub のアクション

■GitHub Actionsとは。

GitHubに組み込まれたCI/CDサービス。ワークフロー（ビルド、テスト、デプロイ）を自動化できる。

- [公式サイト](https://github.co.jp/features/actions)
- [ドキュメント](https://docs.github.com/ja/actions)
  - [GitHub Actionsについて学ぶ](https://docs.github.com/ja/actions/learn-github-actions)
- [Marketplace（アクションの検索）](https://github.com/marketplace?type=actions)

[価格](https://docs.github.com/ja/billing/managing-billing-for-github-actions/about-billing-for-github-actions)
- パブリックリポジトリ
  - 無料で利用できる。
- プライベートリポジトリ
  - Free/Pro/Team/Enterpriseで無料で利用できる時間が異なる
    - Freeの場合は1ヶ月あたり2000分、無料で使用できる、など
  - 追加の時間については有料となる。
- セルフホストランナーは無料。
- [支払い方法のドキュメント](https://docs.github.com/ja/billing/managing-your-github-billing-settings)


■Azureとの関係は。

- [2018年10月、MicrosoftはGitHubの買収を完了](https://www.google.com/search?q=microsoft+github+%E8%B2%B7%E5%8F%8E)。
  - [GitHubの独立性の維持を約束している](https://www.sbbit.jp/article/cont1/35103)
  - [オープンソースの文化に配慮し、「何も変えない」と宣言している](https://www.itmedia.co.jp/pcuser/articles/1807/01/news011.html)
  - GitHubがなくなってAzure DevOpsに統一されたり、逆にAzure DevOpsがなくなってGitHubに統一されたりすることはない。引き続きどちらも利用できる。
- 連携の強化
  - [Azure DevOpsとGitHubは同じチームが開発している](https://codezine.jp/article/detail/12089)
  - 機能の連携については、[今後、さらに統合を加速させていく](https://codezine.jp/article/detail/12089)とされている。
- [GitHub Actionsのランナー（Azure Pipelinesの「エージェント」に相当）](https://docs.github.com/en/actions/using-github-hosted-runners/about-github-hosted-runners#about-virtual-environments):
  - Azure Pipelinesのエージェントのフォークである。
  - AzureのVM (Standard_DS2_v2) でホスティングされている。

■Azure DevOpsとの違いは。

（山田の主観）Azure DevOps（Azure Pipelines）は機能がとても多く、パワフル。一方、GitHub Actionsは、シンプルでわかりやすい。

使い分けの例:

- オープンソースプロジェクトの開発: GitHub Actions
- 企業のプロプライエタリなソフトウェアの開発: Azure DevOps

※[オープンソースプロジェクトでは無料でAzure Pipelinesを使用できる](https://azure.microsoft.com/en-us/blog/announcing-azure-pipelines-with-unlimited-ci-cd-minutes-for-open-source/)

必要であれば両者を組み合わせて使用することもできる。例:

- ソースコードのホスティング、Issueの管理: GitHub
- ビルド・テスト・デプロイ: Azure Pipelines

この[ブログ（英語）](https://medium.com/objectsharp/azure-pipelines-vs-github-actions-key-differences-45390ab132ee)に、詳細な比較がある。

以下、重要と思われる部分の抜粋。

- GitHub ActionsはGitHub専用ですが、Azure Pipelinesは他のソース管理システムに簡単に使用できます。
- Azure Pipelinesは承認、ゲート、チェックをサポートしていますが、GitHub Actionsにはそれらがない。
- Azure Pipelinesでは、パイプラインの実行名（ビルド番号）をカスタマイズできる。GitHub Actionsではできません。
- Azure Pipelinesを使用すると、ジョブ定義の一部の構造を省略できます。たとえば、ジョブが1つしかない場合は、ジョブを定義する必要はなく、そのステップを定義するだけで済みます。GitHub Actionsには明示的な構成が必要であり、YAML構造を省略できません。 

■移行 または 統合

- [Azure と GitHubの統合（Microsoft Docs）](https://docs.microsoft.com/ja-jp/azure/developer/github/github-actions): 組み合わせての使い方の解説
- [Azure PipelinesからGitHub Actionsへの移行ガイド](https://docs.github.com/ja/actions/learn-github-actions/migrating-from-azure-pipelines-to-github-actions)

### アクションとは何ですか?

GitHub Actionsの基本的な構造・用語。

■YAMLのおおまかな構造:

```
イベント または スケジュール
 ↓ 起動
ワークフロー
 └ジョブ: ランナーで実行される
   └ステップ: アクション または シェルコマンド     
```

■用語の概要

- イベント
  - ワークフローをトリガーする特定のアクティビティ
  - コミットをプッシュした、Issueやプルリクエストが作成された、など
  - `on` で指定
  - 【Azure Pipelinesの「トリガー」に相当】
- ワークフロー
  - リポジトリに追加する、自動化された手順
  - YAMLを使用して記述する。
    - 「～.yml」というファイル名にする。
    - リポジトリの「.github/workflows」に格納する。
  - `name:` で、わかりやすい名前をつけることができる（オプション）
  - 1つ以上のジョブで構成
  - スケジュールまたはイベントでトリガーできる
  - 【Azure Pipelinesの「パイプライン」に相当】
- ジョブ
  - 同じランナーで実行される一連のステップ
  - `jobs:` 以下に指定する
  - 複数のジョブはデフォルトでは並行で実行される
    - ジョブAが成功したらジョブBを実行、というように設定することもできる
      - `needs: jobA` のように記述する【Azure Pipelinesの「dependsOn」に相当】
  - 【Azure Pipelinesの「ジョブ」に相当】
- ステップ
  - ジョブで実行できる個々のタスク。
  - アクション(`uses:`) または シェルコマンド(`run:`)。
  - 【Azure Pipelinesの「ステップ」に相当】
- [アクション](https://docs.github.com/ja/actions/learn-github-actions/finding-and-customizing-actions)
  - `uses: actions/checkout@v2`のような形で呼び出す
  - [GitHub Marketplace](https://github.com/marketplace?type=actions)に、多数のアクションが登録されている
  - Docker Hubで公開されたDockerコンテナーイメージを使用することもできる
  - 【Azure Pipelinesの「タスク」に相当】
- シェルコマンド
  - `run: command`
  - 以下の形式で、リポジトリに保存されたシェルスクリプトを起動することもできる。
    ```
    name: sample
    run: ./.github/scripts/sample.sh
    shell: bash
    ```
- ランナー
  - GitHub Actionsランナーアプリケーションがインストールされているサーバー。
  - `runs-on: ubuntu-latest`のような形でプラットフォームを指定する。
  - 【Azure Pipelinesの「エージェント」に相当】

## GitHub アクションとの継続的インテグレーション

### アクションとの継続的インテグレーション

■ビルドマトリックスとは。

[ビルドマトリックス（ジョブマトリックスとも）](https://docs.github.com/ja/actions/learn-github-actions/managing-complex-workflows#using-a-build-matrix): `strategy:` と `matrix:` を使用して、「マトリックス」を作成できる。つまり、複数のジョブを生成できる。[ワークフローの実行ごとに最大で256のジョブを生成できる](https://docs.github.com/ja/actions/reference/usage-limits-billing-and-administration#artifact-and-log-retention-policy)。

例:
- [3つのバージョンのNode.jsで処理を実行する](https://docs.github.com/ja/actions/reference/workflow-syntax-for-github-actions#example)
- [2つのOS、3複数のバージョンのNode.js、計6通りの処理を実行する](https://docs.github.com/ja/actions/reference/workflow-syntax-for-github-actions#jobsjob_idstepscontinue-on-error)

■実際のワークフローの例

以下、Skillpipeテキストの例を少し改変。[参考](https://github.com/actions/setup-dotnet)

```yaml
name: dotnet Build
on: [push]
jobs:
    build:
        runs-on: ubuntu-latest
        strategy:
            matrix:
                dotnet: [ '2.1.x', '3.1.x', '5.0.x' ]
        steps:
        - uses: actions/checkout@main
        - uses: actions/setup-dotnet@v1
            with:
                dotnet-version: ${{ matrix.dotnet }}
        - run: dotnet build awesomeproject
```

- `name`: ワークフローに名前をつけている。GitHubの画面に表示される。
- `on`: コードがプッシュされたときにこのワークフローが開始される。 
- `jobs`: ジョブを指定する。
  - ここでは`build`と名前のついたジョブを1つだけ指定している。
    - `runs-on`: ジョブが ubuntu-latest （ubuntu 20.04）のランナーで実行される。
    - `strategy` と `matrix`: ここでは .NET のバージョン を3つ指定しているので、3つのジョブが作られる。ジョブは並列で実行されていく。
    - `steps`: ジョブのステップを指定する。
      - `uses: actions/checkout@main`: このGitHubリポジトリからコードをチェックアウト（取り出し）する。
      - `actions/setup-dotnet@v1`: ランナーに .NET をセットアップする。
      - `run`: dotnet buildを実行して、.NETプロジェクトをビルドする。

### 環境変数


- GitHubはそれぞれのGitHub Actionsワークフローの実行に対してデフォルトの環境変数を設定する。
- ワークフローファイル中でカスタムの環境変数を設定することもできる。
- たとえば、環境変数の値を `if:` で調べて、条件が成立した場合のみジョブを実行することができる。

[ドキュメント](https://docs.github.com/ja/actions/reference/environment-variables)


### ジョブ間でアーティファクトを渡す

[ジョブで生成された成果物をGitHubに「アーティファクト」として保存（アップロード）できる](https://docs.github.com/ja/actions/learn-github-actions/essential-features-of-github-actions#sharing-data-between-jobs)。

[「アーティファクト」とビルドログはデフォルトでは90日間保存される](https://docs.github.com/ja/actions/guides/storing-workflow-data-as-artifacts)。期間はカスタマイズできる。「アーティファクト」の保存には、GitHub上のストレージ領域が使われる（GitHubリポジトリではない）。無料で利用できる範囲を超えた場合は[ストレージの料金が発生する](https://docs.github.com/ja/billing/managing-billing-for-github-actions/about-billing-for-github-actions)。

[保存されているアーティファクトを「ダウンロード」して、別のジョブまたは別のワークフローで使用することができる](https://docs.github.com/ja/actions/learn-github-actions/essential-features-of-github-actions#sharing-data-between-jobs)。

### ワークフロー バッジ （ステータスバッジ）

ステータスバッジとは。

[ドキュメント](https://docs.github.com/ja/actions/managing-workflow-runs/adding-a-workflow-status-badge)

リポジトリのREADME.md（トップページ）などに「ステータスバッジ」を表示して、ワークフローのステータスを示すことができる。

ワークフローが成功しているかどうかをすばやく確認することができる。

### アクションを作成するためのベスト プラクティス

[自作のアクション](https://docs.github.com/ja/actions/creating-actions)をパブリックに公開する場合。

- ステップを適度にジョブ、ワークフローに分割する。
- [バージョン（リリース）を管理する](https://docs.github.com/ja/github/administering-a-repository/releasing-projects-on-github/about-releases)。
- [ドキュメント（README.md）を作る。](https://docs.github.com/ja/actions/creating-actions/about-actions#creating-a-readme-file-for-your-action)
- [Marketplaceに公開する](https://docs.github.com/ja/actions/creating-actions/publishing-actions-in-github-marketplace)。コミュニティで利用することができる。

### Git タグでリリースをマークする

- 各リリースには、`v1`, `v2` といったタグを付与する。
- 新しいメジャーバージョンの開発中中は、`v3-beta`のようなタグを付けて、それが開発中のベータ版であることを明確にする。その後`-bata`などを削除して`v3` とする。

[ドキュメント](https://docs.github.com/ja/actions/creating-actions/about-actions#using-tags-for-release-management)

## GitHub アクションのシークレットを保護する

暗号化されたシークレットを使うと、機密情報をOrganization、リポジトリ、あるいはリポジトリの環境に保存できます。

[ドキュメント](https://docs.github.com/ja/actions/reference/encrypted-secrets)

## ラボ

(1) [GitHub Actions: Hello World](https://lab.github.com/githubtraining/github-actions:-hello-world)を実施してみましょう。

DevOps Starter を使用して GitHub Actions を実装する