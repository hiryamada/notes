
# プルリクエストとのコラボレーション

プルリクエストとは。

## プルリクエストとのコラボレーション

プルリクエストがマージされるまでの基本的な流れ。

- あるプロジェクトのコードの修正を行いたい人
  - プロジェクトを自分のリポジトリとしてフォークする
  - フォークしたリポジトリで、新しいブランチを作り、修正を行い、コミット・プッシュする
  - プルリクエストを送信する
- プロジェクトのオーナー
  - プルリクエストをレビューする
  - 必要に応じてフィードバックを行う（コメントする）
  - プルリクエストをマージする（または、却下する）


## GitHubモバイルアプリ

GitHub for mobileアプリ: モバイルデバイスを使用して、どこからでも、GitHubのレビューやマージを実行できる。プルリクエストの承認にも対応。

- [公式サイト](https://github.co.jp/mobile.html)
- [ドキュメント](https://docs.github.com/ja/github/getting-started-with-github/using-github/github-for-mobile)

## Azure DevOps

https://docs.microsoft.com/ja-jp/azure/devops/project/navigation/mobile-work?view=azure-devops

Webブラウザーを使用して、作業項目を表示および更新することができる。

※現在のところ、Azure DevOpsの公式モバイルアプリは存在しない。[Azure mobile app](https://azure.microsoft.com/ja-jp/get-started/azure-portal/mobile-app/)というものはあるが、ここからAzure DevOps Servicesを操作することはできない。

## 参考

- プルリクエストの一部として、検査・検証（コードの静的分析等）を自動化することができる
- [Azure CLI (azコマンド)を使用してプルリクエストを作成](https://docs.microsoft.com/ja-jp/cli/azure/repos/pr?view=azure-cli-latest#az_repos_pr_create)することができる
- [GitHub CLIのprコマンドでプルリクエストを作成](https://cli.github.com/manual/gh_pr_create)