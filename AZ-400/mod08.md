# GitHubアクションとの継続的インテグレーションを実装する

GitHub Actionsとは。
Azure Pipelinesとの違いは。

## GitHub のアクション

■GitHub Actionsとは。

GitHubに組み込まれたCI/CDサービス。ワークフロー（ビルド、テスト、デプロイ）を自動化できる。

- [公式サイト](https://github.co.jp/features/actions)
- [ドキュメント](https://docs.github.com/ja/actions)
  - [GitHub Actionsについて学ぶ](https://docs.github.com/ja/actions/learn-github-actions)
- [Marketplace（アクションの検索）](https://github.com/marketplace?type=actions)

価格
- パブリックリポジトリ
  - 無料で利用できる。
- プライベートリポジトリ
  - Free/Pro/Team/Enterpriseで無料で利用できる時間が異なる
    - Freeの場合は1ヶ月あたり2000分、無料で使用できる、など
  - 追加の時間については有料となる。
  - セルフホストは無料。


■Azureとの関係は。

- [2018年10月、MicrosoftはGitHubの買収を完了](https://www.google.com/search?q=microsoft+github+%E8%B2%B7%E5%8F%8E)。
  - [GitHubの独立性の維持を約束している](https://www.sbbit.jp/article/cont1/35103)
  - GitHubがなくなってAzure DevOpsに統一されたり、逆にAzure DevOpsがなくなってGitHubに統一されたりすることはない。
  - [オープンソースの文化に配慮し、「何も変えない」と宣言している](https://www.itmedia.co.jp/pcuser/articles/1807/01/news011.html)
- [GitHub Actionsのランナー（Azure Pipelinesの「エージェント」に相当）](https://docs.github.com/en/actions/using-github-hosted-runners/about-github-hosted-runners#about-virtual-environments):
  - Azure Pipelinesのエージェントのフォークである。
  - AzureのVM (Standard_DS2_v2) でホスティングされている。
- 連携の強化
  - [Azure DevOpsとGitHubは同じチームが開発している](https://codezine.jp/article/detail/12089)
  - 機能の連携については、[今後、さらに統合を加速させていく](https://codezine.jp/article/detail/12089)とされている。

■Azure DevOpsとの違いは。

（山田の主観）Azure DevOpsは機能がとても多く、パワフル。一方、GitHub Actionsは、シンプルでわかりやすい。

使い分けの例:

- オープンソースプロジェクトの開発: GitHub Actions
- 企業のプロプライエタリなソフトウェアの開発: Azure DevOps

必要であれば両者を組み合わせて使用することもできる。例:

- ソースコードのホスティング、Issueの管理: GitHub
- ビルド・テスト・デプロイ: Azure Pipelines

この[ブログ（英語）](https://medium.com/objectsharp/azure-pipelines-vs-github-actions-key-differences-45390ab132ee)に、詳細な比較がある。

以下、重要と思われる部分の抜粋。

- GitHub ActionsはGitHub専用ですが、Azure Pipelinesは他のソース管理システムに簡単に使用できます。
- Azure Pipelinesは承認、ゲート、チェックをサポートしていますが、GitHub Actionsにはそれらがない。
- Azure Pipelinesでは、パイプラインの実行名（ビルド番号）をカスタマイズできる。GitHub Actionsではできません。
- Azure Pipelinesを使用すると、ジョブ定義の一部の構造を省略できます。たとえば、ジョブが1つしかない場合は、ジョブを定義する必要はなく、そのステップを定義するだけで済みます。GitHub Actionsには明示的な構成が必要であり、YAML構造を省略できません。 

### アクションとは何ですか?



```
イベント または スケジュール
 ↓ 起動
ワークフロー
 └ジョブ
   └ステップ: アクション または シェルコマンド     
```


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

### 環境変数

### ジョブ間でアーティファクトを渡す

### ワークフロー バッジ

### アクションを作成するためのベスト プラクティス

### Git タグでリリースをマークする

## GitHub アクションのシークレットを保護する

### 暗号化シークレットの作成

### ワークフローでシークレットを使用する

## ラボ

(1) [GitHub Actions: Hello World](https://lab.github.com/githubtraining/github-actions:-hello-world)を実施してみましょう。

DevOps Starter を使用して GitHub Actions を実装する