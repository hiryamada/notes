# GitHubアクションとの継続的インテグレーションを実装する

## GitHub のアクション

イベントとは。
アクションフローとは。
アクションとは。
ワークフローとは。
イベントとは
ジョブとは
ランナーとは。


### アクションとは何ですか?

GitHub Actionsとは。

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
  - 1つ以上のジョブで構成
  - スケジュールまたはイベントでトリガーできる
  - 【Azure Pipelinesの「パイプライン」に相当】
- ジョブ
  - 同じランナーで実行される一連のステップ
  - 複数のジョブはデフォルトでは並行で実行される
    - ジョブAが成功したらジョブBを実行、というように設定することもできる
  - 【Azure Pipelinesの「ジョブ」に相当】
- ステップ
  - ジョブで実行できる個々のタスク。
  - アクション(`uses:`) または シェルコマンド(`run:`)。
  - 【Azure Pipelinesの「ステップ」に相当】
- [アクション](https://docs.github.com/ja/actions/learn-github-actions/finding-and-customizing-actions)
  - `uses: actions/checkout@v2`のような形で呼び出す
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

アクションとの継続的インテグレーション

環境変数

ジョブ間でアーティファクトを渡す

ワークフロー バッジ

アクションを作成するためのベスト プラクティス

Git タグでリリースをマークする

## GitHub アクションのシークレットを保護する

暗号化シークレットの作成

ワークフローでシークレットを使用する

## ラボ

DevOps Starter を使用して GitHub Actions を実装する