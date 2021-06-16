# モジュール4 エンタープライズ DevOps 用のGitの操作

- Gitリポジトリの構成はどうするべきか。
  - 単一のリポジトリに多数のプロジェクトを入れるべきか。
  - プロジェクトごとにリポジトリを分けるべきか。
- プロジェクトの変更ログ（CHANGELOG.md）とは。
- プロジェクトで、Gitのブランチをどのように運用するか。


## Gitリポジトリを構築する方法

### モノレポ vs 複数リポジトリ

単一のリポジトリに多数のプロジェクトを入れるべきか、プロジェクトごとにリポジトリを分けたほうがよいか。

- [モノレポ](https://en.wikipedia.org/wiki/Monorepo)（monorepo, monolithic repository）モノリポとも
  - 複数のアプリのソースコードを単一のリポジトリに格納
  - Google社、Facebook社、Twitter社などでこの戦略をとっている
  - JavaScriptのコンパイラBabelは、[モノレポ](https://github.com/babel/babel/blob/master/packages/README.md)で開発されている（1つのリポジトリに多数のモジュールを含む）
  - モノレポ＝モノリス（一枚岩の巨大なアプリケーション）では[ない](https://www.graat.co.jp/blogs/ck1099bcoeud60830rf0ej0ix)。
- 復数リポジトリ（Polyrepo, Multi-Repo）ポリリポ、ポリレポとも
  - プロジェクトごとに独自のリポジトリを使用

[モノリシックなバージョン管理の利点(postd.cc)](https://postd.cc/monorepo/)

```
Google内部のビルドシステム では、モジュール化された大規模なコードブロックを使用することで、ソフトウェアの構築が信じられないほど容易になっています。例えば、クローラが必要な時にはこちらから数行、RSSパーサが必要な時にはあちらから数行、そしてフォールトトレランス機能を持った大規模な分散データストアが必要な時には数行を追加、といった具合です。これらは多くのプロジェクト間で共有されているビルディングブロックやサービスで、統合も簡単にできます。
```

Microsoftは、OneDrive、SharePointなどのいくつかの製品プロジェクトでモノレポを使用している。また、それらのプロジェクトで使われている[Rush モノレポマネージャ](https://rushjs.io/)を公開している。

[Rush よりも Lerna がよく使われている](https://www.npmtrends.com/@microsoft/rush-vs-lerna-vs-oao-vs-bolt)

Azure DevOpsで、モノレポも複数リポジトリも運用できる。

- Azure DevOps での、モノレポ運用 [事例1](https://julie.io/writing/monorepo-pipelines-in-azure-devops/), [2](https://florian-rappl.de/Articles/Page/390), [3](https://tech-lead.eu/architecture/monorepo-in-azure-devops/)
- Azure DevOpsでは、1つのプロジェクトの中に複数のリポジトリを持つことができる。プロジェクトが複数のモジュールで構成されている場合に、モジュールごとにリポジトリを持つことができる。

### 変更ログ(Changelog)の実装

変更ログ（Changelog）とは。

- プロジェクトの各バージョン（各リリース）で行われた変更点を記載したMarkdownファイル
  - リリースのバージョンと日付
    - 新機能
    - バグフィックス
    - 互換性を壊すような変更
    - プルリクエストのマージ記録
    - その他の（プロジェクト内部の重要な変更点など）
- だいたいの場合 CHANGELOG.md というファイル名で、リポジトリのトップに置かれる
- サンプル[1](https://github.com/rails/rails/blob/main/activerecord/CHANGELOG.md), [2](https://github.com/git-chglog/git-chglog/blob/master/CHANGELOG.md)
- [良いChangeLog、良くないChangeLog](https://efcl.info/2015/06/18/good-changelog/)

変更ログのジェネレータがいくつか存在する。

- [gitchangelog](https://pypi.org/project/gitchangelog/) ... 2018/12以降、メンテされていない？
- [github-changelog-generator](https://github.com/github-changelog-generator/github-changelog-generator)
- [git-chglog](https://github.com/git-chglog/git-chglog)

## Git分岐（ブランチ）ワークフロー


### Branching Workflow Types （ブランチワークフローの種類）

プロジェクトで、Gitのブランチをどのように運用するか。

以下のような「ワークフロー」がよく使用される。

- [フィーチャー（機能）ブランチ](https://www.atlassian.com/ja/git/tutorials/comparing-workflows/feature-branch-workflow)
- [トランクベース開発](https://cloud.google.com/architecture/devops/devops-tech-trunk-based-development?hl=ja)
- [Gitflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)
- [Forking workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/forking-workflow)

### フィーチャー（機能）ブランチのワークフロー

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

### 継続的デリバリーのためのGit分岐モデル

ブランチの使い方

- main ブランチ
  - プルリクエストのみを受け付ける（直接のコミットはさせない）
- フィーチャー（機能）ブランチ
  - 新機能とバグ修正を行う

プルリクエスト

- プルリクエストの一部として、検査・検証（コードの静的分析等）を自動化する
- [Azure CLI (azコマンド)を使用してプルリクエストを作成](https://docs.microsoft.com/ja-jp/cli/azure/repos/pr?view=azure-cli-latest#az_repos_pr_create)することができる

## Azure Reposでのプルリクエストとのコラボレーション

## Git フックの重要性

## 内部ソースの育成

## Gitリポジトリの管理

## ラボ

