
# Git分岐（ブランチ）ワークフロー

プロジェクトで、Gitのブランチをどのように運用するか。

## ブランチ ワークフローの種類

以下のような「ワークフロー」がよく使用される。

- [フィーチャー（機能）ブランチ](https://www.atlassian.com/ja/git/tutorials/comparing-workflows/feature-branch-workflow)
- [トランクベース開発](https://cloud.google.com/architecture/devops/devops-tech-trunk-based-development?hl=ja)
- [Gitflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)
- [Forking workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/forking-workflow)

## フィーチャー（機能）ブランチのワークフロー

注：[差別的な言葉、センシティブ（取り扱いに最新の注意を要する）とみなされる言葉を使わないようにするため、2020年後期から、Gitのデフォルトブランチの名前として 「master」ではなく「main」が使われるようになってきている。](https://www.publickey1.jp/blog/20/githubmainmastermain.html)

- [Git](https://softantenna.com/wp/software/git-2-30-released/) 
- [GitHub](https://www.publickey1.jp/blog/20/githubmainmastermain.html)
- [Azure DevOps](https://devblogs.microsoft.com/devops/azure-repos-default-branch-name/) 

[用語の置き換えの例(Twitter)](https://twitter.com/TwitterEng/status/1278733305190342656?ref_src=twsrc%5Etfw%7Ctwcamp%5Etweetembed%7Ctwterm%5E1278733305190342656%7Ctwgr%5E%7Ctwcon%5Es1_&ref_url=https%3A%2F%2Fwww.publickey1.jp%2Fblog%2F20%2Ftwitterwhitelistblacklistmasterslavedummy_value.html)

Gitに関する（古い）ドキュメントで「master」と書かれている部分は「main」に置き換えて読むとよい。

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

