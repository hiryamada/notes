# モジュール2 ソース管理の開始

- DevOpsにおいてソース管理はなぜ必要か。
- ソース管理システム(バージョン管理システム)とは何か。
- 集中ソース管理と分散型ソース管理の違いとは何か。
- Gitとは何か。なぜGitを使うのか。
- Azure Reposとは何か。

ラボ: Gitの基本コマンドを学ぶ

## ソース管理とは

### ソース管理の概要

DevOpsにおいてソース管理はなぜ必要か。

Puppet 社、CircleCI 社 が発行している、DevOpsに関するレポート「State of DevOps レポート」によれば、DevOps変革を達成するためには、ソース管理(バージョン管理)の活用が必要不可欠である。

- [概要](https://www.infoq.com/jp/news/2021/01/2020-devops-report/)
- [2020 年版 State of DevOps レポート](https://circleci.com/ja/resources/state-of-devops-report-2020/)
  - 10ページに、DevOps 変革モデル（DevOps Evolution Mode）のステージ1～5の解説がある
  - STAGE 1 Normalization
    - Application development teams use **version control**
    - Teams deploy on a standard set of operating systems
  - STAGE 2 Standardization
    - Teams deploy on a single standard operating system
    - Teams build on a standard set of technologies
  - STAGE 3 Expansion
    - Individuals can do work without manual approval from outside the team
    - Deployment patterns for building apps/services are reused
    - Infrastructure changes are tested before deploying to production
  - STAGE 4 Automated infrastructure delivery
    - System configurations are automated
    - Provisioning is automated
    - System configs are in **version control**
    - Infrastructure teams use **version control**
    - Application configs are in **version control**
    - Security policy configs are automated
  - STAGE 5 Self-service
    - Incident responses are automated
    - Resources are available via self-service 
    - Applications are rearchitected based on business needs
    - Security teams are involved in technology design and deployment
  - ポイント：DevOps変革のステージが上がる（DevOps変革が進む）につれて、プログラムのソースコードだけではなく、システム構成、インフラ構成、アプリ構成などもバージョン管理されるようになる。


### ソース管理とは？

ソース管理システム(バージョン管理システム) の特徴とは。

- 復数の開発者による共同作業
- 変更をトラッキング
- 以前のバージョンにロールバックできる
- 災害などからのソースコードの保護
  - Azure DevOps: [参考](https://docs.microsoft.com/ja-jp/azure/devops/organizations/security/data-protection?view=azure-devops)
    - Azure DevOpsのデータはAzureデータセンターに格納される
    - 同じ地域内の2つのリージョンでレプリケーション（冗長化）される
  - GitHub: [参考](https://news.mynavi.jp/article/20160923-githubuniverse5/)
    - 米国にある3箇所のデータセンター内のサーバー内で3重にレプリケーション
- 誰が、いつ、どこを、どのように変更したかがわかる

## ソース管理の利点

ソース管理の利点とは。ソース管理のベストプラクティスとは。

- ワークフローを利用して作業する
  - Gitで使用される[いくつかの「ワークフロー」](https://www.atlassian.com/ja/git/tutorials/comparing-workflows)がある。
    - 代表的なものは[フィーチャー（機能）ブランチ](https://www.google.com/search?q=%E3%83%95%E3%82%A3%E3%83%BC%E3%83%81%E3%83%A3%E3%83%BC%E3%83%96%E3%83%A9%E3%83%B3%E3%83%81)
    - ブランチモデルについては[モジュール4](mod04.md)で解説
- バージョンを操作
  - [各バージョンにコメントを付与できる](https://www.google.com/search?q=git+%E3%82%B3%E3%83%9F%E3%83%83%E3%83%88%E3%83%A1%E3%83%83%E3%82%BB%E3%83%BC%E3%82%B8)
- コラボレーション
  - [競合の発見と解決ができる](https://www.google.com/search?q=git+%E3%82%B3%E3%83%B3%E3%83%95%E3%83%AA%E3%82%AF%E3%83%88)
- 変更履歴の保持
  - [変更履歴の確認ができる](https://www.google.com/search?q=git+%E5%B1%A5%E6%AD%B4)
  - [ロールバックができる](https://www.google.com/search?q=git+%E3%83%AD%E3%83%BC%E3%83%AB%E3%83%90%E3%83%83%E3%82%AF)
- タスクの自動化
  - コミット（プッシュ）と同時に、ビルドやテストを行うことができる。
  - [Azure Pipelines](https://azure.microsoft.com/ja-jp/services/devops/pipelines/)
  - [GitHub Action](https://github.co.jp/features/actions)

ソース管理のベストプラクティス

- 小さな変更をする
- 個人のファイル（アプリケーション設定や機密情報）をコミットしない
- プッシュ前にプルする
- プッシュ前に、コンパイルが通ることを確認
- コミットメッセージを書く
- コミットメッセージと作業項目をリンクさせる
- チームの規約に従う

## ソース管理システムの種類

- 集中ソース管理
  - [TFVC(Team Foundation Version Control)](https://docs.microsoft.com/ja-jp/azure/devops/repos/tfvc/?view=azure-devops)
  - [CVS](https://ja.wikipedia.org/wiki/Concurrent_Versions_System)
  - [Subversion](https://ja.wikipedia.org/wiki/Apache_Subversion)
  - など
- 分散型ソース管理
  - [Git](https://ja.wikipedia.org/wiki/Git)
  - [Mercurial](https://ja.wikipedia.org/wiki/Mercurial)
  - [Bazaar](https://ja.wikipedia.org/wiki/Bazaar)
  - など

集中ソース管理 vs 分散型ソース管理

- 分散型ソース管理のメリット
  - ローカルでコミットできる（ネットワーク接続が不要）
  - コミットをまとめてプッシュできる
  - 各プログラマーが、リポジトリの完全なコピーを持つ
    - （GitHubでフォークした個人リポジトリにおいて）必要なユーザーにだけ変更を共有できる
- デメリット
  - バイナリファイルの履歴が大きくなりがち
  - 多くの変更セットを持つ履歴全体のダウンロードに時間がかかる

### なぜGitなのか

Gitに移行するアドバンテージとは。

- すでに利用者が多い（トレーニング不要な場合が多い）
- 分散開発がしやすい（ローカルリポジトリを持てる）
- [トランクベース開発がしやすい](https://cloud.google.com/architecture/devops/devops-tech-trunk-based-development?hl=ja)
- プルリクエスト（マージの依頼）
- （以上の結果として）より早いリリースサイクルが実現できる

Gitは、CI/CDと組み合わせて非常にうまく機能する。

フックを使用して、特定のアクションが発生したときにカスタムスクリプトを実行することができる。

フックについては[モジュール4](mod04.md) 「Gitフックの重要性」で解説する。

### Gitの使用に対する反対意見

Gitの弱点とは。

- 履歴が上書きできる
  - 対策
    - 設定で、上書きを禁止できる（Force pushをDeny）
    - [参考](https://qiita.com/KoKeCross/items/243f7b40ef0461f0de1e)
      - Repos / Branches / All / ... / Branch security / Contributors
      - Force push を Deny に設定
- 大きなファイル（音声、動画、フォトショ・イラレなど）の保存が苦手
  - 対策
    - [Git LFS](https://git-lfs.github.com/) を使う
      - コンテンツをリモートサーバーに配置するしくみ
    - プロジェクトの成果物（ビルドされるもの）はリポジトリには含めない。
      - 成果物は通常 Azure Artifacts に格納する
- 学ぶのに時間がかかる （[学習曲線がある](https://tsuhon.jp/column/7582)）
  - 初心者にとって特にブランチと同期（プッシュ・プル）が難しい
  - 対策
    - [入門サイト](https://qiita.com/yuyakato/items/41751848add5dfd5289c)などで学習
    - [GitHub Desktop](https://desktop.github.com/)のようなGUIツールを使う

### Gitをローカルで操作（Gitを使い始める）

Gitの基本操作(ラボで実施)

- git init
- git config
- git branch
- git checkout
- git status
- git add
- git commit
- git merge
- git branch --delete
- git log

Gitの入門資料
- [サル先生のGit入門](https://backlog.com/ja/git-tutorial/intro/01/) - おすすめ！★★★★★
- [Learn Git Branching](https://k.swd.cc/learnGitBranching-ja/)
- [GitHubのGit入門](https://docs.github.com/ja/get-started)
41751848add5dfd5289c)
- [Git入門（Slideshare）](https://www.slideshare.net/y-uti/git-41040074)
- [ドットインストール Git入門 （動画）](https://dotinstall.com/lessons/basic_git)

Gitの入門資料集のまとめ
- [Gitを学び直したい人に見て欲しい。遊んで学べる、無料のGit学習サービス5選！](https://omuriceman.hatenablog.com/entry/enjoy-git)
- [Git、GitHubを教える時に使いたい資料まとめ](https://qiita.com/yuyakato/items/
  - Try Gitは現在利用できないもよう。

## Azure Reposの概要

[Azure Repos](azure-repos.md)

## GitHubの概要

Microsoft Learn: [GitHub の基礎](https://docs.microsoft.com/ja-jp/learn/paths/github-administration-products/)

[GitHub Learning Lab](https://lab.github.com/)

### GitHubをAzure Boardsにリンクする

[Azure Boards](https://github.com/marketplace/azure-boards)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/boards/github/)

- 無料で利用可能
- コードの管理をGitHubで実施し、タスク管理をAzure Boardで実施したい場合に便利。
- GitHub側
  - Issuesのメッセージ内に `AB#123` などと記述すると、Azure Boardsの作業項目にリンクできる。
  - コミットやプルリクエストメッセージ内に `Fixed AB#123` などと記入することで、対応するAzure Boardの作業項目を `done` 状態にすることができる。
  - READMEファイルに、Azure Boardsのかんばんボードの「ステータスバッジ」を表示できる。
- Azure Boards側
  - 作業項目の「リンクの追加」から、GitHubのコミット、プルリクエスト、Issueなどへリンクを設定できる。

## TFVCからAzure Reposへの移行

TFVC(Team Foundation バージョン管理)から、Azure Reposへ、[移行ツールを利用して移行できる](https://docs.microsoft.com/ja-jp/devops/develop/git/migrate-from-tfvc-to-git)

## ラボ

- Skillpipe Module 2、「ソース管理システムの種類」の「Gitをローカルで操作」にかかれている手順を実際にやってみましょう
- GitとVisual Studio Codeが必要です。お手元のPCに以下のものをインストールしてください。
  - [Git for Windows](https://gitforwindows.org/)
  - [Visual Studio Code](https://azure.microsoft.com/ja-jp/products/visual-studio-code/)
- または、Azure 上にWindows VMを立ち上げてリモートデスクトップで接続し、その中で上記ソフトウェアをインストールしてください。
- または、[ラボ環境](https://esi.learnondemand.net/)を起動して使用してください。

- Microsoft Learn: [Git でのバージョン コントロールの概要](https://docs.microsoft.com/ja-jp/learn/paths/intro-to-vc-git/)
  - サンドボックスの起動に失敗する場合は、Azure Passサブスクリプションの環境を利用してください。

