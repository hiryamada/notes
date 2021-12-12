
# Git分岐（ブランチ）ワークフロー

プロジェクトで、Gitのブランチをどのように運用するか。

## ブランチ ワークフローの種類

以下のような「ワークフロー」がよく使用される。

- [フィーチャー（機能）ブランチ](https://www.atlassian.com/ja/git/tutorials/comparing-workflows/feature-branch-workflow)
- [トランクベース開発](https://cloud.google.com/architecture/devops/devops-tech-trunk-based-development?hl=ja)
- [Gitflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)
- [Forking workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/forking-workflow)

## フィーチャー（機能）ブランチのワークフロー

注：差別的な言葉を使わないようにするため、2020年後期から、Gitのデフォルトブランチの名前として 「master」ではなく「main」が使われるようになってきている。
- [Git](https://softantenna.com/wp/software/git-2-30-released/) 
- [GitHub](https://www.publickey1.jp/blog/20/githubmainmastermain.html)
- [Azure DevOps](https://devblogs.microsoft.com/devops/azure-repos-default-branch-name/) 
Gitに関する（古い）ドキュメントで「master」と書かれている部分は「main」に置き換えてお読みください。

- 機能の追加や、バグの修正を行うためのブランチを作る
  - ブランチ名は、そのブランチで作業するものを表す名前にする
- ブランチで、機能の追加や、バグの修正を行う
- ブランチのコミットを追加する
- プルリクエストをオープンする
- プルリクエストをレビューする
- プルリクエストを main にマージする

## 継続的デリバリーのためのGit分岐モデル

フィーチャー（機能）ブランチの基本的な使い方。

- main ブランチ
  - プルリクエストのみを受け付ける（直接のコミットはさせない）
- フィーチャー（機能）ブランチ
  - 新機能とバグ修正を行う

プルリクエスト

- プルリクエストの一部として、検査・検証（コードの静的分析等）を自動化する
- [Azure CLI (azコマンド)を使用してプルリクエストを作成](https://docs.microsoft.com/ja-jp/cli/azure/repos/pr?view=azure-cli-latest#az_repos_pr_create)することができる
