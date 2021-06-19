# モジュール4 エンタープライズ DevOps 用のGitの操作

- Gitリポジトリの構成はどうするべきか。
  - 単一のリポジトリに多数のプロジェクトを入れるべきか。
  - プロジェクトごとにリポジトリを分けるべきか。
- プロジェクトの変更ログ（CHANGELOG.md）とは。
- プロジェクトで、Gitのブランチをどのように運用するか。
- インナーソース（InnerSource）とは。
- Gitフックとは。
- Gitリポジトリの履歴から特定のファイルを完全に削除するには。


## Gitリポジトリを構築する方法

- Gitリポジトリの構成はどうするべきか。
  - 単一のリポジトリに多数のプロジェクトを入れるべきか。
  - プロジェクトごとにリポジトリを分けるべきか。
- プロジェクトの変更ログ（CHANGELOG.md）とは。


### モノレポ vs 複数リポジトリ

単一のリポジトリに多数のプロジェクトを入れるべきか、プロジェクトごとにリポジトリを分けたほうがよいか。

- [モノレポ](https://en.wikipedia.org/wiki/Monorepo)（monorepo, monolithic repository）モノリポとも
  - 複数のアプリのソースコードを単一のリポジトリに格納
  - Google社、Facebook社、Twitter社などでこの戦略をとっている
  - JavaScriptのコンパイラBabelは、[モノレポ](https://github.com/babel/babel/blob/master/packages/README.md)で開発されている（1つのリポジトリに多数のモジュールを含む）
  - モノレポ＝モノリス（一枚岩の巨大なアプリケーション）では[ない](https://www.graat.co.jp/blogs/ck1099bcoeud60830rf0ej0ix)。
- 復数リポジトリ（Polyrepo, Multi-Repo）ポリリポ、ポリレポとも
  - プロジェクトごとに独自のリポジトリを使用

[Googleのソースコード管理 Piper](https://www.school.ctc-g.co.jp/columns/nakai2/nakai220.html)

```
1つの巨大なリポジトリ内に、ディレクトリーを分けるかたちで、すべてのソフトウェアのソースコードが保存されています。
```

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

プロジェクトで、Gitのブランチをどのように運用するか。

### Branching Workflow Types （ブランチワークフローの種類）

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

フィーチャー（機能）ブランチの基本的な使い方。

- main ブランチ
  - プルリクエストのみを受け付ける（直接のコミットはさせない）
- フィーチャー（機能）ブランチ
  - 新機能とバグ修正を行う

プルリクエスト

- プルリクエストの一部として、検査・検証（コードの静的分析等）を自動化する
- [Azure CLI (azコマンド)を使用してプルリクエストを作成](https://docs.microsoft.com/ja-jp/cli/azure/repos/pr?view=azure-cli-latest#az_repos_pr_create)することができる

## Azure Reposでのプルリクエストとのコラボレーション

プルリクエストとは。

### プルリクエストとのコラボレーション

プルリクエストがマージされるまでの基本的な流れ。

- あるプロジェクトのコードの修正を行いたい人
  - プロジェクトを自分のリポジトリとしてフォークする
  - フォークしたリポジトリで、新しいブランチを作り、修正を行い、コミット・プッシュする
  - プルリクエストを送信する
- プロジェクトのオーナー
  - プルリクエストをレビューする
  - 必要に応じてフィードバックを行う（コメントする）
  - プルリクエストをマージする（または、却下する）

### デモンストレーション

（Skillpipe資料を参照）

### プルリクエスト承認のためのGitHubモバイル

※Azure DevOpsではなくGitHubの話題となる。現在のところ、Azure DevOpsの公式モバイルアプリは存在しない。

GitHub for mobile

モバイルデバイスを使用して、どこからでも、GitHubのレビューやマージを実行できる。

- [公式サイト](https://github.co.jp/mobile.html)
- [ドキュメント](https://docs.github.com/ja/github/getting-started-with-github/using-github/github-for-mobile)


## Git フックの重要性

フックを使用して、特定のアクションが発生したときにカスタムスクリプトを実行することができる。

[Git hook](https://git-scm.com/book/ja/v2/Git-%E3%81%AE%E3%82%AB%E3%82%B9%E3%82%BF%E3%83%9E%E3%82%A4%E3%82%BA-Git-%E3%83%95%E3%83%83%E3%82%AF)

フックでは、シェルスクリプト、PowerShell、Pythonコードなど、あらゆる実行可能形式を起動することができる。

フックは .git/hooks フォルダー以下に保存する。「～.sample」というサンプルが格納されているので、これを参考にすることができる。

フックの利用例: [1](https://blog.fenrir-inc.com/jp/2017/10/code-review-git-hooks.html), [2](https://efcl.info/2020/03/24/secretlint/)

コミット前に以下のコードチェックを実施
- コーディング規約に沿ってコードを書き換え
- ドキュメントコメントの有無のチェック
- 未使用コードの有無のチェック
- ユニットテストの実行
- APIトークンや秘密鍵のような機密情報の有無のチェック

## 内部ソース（インナーソース）の育成

インナーソース（InnerSource）とは？

オープンソースのコンセプトと学びを、起業が社内で開発する方法に適用する。

プロプライエタリなソフトウェアの開発を、起業の内部的にオープンにする。

ポイント:
- 所属組織の目的の違いを超えて、協力して開発プロジェクトを進めていくというやり方を、単一の組織内で実践する。
- フォーク、プルリクエストなどの仕組みを社内で活用する。
- オープンソース化するものは製品だけとは限らない。
  - 認証モジュールのような、共通のライブラリ
  - 開発ツール、全社的FAQ、ドキュメントなど
  - 社内の既存プロジェクトで広く使われているものを取り上げるべき
- 放っておけば勝手にうまく回るというものではなく、組織として推進が必要になってくる
  - 環境整備
  - ガイダンスの提供
  - インナーソースをドライブさせるための仕掛けを複数用意
  - 


Microsoftでの取り組み事例:

オープンソースのベストプラクティスを企業内で実践 
- [スライド](https://speakerdeck.com/yuichielectric/how-to-implement-innersource?slide=36)
- [動画](https://resources.github.com/videos/Japan-developer-summit-thankyou/)
- [報道記事](https://codezine.jp/article/detail/13685)

```
インナーソースの最終的な目標は文化的な変化。そのため、オープンソースにコミットする人たちの行動原理と同様に、インナーソースも『コラボレーション』や『コントリビューション』ベースになるよう、我々も気をつけながら取り組みを進めている。
...
最終的には楽しいことが何よりも重要。社内統制や標準化の観点で進めてしまうとインナーソースはドライブされないので、『投資』として行うべきだ。
```

[米国の製薬会社Eli Lilly（イーライ リリー）社での事例](https://www.atmarkit.co.jp/ait/articles/1811/12/news110.html)

```
「全ての開発チームが完全に同一の機能をばらばらに開発している。なぜどこかが一度開発したものを、他のチームが利用できないのか」という疑問から、自ら認証モジュールを構築し、開発チームに提供し始めた。これがEli LillyにおけるInner Sourcingへの旅の始まりになったという。
```

## Gitリポジトリの管理

### 大きなリポジトリの操作

#### クローンのサイズを小さくする

開発者がリポジトリをローカルに「クローン」する際に、リポジトリで利用可能なすべての履歴を必要としない場合、クローンする履歴の深さを指定したり、単一のブランチのみクローンしたりすることができる。

```
git clone --depth
```

#### 参考: MicrosoftのGit Virtual File System（GVFS）

[解説記事](https://jp.techcrunch.com/2017/05/25/20170524microsoft-now-uses-git-and-gvfs-to-develop-windows/)

- WindowsのソースコードはGitで行われるようになった
- トータルサイズは300GBとなる
- 巨大なリポジトリをGitで扱えるように、GVFSというものを開発した
- [Microsoft Git](https://github.com/Microsoft/git)として公開されている。

### リポジトリデータの消去

Gitリポジトリの履歴から特定のファイルを完全に削除するには。

大きなファイルや、機密ファイルをGitにコミットしてしまい、あとからそれを削除したい場合。

[GitHubの解説](https://docs.github.com/ja/github/authenticating-to-github/keeping-your-account-and-data-secure/removing-sensitive-data-from-a-repository)がわかりやすい。

なお上記解説にもあるが、機密情報をGitHubにアップロードしてしまった場合、機密情報を削除するだけでは不十分。

- 誤ってアップロードしてしまった機密情報の無効化を行う必要がある。
  - パスワードの変更、キーのローテーションなどを行う
- 流出した機密情報ですでに攻撃が行われた可能性も考慮する。
  - アクセスログなどを確認

#### git filter-branch

git [filter-branch](https://www.google.com/search?q=filter-branch) を使用して、Gitの履歴から特定のファイルを削除することができる。

#### BFG Repo-Cleaner

BFG Repo-Cleanerでも同様のことができ、より高速に動作する。

- [公式サイト](https://rtyley.github.io/bfg-repo-cleaner/)
- [BFGの由来](https://github.com/rtyley/bfg-repo-cleaner/issues/348)

## ラボ

[Version Controlling with Git in Visual Studio Code and Azure DevOps](https://azuredevopslabs.com/labs/azuredevops/git/)

